# DisposableMemory.ModernNetUAP.XamlCompiler

Provides basic support for Windows.UI.Xaml (UWP) XAML codegen in Visual Studio for Modern .NET (.NET 8+).

[NuGet package](https://www.nuget.org/packages/DisposableMemory.ModernNetUAP.XamlCompiler)

# Requirements

- C#/WinRT with Windows.UI.Xaml support (currently `2.1.1`)
- Supported Windows SDK Projection packages (see C#/WinRT documentation for more information)

# Content

- [DisposableMemory.ModernNetUAP.XamlCompiler](https://www.nuget.org/packages/DisposableMemory.ModernNetUAP.XamlCompiler) for basic support
- [DisposableMemory.ModernNetUAP.WinUI](https://www.nuget.org/packages/DisposableMemory.ModernNetUAP.WinUI) for WinUI 2 projection and build support

For other (non legacy .NET) WinRT components and XAML control libraries, a simple C#/WinRT projection should work starting from 0.2.0.

# Acknowledgements

- Microsoft
- Mono.Cecil for fake WinMD generation
- Mile.Xaml for XAML compiler enablement
