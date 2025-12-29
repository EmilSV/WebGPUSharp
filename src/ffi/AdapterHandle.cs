using System.Buffers;
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
    private readonly unsafe Task<DeviceHandle> RequestDevice(DeviceDescriptorFFI* descriptor)
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
                   Callback = &RequestDeviceFunctions.TaskCallback,
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

    /// <inheritdoc cref="RequestDevice(DeviceDescriptorFFI*)"/>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly Task<DeviceHandle> RequestDevice() => RequestDevice((DeviceDescriptorFFI*)null);


    /// <inheritdoc cref="RequestDevice(DeviceDescriptorFFI*)"/>
    public readonly Task<DeviceHandle> RequestDevice(in DeviceDescriptor descriptor)
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
            var deviceLostUserData = descriptor.DeviceLostCallback != null ? AllocUserData(descriptor.DeviceLostCallback) : null;
            var uncapturedErrorUserData = descriptor.UncapturedErrorCallback != null ? AllocUserData(descriptor.UncapturedErrorCallback) : null;

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
            return RequestDevice(&deviceDescriptor);
        }
    }

    /// <param name="callback">The callback to call when the device is ready</param>
    /// <returns/>
    /// <inheritdoc cref="RequestDevice(DeviceDescriptorFFI*)"/>
    public readonly void RequestDevice(in DeviceDescriptor descriptor, Action<RequestDeviceStatus, DeviceHandle, ReadOnlySpan<byte>> callback)
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
                var deviceLostUserData = descriptor.DeviceLostCallback != null ? AllocUserData(descriptor.DeviceLostCallback) : null;
                var uncapturedErrorUserData = descriptor.UncapturedErrorCallback != null ? AllocUserData(descriptor.UncapturedErrorCallback) : null;

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
                        Callback = &DeviceLostFunctions.DelegateCallback,
                        Userdata1 = deviceLostUserData,
                        Userdata2 = null
                    },
                    UncapturedErrorCallbackInfo = new()
                    {
                        Callback = &DeviceErrorFunctions.DelegateCallback,
                        Userdata1 = uncapturedErrorUserData,
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
                        Callback = &RequestDeviceFunctions.DelegateCallback,
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
        }
    }

    /// <inheritdoc cref="RequestDeviceAsync(in DeviceDescriptor, Action{DeviceHandle})"/>
    public readonly void RequestDevice(in DeviceDescriptor descriptor, Action<RequestDeviceStatus, Device?, ReadOnlySpan<byte>> callback)
    {
        RequestDevice(descriptor, (RequestDeviceStatus status, DeviceHandle device, ReadOnlySpan<byte> message) =>
        {
            if (DeviceHandle.IsNull(device))
            {
                callback(status, null, message);
            }
            else
            {
                callback(status, ToSafeHandle<Device, DeviceHandle>(device), message);
            }
        });
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

    public Adapter? ToSafeHandle()
    {
        return ToSafeHandle<Adapter, AdapterHandle>(this);
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

file static class RequestDeviceFunctions
{
    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe void DelegateCallback(
        RequestDeviceStatus status, DeviceHandle device, StringViewFFI message,
        void* userdata, void* _)
    {
        try
        {
            var callback = (Action<RequestDeviceStatus, DeviceHandle, ReadOnlySpan<byte>>?)ConsumeUserDataIntoObject(userdata);

            if (callback == null)
            {
                return;
            }
            var length = message.Length;
            var arraySegment = new ArraySegment<byte>(ArrayPool<byte>.Shared.Rent((int)length), 0, (int)length);
            message.AsSpan().CopyTo(arraySegment);
            ThreadPool.UnsafeQueueUserWorkItem(
                state: (status, arraySegment, device, callback),
                callBack: static state =>
                {
                    var (status, arraySegment, device, callback) = state;
                    try
                    {
                        callback(status, device, arraySegment.AsSpan());
                    }
                    finally
                    {
                        ArrayPool<byte>.Shared.Return(arraySegment.Array!);
                    }
                },
                preferLocal: false
            );
        }
        catch
        {
            device.Dispose();
        }
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe void TaskCallback(
        RequestDeviceStatus status, DeviceHandle device, StringViewFFI message,
        void* userdata, void* _)
    {
        try
        {
            var tcs = (TaskCompletionSource<DeviceHandle>?)ConsumeUserDataIntoObject(userdata);

            if (tcs == null)
            {
                return;
            }
            int length = (int)message.Length;
            var arraySegment = new ArraySegment<byte>(ArrayPool<byte>.Shared.Rent(length), 0, length);
            message.AsSpan().CopyTo(arraySegment);
            ThreadPool.UnsafeQueueUserWorkItem(
                state: (status, arraySegment, device, tcs),
                callBack: static state =>
                {
                    var (status, arraySegment, device, tcs) = state;
                    try
                    {
                        switch (status)
                        {
                            case RequestDeviceStatus.Success:
                                tcs.SetResult(device);
                                break;
                            case RequestDeviceStatus.Error:
                            case RequestDeviceStatus.CallbackCancelled:
                            default:
                                tcs.SetException(new WebGPUException(Encoding.UTF8.GetString(arraySegment.AsSpan())));
                                break;
                        }
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