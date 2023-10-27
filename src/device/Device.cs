using System.Buffers;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using WebGpuSharp.Internal;

namespace WebGpuSharp.FFI;

public unsafe readonly partial struct DeviceHandle : IDisposable, IWebGpuHandle<DeviceHandle, Device>
{
    private static readonly ConcurrentBag<object> deviceLostCallbacks = new();
    private static volatile uint deviceLostCallbackSetup = 0;

    public readonly void AddDeviceLostCallback(DeviceLostCallbackDelegate callback)
    {
        deviceLostCallbacks.Add(callback);
        unsafe
        {
            if (Interlocked.Exchange(ref deviceLostCallbackSetup, 1) == 0)
            {
                WebGPU_FFI.DeviceSetDeviceLostCallback(
                    device: this,
                    callback: &OnDeviceLostCallback,
                    userdata: null
                );
            }
        }
    }

    public QueueHandle GetQueue()
    {
        return WebGPU_FFI.DeviceGetQueue(this);
    }

    public CommandEncoderHandle CreateCommandEncoder(in CommandEncoderDescriptor descriptor)
    {
        using WebGpuAllocatorHandle allocator = WebGpuAllocatorHandle.Get();

        fixed (byte* LabelPtr = descriptor.label)
        {
            UFT8CStrFactory utf8Factory = new(allocator);
            CommandEncoderDescriptorFFI commandEncoderDescriptor = new()
            {
                Label = utf8Factory.Create(
                    text: LabelPtr,
                    length: descriptor.label.Length,
                    is16BitSize: descriptor.label.Is16BitSize,
                    allowPassthrough: true
                ),
            };
            return WebGPU_FFI.DeviceCreateCommandEncoder(this, &commandEncoderDescriptor);
        }
    }

    public void Tick()
    {
        WebGPU_FFI.DeviceTick(this);
    }

    public BufferHandle CreateBuffer(in BufferDescriptor descriptor)
    {
        fixed (BufferDescriptorFFI* descriptorPtr = &descriptor._unmanagedDescriptor)
        {
            using WebGpuAllocatorHandle allocator = WebGpuAllocatorHandle.Get();
            fixed (byte* LabelPtr = descriptor.Label)
            {
                UFT8CStrFactory uft8Factory = new(allocator);
                descriptorPtr->Label = uft8Factory.Create(
                    text: LabelPtr,
                    is16BitSize: descriptor.Label.Is16BitSize,
                    length: descriptor.Label.Length,
                    allowPassthrough: true
                );

                return WebGPU_FFI.DeviceCreateBuffer(this, descriptorPtr);
            }
        }
    }

    public SwapChainHandle CreateSwapChain(SurfaceHandle surface, in SwapChainDescriptor descriptor)
    {
        WebGpuAllocatorHandle allocator = WebGpuAllocatorHandle.Get();

        fixed (byte* LabelPtr = descriptor.Label)
        fixed (SwapChainDescriptorFFI* descriptorPtr = &descriptor._unsafeDescriptor)
        {
            UFT8CStrFactory utf8Factory = new(allocator);

            descriptorPtr->Label = utf8Factory.Create(
                text: LabelPtr,
                is16BitSize: descriptor.Label.Is16BitSize,
                length: descriptor.Label.Length,
                allowPassthrough: true
            );

            return WebGPU_FFI.DeviceCreateSwapChain(this, surface, descriptorPtr);
        }
    }

    public readonly ShaderModuleHandle CreateShaderModule(in ShaderModuleDescriptor descriptor)
    {
        unsafe
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
    }

    private unsafe readonly ShaderModuleHandle CreateShaderModuleWgsl(in ShaderModuleDescriptor descriptor, WGPURefText code)
    {
        using WebGpuAllocatorHandle allocator = WebGpuAllocatorHandle.Get();
        UFT8CStrFactory utf8Factory = new(allocator);

        fixed (byte* labelPtr = descriptor.Label)
        fixed (byte* codePtr = code)
        {

            ShaderModuleWGSLDescriptorFFI shaderModuleWGSLDescriptor = new()
            {
                Chain = new()
                {
                    Next = null,
                    SType = SType.ShaderModuleWGSLDescriptor
                },
                Code = utf8Factory.Create(
                    text: codePtr,
                    is16BitSize: code.Is16BitSize,
                    length: code.Length,
                    allowPassthrough: true
                ),
            };

            ShaderModuleDescriptorFFI shaderModuleDescriptor = new()
            {
                NextInChain = &shaderModuleWGSLDescriptor.Chain,
                Label = utf8Factory.Create(
                    text: labelPtr,
                    is16BitSize: descriptor.Label.Is16BitSize,
                    length: descriptor.Label.Length,
                    allowPassthrough: true
                ),
            };

            return WebGPU_FFI.DeviceCreateShaderModule(this, &shaderModuleDescriptor);
        }
    }


    [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
    private static unsafe void OnUncapturedErrorCallback(ErrorType type, byte* message, void* userdata)
    {
        ReadOnlySpan<byte> messageSpan;
        if (message != null)
        {
            messageSpan = MemoryMarshal.CreateReadOnlySpanFromNullTerminated(message);
        }
        else
        {
            messageSpan = ReadOnlySpan<byte>.Empty;
        }
        object[]? array = null;

        try
        {
            int count = deviceLostCallbacks.Count;
            array = ArrayPool<object>.Shared.Rent(count);
            deviceLostCallbacks.CopyTo(array, 0);

            foreach (var item in array.AsSpan(0, count))
            {
                Unsafe.As<UncapturedErrorDelegate>(item).Invoke(type, messageSpan);
            }
        }
        finally
        {
            if (array != null)
            {
                ArrayPool<object>.Shared.Return(array, true);
            }
        }
    }

    [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
    internal static unsafe void OnDeviceLostCallback(DeviceLostReason lostReason, byte* message, void* userdata)
    {
        ReadOnlySpan<byte> messageSpan;
        if (message != null)
        {
            messageSpan = MemoryMarshal.CreateReadOnlySpanFromNullTerminated(message);
        }
        else
        {
            messageSpan = ReadOnlySpan<byte>.Empty;
        }
        object[]? array = null;

        try
        {
            int count = deviceLostCallbacks.Count;
            array = ArrayPool<object>.Shared.Rent(count);
            deviceLostCallbacks.CopyTo(array, 0);

            foreach (var item in array.AsSpan(0, count))
            {
                Unsafe.As<DeviceLostCallbackDelegate>(item).Invoke(lostReason, messageSpan);
            }
        }
        finally
        {
            if (array != null)
            {
                ArrayPool<object>.Shared.Return(array, true);
            }
        }
    }



    [SkipLocalsInit]
    public readonly SupportedLimits GetLimits()
    {
        unsafe
        {
            SupportedLimits supportedLimits;
            WebGPU_FFI.DeviceGetLimits(this, &supportedLimits);
            return supportedLimits;
        }
    }

    public readonly void GetLimits(ref SupportedLimits supportedLimits)
    {
        fixed (SupportedLimits* supportedLimitsPtr = &supportedLimits)
        {
            WebGPU_FFI.DeviceGetLimits(this, supportedLimitsPtr);
        }
    }

    public readonly TextureHandle CreateTexture(in TextureDescriptor textureDescriptor)
    {
        using WebGpuAllocatorHandle allocator = WebGpuAllocatorHandle.Get();
        UFT8CStrFactory utf8Factory = new(allocator);

        fixed (byte* labelPtr = textureDescriptor.Label)
        fixed (TextureFormat* viewFormatsPtr = textureDescriptor.ViewFormats)
        fixed (TextureDescriptorFFI* textureDescriptorPtr = &textureDescriptor._unmanagedDescriptor)
        {
            textureDescriptorPtr->Label = utf8Factory.Create(
                text: labelPtr,
                is16BitSize: textureDescriptor.Label.Is16BitSize,
                length: textureDescriptor.Label.Length,
                allowPassthrough: true
            );

            textureDescriptorPtr->ViewFormatCount = (uint)textureDescriptor.ViewFormats.Length;
            textureDescriptorPtr->ViewFormats = viewFormatsPtr;

            return WebGPU_FFI.DeviceCreateTexture(this, textureDescriptorPtr);
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