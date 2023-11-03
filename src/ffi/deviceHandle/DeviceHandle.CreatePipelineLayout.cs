using WebGpuSharp.Internal;
using static WebGpuSharp.WebGPUMarshal;

namespace WebGpuSharp.FFI
{
    public unsafe readonly partial struct DeviceHandle
    {
        public readonly PipelineLayoutHandle CreatePipelineLayout(
            in PipelineLayoutDescriptorFFI descriptor
        )
        {
            fixed (PipelineLayoutDescriptorFFI* descriptorPtr = &descriptor)
            {
                return WebGPU_FFI.DeviceCreatePipelineLayout(this, descriptorPtr);
            }
        }

        public readonly PipelineLayoutHandle CreatePipelineLayout(
            in PipelineLayoutDescriptor descriptor)
        {
            using WebGpuAllocatorHandle allocator = WebGpuAllocatorHandle.Get();
            fixed (byte* labelPtr = ToRefCstrUtf8(descriptor.Label, allocator))
            {
                PipelineLayoutDescriptorFFI descriptorFFI = default;
                descriptorFFI.Label = labelPtr;
                ToFFI(
                    descriptor.BindGroupLayouts,
                    allocator,
                    out descriptorFFI.BindGroupLayouts,
                    out descriptorFFI.BindGroupLayoutCount
                );

                return CreatePipelineLayout(descriptorFFI);
            }
        }
    }
}