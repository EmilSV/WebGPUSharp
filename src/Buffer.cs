using System.Buffers;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using WebGpuSharp.FFI;
using WebGpuSharp.Internal;

namespace WebGpuSharp;


public unsafe sealed class Buffer : BaseWebGpuSafeHandle<Buffer, BufferHandle>
{
    private class BufferAndCallback(Buffer buffer, Action<BufferMapAsyncStatus> callback)
    {
        public readonly Buffer Buffer = buffer;
        public readonly Action<BufferMapAsyncStatus> Callback = callback;
    }

    private class BufferAndTaskCompletionSource(Buffer buffer, TaskCompletionSource<BufferMapAsyncStatus> taskCompletionSource)
    {
        public readonly Buffer Buffer = buffer;
        public readonly TaskCompletionSource<BufferMapAsyncStatus> TaskCompletionSource = taskCompletionSource;
    }

    public delegate void ReadWriteOperationCallback(BufferReadWriteContext status);
    public delegate T ReadWriteOperationCallback<T>(BufferReadWriteContext status);
    public delegate T ReadWriteOperationCallbackWithData<T>(BufferReadWriteContext status, ref T userdata);
    public delegate TReturnData ReadWriteOperationCallbackWithData<TUserdata, TReturnData>(BufferReadWriteContext status, ref TUserdata userdata);


    private long readWriteState = 0;

    private Buffer(BufferHandle handle) : base(handle)
    {
    }

    internal static Buffer? FromHandle(BufferHandle handle, bool isOwnedHandle)
    {
        var newBuffer = WebGpuSafeHandleCache.GetOrCreate(handle, static (handle) => new Buffer(handle));
        if (isOwnedHandle)
        {
            newBuffer?.AddReference(false);
        }
        return newBuffer;
    }

    public void MapAsync(
        MapMode mode,
        nuint offset,
        nuint size,
        Action<BufferMapAsyncStatus> callback)
    {
        CallbackUserDataHandle handle = default;
        try
        {
            BufferAndCallback bufferAndCallback = new(this, callback);
            handle = CallbackUserDataHandle.Alloc(bufferAndCallback);
            WebGPU_FFI.BufferMapAsync(
                buffer: WebGPUMarshal.GetBorrowHandle(this),
                mode: mode,
                offset: offset,
                size: size,
                callback: &OnBufferMapCallback_Action,
                userdata: (void*)handle
            );
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine(ex);
            if (handle.IsValid())
            {
                handle.Dispose();
            }
        }
    }

    public Task<BufferMapAsyncStatus> MapAsync(
        MapMode mode,
        nuint offset,
        nuint size)
    {
        TaskCompletionSource<BufferMapAsyncStatus> taskCompletionSource;
        CallbackUserDataHandle handle = default;
        try
        {
            taskCompletionSource = new TaskCompletionSource<BufferMapAsyncStatus>();
            BufferAndTaskCompletionSource bufferAndTaskCompletionSource = new(this, taskCompletionSource);
            handle = CallbackUserDataHandle.Alloc(bufferAndTaskCompletionSource);
            WebGPU_FFI.BufferMapAsync(
                buffer: WebGPUMarshal.GetBorrowHandle(this),
                mode: mode,
                offset: offset,
                size: size,
                callback: &OnBufferMapCallback_TaskCompletionSource,
                userdata: (void*)handle
            );
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine(ex);
            if (handle.IsValid())
            {
                handle.Dispose();
            }
            return Task.FromResult(BufferMapAsyncStatus.Unknown);
        }
        return taskCompletionSource.Task;
    }

    public void Destroy() => _handle.Destroy();
    public BufferMapState GetMapState() => _handle.GetMapState();
    public ulong GetSize() => _handle.GetSize();
    public BufferUsage GetUsage() => _handle.GetUsage();
    public void Unmap() => _handle.Unmap();

    public static void DoReadWriteOperation(
        ReadOnlySpan<Buffer> buffers,
        ReadWriteOperationCallback callback
    )
    {
        using BufferReadWriteContext context = new(buffers, ArrayPool<object>.Shared);
        callback(context);
    }

    public static T DoReadWriteOperation<T>(
        ReadOnlySpan<Buffer> buffers,
        ReadWriteOperationCallback<T> callback
    )
    {
        using BufferReadWriteContext context = new(buffers, ArrayPool<object>.Shared);
        return callback(context);
    }


    public static void DoReadWriteOperation<TUserdata>(
        ReadOnlySpan<Buffer> buffers,
        ref TUserdata state,
        ReadWriteOperationCallbackWithData<TUserdata> callback
    )
    {
        using BufferReadWriteContext context = new(buffers, ArrayPool<object>.Shared);
        callback(context, ref state);
    }

    public static TReturnData DoReadWriteOperation<TUserdata, TReturnData>(
        ReadOnlySpan<Buffer> buffers,
        ref TUserdata state,
        ReadWriteOperationCallbackWithData<TUserdata, TReturnData> callback
    )
    {
        using BufferReadWriteContext context = new(buffers, ArrayPool<object>.Shared);
        return callback(context, ref state);
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    public unsafe static void OnBufferMapCallback_Action(BufferMapAsyncStatus status, void* userdata)
    {
        CallbackUserDataHandle handle = (CallbackUserDataHandle)userdata;
        BufferAndCallback? bufferAndCallback;

        try
        {
            bufferAndCallback = (BufferAndCallback)handle.GetObject()!;
            bufferAndCallback.Callback(status);
        }
        catch (Exception)
        {

        }
        finally
        {
            if (handle.IsValid())
            {
                handle.Dispose();
            }
        }
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    public unsafe static void OnBufferMapCallback_TaskCompletionSource(
        BufferMapAsyncStatus status, void* userdata)
    {
        CallbackUserDataHandle handle = (CallbackUserDataHandle)userdata;
        BufferAndTaskCompletionSource? bufferAndTaskCompletionSource;

        try
        {
            bufferAndTaskCompletionSource = (BufferAndTaskCompletionSource)handle.GetObject()!;
            bufferAndTaskCompletionSource.TaskCompletionSource.SetResult(status);
        }
        catch (Exception)
        {

        }
        finally
        {
            if (handle.IsValid())
            {
                handle.Dispose();
            }
        }
    }
}