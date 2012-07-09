﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using MySQL.Utility;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace MySQL.ForExcel
{
  public partial class EditDataDialog : AutoStyleableBaseForm
  {
    private Point mouseDownPoint = Point.Empty;
    private MySqlWorkbenchConnection wbConnection;
    private DataTable editingTable = null;
    private Excel.Range editDataRange;
    private bool importedHeaders = false;
    private string queryString = String.Empty;
    private MySQLTable editMySQLTable;
    private MySqlDataAdapter dataAdapter;
    private MySqlConnection connection;
    private List<string> modifiedCellAddressesList;
    private int commitedCellsOLEColor = ColorTranslator.ToOle(ColorTranslator.FromHtml("#B8E5F7"));
    private int uncommitedCellsOLEColor = ColorTranslator.ToOle(ColorTranslator.FromHtml("#FF8282"));
    private int newRowCellsOLEColor = ColorTranslator.ToOle(ColorTranslator.FromHtml("#FFFCC7"));
    private int defaultCellsOLEColor = ColorTranslator.ToOle(Color.White);
    private long editingRowsQuantity = 0;
    private long editingColsQuantity = 0;

    public Excel.Worksheet EditingWorksheet = null;
    public TaskPaneControl CallerTaskPane;
    public string EditingTableName { get; private set; }

    public EditDataDialog(MySqlWorkbenchConnection wbConnection, Excel.Range editDataRange, DataTable importTable, Excel.Worksheet editingWorksheet)
    {
      InitializeComponent();

      this.wbConnection = wbConnection;
      this.editingTable = importTable;
      this.editDataRange = editDataRange;
      EditingTableName = importTable.ExtendedProperties["TableName"].ToString();
      importedHeaders = (bool)importTable.ExtendedProperties["ImportedHeaders"];
      queryString = importTable.ExtendedProperties["QueryString"].ToString();
      getMySQLTableSchemaInfo(EditingTableName);
      initializeDataAdapter();
      EditingWorksheet = editingWorksheet;
      EditingWorksheet.Change += new Excel.DocEvents_ChangeEventHandler(EditingWorksheet_Change);
      EditingWorksheet.SelectionChange += new Excel.DocEvents_SelectionChangeEventHandler(EditingWorksheet_SelectionChange);
      modifiedCellAddressesList = new List<string>(editDataRange.Count);
      toolTip.SetToolTip(this, String.Format("Editing data for Table {0} on Worksheet {1}", EditingTableName, editingWorksheet.Name));
      editingRowsQuantity = editingWorksheet.UsedRange.Rows.Count;
      editingColsQuantity = editingWorksheet.UsedRange.Columns.Count;
    }

    protected override void OnPaintBackground(PaintEventArgs e)
    {
      base.OnPaintBackground(e);
      Pen pen = new Pen(Color.White, 3f);
      e.Graphics.DrawRectangle(pen, 0, 0, this.Width - 2, this.Height - 2);
      pen.Width = 1f;
      e.Graphics.DrawLine(pen, 0, 25, this.Width, 25);
      pen.Dispose();
    }

    private void getMySQLTableSchemaInfo(string tableName)
    {
      DataTable tablesData = Utilities.GetSchemaCollection(wbConnection, "Tables", null, wbConnection.Schema, tableName);
      if (tablesData.Rows.Count == 0)
      {
        System.Diagnostics.Debug.WriteLine(String.Format("Schema info for table {0} not found.", tableName));
        return;
      }
      DataTable columnsData = Utilities.GetSchemaCollection(wbConnection, "Columns", null, wbConnection.Schema, tableName);
      editMySQLTable = new MySQLTable(wbConnection, tablesData.Rows[0], columnsData);
    }

    private void initializeDataAdapter()
    {
      connection = new MySqlConnection(Utilities.GetConnectionString(wbConnection));
      dataAdapter = new MySqlDataAdapter(this.queryString, connection);
      dataAdapter.UpdateCommand = new MySqlCommand(String.Empty, connection);
      StringBuilder queryString = new StringBuilder();
      StringBuilder wClauseString = new StringBuilder();
      wClauseString.AppendFormat("{0}WHERE{0}", Environment.NewLine);
      StringBuilder setClauseString = new StringBuilder();
      string wClause = String.Empty;
      MySqlParameter updateParam = null;

      string wClauseSeparator = String.Empty;
      string sClauseSeparator = String.Empty;
      queryString.AppendFormat("USE {0};{2}UPDATE {1}{2}SET{2}", wbConnection.Schema, EditingTableName, Environment.NewLine);

      foreach (MySQLColumn mysqlCol in editMySQLTable.Columns)
      {
        bool isPrimaryKeyColumn = editMySQLTable.PrimaryKey != null && editMySQLTable.PrimaryKey.Columns.Any(idx => idx.ColumnName == mysqlCol.ColumnName);
        MySqlDbType mysqlColType = Utilities.NameToType(mysqlCol.DataType, mysqlCol.IsUnsigned, false);

        updateParam = new MySqlParameter(String.Format("@W_{0}", mysqlCol.ColumnName), mysqlColType);
        updateParam.SourceColumn = mysqlCol.ColumnName;
        updateParam.SourceVersion = DataRowVersion.Original;
        dataAdapter.UpdateCommand.Parameters.Add(updateParam);
        wClauseString.AppendFormat("{0}{1}=@W_{1}", wClauseSeparator, mysqlCol.ColumnName);

        if (!isPrimaryKeyColumn)
        {
          updateParam = new MySqlParameter(String.Format("@S_{0}", mysqlCol.ColumnName), mysqlColType);
          updateParam.SourceColumn = mysqlCol.ColumnName;
          dataAdapter.UpdateCommand.Parameters.Add(updateParam);
          setClauseString.AppendFormat("{0}{1}=@S_{1}", sClauseSeparator, mysqlCol.ColumnName);
        }
        wClauseSeparator = " AND ";
        sClauseSeparator = ",";
      }
      queryString.Append(setClauseString.ToString());
      queryString.Append(wClauseString.ToString());
      dataAdapter.UpdateCommand.CommandText = queryString.ToString();
    }

    private void changeExcelCellsColor(int oleColor)
    {
      Excel.Range modifiedRange = null;
      foreach (string modifiedRangeAddress in modifiedCellAddressesList)
      {
        string[] startAndEndRange = modifiedRangeAddress.Split(new char[] { ':' });
        if (startAndEndRange.Length > 1)
          modifiedRange = EditingWorksheet.get_Range(startAndEndRange[0], startAndEndRange[1]);
        else
          modifiedRange = EditingWorksheet.get_Range(modifiedRangeAddress);
        modifiedRange.Interior.Color = oleColor;
      }
      modifiedCellAddressesList.Clear();
    }

    private void revertDataChanges(bool refreshFromDB)
    {
      if (refreshFromDB)
      {
        editingTable.Clear();
        dataAdapter.Fill(editingTable);
        Utilities.AddExtendedProperties(ref editingTable, queryString, importedHeaders, EditingTableName);
      }
      else
      {
        editingTable.RejectChanges();
      }
      Excel.Range topLeftCell = editDataRange.Cells[1, 1];
      CallerTaskPane.ImportDataTableToExcelAtGivenCell(editingTable, importedHeaders, topLeftCell);
      changeExcelCellsColor(defaultCellsOLEColor);
      btnCommit.Enabled = false;
    }

    private void pushDataChanges()
    {
      int updatedCount = 0;
      bool pushSuccessful = true;
      string operationSummary = String.Format("Edited data for Table {0} was committed to MySQL successfully.", EditingTableName);
      StringBuilder operationDetails = new StringBuilder();
      operationDetails.AppendFormat("Updating data rows...{0}{0}", Environment.NewLine);
      operationDetails.Append(dataAdapter.UpdateCommand.CommandText);
      operationDetails.Append(Environment.NewLine);
      operationDetails.Append(Environment.NewLine);

      try
      {
        DataTable changesTable = editingTable.GetChanges();
        int editingRowsCount = (changesTable != null ? changesTable.Rows.Count : 0);
        updatedCount = dataAdapter.Update(editingTable);
        operationDetails.AppendFormat("{1}{0} rows have been updated successfully.", editingRowsCount, Environment.NewLine);
      }
      catch (MySqlException ex)
      {
        if (chkAutoCommit.Checked)
        {
          System.Diagnostics.Debug.WriteLine(ex.Message);
          return;
        }
        pushSuccessful = false;
        operationSummary = String.Format("Edited data for Table {0} could not be committed to MySQL.", EditingTableName);
        operationDetails.AppendFormat("MySQL Error {0}:{1}", ex.Number, Environment.NewLine);
        operationDetails.Append(ex.Message);
      }

      if (!chkAutoCommit.Checked)
      {
        InfoDialog infoDialog = new InfoDialog(pushSuccessful, operationSummary, operationDetails.ToString());
        DialogResult dr = infoDialog.ShowDialog();
        if (dr == DialogResult.Cancel)
          return;
      }
      changeExcelCellsColor(commitedCellsOLEColor);
      btnCommit.Enabled = false;
    }

    private void EditingWorksheet_Change(Excel.Range Target)
    {
      Excel.Range intersectRange = CallerTaskPane.IntersectRanges(editDataRange, Target);
      if (intersectRange == null || intersectRange.Count == 0)
        return;
      if (!chkAutoCommit.Checked && !modifiedCellAddressesList.Contains(intersectRange.Address))
        modifiedCellAddressesList.Add(intersectRange.Address);
      intersectRange.Interior.Color = (chkAutoCommit.Checked ? commitedCellsOLEColor : uncommitedCellsOLEColor);
      
      // We subtract from the Excel indexes since they start at 1, Row is subtracted by 2 if we imported headers.
      Excel.Range startCell = (intersectRange.Item[1, 1] as Excel.Range);
      int startDataTableRow = startCell.Row - (importedHeaders ? 2 : 1);
      int startDataTableCol = startCell.Column - 1;

      // Detect if a row was deleted and if so flag a row for deletion
      if (EditingWorksheet.UsedRange.Rows.Count < editingRowsQuantity)
      {
        editingTable.Rows[startDataTableRow].Delete();
        editingRowsQuantity = EditingWorksheet.UsedRange.Rows.Count;
      }
      // Detect if a column was deleted and if so remove the column from the Columns colletion
      else if (EditingWorksheet.UsedRange.Columns.Count < editingColsQuantity)
      {
        editingTable.Columns.RemoveAt(startDataTableCol);
      }
      else
      {
        object[,] formattedArrayFromRange;
        if (intersectRange.Count > 1)
          formattedArrayFromRange = intersectRange.Value as object[,];
        else
        {
          formattedArrayFromRange = new object[2, 2];
          formattedArrayFromRange[1, 1] = intersectRange.Value;
        }
        int startRangeRow = 1;
        if (startDataTableRow < 0)
        {
          for (int colIdx = 1; colIdx <= intersectRange.Columns.Count; colIdx++)
            editingTable.Columns[startDataTableCol + colIdx - 1].ColumnName = formattedArrayFromRange[startRangeRow, colIdx].ToString();
          startDataTableRow++;
          startRangeRow++;
        }
        for (int rowIdx = startRangeRow; rowIdx <= intersectRange.Rows.Count; rowIdx++)
        {
          for (int colIdx = 1; colIdx <= intersectRange.Columns.Count; colIdx++)
          {
            int absRow = startDataTableRow + rowIdx - 1;
            int absCol = startDataTableCol + colIdx - 1;
            editingTable.Rows[absRow][absCol] = formattedArrayFromRange[rowIdx, colIdx];
          }
        }
      }

      btnCommit.Enabled = intersectRange.Count > 0 && !chkAutoCommit.Checked;
      if (chkAutoCommit.Checked)
        pushDataChanges();
    }

    void EditingWorksheet_SelectionChange(Excel.Range Target)
    {
      Excel.Range intersectRange = CallerTaskPane.IntersectRanges(editDataRange, Target);
      if (intersectRange == null || intersectRange.Count == 0)
        Hide();
      else
        Show();
    }

    private void GenericMouseDown(object sender, MouseEventArgs e)
    {
      if (e.Button == MouseButtons.Left)
        mouseDownPoint = new Point(e.X, e.Y);
    }

    private void GenericMouseUp(object sender, MouseEventArgs e)
    {
      if (e.Button == MouseButtons.Left)
        mouseDownPoint = Point.Empty;
    }

    private void GenericMouseMove(object sender, MouseEventArgs e)
    {
      if (e.Button == MouseButtons.Left)
      {
        if (mouseDownPoint.IsEmpty)
          return;
        Location = new Point(Location.X + (e.X - mouseDownPoint.X), Location.Y + (e.Y - mouseDownPoint.Y));
      }
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
      base.OnMouseDown(e);
      GenericMouseDown(this, e);
    }

    protected override void OnMouseUp(MouseEventArgs e)
    {
      base.OnMouseUp(e);
      GenericMouseUp(this, e);
    }

    protected override void OnMouseMove(MouseEventArgs e)
    {
      base.OnMouseMove(e);
      GenericMouseMove(this, e);
    }

    private void exitEditModeToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (connection != null)
        connection.Close();
      Close();
      CallerTaskPane.TableNameEditFormsHashtable.Remove(EditingTableName);
      CallerTaskPane.WorkSheetEditFormsHashtable.Remove(EditingWorksheet.Name);
      Dispose();
    }

    private void btnRevert_Click(object sender, EventArgs e)
    {
      EditDataRevertDialog reverDialog = new EditDataRevertDialog(chkAutoCommit.Checked);
      DialogResult dr = reverDialog.ShowDialog();
      if (dr == DialogResult.Cancel)
        return;
      revertDataChanges(reverDialog.SelectedAction == EditDataRevertDialog.EditUndoAction.RefreshData);
    }

    private void btnCommit_Click(object sender, EventArgs e)
    {
      pushDataChanges();
    }

    private void chkAutoCommit_CheckedChanged(object sender, EventArgs e)
    {
      btnCommit.Enabled = !chkAutoCommit.Checked;
      btnRevert.Enabled = !chkAutoCommit.Checked;
    }

    private void EditDataDialog_Activated(object sender, EventArgs e)
    {
      Opacity = 1;
    }

    private void EditDataDialog_Deactivate(object sender, EventArgs e)
    {
      Opacity = 0.60;
    }

  }
}