﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34003
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MySQL.ForExcel.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "11.0.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.SettingsProviderAttribute(typeof(MySQL.ForExcel.Classes.MySqlForExcelSettings))]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool ExportDetectDatatype {
            get {
                return ((bool)(this["ExportDetectDatatype"]));
            }
            set {
                this["ExportDetectDatatype"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.SettingsProviderAttribute(typeof(MySQL.ForExcel.Classes.MySqlForExcelSettings))]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool ExportAddBufferToVarchar {
            get {
                return ((bool)(this["ExportAddBufferToVarchar"]));
            }
            set {
                this["ExportAddBufferToVarchar"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.SettingsProviderAttribute(typeof(MySQL.ForExcel.Classes.MySqlForExcelSettings))]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool ExportAutoIndexIntColumns {
            get {
                return ((bool)(this["ExportAutoIndexIntColumns"]));
            }
            set {
                this["ExportAutoIndexIntColumns"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.SettingsProviderAttribute(typeof(MySQL.ForExcel.Classes.MySqlForExcelSettings))]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool ExportAutoAllowEmptyNonIndexColumns {
            get {
                return ((bool)(this["ExportAutoAllowEmptyNonIndexColumns"]));
            }
            set {
                this["ExportAutoAllowEmptyNonIndexColumns"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.SettingsProviderAttribute(typeof(MySQL.ForExcel.Classes.MySqlForExcelSettings))]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool ExportUseFormattedValues {
            get {
                return ((bool)(this["ExportUseFormattedValues"]));
            }
            set {
                this["ExportUseFormattedValues"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.SettingsProviderAttribute(typeof(MySQL.ForExcel.Classes.MySqlForExcelSettings))]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool AppendPerformAutoMap {
            get {
                return ((bool)(this["AppendPerformAutoMap"]));
            }
            set {
                this["AppendPerformAutoMap"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.SettingsProviderAttribute(typeof(MySQL.ForExcel.Classes.MySqlForExcelSettings))]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool AppendAutoStoreColumnMapping {
            get {
                return ((bool)(this["AppendAutoStoreColumnMapping"]));
            }
            set {
                this["AppendAutoStoreColumnMapping"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.SettingsProviderAttribute(typeof(MySQL.ForExcel.Classes.MySqlForExcelSettings))]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool AppendReloadColumnMapping {
            get {
                return ((bool)(this["AppendReloadColumnMapping"]));
            }
            set {
                this["AppendReloadColumnMapping"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.SettingsProviderAttribute(typeof(MySQL.ForExcel.Classes.MySqlForExcelSettings))]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool AppendUseFormattedValues {
            get {
                return ((bool)(this["AppendUseFormattedValues"]));
            }
            set {
                this["AppendUseFormattedValues"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.SettingsProviderAttribute(typeof(MySQL.ForExcel.Classes.MySqlForExcelSettings))]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::System.Collections.Generic.List<MySQL.ForExcel.Classes.MySqlColumnMapping> StoredDataMappings {
            get {
                return ((global::System.Collections.Generic.List<MySQL.ForExcel.Classes.MySqlColumnMapping>)(this["StoredDataMappings"]));
            }
            set {
                this["StoredDataMappings"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.SettingsProviderAttribute(typeof(MySQL.ForExcel.Classes.MySqlForExcelSettings))]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("100")]
        public int ExportLimitPreviewRowsQuantity {
            get {
                return ((int)(this["ExportLimitPreviewRowsQuantity"]));
            }
            set {
                this["ExportLimitPreviewRowsQuantity"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.SettingsProviderAttribute(typeof(MySQL.ForExcel.Classes.MySqlForExcelSettings))]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("100")]
        public int AppendLimitPreviewRowsQuantity {
            get {
                return ((int)(this["AppendLimitPreviewRowsQuantity"]));
            }
            set {
                this["AppendLimitPreviewRowsQuantity"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.SettingsProviderAttribute(typeof(MySQL.ForExcel.Classes.MySqlForExcelSettings))]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool ExportRemoveEmptyColumns {
            get {
                return ((bool)(this["ExportRemoveEmptyColumns"]));
            }
            set {
                this["ExportRemoveEmptyColumns"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.SettingsProviderAttribute(typeof(MySQL.ForExcel.Classes.MySqlForExcelSettings))]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("15")]
        public uint GlobalConnectionConnectionTimeout {
            get {
                return ((uint)(this["GlobalConnectionConnectionTimeout"]));
            }
            set {
                this["GlobalConnectionConnectionTimeout"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.SettingsProviderAttribute(typeof(MySQL.ForExcel.Classes.MySqlForExcelSettings))]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("30")]
        public uint GlobalConnectionCommandTimeout {
            get {
                return ((uint)(this["GlobalConnectionCommandTimeout"]));
            }
            set {
                this["GlobalConnectionCommandTimeout"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.SettingsProviderAttribute(typeof(MySQL.ForExcel.Classes.MySqlForExcelSettings))]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("10")]
        public int ImportPreviewRowsQuantity {
            get {
                return ((int)(this["ImportPreviewRowsQuantity"]));
            }
            set {
                this["ImportPreviewRowsQuantity"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.SettingsProviderAttribute(typeof(MySQL.ForExcel.Classes.MySqlForExcelSettings))]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool ImportEscapeFormulaTextValues {
            get {
                return ((bool)(this["ImportEscapeFormulaTextValues"]));
            }
            set {
                this["ImportEscapeFormulaTextValues"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.SettingsProviderAttribute(typeof(MySQL.ForExcel.Classes.MySqlForExcelSettings))]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool ConvertedSettingsStoredMappingsCasing {
            get {
                return ((bool)(this["ConvertedSettingsStoredMappingsCasing"]));
            }
            set {
                this["ConvertedSettingsStoredMappingsCasing"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.SettingsProviderAttribute(typeof(MySQL.ForExcel.Classes.MySqlForExcelSettings))]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool EditUseOptimisticUpdate {
            get {
                return ((bool)(this["EditUseOptimisticUpdate"]));
            }
            set {
                this["EditUseOptimisticUpdate"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.SettingsProviderAttribute(typeof(MySQL.ForExcel.Classes.MySqlForExcelSettings))]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool GlobalSqlQueriesPreviewQueries {
            get {
                return ((bool)(this["GlobalSqlQueriesPreviewQueries"]));
            }
            set {
                this["GlobalSqlQueriesPreviewQueries"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.SettingsProviderAttribute(typeof(MySQL.ForExcel.Classes.MySqlForExcelSettings))]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool GlobalSqlQueriesShowQueriesWithResults {
            get {
                return ((bool)(this["GlobalSqlQueriesShowQueriesWithResults"]));
            }
            set {
                this["GlobalSqlQueriesShowQueriesWithResults"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.SettingsProviderAttribute(typeof(MySQL.ForExcel.Classes.MySqlForExcelSettings))]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool ImportCreateExcelTable {
            get {
                return ((bool)(this["ImportCreateExcelTable"]));
            }
            set {
                this["ImportCreateExcelTable"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.SettingsProviderAttribute(typeof(MySQL.ForExcel.Classes.MySqlForExcelSettings))]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("MySqlDefault")]
        public string ImportExcelTableStyleName {
            get {
                return ((string)(this["ImportExcelTableStyleName"]));
            }
            set {
                this["ImportExcelTableStyleName"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.SettingsProviderAttribute(typeof(MySQL.ForExcel.Classes.MySqlForExcelSettings))]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool EditSessionsRestoreWhenOpeningWorkbook {
            get {
                return ((bool)(this["EditSessionsRestoreWhenOpeningWorkbook"]));
            }
            set {
                this["EditSessionsRestoreWhenOpeningWorkbook"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.SettingsProviderAttribute(typeof(MySQL.ForExcel.Classes.MySqlForExcelSettings))]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::System.Collections.Generic.List<MySQL.ForExcel.Classes.EditSessionInfo> EditSessionsList {
            get {
                return ((global::System.Collections.Generic.List<MySQL.ForExcel.Classes.EditSessionInfo>)(this["EditSessionsList"]));
            }
            set {
                this["EditSessionsList"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.SettingsProviderAttribute(typeof(MySQL.ForExcel.Classes.MySqlForExcelSettings))]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool EditSessionsReuseWorksheets {
            get {
                return ((bool)(this["EditSessionsReuseWorksheets"]));
            }
            set {
                this["EditSessionsReuseWorksheets"] = value;
            }
        }
    }
}
