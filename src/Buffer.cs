using System.Buffers;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using WebGpuSharp.FFI;
using WebGpuSharp.Internal;

namespace WebGpuSharp;


public sealed class Buffer : BaseWebGpuSafeHandle<Buffer, BufferHandle>
{
    [StructLayout(LayoutKind.Explicit)]
    internal struct ReadWriteStateChange(ulong value)
    {
        [FieldOffset(0)]
        public ulong value = value;

        [FieldOffset(0)]
        public uint readWrite;

        [FieldOffset(4)]
        public uint stateChange;
    }

    private class BufferAndCallback(Buffer buffer, Action<BufferMapAsyncStatus> callback)
    {
        public readonly Buffer Buffer = buffer;
        public readonly Action<BufferMapAsyncStatus> Callback = callback;
    }

    public delegate void ReadWriteOperationCallback(BufferReadWriteContext status);
    public delegate T ReadWriteOperationCallback<T>(BufferReadWriteContext status);
    public delegate T ReadWriteOperationCallbackWithData<T>(BufferReadWriteContext status, ref T userdata);
    public delegate TReturnData ReadWriteOperationCallbackWithData<TUserdata, TReturnData>(BufferReadWriteContext status, ref TUserdata userdata);

    internal ReadWriteStateChange readWriteStateChange = default;

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

    public unsafe void MapAsync(
        MapMode mode,
        nuint offset,
        nuint size,
        Action<BufferMapAsyncStatus> callback)
    {
        CallbackUserDataHandle handle = default;
        try
        {
            UnsafeBufferLock.AddStateChangeLock(this);
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
        catch (Exception)
        {
            if (handle.IsValid())
            {
                handle.Dispose();
            }
            UnsafeBufferLock.RemoveStateChangeLock(this);
            throw;
        }
    }

    public async Task<BufferMapAsyncStatus> MapAsync(
        MapMode mode,
        nuint offset,
        nuint size)
    {
        try
        {
            UnsafeBufferLock.AddStateChangeLock(this);
            return await _handle.MapAsync(mode, offset, size);
        }
        finally
        {
            UnsafeBufferLock.RemoveStateChangeLock(this);
        }
    }

    public void Destroy()
    {
        try
        {
            UnsafeBufferLock.AddStateChangeLock(this);
            _handle.Destroy();
        }
        finally
        {
            UnsafeBufferLock.RemoveStateChangeLock(this);
        }
    }

    public BufferMapState GetMapState() => _handle.GetMapState();
    public ulong GetSize() => _handle.GetSize();
    public BufferUsage GetUsage() => _handle.GetUsage();

    public void Unmap()
    {
        try
        {
            UnsafeBufferLock.AddStateChangeLock(this);
            _handle.Unmap();
        }
        finally
        {
            UnsafeBufferLock.RemoveStateChangeLock(this);
        }
    }


    public static void DoReadWriteOperation(
        ReadOnlySpan<Buffer> buffers,
        ReadWriteOperationCallback callback
    )
    {
        try
        {
            foreach (Buffer buffer in buffers)
            {
                UnsafeBufferLock.AddReadWriteLock(buffer);
            }
            using BufferReadWriteContext context = new(buffers, ArrayPool<object>.Shared);
            callback(context);
        }
        finally
        {
            foreach (Buffer buffer in buffers)
            {
                UnsafeBufferLock.RemoveReadWriteLock(buffer);
            }
        }
    }

    public static T DoReadWriteOperation<T>(
        ReadOnlySpan<Buffer> buffers,
        ReadWriteOperationCallback<T> callback
    )
    {
        try
        {
            foreach (Buffer buffer in buffers)
            {
                UnsafeBufferLock.AddReadWriteLock(buffer);
            }
            using BufferReadWriteContext context = new(buffers, ArrayPool<object>.Shared);
            return callback(context);
        }
        finally
        {
            foreach (Buffer buffer in buffers)
            {
                UnsafeBufferLock.RemoveReadWriteLock(buffer);
            }
        }
    }


    public static void DoReadWriteOperation<TUserdata>(
        ReadOnlySpan<Buffer> buffers,
        ref TUserdata state,
        ReadWriteOperationCallbackWithData<TUserdata> callback
    )
    {
        try
        {
            foreach (Buffer buffer in buffers)
            {
                UnsafeBufferLock.AddReadWriteLock(buffer);
            }
            using BufferReadWriteContext context = new(buffers, ArrayPool<object>.Shared);
            callback(context, ref state);
        }
        finally
        {
            foreach (Buffer buffer in buffers)
            {
                UnsafeBufferLock.RemoveReadWriteLock(buffer);
            }
        }
    }

    public static TReturnData DoReadWriteOperation<TUserdata, TReturnData>(
        ReadOnlySpan<Buffer> buffers,
        ref TUserdata state,
        ReadWriteOperationCallbackWithData<TUserdata, TReturnData> callback
    )
    {
        try
        {
            foreach (Buffer buffer in buffers)
            {
                UnsafeBufferLock.AddReadWriteLock(buffer);
            }
            using BufferReadWriteContext context = new(buffers, ArrayPool<object>.Shared);
            return callback(context, ref state);
        }
        finally
        {
            foreach (Buffer buffer in buffers)
            {
                UnsafeBufferLock.RemoveReadWriteLock(buffer);
            }
        }
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    public unsafe static void OnBufferMapCallback_Action(BufferMapAsyncStatus status, void* userdata)
    {
        CallbackUserDataHandle handle = (CallbackUserDataHandle)userdata;
        try
        {
            BufferAndCallback bufferAndCallback = (BufferAndCallback)handle.GetObject()!;
            UnsafeBufferLock.RemoveStateChangeLock(bufferAndCallback.Buffer);
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
        try
        {
            TaskCompletionSource<BufferMapAsyncStatus> taskCompletionSource = (TaskCompletionSource<BufferMapAsyncStatus>)handle.GetObject()!;
            taskCompletionSource.SetResult(status);
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