using System.Collections.Concurrent;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using WebGpuSharp.Internal;
using static WebGpuSharp.FFI.WebGPUMarshal;

namespace WebGpuSharp.FFI;

public unsafe readonly partial struct AdapterHandle :
    IDisposable, IWebGpuHandle<AdapterHandle, Adapter>
{
    public readonly FeatureName[] GetFeatures()
    {
        bool gotFeatures = false;
        SupportedFeaturesFFI supportedFeaturesFFI;
        Unsafe.SkipInit(out supportedFeaturesFFI);
        try
        {
            WebGPU_FFI.AdapterGetFeatures(this, &supportedFeaturesFFI);
            gotFeatures = true;
            FeatureName[] features = new FeatureName[supportedFeaturesFFI.FeatureCount];
            features.CopyTo(new Span<FeatureName>(supportedFeaturesFFI.Features, (int)supportedFeaturesFFI.FeatureCount));
            return features;
        }
        finally
        {
            if (gotFeatures)
            {
                WebGPU_FFI.SupportedFeaturesFreeMembers(supportedFeaturesFFI);
            }
        }
    }

    public readonly bool GetLimits(out SupportedLimits limits)
    {
        limits = default;
        fixed (SupportedLimits* limitsPtr = &limits)
        {
            return WebGPU_FFI.AdapterGetLimits(this, limitsPtr) == Status.Success;
        }
    }

    public readonly SupportedLimits? GetLimits()
    {
        SupportedLimits limits = default;
        if (WebGPU_FFI.AdapterGetLimits(this, &limits) == Status.Success)
        {
            return limits;
        }
        else
        {
            return null;
        }
    }

    public readonly AdapterInfo? GetInfo()
    {
        AdapterInfoFFI adapterInfoFFI = default;
        WebGPU_FFI.AdapterGetInfo(this, &adapterInfoFFI);
        var outAdapterInfo = new AdapterInfo(adapterInfoFFI);
        WebGPU_FFI.AdapterInfoFreeMembers(adapterInfoFFI);
        return outAdapterInfo;
    }

    private readonly unsafe Task<DeviceHandle> RequestDeviceAsync(DeviceDescriptorFFI* descriptor)
    {
        TaskCompletionSource<DeviceHandle> taskCompletionSource;
        void* userData = default;
        try
        {
            taskCompletionSource = new TaskCompletionSource<DeviceHandle>();
            userData = AllocUserData(taskCompletionSource);

            WebGPU_FFI.AdapterRequestDevice(
               adapter: this,
               descriptor: descriptor,
               callback: &OnDeviceRequestEndedTaskCompletionSource,
               userdata: userData
            );
        }
        catch (Exception e)
        {
            Console.Error.WriteLine(e);
            FreeUserData(userData);
            return Task.FromResult(default(DeviceHandle));
        }

        return taskCompletionSource.Task;
    }


    public readonly Task<DeviceHandle> RequestDeviceAsync(in DeviceDescriptor descriptor)
    {
        using WebGpuAllocatorHandle allocator = WebGpuAllocatorHandle.Get();

        var labelUtf8Span = ToUtf8Span(descriptor.Label, allocator, addNullTerminator: false);
        var queueLabelUtf8Span = ToUtf8Span(descriptor.DefaultQueue.Label, allocator, addNullTerminator: false);

        fixed (byte* deviceDescriptorLabelPtr = labelUtf8Span)
        fixed (byte* queueLabelPtr = queueLabelUtf8Span)
        fixed (FeatureName* requiredFeaturesPtr = descriptor.RequiredFeatures)
        fixed (RequiredLimits* requiredLimitsPtr = descriptor.RequiredLimits)
        {
            var deviceLostCallbackFuncPtrAndId = DeviceLostCallbackHandler.AddDeviceLostCallback(descriptor.DeviceLostCallback);
            var uncapturedErrorCallbackFuncPtrAndId = UncapturedErrorDelegateHandler.AddUncapturedErrorCallback(descriptor.UncapturedErrorCallback);

            DeviceDescriptorFFI deviceDescriptor = new()
            {
                Label = StringViewFFI.CreateExplicitlySized(deviceDescriptorLabelPtr, labelUtf8Span.Length),
                RequiredFeatures = requiredFeaturesPtr,
                RequiredFeatureCount = (uint)descriptor.RequiredFeatures.Length,
                RequiredLimits = requiredLimitsPtr,
                DefaultQueue = {
                    Label = StringViewFFI.CreateExplicitlySized(queueLabelPtr, queueLabelUtf8Span.Length)
                },
                DeviceLostCallbackInfo2 = {
                    Mode = descriptor.DeviceLostCallbackMode,
                    Callback = deviceLostCallbackFuncPtrAndId.funcPtr,
                    Userdata1 = (void*)deviceLostCallbackFuncPtrAndId.id,
                },
                UncapturedErrorCallbackInfo2 = {
                    Callback = uncapturedErrorCallbackFuncPtrAndId.funcPtr,
                    Userdata1 = (void*)uncapturedErrorCallbackFuncPtrAndId.id
                }
            };
            return RequestDeviceAsync(&deviceDescriptor);
        }
    }

    public readonly void RequestDeviceAsync(in DeviceDescriptor descriptor, Action<DeviceHandle> callback)
    {
        using WebGpuAllocatorHandle allocator = WebGpuAllocatorHandle.Get();

        void* userData = null;
        try
        {
            var deviceDescriptorLabelUtf8Span = ToUtf8Span(descriptor.Label, allocator, addNullTerminator: false);
            var queueLabelUtf8Span = ToUtf8Span(descriptor.DefaultQueue.Label, allocator, addNullTerminator: false);

            fixed (byte* deviceDescriptorLabelPtr = deviceDescriptorLabelUtf8Span)
            fixed (byte* queueLabelPtr = queueLabelUtf8Span)
            fixed (FeatureName* requiredFeaturesPtr = descriptor.RequiredFeatures)
            fixed (RequiredLimits* requiredLimitsPtr = descriptor.RequiredLimits)
            {
                var deviceLostCallbackFuncPtrAndId = DeviceLostCallbackHandler.AddDeviceLostCallback(descriptor.DeviceLostCallback);
                var uncapturedErrorCallbackFuncPtrAndId = UncapturedErrorDelegateHandler.AddUncapturedErrorCallback(descriptor.UncapturedErrorCallback);

                DeviceDescriptorFFI deviceDescriptor = new()
                {
                    NextInChain = default,
                    Label = StringViewFFI.CreateExplicitlySized(deviceDescriptorLabelPtr, deviceDescriptorLabelUtf8Span.Length),
                    RequiredFeatures = requiredFeaturesPtr,
                    RequiredFeatureCount = (uint)descriptor.RequiredFeatures.Length,
                    RequiredLimits = requiredLimitsPtr,
                    DefaultQueue = new()
                    {
                        Label = StringViewFFI.CreateExplicitlySized(queueLabelPtr, queueLabelUtf8Span.Length)
                    },
                    DeviceLostCallbackInfo2 = new()
                    {
                        Mode = descriptor.DeviceLostCallbackMode,
                        Callback = deviceLostCallbackFuncPtrAndId.funcPtr,
                        Userdata1 = (void*)deviceLostCallbackFuncPtrAndId.id
                    },
                    UncapturedErrorCallbackInfo2 = new()
                    {
                        Callback = uncapturedErrorCallbackFuncPtrAndId.funcPtr,
                        Userdata1 = (void*)uncapturedErrorCallbackFuncPtrAndId.id
                    }
                };

                userData = AllocUserData(callback);
                WebGPU_FFI.AdapterRequestDevice(
                   adapter: this,
                   descriptor: &deviceDescriptor,
                   callback: &OnDeviceRequestEndedDelegate,
                   userdata: userData
                );
            }
        }
        catch (Exception e)
        {
            Console.Error.WriteLine(e);
            FreeUserData(userData);
            callback(default);
        }
    }

    public readonly void RequestDeviceAsync(in DeviceDescriptor descriptor, Action<Device?> callback)
    {
        RequestDeviceAsync(descriptor, (DeviceHandle device) =>
        {
            if (DeviceHandle.IsNull(device))
            {
                callback(null);
            }
            else
            {
                callback(ToSafeHandleNoRefIncrement<Device, DeviceHandle>(device));
            }
        });
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static unsafe void OnDeviceRequestEndedDelegate(
      RequestDeviceStatus status, DeviceHandle device, StringViewFFI message, void* userdata)
    {
        Action<DeviceHandle>? callback = null;
        try
        {
            callback = (Action<DeviceHandle>?)ConsumeUserDataIntoObject(userdata);

            if (callback == null)
            {
                return;
            }

            if (status == RequestDeviceStatus.Success)
            {
                callback(device);
            }
            else
            {
                string? messageStr = Encoding.UTF8.GetString(message.AsSpan());
                Console.WriteLine($"Could not get WebGPU device: {messageStr ?? "Failed to get error message"}");
                callback(default);
            }
        }
        catch (Exception)
        {
            device.Dispose();
            callback?.Invoke(default);
        }
    }




    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static unsafe void OnDeviceRequestEndedTaskCompletionSource(
      RequestDeviceStatus status, DeviceHandle device, StringViewFFI message, void* userdata)
    {
        TaskCompletionSource<DeviceHandle>? taskCompletionSource = null;
        try
        {

            taskCompletionSource = (TaskCompletionSource<DeviceHandle>?)ConsumeUserDataIntoObject(userdata);

            if (taskCompletionSource == null)
            {
                return;
            }

            if (status == RequestDeviceStatus.Success)
            {
                taskCompletionSource.SetResult(device);
            }
            else
            {
                string? messageStr = Encoding.UTF8.GetString(message.AsSpan());
                Console.WriteLine($"Could not get WebGPU device: {messageStr ?? "Failed to get error message"}");
                taskCompletionSource.SetResult(DeviceHandle.Null);
            }
        }
        catch (Exception)
        {
            taskCompletionSource?.SetResult(DeviceHandle.Null);
            device.Dispose();
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

    public Adapter? ToSafeHandle(bool incrementRefCount)
    {
        if (incrementRefCount)
        {
            return ToSafeHandle<Adapter, AdapterHandle>(this);
        }
        else
        {
            return ToSafeHandleNoRefIncrement<Adapter, AdapterHandle>(this);
        }
    }

    public static void Reference(AdapterHandle handle)
    {
        WebGPU_FFI.AdapterAddRef(handle);
    }

    public static void Release(AdapterHandle handle)
    {
        WebGPU_FFI.AdapterRelease(handle);
    }
}


file static class DeviceLostCallbackHandler
{
    public unsafe struct FuncPtrAndId
    {
        public delegate* unmanaged[Cdecl]<DeviceHandle*, DeviceLostReason, StringViewFFI, void*, void*, void> funcPtr;
        public nuint id;
    }

    private static volatile uint deviceLostCallbackId = 0;
    private static readonly ConcurrentDictionary<nuint, DeviceLostCallbackDelegate> deviceLostCallbacks = new();

    public unsafe static FuncPtrAndId AddDeviceLostCallback(DeviceLostCallbackDelegate? callback)
    {
        if (callback == null)
        {
            return new FuncPtrAndId { funcPtr = null, id = 0 };
        }

        nuint id = Interlocked.Increment(ref deviceLostCallbackId);
        deviceLostCallbacks.TryAdd(id, callback);
        return new FuncPtrAndId { funcPtr = &DeviceLostCallback, id = id };
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static unsafe void DeviceLostCallback(
      DeviceHandle* device, DeviceLostReason lostReason, StringViewFFI message, void* id, void* _)
    {
        nuint callbackId = (nuint)id;
        if (deviceLostCallbacks.TryGetValue(callbackId, out var callback))
        {
            callback(lostReason, message.AsSpan());
        }
    }
}

file static class UncapturedErrorDelegateHandler
{
    public unsafe struct FuncPtrAndId
    {
        public delegate* unmanaged[Cdecl]<DeviceHandle*, ErrorType, StringViewFFI, void*, void*, void> funcPtr;
        public nuint id;
    }


    private static volatile uint uncapturedErrorCallbackId = 0;
    private static readonly ConcurrentDictionary<nuint, UncapturedErrorDelegate> uncapturedErrorCallbacks = new();

    public unsafe static FuncPtrAndId AddUncapturedErrorCallback(UncapturedErrorDelegate? callback)
    {
        if (callback == null)
        {
            return new FuncPtrAndId { funcPtr = null, id = 0 };
        }

        nuint id = Interlocked.Increment(ref uncapturedErrorCallbackId);
        uncapturedErrorCallbacks.TryAdd(id, callback);
        return new FuncPtrAndId { funcPtr = &UncapturedErrorCallback, id = id };
    }


    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static unsafe void UncapturedErrorCallback(
       DeviceHandle* _1, ErrorType type, StringViewFFI message, void* id, void* _)
    {
        nuint callbackId = (nuint)id;
        if (uncapturedErrorCallbacks.TryGetValue(callbackId, out var callback))
        {
            callback(type, message.AsSpan());
        }
    }
}