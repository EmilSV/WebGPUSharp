using System.Runtime.CompilerServices;
using WebGpuSharp.Internal;
using static WebGpuSharp.FFI.WebGPUMarshal;

namespace WebGpuSharp.FFI
{
    public readonly unsafe partial struct DeviceHandle
    {
        public readonly SamplerHandle CreateSampler(ref SamplerDescriptor descriptor)
        {
            using WebGpuAllocatorHandle allocator = WebGpuAllocatorHandle.Get();
            SamplerDescriptorFFI descriptorFFI = descriptor._unsafeDescriptor;

            fixed (byte* labelPtr = ToRefCstrUtf8(descriptor.Label, allocator))
            {
                descriptorFFI.Label = labelPtr;
                return WebGPU_FFI.DeviceCreateSampler(this, &descriptorFFI);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly SamplerHandle CreateSampler(SamplerDescriptor descriptor)
        {
            using WebGpuAllocatorHandle allocator = WebGpuAllocatorHandle.Get();
            fixed (byte* labelPtr = ToRefCstrUtf8(descriptor.Label, allocator))
            {
                descriptor._unsafeDescriptor.Label = labelPtr;
                return WebGPU_FFI.DeviceCreateSampler(this, &descriptor._unsafeDescriptor);
            }
        }
    }
}