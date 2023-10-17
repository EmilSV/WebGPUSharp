using WebGpuSharp.Internal;

namespace WebGpuSharp.FFI
{
    public readonly unsafe partial struct DeviceHandle
    {
        public BindGroupHandle CreateBindGroup(
            WGPURefText label, BindGroupLayoutHandle layout,
            BindGroupEntryList entries)
        {

            using WebGpuAllocatorHandle allocator = WebGpuAllocatorHandle.Get();
            UFT8CStrFactory utf8Factory = new(allocator);

            fixed (byte* labelPtr = label)
            {
                BindGroupDescriptorFFI nativeDescriptor = new()
                {
                    Label = utf8Factory.Create(
                        text: labelPtr,
                        length: label.Length,
                        is16BitSize: label.Is16BitSize,
                        allowPassthrough: true
                    ),
                    Layout = layout,
                    EntryCount = (uint)entries.Count,
                    Entries = entries.GetPointerToFFIItems(allocator),
                };

                return WebGPU_FFI.DeviceCreateBindGroup(this, &nativeDescriptor);
            }
        }

        public BindGroupHandle CreateBindGroup(
            WGPURefText label, BindGroupLayoutHandle layout,
            ReadOnlySpan<BindGroupEntryFFI> entries)
        {
            using WebGpuAllocatorHandle allocator = WebGpuAllocatorHandle.Get();
            UFT8CStrFactory utf8Factory = new(allocator);

            fixed (byte* labelPtr = label)
            fixed (BindGroupEntryFFI* entriesPtr = entries)
            {
                BindGroupDescriptorFFI nativeDescriptor = new()
                {
                    Label = utf8Factory.Create(
                        text: labelPtr,
                        length: label.Length,
                        is16BitSize: label.Is16BitSize,
                        allowPassthrough: true
                    ),
                    Layout = layout,
                    EntryCount = (uint)entries.Length,
                    Entries = entriesPtr,
                };

                return WebGPU_FFI.DeviceCreateBindGroup(this, &nativeDescriptor);
            }
        }
    }
}

namespace WebGpuSharp
{
    public partial class Device
    {
        public BindGroup? CreateBindGroup(WGPURefText label, BindGroupLayout layout, BindGroupEntryList entries)
        {
            return BindGroup.FromHandle(_handle.CreateBindGroup(label, layout.GetHandle(), entries));
        }
    }
}