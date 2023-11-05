using WebGpuSharp.Internal;
using static WebGpuSharp.FFI.WebGPUMarshal;

namespace WebGpuSharp.FFI
{
    public readonly unsafe partial struct DeviceHandle
    {
        public BindGroupHandle CreateBindGroup(BindGroupDescriptorFFI* descriptor)
        {
            return WebGPU_FFI.DeviceCreateBindGroup(this, descriptor);
        }

        public BindGroupHandle CreateBindGroup(in BindGroupDescriptor descriptor)
        {
            using WebGpuAllocatorHandle allocator = WebGpuAllocatorHandle.Get();
            ToFFI(
                input: descriptor.Entries,
                allocator: allocator,
                dest: out BindGroupEntryFFI* entriesPtr,
                outCount: out nuint entriesCount
            );
            fixed (byte* labelPtr = ToRefCstrUtf8(descriptor.Label, allocator))
            {
                BindGroupDescriptorFFI descriptorFFI = default;
                descriptorFFI.Label = labelPtr;
                ToFFI(descriptor.Layout, out descriptorFFI.Layout);
                descriptorFFI.EntryCount = entriesCount;
                descriptorFFI.Entries = entriesPtr;
                return CreateBindGroup(&descriptorFFI);
            }
        }
    }
}