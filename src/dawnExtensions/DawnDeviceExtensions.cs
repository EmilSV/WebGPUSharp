using WebGpuSharp.FFI;
using static WebGpuSharp.FFI.WebGPUMarshal;

namespace WebGpuSharp.DawnExtensions;

public unsafe static class DawnDeviceExtensions
{
    public static SharedFenceHandle ImportSharedFence(this DeviceHandle device, in SharedFenceDescriptorFFI descriptor)
    {
        fixed (SharedFenceDescriptorFFI* descriptorPtr = &descriptor)
        {
            return WebGPU_FFI.DeviceImportSharedFence(device, descriptorPtr);
        }
    }

    public static SharedFenceHandle ImportSharedFence(this DeviceHandle device, in SharedFenceDescriptor descriptor)
    {
        using WebGpuAllocatorHandle allocator = WebGpuAllocatorHandle.Get();
        fixed (byte* labelPtr = ToRefCstrUtf8(descriptor.Label, allocator))
        {
            SharedFenceDescriptorFFI descriptorFFI = new(label: labelPtr);
            return WebGPU_FFI.DeviceImportSharedFence(device, &descriptorFFI);
        }
    }

    public static SharedTextureMemoryHandle ImportSharedTextureMemory(
        this DeviceHandle device, in SharedTextureMemoryDescriptorFFI descriptor)
    {
        fixed (SharedTextureMemoryDescriptorFFI* descriptorPtr = &descriptor)
        {
            return WebGPU_FFI.DeviceImportSharedTextureMemory(device, descriptorPtr);
        }
    }

    public static SharedTextureMemoryHandle ImportSharedTextureMemory(
      this DeviceHandle device, in SharedTextureMemoryDescriptor descriptor)
    {
        using WebGpuAllocatorHandle allocator = WebGpuAllocatorHandle.Get();
        fixed (byte* labelPtr = ToRefCstrUtf8(descriptor.Label, allocator))
        {
            SharedTextureMemoryDescriptorFFI descriptorFFI = new(label: labelPtr);
            return WebGPU_FFI.DeviceImportSharedTextureMemory(device, &descriptorFFI);
        }
    }
}