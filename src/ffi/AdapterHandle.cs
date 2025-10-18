using System.Collections.Concurrent;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using WebGpuSharp.Internal;
using WebGpuSharp.Marshalling;
using static WebGpuSharp.Marshalling.WebGPUMarshal;

namespace WebGpuSharp.FFI;

public unsafe readonly partial struct AdapterHandle :
    IDisposable, IWebGpuHandle<AdapterHandle, Adapter>
{

    /// <returns>The features supported.</returns>
    /// <inheritdoc cref="GetFeatures(SupportedFeaturesFFI*)" />
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
            var supportedFeaturesFFISpan = new Span<FeatureName>(supportedFeaturesFFI.Features, (int)supportedFeaturesFFI.FeatureCount);
            supportedFeaturesFFISpan.CopyTo(features);
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

    /// <returns>If true the call was successful, false otherwise.</returns>
    /// <inheritdoc cref="GetLimits(Limits*)"/>
    public readonly bool GetLimits(out Limits limits)
    {
        limits = default;
        fixed (Limits* limitsPtr = &limits)
        {
            return WebGPU_FFI.AdapterGetLimits(this, limitsPtr) == Status.Success;
        }
    }


    /// <returns>The limits or null if it failed</returns>
    /// <inheritdoc cref="GetLimits(Limits*)"/>
    public readonly Limits? GetLimits()
    {
        Limits limits = default;
        if (WebGPU_FFI.AdapterGetLimits(this, &limits) == Status.Success)
        {
            return limits;
        }
        else
        {
            return null;
        }
    }


    /// <returns>The AdapterInfo or null if it failed</returns>
    /// <inheritdoc cref="GetInfo(AdapterInfoFFI*)"/>
    public readonly AdapterInfo? GetInfo()
    {
        AdapterInfoFFI adapterInfoFFI = default;
        WebGPU_FFI.AdapterGetInfo(this, &adapterInfoFFI);
        var outAdapterInfo = new AdapterInfo(adapterInfoFFI);
        WebGPU_FFI.AdapterInfoFreeMembers(adapterInfoFFI);
        return outAdapterInfo;
    }

    /// <param name="descriptor">Description of the  <see cref="Device"/> to request.</param>
    /// <returns>A task that resolve into a device.</returns>
    /// <inheritdoc cref="RequestDevice(DeviceDescriptorFFI*, RequestDeviceCallbackInfoFFI)"/>
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
               callbackInfo: new()
               {
                   Mode = CallbackMode.AllowSpontaneous,
                   Callback = &OnDeviceRequestEndedTaskCompletionSource,
                   Userdata1 = userData,
                   Userdata2 = null
               }
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

    /// <inheritdoc cref="RequestDeviceAsync(DeviceDescriptorFFI*)"/>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly Task<DeviceHandle> RequestDeviceAsync() => RequestDeviceAsync((DeviceDescriptorFFI*)null);


    /// <inheritdoc cref="RequestDeviceAsync(DeviceDescriptorFFI*)"/>
    public readonly Task<DeviceHandle> RequestDeviceAsync(in DeviceDescriptor descriptor)
    {
        WebGpuAllocatorLogicBlock allocatorLogicBlock = default;
        const int stackAllocSize = 16 * 2 * sizeof(byte);
        byte* stackAllocPtr = stackalloc byte[stackAllocSize];

        using var allocator = WebGpuMarshallingMemory.GetAllocatorHandle(
            ref allocatorLogicBlock,
            stackAllocPtr,
            stackAllocSize
        );

        var labelUtf8Span = ToUtf8Span(descriptor.Label, allocator, addNullTerminator: false);
        var queueLabelUtf8Span = ToUtf8Span(descriptor.DefaultQueue.Label, allocator, addNullTerminator: false);

        fixed (byte* deviceDescriptorLabelPtr = labelUtf8Span)
        fixed (byte* queueLabelPtr = queueLabelUtf8Span)
        fixed (FeatureName* requiredFeaturesPtr = descriptor.RequiredFeatures)
        fixed (Limits* requiredLimitsPtr = &Nullable.GetValueRefOrDefaultRef(in descriptor.RequiredLimits))
        {
            var deviceLostCallbackFuncPtrAndId = DeviceLostCallbackHandler.AddDeviceLostCallback(descriptor.DeviceLostCallback);
            var uncapturedErrorCallbackFuncPtrAndId = UncapturedErrorDelegateHandler.AddUncapturedErrorCallback(descriptor.UncapturedErrorCallback);

            DeviceDescriptorFFI deviceDescriptor = new()
            {
                Label = StringViewFFI.CreateExplicitlySized(deviceDescriptorLabelPtr, labelUtf8Span.Length),
                RequiredFeatures = requiredFeaturesPtr,
                RequiredFeatureCount = (uint)descriptor.RequiredFeatures.Length,
                RequiredLimits = descriptor.RequiredLimits.HasValue ? requiredLimitsPtr : null,
                DefaultQueue = {
                    Label = StringViewFFI.CreateExplicitlySized(queueLabelPtr, queueLabelUtf8Span.Length)
                },
                DeviceLostCallbackInfo = {
                    Mode = descriptor.DeviceLostCallbackMode,
                    Callback = deviceLostCallbackFuncPtrAndId.funcPtr,
                    Userdata1 = (void*)deviceLostCallbackFuncPtrAndId.id,
                    Userdata2 = null
                },
                UncapturedErrorCallbackInfo = {
                    Callback = uncapturedErrorCallbackFuncPtrAndId.funcPtr,
                    Userdata1 = (void*)uncapturedErrorCallbackFuncPtrAndId.id,
                    Userdata2 = null
                }
            };
            return RequestDeviceAsync(&deviceDescriptor);
        }
    }

    /// <param name="callback">The callback to call when the device is ready</param>
    /// <returns/>
    /// <inheritdoc cref="RequestDeviceAsync(DeviceDescriptorFFI*)"/>
    public readonly void RequestDeviceAsync(in DeviceDescriptor descriptor, Action<DeviceHandle> callback)
    {
        WebGpuAllocatorLogicBlock allocatorLogicBlock = default;
        const int stackAllocSize = 16 * 2 * sizeof(byte);
        byte* stackAllocPtr = stackalloc byte[stackAllocSize];

        using var allocator = WebGpuMarshallingMemory.GetAllocatorHandle(
            ref allocatorLogicBlock,
            stackAllocPtr,
            stackAllocSize
        );

        void* userData = null;
        try
        {
            var deviceDescriptorLabelUtf8Span = ToUtf8Span(descriptor.Label, allocator, addNullTerminator: false);
            var queueLabelUtf8Span = ToUtf8Span(descriptor.DefaultQueue.Label, allocator, addNullTerminator: false);

            fixed (byte* deviceDescriptorLabelPtr = deviceDescriptorLabelUtf8Span)
            fixed (byte* queueLabelPtr = queueLabelUtf8Span)
            fixed (FeatureName* requiredFeaturesPtr = descriptor.RequiredFeatures)
            fixed (Limits* requiredLimitsPtr = &Nullable.GetValueRefOrDefaultRef(in descriptor.RequiredLimits))
            {
                var deviceLostCallbackFuncPtrAndId = DeviceLostCallbackHandler.AddDeviceLostCallback(descriptor.DeviceLostCallback);
                var uncapturedErrorCallbackFuncPtrAndId = UncapturedErrorDelegateHandler.AddUncapturedErrorCallback(descriptor.UncapturedErrorCallback);

                DeviceDescriptorFFI deviceDescriptor = new()
                {
                    NextInChain = default,
                    Label = StringViewFFI.CreateExplicitlySized(deviceDescriptorLabelPtr, deviceDescriptorLabelUtf8Span.Length),
                    RequiredFeatures = requiredFeaturesPtr,
                    RequiredFeatureCount = (uint)descriptor.RequiredFeatures.Length,
                    RequiredLimits = descriptor.RequiredLimits.HasValue ? requiredLimitsPtr : null,
                    DefaultQueue = new()
                    {
                        Label = StringViewFFI.CreateExplicitlySized(queueLabelPtr, queueLabelUtf8Span.Length)
                    },
                    DeviceLostCallbackInfo = new()
                    {
                        Mode = descriptor.DeviceLostCallbackMode,
                        Callback = deviceLostCallbackFuncPtrAndId.funcPtr,
                        Userdata1 = (void*)deviceLostCallbackFuncPtrAndId.id,
                        Userdata2 = null
                    },
                    UncapturedErrorCallbackInfo = new()
                    {
                        Callback = uncapturedErrorCallbackFuncPtrAndId.funcPtr,
                        Userdata1 = (void*)uncapturedErrorCallbackFuncPtrAndId.id,
                        Userdata2 = null
                    }
                };

                userData = AllocUserData(callback);
                WebGPU_FFI.AdapterRequestDevice(
                   adapter: this,
                   descriptor: &deviceDescriptor,
                   callbackInfo: new()
                   {
                       Mode = CallbackMode.AllowSpontaneous,
                       Callback = &OnDeviceRequestEndedDelegate,
                       Userdata1 = userData,
                       Userdata2 = null
                   }
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

    /// <inheritdoc cref="RequestDeviceAsync(in DeviceDescriptor, Action{DeviceHandle})"/>
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
      RequestDeviceStatus status, DeviceHandle device, StringViewFFI message,
      void* userdata, void* _)
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
      RequestDeviceStatus status, DeviceHandle device, StringViewFFI message, void* userdata, void* _)
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
    private static readonly ConcurrentDictionary<nuint, Action<DeviceLostReason, ReadOnlySpan<byte>>> deviceLostCallbacks = new();

    public unsafe static FuncPtrAndId AddDeviceLostCallback(Action<DeviceLostReason, ReadOnlySpan<byte>>? callback)
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
    private static readonly ConcurrentDictionary<nuint, Action<ErrorType, ReadOnlySpan<byte>>> uncapturedErrorCallbacks = new();

    public unsafe static FuncPtrAndId AddUncapturedErrorCallback(Action<ErrorType, ReadOnlySpan<byte>>? callback)
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