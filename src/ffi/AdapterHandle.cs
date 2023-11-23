using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using WebGpuSharp.Internal;
using static WebGpuSharp.FFI.WebGPUMarshal;

namespace WebGpuSharp.FFI;

public unsafe readonly partial struct AdapterHandle :
    IDisposable, IWebGpuHandle<AdapterHandle, Adapter>
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

    public readonly FeatureName[] GetFeatures()
    {
        nuint count = GetEnumerateFeaturesCount();
        FeatureName[] features = new FeatureName[count];
        EnumerateFeatures(features);
        return features;
    }

    public readonly bool GetLimits(out SupportedLimits limits)
    {
        limits = default;
        fixed (SupportedLimits* limitsPtr = &limits)
        {
            return WebGPU_FFI.AdapterGetLimits(this, limitsPtr);
        }
    }

    public readonly SupportedLimits? GetLimits()
    {
        SupportedLimits limits = default;
        if (WebGPU_FFI.AdapterGetLimits(this, &limits))
        {
            return limits;
        }
        else
        {
            return null;
        }
    }

    public readonly void GetProperties(out AdapterProperties properties)
    {
        fixed (AdapterPropertiesFFI* propertiesPtr = &properties._unmanagedDescriptor)
        {
            WebGPU_FFI.AdapterGetProperties(this, propertiesPtr);
        }
    }

    public readonly AdapterProperties GetProperties()
    {
        AdapterProperties properties;
        WebGPU_FFI.AdapterGetProperties(this, &properties._unmanagedDescriptor);
        return properties;
    }

    public readonly bool HasFeature(FeatureName feature)
    {
        return WebGPU_FFI.AdapterHasFeature(this, feature);
    }

    private readonly unsafe Task<DeviceHandle> RequestDeviceAsync(DeviceDescriptorFFI* descriptor)
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
               callback: &OnDeviceRequestEndedTaskCompletionSource,
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

        fixed (byte* deviceDescriptorLabelPtr = ToRefCstrUtf8(descriptor.Label, allocator))
        fixed (byte* queueLabelPtr = ToRefCstrUtf8(descriptor.DefaultQueue.Label, allocator))
        fixed (FeatureName* requiredFeaturesPtr = descriptor.RequiredFeatures)
        fixed (RequiredLimits* requiredLimitsPtr = descriptor.RequiredLimits)
        {
            DeviceDescriptorFFI deviceDescriptor = new(
                label: deviceDescriptorLabelPtr,
                requiredFeatures: requiredFeaturesPtr,
                requiredFeatureCount: (uint)descriptor.RequiredFeatures.Length,
                requiredLimits: requiredLimitsPtr,
                defaultQueue: new(
                    label: queueLabelPtr
                ),
                deviceLostCallback: null,
                deviceLostUserdata: null
            );
            return RequestDeviceAsync(&deviceDescriptor);
        }
    }

    public readonly void RequestDeviceAsync(in DeviceDescriptor descriptor, Action<DeviceHandle> callback)
    {
        using WebGpuAllocatorHandle allocator = WebGpuAllocatorHandle.Get();

        CallbackUserDataHandle handle = default;
        try
        {
            fixed (byte* deviceDescriptorLabelPtr = ToRefCstrUtf8(descriptor.Label, allocator))
            fixed (byte* queueLabelPtr = ToRefCstrUtf8(descriptor.DefaultQueue.Label, allocator))
            fixed (FeatureName* requiredFeaturesPtr = descriptor.RequiredFeatures)
            fixed (RequiredLimits* requiredLimitsPtr = descriptor.RequiredLimits)
            {
                DeviceDescriptorFFI deviceDescriptor = new(
                    label: deviceDescriptorLabelPtr,
                    requiredFeatures: requiredFeaturesPtr,
                    requiredFeatureCount: (uint)descriptor.RequiredFeatures.Length,
                    requiredLimits: requiredLimitsPtr,
                    defaultQueue: new(
                        label: queueLabelPtr
                    ),
                    deviceLostCallback: null,
                    deviceLostUserdata: null
                );

                handle = CallbackUserDataHandle.Alloc(callback);
                WebGPU_FFI.AdapterRequestDevice(
                   adapter: this,
                   descriptor: &deviceDescriptor,
                   callback: &OnDeviceRequestEndedDelegate,
                   userdata: (void*)handle
                );
            }
        }
        catch (Exception e)
        {
            Console.Error.WriteLine(e);
            if (handle.IsValid())
            {
                handle.Dispose();
            }
            callback(default);
        }
    }

    public readonly void RequestDeviceAsync(in DeviceDescriptor descriptor, Action<Device?> callback)
    {
        RequestDeviceAsync(descriptor, (DeviceHandle device) =>
        {
            if (DeviceHandle.IsNull(device))
            {
                callback(default);
            }
            else
            {
                callback(Device.FromHandle(device, true)!);
            }
        });
    }

    [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
    private static unsafe void OnDeviceRequestEndedDelegate(
      RequestDeviceStatus status, DeviceHandle device, byte* message, void* userdata)
    {
        CallbackUserDataHandle handle = (CallbackUserDataHandle)userdata;
        Action<DeviceHandle>? callback = null;
        try
        {

            callback = (Action<DeviceHandle>)handle.GetObject()!;

            if (status == RequestDeviceStatus.Success)
            {
                callback(device);
            }
            else
            {
                string? messageStr = Marshal.PtrToStringAnsi((IntPtr)message);
                Console.WriteLine($"Could not get WebGPU device: {messageStr ?? "Failed to get error message"}");
                callback(default);
            }
        }
        catch (Exception)
        {
            device.Dispose();
            callback?.Invoke(default);
        }
        finally
        {
            if (handle.IsValid())
            {
                handle.Dispose();
            }
        }
    }


    [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
    private static unsafe void OnDeviceRequestEndedTaskCompletionSource(
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

    public Adapter? ToSafeHandle(bool isOwnedHandle)
    {
        return Adapter.FromHandle(this, isOwnedHandle);
    }

    public static void Reference(AdapterHandle handle)
    {
        WebGPU_FFI.AdapterReference(handle);
    }

    public static void Release(AdapterHandle handle)
    {
        WebGPU_FFI.AdapterRelease(handle);
    }
}