using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

/// <inheritdoc cref="FFI.ShaderSourceWGSLFFI"/>
[StructLayout(LayoutKind.Sequential)]
public ref partial struct ShaderModuleWGSLDescriptor
{
    internal SType _chainType = SType.ShaderSourceWGSL;
    /// <inheritdoc cref="FFI.ShaderSourceWGSLFFI.Code"/>
    public WGPURefText Code;
    public readonly SType ChainType => _chainType;

    public ShaderModuleWGSLDescriptor()
    {
    }
}