﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.239
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.CodeDom.Compiler;
using System.Collections.Specialized;
using System.Configuration;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace DotSpatial.Data.Properties
{
#pragma warning disable 1591

    [CompilerGenerated()]
    [GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "10.0.0.0")]
    public sealed partial class Settings : ApplicationSettingsBase
    {

        private static Settings defaultInstance = ((Settings)(Synchronized(new Settings())));

        public static Settings Default
        {
            get
            {
                return defaultInstance;
            }
        }

        [ApplicationScopedSetting()]
        [DebuggerNonUserCode()]
        [DefaultSettingValue("<?xml version=\"1.0\" encoding=\"utf-16\"?>\r\n<ArrayOfString xmlns:xsi=\"http://www.w3." +
                             "org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">\r\n  <s" +
                             "tring />\r\n</ArrayOfString>")]
        public StringCollection RecentFiles
        {
            get
            {
                return ((StringCollection)(this["RecentFiles"]));
            }
        }

        [ApplicationScopedSetting()]
        [DebuggerNonUserCode()]
        [DefaultSettingValue("10")]
        public int MaximumNumberOfRecentFiles
        {
            get
            {
                return ((int)(this["MaximumNumberOfRecentFiles"]));
            }
        }
    }
#pragma warning restore 1591
}
