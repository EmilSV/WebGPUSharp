
using System.Runtime.InteropServices;
using WebGpuSharp.Internal;

namespace WebGpuSharp.FFI
{
    public unsafe readonly partial struct DeviceHandle
    {
        public BindGroupLayoutHandle CreateBindGroupLayout(WGPURefText label, List<BindGroupLayoutEntry> entries)
        {
            return CreateBindGroupLayout(label, CollectionsMarshal.AsSpan(entries));
        }


        public BindGroupLayoutHandle CreateBindGroupLayout(WGPURefText label, ReadOnlySpan<BindGroupLayoutEntry> entries)
        {
            using WebGpuAllocatorHandle allocator = WebGpuAllocatorHandle.Get();
            UFT8CStrFactory utf8Factory = new(allocator);

            fixed (byte* labelPtr = label)
            fixed (BindGroupLayoutEntry* entriesPtr = entries)
            {
                BindGroupLayoutDescriptorFFI bindGroupLayoutDescriptor = new()
                {
                    Label = utf8Factory.Create(
                        text: labelPtr,
                        length: label.Length,
                        is16BitSize: label.Is16BitSize,
                        allowPassthrough: true
                    ),
                    EntryCount = (uint)entries.Length,
                    Entries = entriesPtr,
                };

                return WebGPU_FFI.DeviceCreateBindGroupLayout(this, &bindGroupLayoutDescriptor);
            }
        }
    }
}

namespace WebGpuSharp
{
    public partial class Device
    {
        public BindGroupLayout? CreateBindGroupLayout(WGPURefText label, List<BindGroupLayoutEntry> entries)
        {
            return BindGroupLayout.FromHandle(_handle.CreateBindGroupLayout(label, entries));
        }

        public BindGroupLayout? CreateBindGroupLayout(WGPURefText label, ReadOnlySpan<BindGroupLayoutEntry> entries)
        {
            return BindGroupLayout.FromHandle(_handle.CreateBindGroupLayout(label, entries));
        }
    }
}