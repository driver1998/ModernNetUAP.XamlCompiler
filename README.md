> [!WARNING]
> This package has been deprecated, as Microsoft now officially supports .NET 9 UWP with Visual Studio 17.12.
> See https://devblogs.microsoft.com/ifdef-windows/preview-uwp-support-for-dotnet-9-native-aot/ for details.
>
> You should only use this package if:
> - You need to use older versions of Visual Studio.
> - You need to use older versions of .NET and/or Windows SDK. (Note: targeting .NET 8 using .NET 9 SDK works fine with official UWP support)
> - You need to mix WinForms / WPF with Windows.UI.Xaml (for XAML islands) in the same project (experimental)
>
> [DisposableMemory.ModernNetUAP.WinUI](https://www.nuget.org/packages/DisposableMemory.ModernNetUAP.WinUI) works with official .NET 9 UWP support, if you wish to use WinUI 2 in that scenario.

# DisposableMemory.ModernNetUAP.XamlCompiler

Provides basic support for Windows.UI.Xaml (UWP) XAML codegen in Visual Studio for Modern .NET (.NET 8+).

[NuGet package](https://www.nuget.org/packages/DisposableMemory.ModernNetUAP.XamlCompiler)

# Requirements

- C#/WinRT with Windows.UI.Xaml support (`2.1.1` and higher)
- Supported Windows SDK Projection packages (see C#/WinRT documentation for more information)

# Content

- [DisposableMemory.ModernNetUAP.XamlCompiler](https://www.nuget.org/packages/DisposableMemory.ModernNetUAP.XamlCompiler) for basic support
- [DisposableMemory.ModernNetUAP.WinUI](https://www.nuget.org/packages/DisposableMemory.ModernNetUAP.WinUI) for WinUI 2 projection

For other (non legacy .NET) WinRT components and XAML control libraries, a simple C#/WinRT projection should work starting from 0.2.0.

# Acknowledgements

- Microsoft
- Mono.Cecil for fake WinMD generation
- Mile.Xaml for XAML compiler enablement
