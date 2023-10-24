using WebGpuSharp.FFI;
using WebGpuSharp.Internal;
using static WebGpuSharp.WebGPU.Unsafe;

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
        Marshal(input.Module, out dest.Module);
        Marshal(input.EntryPoint, allocator, out dest.EntryPoint);
        Marshal(input.Constants, allocator, out dest.Constants, out dest.ConstantCount);
        Marshal(input.Targets, out dest.Targets, out dest.TargetCount);
    }
}