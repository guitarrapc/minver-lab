using System.Diagnostics;
using System.Reflection;

Console.WriteLine($$"""
{{nameof(ApplicationInformation.Current.AssemblyInformationalVersion)}} : {{ApplicationInformation.Current.AssemblyInformationalVersion}}
{{nameof(ApplicationInformation.Current.FileVersion)}} : {{ApplicationInformation.Current.FileVersion}}
{{nameof(ApplicationInformation.Current.ProductVersion)}} : {{ApplicationInformation.Current.ProductVersion}}
""");

public class ApplicationInformation
{
    public static ApplicationInformation Current { get; } = new ApplicationInformation();
    public string? AssemblyInformationalVersion { get; } = typeof(ApplicationInformation).Assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion;
    public string? FileVersion { get; } = FileVersionInfo.GetVersionInfo(typeof(ApplicationInformation).Assembly.Location)?.FileVersion;
    public string? ProductVersion { get; } = FileVersionInfo.GetVersionInfo(typeof(ApplicationInformation).Assembly.Location)?.ProductVersion;
}