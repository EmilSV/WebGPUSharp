using System;
using System.Buffers;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using WebGpuSharp.FFI;
using WebGpuSharp.Internal;
using static WebGpuSharp.Buffer;

namespace WebGpuSharp;

public abstract class BufferBase : WebGPUHandleWrapperBase<BufferHandle>
{
    public delegate void ReadWriteContextDelegate<T>(Span<T> data)
        where T : unmanaged;

    public delegate TResult ReadWriteContextDelegate<TResult, T>(Span<T> data)
        where T : unmanaged;

    public delegate void ReadContextDelegate<T>(ReadOnlySpan<T> data)
        where T : unmanaged;

    public delegate TResult ReadContextDelegate<TResult, T>(ReadOnlySpan<T> data)
        where T : unmanaged;

    private readonly ReadWriteStateChangeLock readWriteStateChangeLock = new();

    public unsafe void MapAsync(
       MapMode mode,
       nuint offset,
       nuint size,
       Action<MapAsyncStatus> callback)
    {

        readWriteStateChangeLock.AddStateChangeLock();
        CallbackUserDataHandle bufferBaseHandle = default;
        CallbackUserDataHandle callbackHandle = default;
        try
        {
            bufferBaseHandle = CallbackUserDataHandle.Alloc(this);
            callbackHandle = CallbackUserDataHandle.Alloc(callback);

            Handle.MapAsync(
                mode: mode,
                offset: offset,
                size: size,
                callbackInfo: new()
                {
                    Callback = &BufferCallbackHandler.OnBufferMapCallback_Action,
                    Userdata1 = (void*)bufferBaseHandle,
                    Userdata2 = (void*)callbackHandle,
                    Mode = CallbackMode.AllowSpontaneous,
                }
            );
        }
        catch (Exception)
        {
            bufferBaseHandle.Dispose();
            callbackHandle.Dispose();
            readWriteStateChangeLock.RemoveStateChangeLock();
            throw;
        }
    }


    public void MapAsync(MapMode mode, nuint offset, Action<MapAsyncStatus> callback)
    {
        MapAsync(mode, offset, (nuint)GetSize(), callback);
    }

    public void MapAsync(MapMode mode, Action<MapAsyncStatus> callback)
    {
        MapAsync(mode, 0, (nuint)GetSize(), callback);
    }

    public unsafe Task<MapAsyncStatus> MapAsync(
        MapMode mode,
        nuint offset,
        nuint size)
    {
        readWriteStateChangeLock.AddStateChangeLock();
        TaskCompletionSource<MapAsyncStatus> taskCompletionSource = new();
        CallbackUserDataHandle bufferBaseHandle = default;
        CallbackUserDataHandle taskCompletionSourceHandle = default;
        try
        {
            bufferBaseHandle = CallbackUserDataHandle.Alloc(this);
            taskCompletionSourceHandle = CallbackUserDataHandle.Alloc(taskCompletionSource);

            Handle.MapAsync(
                mode: mode,
                offset: offset,
                size: size,
                callbackInfo: new()
                {
                    Callback = &BufferCallbackHandler.OnBufferMapCallback_TaskCompletionSource,
                    Userdata1 = (void*)bufferBaseHandle,
                    Userdata2 = (void*)taskCompletionSourceHandle,
                    Mode = CallbackMode.AllowSpontaneous,
                }
            );

            return taskCompletionSource.Task;
        }
        catch (Exception)
        {
            bufferBaseHandle.Dispose();
            taskCompletionSourceHandle.Dispose();
            readWriteStateChangeLock.RemoveStateChangeLock();
            throw;
        }
    }

    public Task<MapAsyncStatus> MapAsync(MapMode mode, nuint offset = 0)
    {
        return MapAsync(mode, offset, (nuint)GetSize());
    }

    public void Destroy()
    {
        readWriteStateChangeLock.AddStateChangeLock();
        try
        {
            Handle.Destroy();
        }
        finally
        {
            readWriteStateChangeLock.RemoveStateChangeLock();
        }
    }


