using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

[StructLayout(LayoutKind.Sequential)]
public ref partial struct ShaderModuleWGSLDescriptor
{
    internal SType _chainType = SType.ShaderModuleWGSLDescriptor;
    public WGPURefText Code;
    public readonly SType ChainType => _chainType;

    public ShaderModuleWGSLDescriptor()
    {
    }
}