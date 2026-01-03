using System.Buffers;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using WebGpuSharp.FFI;
using WebGpuSharp.Internal;
using WebGpuSharp.Marshalling;
using static WebGpuSharp.Marshalling.WebGPUMarshal;

namespace WebGpuSharp;


/// <inheritdoc cref="AdapterHandle"/>
public sealed class Adapter :
    WebGPUManagedHandleBase<AdapterHandle>,
    IFromHandleWithInstance<Adapter, AdapterHandle>
{
    private readonly Instance _instance;

    private Adapter(AdapterHandle handle, Instance instance) : base(handle)
    {
        _instance = instance;
    }

    /// <inheritdoc cref="AdapterHandle.GetInfo()"/>
    public AdapterInfo GetInfo() => Handle.GetInfo()!;

    /// <inheritdoc cref="AdapterHandle.GetLimits(out Limits)"/>
    public bool GetLimits(out Limits limits) => Handle.GetLimits(out limits);

    /// <inheritdoc cref="AdapterHandle.GetLimits()"/>
    public Limits? GetLimits() => Handle.GetLimits();

    /// <inheritdoc cref="AdapterHandle.GetFeatures()"/>
    public FeatureName[] GetFeatures() => Handle.GetFeatures();

    /// <inheritdoc cref="AdapterHandle.HasFeature(FeatureName)"/>
    public bool HasFeature(FeatureName feature) => Handle.HasFeature(feature);

    private unsafe Future RequestDevice(
        CallbackMode mode,
        Action<RequestDeviceStatus, Device?, ReadOnlySpan<byte>>? callback,
        TaskCompletionSource<Device>? tcs)
    {
        Debug.Assert(callback != null || tcs != null, "Either callback or tcs must be provided.");
        Debug.Assert(!(callback != null && tcs != null), "Only one of callback or tcs should be provided.");

        void* userdata1;
        void* userdata2 = AllocUserData(_instance);
        delegate* unmanaged[Cdecl]<RequestDeviceStatus, DeviceHandle, StringViewFFI, void*, void*, void> callbackFunction;
        if (callback != null)
        {
            userdata1 = AllocUserData(callback);
            callbackFunction = &RequestDeviceFunctions.DelegateCallback;
        }
        else
        {
            userdata1 = AllocUserData(tcs!);
            callbackFunction = &RequestDeviceFunctions.TaskCallback;
        }

        return WebGPU_FFI.AdapterRequestDevice(
             adapter: Handle,
             descriptor: null,
             callbackInfo: new()
             {
                 Mode = mode,
                 Callback = callbackFunction,
                 Userdata1 = userdata1,
                 Userdata2 = userdata2
             }
         );
    }

    private unsafe Future RequestDevice(
        in DeviceDescriptor descriptor,
        CallbackMode mode,
        Action<RequestDeviceStatus, Device?, ReadOnlySpan<byte>>? callback,
        TaskCompletionSource<Device>? tcs)
    {
        Debug.Assert(callback != null || tcs != null, "Either callback or tcs must be provided.");
        Debug.Assert(!(callback != null && tcs != null), "Only one of callback or tcs should be provided.");

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
            var deviceLostUserData = descriptor.DeviceLostCallback != null ? AllocUserData(descriptor.DeviceLostCallback) : null;
            var uncapturedErrorUserData = descriptor.UncapturedErrorCallback != null ? AllocUserData(descriptor.UncapturedErrorCallback) : null;

            DeviceDescriptorFFI deviceDescriptorFFI = new()
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
                    Callback = &DeviceLostFunctions.DelegateCallback,
                    Userdata1 = deviceLostUserData,
                    Userdata2 = null
                },
                UncapturedErrorCallbackInfo = {
                    Callback = &DeviceErrorFunctions.DelegateCallback,
                    Userdata1 = uncapturedErrorUserData,
                    Userdata2 = null
                }
            };

            void* userdata1;
            void* userdata2 = AllocUserData(_instance);
            delegate* unmanaged[Cdecl]<RequestDeviceStatus, DeviceHandle, StringViewFFI, void*, void*, void> callbackFunction;
            if (callback != null)
            {
                userdata1 = AllocUserData(callback);
                callbackFunction = &RequestDeviceFunctions.DelegateCallback;
            }
            else
            {
                userdata1 = AllocUserData(tcs!);
                callbackFunction = &RequestDeviceFunctions.TaskCallback;
            }

            return WebGPU_FFI.AdapterRequestDevice(
                 adapter: Handle,
                 descriptor: &deviceDescriptorFFI,
                 callbackInfo: new()
                 {
                     Mode = mode,
                     Callback = callbackFunction,
                     Userdata1 = userdata1,
                     Userdata2 = userdata2
                 }
             );
        }
    }

    /// <inheritdoc cref="RequestDeviceAsync(in DeviceDescriptor)"/>
    public Task<Device> RequestDeviceAsync()
    {
        var tcs = new TaskCompletionSource<Device>(TaskCreationOptions.RunContinuationsAsynchronously);
        var future = RequestDevice(
            CallbackMode.AllowProcessEvents,
            callback: null,
            tcs: tcs
        );
        _instance._eventHandler.EnqueueCpuFuture(future);
        return tcs.Task;
    }

    /// <param name="descriptor">Description of the  <see cref="Device"/> to request.</param>
    /// <returns>A task that resolve into a device.</returns>
    /// <inheritdoc cref="AdapterHandle.RequestDevice(DeviceDescriptorFFI*, RequestDeviceCallbackInfoFFI)"/>
    public Task<Device> RequestDeviceAsync(in DeviceDescriptor descriptor)
    {
        var tcs = new TaskCompletionSource<Device>(TaskCreationOptions.RunContinuationsAsynchronously);
        var future = RequestDevice(
            in descriptor,
            CallbackMode.AllowProcessEvents,
            callback: null,
            tcs: tcs
        );
        _instance._eventHandler.EnqueueCpuFuture(future);
        return tcs.Task;
    }

    /// <inheritdoc cref="RequestDevice(in DeviceDescriptor, Action{RequestDeviceStatus, Device?, ReadOnlySpan{byte}})"/>
    public void RequestDevice(Action<RequestDeviceStatus, Device?, ReadOnlySpan<byte>> callback)
    {
        var future = RequestDevice(
            CallbackMode.AllowProcessEvents,
            callback: callback,
            tcs: null
        );
        _instance._eventHandler.EnqueueCpuFuture(future);
    }

    /// <param name="callback">The callback to call when the device is ready</param>
    /// <returns/>
    /// <inheritdoc cref="AdapterHandle.RequestDevice(DeviceDescriptorFFI*)"/>
    public void RequestDevice(in DeviceDescriptor descriptor, Action<RequestDeviceStatus, Device?, ReadOnlySpan<byte>> callback)
    {
        var future = RequestDevice(
            in descriptor,
            CallbackMode.AllowProcessEvents,
            callback: callback,
            tcs: null
        );
        _instance._eventHandler.EnqueueCpuFuture(future);
    }

    /// <inheritdoc cref="AdapterHandle.RequestDevice(in DeviceDescriptor, Action{Device?})"/>
    public Device RequestDeviceSync(ulong timeoutNS = ulong.MaxValue)
    {
        Device? _result = null;
        Exception? _exception = null;

        void Callback(RequestDeviceStatus status, Device? device, ReadOnlySpan<byte> message)
        {
            if (status == RequestDeviceStatus.Success)
            {
                _result = device!;
            }
            else
            {
                _exception = new WebGPUException(Encoding.UTF8.GetString(message));
            }
        }

        var future = RequestDevice(
            CallbackMode.WaitAnyOnly,
            callback: Callback,
            tcs: null
        );

        var status = _instance.WaitAny(future, timeoutNS);
        if (status == WaitStatus.TimedOut)
        {
            throw new TimeoutException("RequestDeviceSync timed out.");
        }
        else if (status == WaitStatus.Error)
        {
            throw new WebGPUException("An error occurred while waiting for RequestDeviceSync to complete.");
        }
        else if (_exception != null)
        {
            throw _exception;
        }

        return _result!;
    }

    /// <inheritdoc cref="AdapterHandle.RequestDevice(DeviceDescriptorFFI*)"/>
    public Device RequestDeviceSync(in DeviceDescriptor descriptor, ulong timeoutNS = ulong.MaxValue)
    {
        Device? _result = null;
        Exception? _exception = null;

        void Callback(RequestDeviceStatus status, Device? device, ReadOnlySpan<byte> message)
        {
            if (status == RequestDeviceStatus.Success)
            {
                _result = device!;
            }
            else
            {
                _exception = new WebGPUException(Encoding.UTF8.GetString(message));
            }
        }

        var future = RequestDevice(
            in descriptor,
            CallbackMode.WaitAnyOnly,
            callback: Callback,
            tcs: null
        );

        var status = _instance.WaitAny(future, timeoutNS);
        if (status == WaitStatus.TimedOut)
        {
            throw new TimeoutException("RequestDeviceSync timed out.");
        }
        else if (status == WaitStatus.Error)
        {
            throw new WebGPUException("An error occurred while waiting for RequestDeviceSync to complete.");
        }
        else if (_exception != null)
        {
            throw _exception;
        }

        return _result!;
    }

    static Adapter? IFromHandleWithInstance<Adapter, AdapterHandle>.FromHandle(AdapterHandle handle, Instance instance)
    {
        if (AdapterHandle.IsNull(handle))
        {
            return null;
        }

        AdapterHandle.Reference(handle);
        return new(handle, instance);
    }

    static Instance IFromHandleWithInstance<Adapter, AdapterHandle>.GetOwnerInstance(Adapter instance)
    {
        return instance._instance;
    }
}


