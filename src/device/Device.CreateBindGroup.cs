using WebGpuSharp.Internal;
using static WebGpuSharp.WebGPUMarshal;

namespace WebGpuSharp.FFI
{
    public readonly unsafe partial struct DeviceHandle
    {
        public BindGroupHandle CreateBindGroup(BindGroupDescriptorFFI* descriptor)
        {
            return WebGPU_FFI.DeviceCreateBindGroup(this, descriptor);
        }

        public BindGroup? CreateBindGroup(in BindGroupDescriptor descriptor)
        {
            using WebGpuAllocatorHandle allocator = WebGpuAllocatorHandle.Get();
            fixed (byte* labelPtr = ToRefCstrUtf8(descriptor.Label, allocator))
            fixed (BindGroupEntryFFI* entriesPtr = descriptor.Entries)
            {
                BindGroupDescriptorFFI descriptorFFI = default;
                descriptorFFI.Label = labelPtr;
                ToFFI(descriptor.Layout, out descriptorFFI.Layout);
                descriptorFFI.EntryCount = (uint)descriptor.Entries.Length;
                descriptorFFI.Entries = entriesPtr;
                return CreateBindGroup(&descriptorFFI).ToSafeHandle(true);
            }
        }
    }
}