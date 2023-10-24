using WebGpuSharp.FFI;
using WebGpuSharp.Internal;
using static WebGpuSharp.WebGPUMarshal;

namespace WebGpuSharp;

public partial struct FragmentState :
    IUnsafeMarshalAlloc<FragmentState, FragmentStateFFI>
{
    public ShaderModule Module;
    public string EntryPoint;
    public ConstantEntryList? Constants;
    public ColorTargetStateList? Targets;

    static unsafe void IUnsafeMarshalAlloc<FragmentState, FragmentStateFFI>.UnsafeMarshalTo(
        in FragmentState input,
        WebGpuAllocatorHandle allocator,
        ref FragmentStateFFI dest)
    {
        ToFFI(input.Module, out dest.Module);
        ToFFI(input.EntryPoint, allocator, out dest.EntryPoint);
        ToFFI(input.Constants, allocator, out dest.Constants, out dest.ConstantCount);
        ToFFI(input.Targets, out dest.Targets, out dest.TargetCount);
    }
}