using System.Diagnostics;
using System.Reflection;

// -p:Version=2.0.0 will show...
// Version: 2.0.0.0
// AssemblyInformationalVersion: 2.0.0 + 28b1af1b8db3fed6fead06d85e508460cef60355
// FileVersion : 2.0.0.0
// ProductVersion: 2.0.0 + 28b1af1b8db3fed6fead06d85e508460cef60355

Console.WriteLine($$"""
{{nameof(ApplicationInformation.Current.Version)}} : {{ApplicationInformation.Current.Version}}
{{nameof(ApplicationInformation.Current.AssemblyInformationalVersion)}} : {{ApplicationInformation.Current.AssemblyInformationalVersion}}
{{nameof(ApplicationInformation.Current.FileVersion)}} : {{ApplicationInformation.Current.FileVersion}}
{{nameof(ApplicationInformation.Current.ProductVersion)}} : {{ApplicationInformation.Current.ProductVersion}}
""");

public class ApplicationInformation
{
    public static ApplicationInformation Current { get; } = new ApplicationInformation();
    public string? Version { get; } = typeof(ApplicationInformation).Assembly.GetName().Version?.ToString();
    public string? AssemblyInformationalVersion { get; } = typeof(ApplicationInformation).Assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion;
    public string? FileVersion { get; } = FileVersionInfo.GetVersionInfo(typeof(ApplicationInformation).Assembly.Location)?.FileVersion;
    public string? ProductVersion { get; } = FileVersionInfo.GetVersionInfo(typeof(ApplicationInformation).Assembly.Location)?.ProductVersion;
}