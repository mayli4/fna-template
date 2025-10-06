using System.Runtime.InteropServices;

namespace FnaTemplate;

//from tomat

/// <summary>
///		Early bootstrapping of FNA to bypass native library resolution
///		expectations.
/// </summary>
internal static class FnaBootstrap
{
    /// <summary>
    ///		Naively searches for all native libraries FNA depends on and
    ///		preloads them to skip FNA's DllMap behavior since we package all the
    ///		natives directly in their own assemblies.
    /// </summary>
    public static void Bootstrap()
    {
        if (GetNativeDirectory() is not { } dir)
        {
            throw new PlatformNotSupportedException("Unsupported platform (operating system or architecture); no FNA natives provided");
        }

        Console.WriteLine("BOOTSTRAP: Naively determined natives directory: " + dir);

        foreach (string lib in Directory.GetFiles(dir, "*", SearchOption.TopDirectoryOnly))
        {
            if (!NativeLibrary.TryLoad(lib, out nint handle))
            {
                Console.WriteLine($"BOOTSTRAP: Failed to load native library '{lib}'");
                continue;
            }

            Console.WriteLine($"BOOTSTRAP: Loaded native library '{lib}' @ 0x{handle:x8}");
        }
    }

    private static string? GetNativeDirectory()
    {
        Architecture arch = RuntimeInformation.ProcessArchitecture;

        if (OperatingSystem.IsWindows())
        {
            return arch switch
            {
                Architecture.X86 => "x86",
                Architecture.X64 => "x64",
                _ => null,
            };
        }

        if (OperatingSystem.IsLinux())
        {
            return arch switch
            {
                Architecture.X64 => "lib64",
                Architecture.Arm64 => "libaarch64",
                _ => null,
            };
        }

        return null;
    }
}