file static class RequestDeviceFunctions
{
    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe void DelegateCallback(
        RequestDeviceStatus status, DeviceHandle device, StringViewFFI message,
        void* userdata1, void* userdata2)
    {
        try
        {
            var callback = (Action<RequestDeviceStatus, Device?, ReadOnlySpan<byte>>?)ConsumeUserDataIntoObject(userdata1);
            var instance = (Instance?)ConsumeUserDataIntoObject(userdata2);
            if (callback == null || instance == null)
            {
                return;
            }


            callback(status, device.ToSafeHandle(instance)!, message.AsSpan());
        }
        catch
        {
        }
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe void TaskCallback(
        RequestDeviceStatus status, DeviceHandle device, StringViewFFI message,
        void* userdata1, void* userdata2)
    {
        try
        {
            var tcs = (TaskCompletionSource<Device>?)ConsumeUserDataIntoObject(userdata1);
            var instance = (Instance?)ConsumeUserDataIntoObject(userdata2);

            if (tcs == null || instance == null)
            {
                return;
            }
            switch (status)
            {
                case RequestDeviceStatus.Success:
                    tcs.SetResult(device.ToSafeHandle(instance)!);
                    break;
                case RequestDeviceStatus.Error:
                case RequestDeviceStatus.CallbackCancelled:
                default:
                    tcs.SetException(new WebGPUException(Encoding.UTF8.GetString(message.AsSpan())));
                    break;
            }
        }
        catch { }
    }
}

file static class DeviceLostFunctions
{
    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe void DelegateCallback(
      DeviceHandle* device, DeviceLostReason lostReason, StringViewFFI message, void* userdata, void* _)
    {
        try
        {
            var callback = (Action<DeviceHandle, DeviceLostReason, ReadOnlySpan<byte>>?)ConsumeUserDataIntoObject(userdata);

            if (callback == null)
            {
                return;
            }
            var length = message.Length;
            var arraySegment = new ArraySegment<byte>(ArrayPool<byte>.Shared.Rent((int)length), 0, (int)length);
            message.AsSpan().CopyTo(arraySegment);
            ThreadPool.UnsafeQueueUserWorkItem(
                state: (*device, lostReason, arraySegment, callback),
                callBack: static state =>
                {
                    var (device, lostReason, arraySegment, callback) = state;
                    try
                    {
                        callback(device, lostReason, arraySegment.AsSpan());
                    }
                    finally
                    {
                        ArrayPool<byte>.Shared.Return(arraySegment.Array!);
                    }
                },
                preferLocal: false
            );
        }
        catch { }
    }
}

file static class DeviceErrorFunctions
{
    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe void DelegateCallback(
      DeviceHandle* device, ErrorType type, StringViewFFI message, void* userdata, void* _)
    {
        try
        {
            //Keep userdata alive
            var callback = (Action<DeviceHandle, ErrorType, ReadOnlySpan<byte>>?)GetObjectFromUserData(userdata);

            if (callback == null)
            {
                return;
            }
            var length = message.Length;
            var arraySegment = new ArraySegment<byte>(ArrayPool<byte>.Shared.Rent((int)length), 0, (int)length);
            message.AsSpan().CopyTo(arraySegment);
            ThreadPool.UnsafeQueueUserWorkItem(
                state: (*device, type, arraySegment, callback),
                callBack: static state =>
                {
                    var (device, type, arraySegment, callback) = state;
                    try
                    {
                        callback(device, type, arraySegment.AsSpan());
                    }
                    finally
                    {
                        ArrayPool<byte>.Shared.Return(arraySegment.Array!);
                    }
                },
                preferLocal: false
            );
        }
        catch { }
    }
}