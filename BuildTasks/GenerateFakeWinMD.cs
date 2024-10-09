using System;
using System.Linq;
using System.Runtime.CompilerServices;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;
using Mono.Cecil;

namespace DisposableMemory.ModernNetUAP.BuildTasks
{
    public class GenerateFakeWinMD : Task
    {
        [Required]
        public ITaskItem[] SourceProjectionDlls { get; set; }

        [Required]
        public string TargetWinMD { get; set; }

        public override bool Execute()
        {
            try
            {
                Log.LogMessage(MessageImportance.High, "Generating Fake WinMD...");

                var assemblyName = new AssemblyNameDefinition("Windows.FakeWinMetadata", new Version(0, 0, 0, 0));
                using var outputAssembly = AssemblyDefinition.CreateAssembly(assemblyName, "Windows.FakeWinMetadata.dll", ModuleKind.Dll);
                outputAssembly.Name.IsWindowsRuntime = true;

                var outputModule = outputAssembly.MainModule;
                MethodReference fowardedToAttrCtor = outputModule.ImportReference(typeof(TypeForwardedToAttribute).GetConstructor(new Type[] { typeof(Type) }));

                var sourceAssemblyList = SourceProjectionDlls.Select(p => p.ItemSpec).ToList();
                Log.LogMessage(MessageImportance.High, "Source projections: \n" + string.Join("\n", sourceAssemblyList));

                foreach (var sourceAssemblyFile in sourceAssemblyList)
                {
                    using var sourceAssembly = AssemblyDefinition.ReadAssembly(sourceAssemblyFile);
                    foreach (var type in sourceAssembly.MainModule.Types)
                    {
                        if (string.IsNullOrEmpty(type.Namespace))
                        {
                            continue;
                        }
                        if (!type.IsPublic)
                        {
                            continue;
                        }
                        if (!type.CustomAttributes.Any(p => p.AttributeType.FullName == "WinRT.WindowsRuntimeTypeAttribute"))
                        {
                            continue;
                        }

                        var attr = new CustomAttribute(fowardedToAttrCtor);
                        var typeRef = outputModule.ImportReference(type);
                        var attrParam = new CustomAttributeArgument(outputModule.ImportReference(typeof(Type)), typeRef);
                        attr.ConstructorArguments.Add(attrParam);
                        outputAssembly.CustomAttributes.Add(attr);
                        outputModule.ExportedTypes.Add(new ExportedType(typeRef.Namespace, typeRef.Name, typeRef.Module, typeRef.Scope));
                    }
                }

                outputAssembly.Write(TargetWinMD);
                Log.LogMessage(MessageImportance.High, "Output file: " + TargetWinMD);
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
