using System.Diagnostics;
using System.Runtime.CompilerServices;
namespace WebGpuSharp;

public ref partial struct ShaderModuleDescriptor
{
    internal ref SType _next;
    public WGPURefText Label;
    // public Span<ShaderModuleCompilationHint> Hints;

    public ShaderModuleDescriptor(
        ref ShaderModuleWGSLDescriptor next
    )
    {
        next._chainType = SType.ShaderSourceWGSL;
        _next = ref next._chainType;
        unsafe
        {
#pragma warning disable CS8500
            fixed (ShaderModuleWGSLDescriptor* ptr = &next)
            {
                Debug.Assert(ptr == Unsafe.AsPointer(ref _next));
            }
#pragma warning restore  CS8500
        }
    }

    public bool IsWgslNext()
    {
        return _next == SType.ShaderSourceWGSL;
    }

    public bool IsSpirvNext()
    {
        return _next == SType.ShaderSourceSPIRV;
    }

    internal unsafe ref ShaderModuleWGSLDescriptor GetNextWgsl()
    {
        Debug.Assert(IsWgslNext());
#pragma warning disable CS8500
        return ref *(ShaderModuleWGSLDescriptor*)Unsafe.AsPointer(ref _next);
#pragma warning restore CS8500
    }
}