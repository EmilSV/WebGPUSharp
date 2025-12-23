using WebGpuSharp.FFI;
using WebGpuSharp.Internal;
using WebGpuSharp.Marshalling;
using static WebGpuSharp.Marshalling.WebGPUMarshal;

namespace WebGpuSharp;

/// <inheritdoc cref="FragmentStateFFI"/>
public partial struct FragmentState :
    IWebGpuMarshallableAlloc<FragmentState, FragmentStateFFI>
{
    /// <inheritdoc cref="FragmentStateFFI.Module"/>
    public required ShaderModule Module;
    /// <inheritdoc cref="FragmentStateFFI.EntryPoint"/>
    public string? EntryPoint;
    /// <inheritdoc cref="FragmentStateFFI.Constants"/>
    public WebGpuManagedSpan<ConstantEntry> Constants;
    /// <inheritdoc cref="FragmentStateFFI.Targets"/>
    public required WebGpuManagedSpan<ColorTargetState> Targets;

    static unsafe void IWebGpuMarshallableAlloc<FragmentState, FragmentStateFFI>.MarshalToFFI(
        in FragmentState input,
        WebGpuAllocatorHandle allocator,
        out FragmentStateFFI dest)
    {
        dest = default;
        ToFFI(input.Targets, allocator, out dest.Targets, out dest.TargetCount);
        dest.Module = GetHandle(input.Module);
        dest.EntryPoint = ToStringViewFFI(input.EntryPoint, allocator);
        ToFFI(input.Constants, allocator, out dest.Constants, out dest.ConstantCount);
    }
}