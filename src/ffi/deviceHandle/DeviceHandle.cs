using System.Buffers;
using System.Collections.Concurrent;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using WebGpuSharp.Internal;
using static WebGpuSharp.WebGPUMarshal;

namespace WebGpuSharp.FFI;

public unsafe readonly partial struct DeviceHandle : IDisposable, IWebGpuHandle<DeviceHandle, Device>
{
    public QueueHandle GetQueue()
    {
        return WebGPU_FFI.DeviceGetQueue(this);
    }

    public CommandEncoderHandle CreateCommandEncoder(in CommandEncoderDescriptor descriptor)
    {
        using WebGpuAllocatorHandle allocator = WebGpuAllocatorHandle.Get();
        fixed (byte* LabelPtr = ToRefCstrUtf8(descriptor.label, allocator))
        {
            CommandEncoderDescriptorFFI commandEncoderDescriptor = new(label: LabelPtr);
            return WebGPU_FFI.DeviceCreateCommandEncoder(this, &commandEncoderDescriptor);
        }
    }

    public void Tick()
    {
        WebGPU_FFI.DeviceTick(this);
    }

    public BufferHandle CreateBuffer(ref BufferDescriptor descriptor)
    {
        using WebGpuAllocatorHandle allocator = WebGpuAllocatorHandle.Get();
        fixed (byte* LabelPtr = ToRefCstrUtf8(descriptor.Label, allocator))
        fixed (BufferDescriptorFFI* descriptorPtr = &descriptor._unmanagedDescriptor)
        {
            descriptorPtr->Label = LabelPtr;
            return WebGPU_FFI.DeviceCreateBuffer(this, descriptorPtr);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public BufferHandle CreateBuffer(BufferDescriptor descriptor)
    {
        using WebGpuAllocatorHandle allocator = WebGpuAllocatorHandle.Get();
        fixed (byte* LabelPtr = ToRefCstrUtf8(descriptor.Label, allocator))
        {
            descriptor._unmanagedDescriptor.Label = LabelPtr;
            return WebGPU_FFI.DeviceCreateBuffer(this, &descriptor._unmanagedDescriptor);
        }
    }

    public SwapChainHandle CreateSwapChain(SurfaceHandle surface, ref SwapChainDescriptor descriptor)
    {
        WebGpuAllocatorHandle allocator = WebGpuAllocatorHandle.Get();
        fixed (byte* LabelPtr = ToRefCstrUtf8(descriptor.Label, allocator))
        fixed (SwapChainDescriptorFFI* descriptorPtr = &descriptor._unsafeDescriptor)
        {
            descriptorPtr->Label = LabelPtr;
            return WebGPU_FFI.DeviceCreateSwapChain(this, surface, descriptorPtr);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public SwapChainHandle CreateSwapChain(SurfaceHandle surface, SwapChainDescriptor descriptor)
    {
        WebGpuAllocatorHandle allocator = WebGpuAllocatorHandle.Get();
        fixed (byte* LabelPtr = ToRefCstrUtf8(descriptor.Label, allocator))
        {
            descriptor._unsafeDescriptor.Label = LabelPtr;
            return WebGPU_FFI.DeviceCreateSwapChain(this, surface, &descriptor._unsafeDescriptor);
        }
    }

    public readonly ShaderModuleHandle CreateShaderModule(in ShaderModuleDescriptor descriptor)
    {
        if (descriptor.IsWgslNext())
        {
            return CreateShaderModuleWgsl(descriptor, descriptor.GetNextWgsl().Code);
        }
        else if (descriptor.IsSpirvNext())
        {
            throw new NotImplementedException();
            //return CreateShaderModuleSpirv(descriptor, descriptor.GetNextSpirv().Code);
        }
        else
        {
            throw new NotImplementedException();
        }
    }

    private readonly ShaderModuleHandle CreateShaderModuleWgsl(in ShaderModuleDescriptor descriptor, WGPURefText code)
    {
        using WebGpuAllocatorHandle allocator = WebGpuAllocatorHandle.Get();
        fixed (byte* labelPtr = ToRefCstrUtf8(descriptor.Label, allocator))
        fixed (byte* codePtr = ToRefCstrUtf8(code, allocator))
        {

            ShaderModuleWGSLDescriptorFFI shaderModuleWGSLDescriptor = new(
                chain: new ChainedStruct(
                    next: null,
                    sType: SType.ShaderModuleWGSLDescriptor
                ),
                code: codePtr
            );

            ShaderModuleDescriptorFFI shaderModuleDescriptor = new(
                nextInChain: &shaderModuleWGSLDescriptor.Chain,
                label: labelPtr
            );

            return WebGPU_FFI.DeviceCreateShaderModule(this, &shaderModuleDescriptor);
        }
    }

    [SkipLocalsInit]
    public readonly SupportedLimits GetLimits()
    {
        SupportedLimits supportedLimits;
        WebGPU_FFI.DeviceGetLimits(this, &supportedLimits);
        return supportedLimits;
    }

    public readonly void GetLimits(ref SupportedLimits supportedLimits)
    {
        fixed (SupportedLimits* supportedLimitsPtr = &supportedLimits)
        {
            WebGPU_FFI.DeviceGetLimits(this, supportedLimitsPtr);
        }
    }

    public readonly TextureHandle CreateTexture(ref TextureDescriptor textureDescriptor)
    {
        using WebGpuAllocatorHandle allocator = WebGpuAllocatorHandle.Get();
        fixed (byte* labelPtr = ToRefCstrUtf8(textureDescriptor.Label, allocator))
        fixed (TextureFormat* viewFormatsPtr = textureDescriptor.ViewFormats)
        fixed (TextureDescriptorFFI* textureDescriptorPtr = &textureDescriptor._unmanagedDescriptor)
        {
            textureDescriptorPtr->Label = labelPtr;
            textureDescriptorPtr->ViewFormatCount = (uint)textureDescriptor.ViewFormats.Length;
            textureDescriptorPtr->ViewFormats = viewFormatsPtr;

            return WebGPU_FFI.DeviceCreateTexture(this, textureDescriptorPtr);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly TextureHandle CreateTexture(TextureDescriptor textureDescriptor)
    {
        using WebGpuAllocatorHandle allocator = WebGpuAllocatorHandle.Get();
        fixed (byte* labelPtr = ToRefCstrUtf8(textureDescriptor.Label, allocator))
        fixed (TextureFormat* viewFormatsPtr = textureDescriptor.ViewFormats)
        {
            textureDescriptor._unmanagedDescriptor.Label = labelPtr;
            textureDescriptor._unmanagedDescriptor.ViewFormatCount = (uint)textureDescriptor.ViewFormats.Length;
            textureDescriptor._unmanagedDescriptor.ViewFormats = viewFormatsPtr;

            return WebGPU_FFI.DeviceCreateTexture(this, &textureDescriptor._unmanagedDescriptor);
        }
    }

    public readonly void Dispose()
    {
        if (_ptr != UIntPtr.Zero)
        {
            WebGPU_FFI.DeviceRelease(this);
        }
    }

    public static ref nuint AsPointer(ref DeviceHandle handle)
    {
        return ref Unsafe.AsRef(in handle._ptr);
    }

    public static DeviceHandle GetNullHandle()
    {
        return Null;
    }

    public static bool IsNull(DeviceHandle handle)
    {
        return handle == Null;
    }

    public static DeviceHandle UnsafeFromPointer(nuint pointer)
    {
        return new DeviceHandle(pointer);
    }

    public Device? ToSafeHandle(bool incrementReferenceCount)
    {
        return Device.FromHandle(this, incrementReferenceCount);
    }

    public static void Reference(DeviceHandle handle)
    {
        WebGPU_FFI.DeviceReference(handle);
    }

    public static void Release(DeviceHandle handle)
    {
        WebGPU_FFI.DeviceRelease(handle);
    }
}