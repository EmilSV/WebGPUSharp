using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using WebGpuSharp.Internal;

namespace WebGpuSharp.FFI;

public unsafe readonly partial struct AdapterHandle : IDisposable, IWebGpuHandle<AdapterHandle>
{
    public readonly nuint GetEnumerateFeaturesCount()
    {
        return WebGPU_FFI.AdapterEnumerateFeatures(this, null);
    }

    public readonly nuint EnumerateFeatures(Span<FeatureName> output)
    {
        Debug.Assert((nuint)output.Length >= GetEnumerateFeaturesCount());

        fixed (FeatureName* outputPtr = output)
        {
            return WebGPU_FFI.AdapterEnumerateFeatures(this, outputPtr);
        }
    }

    public readonly bool AdapterGetLimits(out SupportedLimits limits)
    {
        limits = default;
        fixed (SupportedLimits* limitsPtr = &limits)
        {
            return WebGPU_FFI.AdapterGetLimits(this, limitsPtr);
        }
    }

    public readonly SupportedLimits? AdapterGetLimits()
    {
        SupportedLimits limits;
        if (WebGPU_FFI.AdapterGetLimits(this, &limits))
        {
            return limits;
        }
        else
        {
            return null;
        }
    }

    public readonly void AdapterGetProperties(out AdapterProperties properties)
    {
        fixed (AdapterPropertiesFFI* propertiesPtr = &properties._unmanagedDescriptor)
        {
            WebGPU_FFI.AdapterGetProperties(this, propertiesPtr);
        }
    }

    public readonly AdapterProperties AdapterGetProperties()
    {
        AdapterProperties properties;
        WebGPU_FFI.AdapterGetProperties(this, &properties._unmanagedDescriptor);
        return properties;
    }

    public readonly bool AdapterHasFeature(FeatureName feature)
    {
        return WebGPU_FFI.AdapterHasFeature(this, feature);
    }

    public readonly unsafe Task<DeviceHandle> RequestDeviceAsync(DeviceDescriptorFFI* descriptor)
    {
        TaskCompletionSource<DeviceHandle> taskCompletionSource;
        CallbackUserDataHandle handle = default;
        try
        {
            taskCompletionSource = new TaskCompletionSource<DeviceHandle>();
            handle = CallbackUserDataHandle.Alloc(taskCompletionSource);

            WebGPU_FFI.AdapterRequestDevice(
               adapter: this,
               descriptor: descriptor,
               callback: &OnDeviceRequestEnded,
               userdata: (void*)handle
            );
        }
        catch (Exception e)
        {
            Console.Error.WriteLine(e);
            if (handle.IsValid())
            {
                handle.Dispose();
            }
            return Task.FromResult(default(DeviceHandle));
        }

        return taskCompletionSource.Task;
    }


    public readonly Task<DeviceHandle> RequestDeviceAsync(in DeviceDescriptor descriptor)
    {
        using WebGpuAllocatorHandle allocator = WebGpuAllocatorHandle.Get();

        fixed (byte* DeviceDescriptorLabelPtr = descriptor.Label)
        fixed (byte* QueueLabelPtr = descriptor.DefaultQueue.Label)
        fixed (FeatureName* requiredFeaturesPtr = descriptor.RequiredFeatures)
        fixed (RequiredLimits* requiredLimitsPtr = &descriptor.RequiredLimits)
        {
            UFT8CStrFactory uft8Factory = new(allocator);

            DeviceDescriptorFFI deviceDescriptor = new()
            {
                Label = uft8Factory.Create(
                    text: DeviceDescriptorLabelPtr,
                    is16BitSize: descriptor.Label.Is16BitSize,
                    length: descriptor.Label.Length,
                    allowPassthrough: true
                ),
                RequiredFeatures = requiredFeaturesPtr,
                RequiredFeaturesCount = (uint)descriptor.RequiredFeatures.Length,
                RequiredLimits = requiredLimitsPtr,
                DefaultQueue = new()
                {
                    Label = uft8Factory.Create(
                        text: QueueLabelPtr,
                        is16BitSize: descriptor.DefaultQueue.Label.Is16BitSize,
                        length: descriptor.DefaultQueue.Label.Length,
                        allowPassthrough: true
                    )
                },
                DeviceLostCallback = &DeviceHandle.OnDeviceLostCallback,
                DeviceLostUserdata = null
            };
            return RequestDeviceAsync(&deviceDescriptor);
        }
    }

    [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
    private static unsafe void OnDeviceRequestEnded(
      RequestDeviceStatus status, DeviceHandle device, byte* message, void* userdata)
    {
        CallbackUserDataHandle handle = (CallbackUserDataHandle)userdata;
        TaskCompletionSource<DeviceHandle>? taskCompletionSource = null;
        try
        {

            taskCompletionSource = (TaskCompletionSource<DeviceHandle>)handle.GetObject()!;

            if (status == RequestDeviceStatus.Success)
            {
                taskCompletionSource.SetResult(device);
            }
            else
            {
                string? messageStr = Marshal.PtrToStringAnsi((IntPtr)message);
                Console.WriteLine($"Could not get WebGPU device: {messageStr ?? "Failed to get error message"}");
                taskCompletionSource.SetResult(DeviceHandle.Null);
            }
        }
        catch (Exception)
        {
            taskCompletionSource?.SetResult(DeviceHandle.Null);
            device.Dispose();
        }
        finally
        {
            if (handle.IsValid())
            {
                handle.Dispose();
            }
        }
    }

    public readonly SupportedLimits GetLimits()
    {
        SupportedLimits limits = default;
        GetLimits(ref limits);
        return limits;
    }

    public readonly void GetLimits(ref SupportedLimits limits)
    {
        fixed (SupportedLimits* limitsPtr = &limits)
        {
            WebGPU_FFI.AdapterGetLimits(this, limitsPtr);
        }
    }

    public void Dispose()
    {
        if (_ptr != UIntPtr.Zero)
        {
            WebGPU_FFI.AdapterRelease(this);
        }
    }

    public static ref nuint AsPointer(ref AdapterHandle handle)
    {
        return ref Unsafe.AsRef(in handle._ptr);
    }

    public static AdapterHandle GetNullHandle()
    {
        return Null;
    }

    public static bool IsNull(AdapterHandle handle)
    {
        return handle == Null;
    }

    public static AdapterHandle UnsafeFromPointer(nuint pointer)
    {
        return new AdapterHandle(pointer);
    }
}