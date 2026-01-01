#pragma warning disable CS0162 // Unreachable code detected  

using System.Buffers;
using System.IO.Compression;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Unicode;
using WebGpuSharp.Internal;
using WebGpuSharp.Marshalling;
using static WebGpuSharp.Marshalling.WebGPUMarshal;
namespace WebGpuSharp.FFI;


public readonly unsafe partial struct InstanceHandle :
    IDisposable, IWebGpuHandle<InstanceHandle>
{
    /// <returns> A task that will complete when the adapter is ready.</returns>
    /// <inheritdoc cref="RequestAdapter(RequestAdapterOptionsFFI*, RequestAdapterCallbackInfoFFI)"/>
    public Task<AdapterHandle> RequestAdapter(in RequestAdapterOptionsFFI options)
    {
        unsafe
        {
            TaskCompletionSource<AdapterHandle> taskCompletionSource = new();
            fixed (RequestAdapterOptionsFFI* optionsPtr = &options)
            {
                WebGPU_FFI.InstanceRequestAdapter(
                  instance: this,
                  options: optionsPtr,
                  callbackInfo: new()
                  {
                      Mode = CallbackMode.AllowSpontaneous,
                      Callback = &RequestAdapterCallbackFunctions.TaskCallback,
                      Userdata1 = AllocUserData(taskCompletionSource),
                      Userdata2 = null
                  }
               );
            }

            return taskCompletionSource.Task;
        }
    }

    /// <returns> A task that will complete when the adapter is ready.</returns>
    /// <inheritdoc cref="RequestAdapter(RequestAdapterOptionsFFI*, RequestAdapterCallbackInfoFFI)"/>
    public Task<AdapterHandle> RequestAdapter(in RequestAdapterOptions options)
    {
        ToFFI(options, out RequestAdapterOptionsFFI optionFFI);
        return RequestAdapter(optionFFI);
    }

    /// <inheritdoc cref="RequestAdapter(RequestAdapterOptionsFFI*, RequestAdapterCallbackInfoFFI)"/>
    public void RequestAdapter(in RequestAdapterOptionsFFI options, Action<RequestAdapterStatus, AdapterHandle, ReadOnlySpan<byte>> callback)
    {
        unsafe
        {
            fixed (RequestAdapterOptionsFFI* optionsPtr = &options)
            {
                WebGPU_FFI.InstanceRequestAdapter(
                  instance: this,
                  options: optionsPtr,
                  callbackInfo: new()
                  {
                      Mode = CallbackMode.AllowSpontaneous,
                      Callback = &RequestAdapterCallbackFunctions.DelegateCallback,
                      Userdata1 = AllocUserData(callback),
                      Userdata2 = null
                  }
               );
            }
        }
    }

    /// <inheritdoc cref="RequestAdapter(RequestAdapterOptionsFFI*, RequestAdapterCallbackInfoFFI)"/>
    public void RequestAdapter(in RequestAdapterOptions options, Action<RequestAdapterStatus, AdapterHandle, ReadOnlySpan<byte>> callback)
    {
        ToFFI(options, out RequestAdapterOptionsFFI optionFFI);
        RequestAdapter(optionFFI, callback);
    }

    public void Dispose()
    {
        if (_ptr != UIntPtr.Zero)
        {
            WebGPU_FFI.InstanceRelease(this);
        }
    }

    /// <inheritdoc cref="CreateSurface(SurfaceDescriptorFFI*)"/>
    public SurfaceHandle CreateSurface(in SurfaceDescriptorFFI descriptor)
    {
        fixed (SurfaceDescriptorFFI* surfaceDescriptorPtr = &descriptor)
        {
            return WebGPU_FFI.InstanceCreateSurface(this, surfaceDescriptorPtr);
        }
    }

    /// <inheritdoc cref="CreateSurface(SurfaceDescriptorFFI*)"/>
    public SurfaceHandle CreateSurface(SurfaceDescriptor descriptor)
    {
        WebGpuAllocatorLogicBlock allocatorLogicBlock = default;
        const int stackAllocSize = 16 * sizeof(byte);
        byte* stackAllocPtr = stackalloc byte[stackAllocSize];

        using var allocator = WebGpuMarshallingMemory.GetAllocatorHandle(
            ref allocatorLogicBlock,
            stackAllocPtr,
            stackAllocSize
        );

        ref var next = ref descriptor._next;

        var labelUtf8Span = ToUtf8Span(descriptor.Label, allocator, addNullTerminator: true);

        fixed (byte* labelPtr = labelUtf8Span)
        fixed (ChainedStruct* nextPtr = &next)
        {
            SurfaceDescriptorFFI surfaceDescriptor = new()
            {
                NextInChain = nextPtr,
                Label = StringViewFFI.CreateExplicitlySized(labelPtr, labelUtf8Span.Length)
            };
            return WebGPU_FFI.InstanceCreateSurface(this, &surfaceDescriptor);
        }
    }

    public static ref nuint AsPointer(ref InstanceHandle handle)
    {
        return ref Unsafe.AsRef(in handle._ptr);
    }

    public static InstanceHandle GetNullHandle()
    {
        return Null;
    }

    public static bool IsNull(InstanceHandle handle)
    {
        return handle == Null;
    }

    public static InstanceHandle UnsafeFromPointer(nuint pointer)
    {
        return new InstanceHandle(pointer);
    }

    public static void Reference(InstanceHandle handle)
    {
        WebGPU_FFI.InstanceAddRef(handle);
    }

    public static void Release(InstanceHandle handle)
    {
        WebGPU_FFI.InstanceRelease(handle);
    }
}