    public unsafe void GetConstMappedRange<T>(nuint offset, nuint size, ReadContextDelegate<T> callback)
        where T : unmanaged
    {
        readWriteStateChangeLock.AddReadWriteLock();
        try
        {
            void* ptr = Handle.GetConstMappedRange(offset, size);
            if (ptr == null)
            {
                callback([]);
            }
            else
            {
                callback(new ReadOnlySpan<T>(ptr, (int)size));
            }
        }
        finally
        {
            readWriteStateChangeLock.RemoveReadWriteLock();
        }
    }

    public unsafe void GetConstMappedRange(nuint offset, nuint size, ReadContextDelegate<byte> callback)
    {
        GetConstMappedRange<byte>(offset, size, callback);
    }


    public BufferMapState GetMapState() => Handle.GetMapState();
    public ulong GetSize() => Handle.GetSize();
    public BufferUsage GetUsage() => Handle.GetUsage();

    public void Unmap()
    {
        readWriteStateChangeLock.AddStateChangeLock();
        try
        {
            Handle.Unmap();
            readWriteStateChangeLock.RemoveStateChangeLock();
        }
        finally
        {
            readWriteStateChangeLock.RemoveStateChangeLock();
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



    private static unsafe class BufferCallbackHandler
    {
        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
        public static void OnBufferMapCallback_TaskCompletionSource(
            MapAsyncStatus status, byte* _, void* userdata1, void* userdata2)
        {
            try
            {
                BufferBase? bufferBase = null;
                TaskCompletionSource<MapAsyncStatus>? taskCompletionSource = null;
                {
                    using CallbackUserDataHandle handle1 = (CallbackUserDataHandle)userdata1;
                    using CallbackUserDataHandle handle2 = (CallbackUserDataHandle)userdata2;
                    if (handle1.IsValid())
                    {
                        bufferBase = (BufferBase)handle1.GetObject()!;
                    }

                    if (handle2.IsValid())
                    {
                        taskCompletionSource = (TaskCompletionSource<MapAsyncStatus>)handle2.GetObject()!;
                    }
                }
                if (bufferBase == null || taskCompletionSource == null)
                {
                    Console.Error.WriteLine("Invalid buffer map callback");
                    return;
                }

                bufferBase.readWriteStateChangeLock.RemoveStateChangeLock();
                taskCompletionSource.SetResult(status);
            }
            catch (Exception)
            {
                try
                {
                    Console.Error.WriteLine($"Invalid buffer map callback{nameof(OnBufferMapCallback_TaskCompletionSource)}");
                }
                catch (Exception)
                {

                }
            }
        }

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
        public static void OnBufferMapCallback_Action(
            MapAsyncStatus status, byte* _, void* userdata1, void* userdata2)
        {
            try
            {
                BufferBase? bufferBase = null;
                Action<MapAsyncStatus>? callback = null;
                {
                    using CallbackUserDataHandle handle1 = (CallbackUserDataHandle)userdata1;
                    using CallbackUserDataHandle handle2 = (CallbackUserDataHandle)userdata2;
                    if (handle1.IsValid())
                    {
                        bufferBase = (BufferBase)handle1.GetObject()!;
                    }

                    if (handle2.IsValid())
                    {
                        callback = (Action<MapAsyncStatus>?)handle2.GetObject()!;
                    }
                }
                if (bufferBase == null || callback == null)
                {
                    Console.Error.WriteLine("Invalid buffer map callback");
                    return;
                }

                bufferBase.readWriteStateChangeLock.RemoveStateChangeLock();
                callback(status);
            }
            catch (Exception)
            {
                try
                {
                    Console.Error.WriteLine($"Invalid buffer map callback{nameof(OnBufferMapCallback_Action)}");
                }
                catch (Exception)
                {

                }
            }
        }
    }
}

