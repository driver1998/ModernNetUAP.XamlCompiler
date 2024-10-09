using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;
using System;
using System.IO;
using System.Text.RegularExpressions;

namespace DisposableMemory.ModernNetUAP.BuildTasks
{
    internal class NativeAotFixupException : Exception
    {
        public NativeAotFixupException(string message) : base(message) { }
    }
    public class NativeAotFixup : Task
    {
        [Required]
        public string ObjDirectory { get; set; }

        private void Pass1Fixes()
        {
            var xamlTypeInfoCs = Path.Combine(ObjDirectory, "XamlTypeInfo.g.cs");
            if (!File.Exists(xamlTypeInfoCs))
            {
                throw new NativeAotFixupException($"XamlTypeInfo.g.cs does not exist in {ObjDirectory}, XAML compilation may be failed.");
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

        private void Pass2Fixes()
        {
            var pagePass2CsList = Directory.GetFiles(ObjDirectory, "*.g.cs", SearchOption.AllDirectories);
            foreach (var pagePass2Cs in pagePass2CsList)
            {
                var filename = Path.GetFileName(pagePass2Cs);
                if (string.Equals(filename, "App.g.cs", StringComparison.InvariantCultureIgnoreCase) ||
                    string.Equals(filename, "XamlTypeInfo.g.cs", StringComparison.InvariantCultureIgnoreCase))
                {
                    continue;
                }

                var str = File.ReadAllText(pagePass2Cs);
                str = Regex.Replace(str,
                    "private class (.*?_obj\\d*_Bindings) :(\\s+global::Windows.UI.Xaml.(?:IDataTemplateExtension|Markup.IDataTemplateComponent|Markup.IXamlBindScopeDiagnostics|Markup.IComponentConnector),)",
                    "private partial class $1 :$2");

                // IComponentConnector.Connect(int connectionId, global::System.Object target);
                // Connect(int connectionId, object target);
                str = Regex.Replace(str,
                    "(\\s+?case \\d*: \\/\\/ .*?\\.xaml line \\d+\\s+\\{{0,1}\\s+?(?:global::.*? element\\d+|this\\..+?) = )\\((global::.*?)\\)\\({0,1}(target)\\){0,1};",
                    "$1global::WinRT.CastExtensions.As<$2>($3);");
                str = Regex.Replace(str,
                    "(\\s+?case \\d*: \\/\\/ .*?\\.xaml line \\d+\\s+\\{{0,1}\\s+?(?:global::.*? element\\d+|this\\..+?) = new global::System.WeakReference)\\(\\((.*?)\\)(.*?)\\);",
                    "$1(global::WinRT.CastExtensions.As<$2>($3));");

                // ElementName_objX_Bindings.SetDataRoot(global::System.Object newDataRoot)
                str = Regex.Replace(str,
                    "(this.dataRoot = )\\((global::.*?)\\)(.*?);",
                    "$1global::WinRT.CastExtensions.As<$2>($3);");
                File.WriteAllText(pagePass2Cs, str);
            }
        }

        public override bool Execute()
        {
            try
            {                
                Pass1Fixes();
                Pass2Fixes();
                return true;
            }
            catch (NativeAotFixupException ex)
            {
                Log.LogError(ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                Log.LogErrorFromException(ex, showStackTrace: true);
                return false;
            }
        }
    }
}
