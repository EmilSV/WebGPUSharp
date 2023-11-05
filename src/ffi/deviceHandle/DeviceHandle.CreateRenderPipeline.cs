using System.Runtime.CompilerServices;
using WebGpuSharp.FFI;
using WebGpuSharp.Internal;
using static WebGpuSharp.FFI.WebGPUMarshal;

namespace WebGpuSharp.FFI
{
    public unsafe readonly partial struct DeviceHandle
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly RenderPipelineHandle CreateRenderPipeline(in RenderPipelineDescriptorFFI descriptor)
        {
            fixed (RenderPipelineDescriptorFFI* descriptorPtr = &descriptor)
            {
                return WebGPU_FFI.DeviceCreateRenderPipeline(this, descriptorPtr);
            }
        }

        public RenderPipelineHandle CreateRenderPipeline(in RenderPipelineDescriptor descriptor)
        {
            using WebGpuAllocatorHandle allocator = WebGpuAllocatorHandle.Get();
            fixed (byte* labelPtr = ToRefCstrUtf8(descriptor.Label, allocator))
            fixed (DepthStencilState* depthStencilPtr = descriptor.DepthStencil)
            {
                RenderPipelineDescriptorFFI descriptorFFI = default;
                descriptorFFI.Label = labelPtr;
                ToFFI(descriptor.Layout, out descriptorFFI.Layout);
                ToFFI(descriptor.Vertex, allocator, out descriptorFFI.Vertex);
                descriptorFFI.Primitive = descriptor.Primitive;
                descriptorFFI.DepthStencil = depthStencilPtr;
                descriptorFFI.Multisample = descriptor.Multisample;
                ToFFI(descriptor.Fragment, allocator, out descriptorFFI.Fragment);

                return CreateRenderPipeline(descriptorFFI);
            }
        }
    }
}
