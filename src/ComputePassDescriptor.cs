using WebGpuSharp.FFI;

namespace WebGpuSharp;


public ref struct ComputePassDescriptor
{
    /// <inheritdoc cref="ComputePassDescriptorFFI.Label"/>
    public WGPURefText Label;

    /// <inheritdoc cref="ComputePassDescriptorFFI.TimestampWrites"/>
    public PassTimestampWrites? TimestampWrites;

    public ComputePassDescriptor() { }
}