file unsafe static class RequestAdapterCallbackFunctions
{
    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe void DelegateCallback(
        RequestAdapterStatus status, AdapterHandle adapter,
        StringViewFFI message, void* userdata1, void* _)
    {
        try
        {
            var callback = (Action<RequestAdapterStatus, AdapterHandle, ReadOnlySpan<byte>>?)ConsumeUserDataIntoObject(userdata1);
            if (callback == null)
            {
                return;
            }
            var length = message.Length;
            var arraySegment = new ArraySegment<byte>(ArrayPool<byte>.Shared.Rent((int)length), 0, (int)length);
            message.AsSpan().CopyTo(arraySegment);
            ThreadPool.UnsafeQueueUserWorkItem(
                state: (status, arraySegment, adapter, callback),
                callBack: static state =>
                {
                    var (status, arraySegment, adapter, callback) = state;
                    try
                    {
                        callback(status, adapter, arraySegment.AsSpan());
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
        }
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe void TaskCallback(
        RequestAdapterStatus status, AdapterHandle adapter,
        StringViewFFI message, void* userdata1, void* _)
    {
        try
        {
            var tsc = (TaskCompletionSource<AdapterHandle>?)ConsumeUserDataIntoObject(userdata1);
            if (tsc == null)
            {
                return;
            }
            var length = message.Length;
            var arraySegment = new ArraySegment<byte>(ArrayPool<byte>.Shared.Rent((int)length), 0, (int)length);
            message.AsSpan().CopyTo(arraySegment);
            ThreadPool.UnsafeQueueUserWorkItem(
                state: (status, arraySegment, adapter, tsc),
                callBack: static state =>
                {
                    var (status, arraySegment, adapter, tsc) = state;
                    try
                    {
                        switch (status)
                        {
                            case RequestAdapterStatus.Success:
                                tsc.SetResult(adapter);
                                break;
                            case RequestAdapterStatus.CallbackCancelled:
                            case RequestAdapterStatus.Unavailable:
                            case RequestAdapterStatus.Error:
                            default:
                                tsc.SetException(new WebGPUException(Encoding.UTF8.GetString(arraySegment.AsSpan())));
                                return;
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
        catch
        {
        }
    }
}