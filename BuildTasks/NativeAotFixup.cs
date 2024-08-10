using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;
using System;
using System.IO;
using System.Text.RegularExpressions;

namespace BuildTasks
{
    public class NativeAotFixup : Task
    {
        [Required]
        public string ObjDirectory { get; set; }

        public override bool Execute()
        {
            try
            {
                {
                    var xamlTypeInfoCs = Path.Combine(ObjDirectory, "XamlTypeInfo.g.cs");
                    if (!File.Exists(xamlTypeInfoCs))
                    {
                        Log.LogError("XamlTypeInfo.g.cs does not exist in " + ObjDirectory);
                        return false;
                    }
                    var str = File.ReadAllText(xamlTypeInfoCs);
                    str = Regex.Replace(str,
                        "public sealed class XamlMetaDataProvider : global::Windows.UI.Xaml.Markup.IXamlMetadataProvider",
                        "public sealed partial class XamlMetaDataProvider : global::Windows.UI.Xaml.Markup.IXamlMetadataProvider");
                    str = Regex.Replace(str,
                        "internal class XamlSystemBaseType : global::Windows.UI.Xaml.Markup.IXamlType",
                        "internal partial class XamlSystemBaseType : global::Windows.UI.Xaml.Markup.IXamlType");
                    str = Regex.Replace(str,
                        "internal class XamlUserType : global::(.*?)_XamlTypeInfo.XamlSystemBaseType",
                        "internal partial class XamlUserType : global::$1_XamlTypeInfo.XamlSystemBaseType");
                    str = Regex.Replace(str,
                        "internal class XamlMember : global::Windows.UI.Xaml.Markup.IXamlMember",
                        "internal partial class XamlMember : global::Windows.UI.Xaml.Markup.IXamlMember");
                    File.WriteAllText(xamlTypeInfoCs, str);
                }

                var pagePass2CsList = Directory.GetFiles(ObjDirectory, "*.g.cs");
                foreach (var pagePass2Cs in pagePass2CsList)
                {
                    var filename = Path.GetFileName(pagePass2Cs);
                    if (string.Equals(filename, "App.g.cs", StringComparison.InvariantCultureIgnoreCase) ||
                        string.Equals(filename, "XamlTypeInfo.g.cs", StringComparison.InvariantCultureIgnoreCase))
                    {
                        continue;
                    }

                    var path = Path.Combine(ObjDirectory, filename);

                    var str = File.ReadAllText(path);
                    str = Regex.Replace(str,
                        "private class (.*?_obj\\d*_Bindings) :(\\s+global::Windows.UI.Xaml.(?:IDataTemplateExtension|Markup.IDataTemplateComponent|Markup.IXamlBindScopeDiagnostics|Markup.IComponentConnector),)",
                        "private partial class $1 :$2");
                    File.WriteAllText(path, str);
                }

                return true;
            }
            catch (Exception ex)
            {
                Log.LogErrorFromException(ex, showStackTrace: true);
                return false;
            }
        }
    }
}
