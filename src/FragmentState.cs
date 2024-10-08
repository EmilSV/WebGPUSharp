using WebGpuSharp.FFI;
using WebGpuSharp.Internal;
using static WebGpuSharp.FFI.WebGPUMarshal;

namespace WebGpuSharp;

public partial struct FragmentState :
    IWebGpuFFIConvertibleAlloc<FragmentState, FragmentStateFFI>
{
    public required ShaderModule Module;
    public string? EntryPoint;
    public ConstantEntryList? Constants;
    public required ColorTargetStateList Targets;

    static unsafe void IWebGpuFFIConvertibleAlloc<FragmentState, FragmentStateFFI>.UnsafeConvertToFFI(
        in FragmentState input,
        WebGpuAllocatorHandle allocator,
        out FragmentStateFFI dest)
    {
        dest = new FragmentStateFFI();
        ToFFI(input.Module, out dest.Module);
        ToFFI(input.EntryPoint, allocator, out dest.EntryPoint);
        ToFFI(input.Constants, allocator, out dest.Constants, out dest.ConstantCount);
        ToFFI(input.Targets, out dest.Targets, out dest.TargetCount);
    }
}