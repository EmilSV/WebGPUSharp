
using WebGpuSharp.Internal;
using static WebGpuSharp.WebGPUMarshal;

namespace WebGpuSharp.FFI
{
    public unsafe readonly partial struct DeviceHandle
    {
        public BindGroupLayoutHandle CreateBindGroupLayout(in BindGroupLayoutDescriptorFFI descriptor)
        {
            fixed (BindGroupLayoutDescriptorFFI* descriptorPtr = &descriptor)
            {
                return WebGPU_FFI.DeviceCreateBindGroupLayout(this, descriptorPtr);
            }
        }

        public BindGroupLayoutHandle CreateBindGroupLayout(in BindGroupLayoutDescriptor descriptor)
        {
            using WebGpuAllocatorHandle allocator = WebGpuAllocatorHandle.Get();

            fixed (BindGroupLayoutEntry* entriesPtr = descriptor.Entries)
            fixed (byte* labelPtr = ToRefCstrUtf8(descriptor.Label, allocator))
            {
                return CreateBindGroupLayout(new BindGroupLayoutDescriptorFFI(
                    label: labelPtr,
                    entries: entriesPtr,
                    entryCount: (nuint)descriptor.Entries.Length
                ));
            }
        }
    }
}