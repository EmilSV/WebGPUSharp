using System.Buffers;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using WebGpuSharp.FFI;
using WebGpuSharp.Internal;
using WebGPUSharp.Internal;
using static WebGpuSharp.Marshalling.WebGPUMarshal;

namespace WebGpuSharp;

///<inheritdoc cref="InstanceHandle"/>
public sealed class Instance :
    WebGPUManagedHandleBase<InstanceHandle>
{
    internal readonly WebGPUEventHandler _eventHandler;

    internal Instance(InstanceHandle handle, WebGPUEventHandler eventHandler) : base(handle)
    {
        _eventHandler = eventHandler;
    }

    /// <summary>
    /// Retrieves an Adapter which matches the given <see cref="RequestAdapterOptions" />.
    /// </summary>
    /// <param name="options">The options to use for the adapter</param>
    /// <returns> A task that will complete when the adapter is ready.</returns>
    public Task<Adapter> RequestAdapterAsync(in RequestAdapterOptions options)
    {
        unsafe
        {
            ToFFI(options, out RequestAdapterOptionsFFI optionFFI);
            TaskCompletionSource<Adapter> taskCompletionSource = new();
            var future = WebGPU_FFI.InstanceRequestAdapter(
              instance: Handle,
              options: &optionFFI,
              callbackInfo: new()
              {
                  Mode = CallbackMode.WaitAnyOnly,
                  Callback = &RequestAdapterCallbackFunctions.TaskCallback,
                  Userdata1 = AllocUserData(taskCompletionSource),
                  Userdata2 = AllocUserData(this)
              }
           );
            _eventHandler.EnqueueCpuFuture(future);
            return taskCompletionSource.Task;
        }
    }

    /// <summary>
    /// Retrieves an Adapter which matches the given <see cref="RequestAdapterOptions" />.
    /// </summary>
    /// <param name="callback">The callback to call when the adapter is ready</param>
    /// <param name="options">The options to use for the adapter</param>
    public void RequestAdapterAsync(in RequestAdapterOptions options, Action<RequestAdapterStatus, Adapter, ReadOnlySpan<byte>> callback)
    {
        unsafe
        {
            ToFFI(options, out RequestAdapterOptionsFFI optionFFI);
            var future = WebGPU_FFI.InstanceRequestAdapter(
              instance: Handle,
              options: &optionFFI,
              callbackInfo: new()
              {
                  Mode = CallbackMode.WaitAnyOnly,
                  Callback = &RequestAdapterCallbackFunctions.DelegateCallback,
                  Userdata1 = AllocUserData(callback),
                  Userdata2 = AllocUserData(this)
              }
           );
            _eventHandler.EnqueueCpuFuture(future);
        }
    }

    ///<inheritdoc cref="InstanceHandle.CreateSurface(SurfaceDescriptor)"/>
    public Surface? CreateSurface(SurfaceDescriptor descriptor)
    {
        return Handle.CreateSurface(descriptor).ToSafeHandle();
    }


    public WaitStatus WaitAny(Span<FutureWaitInfo> futures, ulong timeoutNS)
    {
        unsafe
        {
            fixed (FutureWaitInfo* pFutures = futures)
            {
                return Handle.WaitAny((uint)futures.Length, pFutures, timeoutNS);
            }
        }
    }

    public WaitStatus WaitAny(Future future, ulong timeoutNS)
    {
        unsafe
        {
            FutureWaitInfo info = new()
            {
                Future = future,
                Completed = false
            };
            return Handle.WaitAny(1, &info, timeoutNS);
        }
    }

    ~Instance()
    {
        _eventHandler.Dispose();
    }
}

file static class RequestAdapterCallbackFunctions
{
    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe void DelegateCallback(
        RequestAdapterStatus status, AdapterHandle adapter,
        StringViewFFI message, void* userdata1, void* userdata2)
    {
        try
        {
            var callback = (Action<RequestAdapterStatus, Adapter, ReadOnlySpan<byte>>?)ConsumeUserDataIntoObject(userdata1);
            if (callback == null)
            {
                return;
            }
            var length = message.Length;
            var instance = (Instance)ConsumeUserDataIntoObject(userdata2)!;
            callback(status, adapter.ToSafeHandle(instance)!, message.AsSpan());
        }
        catch
        {
            // Swallow exceptions to avoid crashing native code
        }
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe void TaskCallback(
        RequestAdapterStatus status, AdapterHandle adapter,
        StringViewFFI message, void* userdata1, void* userdata2)
    {
        try
        {
            var tsc = (TaskCompletionSource<Adapter>?)ConsumeUserDataIntoObject(userdata1);
            if (tsc == null)
            {
                return;
            }
            var length = message.Length;
            var instance = (Instance)ConsumeUserDataIntoObject(userdata2)!;

            switch (status)
            {
                case RequestAdapterStatus.Success:
                    tsc.SetResult(adapter.ToSafeHandle(instance)!);
                    break;
                case RequestAdapterStatus.CallbackCancelled:
                case RequestAdapterStatus.Unavailable:
                case RequestAdapterStatus.Error:
                default:
                    tsc.SetException(new WebGPUException(Encoding.UTF8.GetString(message.AsSpan())));
                    return;
            }
        }
        catch
        {
            // Swallow exceptions to avoid crashing native code
        }
    }
}