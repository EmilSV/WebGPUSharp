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

    public delegate void ReadWriteContextDelegateWithState<T, TState>(Span<T> data, ref TState state)
    where T : unmanaged;

    public delegate TResult ReadWriteContextDelegateWithState<TResult, T, TState>(Span<T> data, ref TState state)
        where T : unmanaged;

    public delegate void ReadContextDelegateWithState<T, TState>(ReadOnlySpan<T> data, ref TState state)
        where T : unmanaged;

    public delegate TResult ReadContextDelegateWithState<TResult, T, TState>(ReadOnlySpan<T> data, ref TState state)
        where T : unmanaged;

    public delegate void ReadWriteOperationCallback(BufferReadWriteContext status);
    public delegate T ReadWriteOperationCallback<T>(BufferReadWriteContext status);
    public delegate T ReadWriteOperationCallbackWithData<T>(BufferReadWriteContext status, ref T userdata);
    public delegate TReturnData ReadWriteOperationCallbackWithData<TReturnData, TUserdata>(BufferReadWriteContext status, ref TUserdata userdata);



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
        MapAsync(mode, offset, (nuint)GetSize() - offset, callback);
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
        return MapAsync(mode, offset, (nuint)GetSize() - offset);
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
            var span = ptr == null ? [] : new ReadOnlySpan<T>(ptr, (int)size);
            callback(span);
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



    public unsafe TResult GetConstMappedRange<TResult, T>(nuint offset, nuint size, ReadContextDelegate<TResult, T> callback)
        where T : unmanaged
    {
        readWriteStateChangeLock.AddReadWriteLock();
        try
        {
            void* ptr = Handle.GetConstMappedRange(offset, size);
            var span = ptr == null ? [] : new ReadOnlySpan<T>(ptr, (int)size);
            return callback(span);
        }
        finally
        {
            readWriteStateChangeLock.RemoveReadWriteLock();
        }
    }


    public unsafe void GetConstMappedRange<T, TState>(nuint offset, nuint size, ReadContextDelegateWithState<T, TState> callback, ref TState state)
        where T : unmanaged
    {
        readWriteStateChangeLock.AddReadWriteLock();
        try
        {
            void* ptr = Handle.GetConstMappedRange(offset, size);
            var span = ptr == null ? [] : new ReadOnlySpan<T>(ptr, (int)size);
            callback(span, ref state);
        }
        finally
        {
            readWriteStateChangeLock.RemoveReadWriteLock();
        }
    }

    public unsafe void GetConstMappedRange<TState>(nuint offset, nuint size, ReadContextDelegateWithState<byte, TState> callback, ref TState state)
    {
        GetConstMappedRange<byte, TState>(offset, size, callback, ref state);
    }

    public unsafe TResult GetConstMappedRange<TResult, T, TState>(nuint offset, nuint size, ReadContextDelegateWithState<TResult, T, TState> callback, ref TState state)
        where T : unmanaged
    {
        readWriteStateChangeLock.AddReadWriteLock();
        try
        {
            void* ptr = Handle.GetConstMappedRange(offset, size);
            var span = ptr == null ? [] : new ReadOnlySpan<T>(ptr, (int)size);
            return callback(span, ref state);
        }
        finally
        {
            readWriteStateChangeLock.RemoveReadWriteLock();
        }
    }

    public unsafe void GetMappedRange<T>(nuint offset, nuint size, ReadWriteContextDelegate<T> callback)
    where T : unmanaged
    {
        readWriteStateChangeLock.AddReadWriteLock();
        try
        {
            void* ptr = Handle.GetMappedRange(offset, size);
            var span = ptr == null ? [] : new Span<T>(ptr, (int)size);
            callback(span);
        }
        finally
        {
            readWriteStateChangeLock.RemoveReadWriteLock();
        }
    }

    public unsafe void GetMappedRange(nuint offset, nuint size, ReadWriteContextDelegate<byte> callback)
    {
        GetMappedRange<byte>(offset, size, callback);
    }



    public unsafe TResult GetMappedRange<TResult, T>(nuint offset, nuint size, ReadWriteContextDelegate<TResult, T> callback)
        where T : unmanaged
    {
        readWriteStateChangeLock.AddReadWriteLock();
        try
        {
            void* ptr = Handle.GetMappedRange(offset, size);
            var span = ptr == null ? [] : new Span<T>(ptr, (int)size);
            return callback(span);
        }
        finally
        {
            readWriteStateChangeLock.RemoveReadWriteLock();
        }
    }


    public unsafe void GetMappedRange<T, TState>(nuint offset, nuint size, ReadWriteContextDelegateWithState<T, TState> callback, ref TState state)
        where T : unmanaged
    {
        readWriteStateChangeLock.AddReadWriteLock();
        try
        {
            void* ptr = Handle.GetMappedRange(offset, size);
            var span = ptr == null ? [] : new Span<T>(ptr, (int)size);
            callback(span, ref state);
        }
        finally
        {
            readWriteStateChangeLock.RemoveReadWriteLock();
        }
    }

    public unsafe void GetMappedRange<TState>(nuint offset, nuint size, ReadWriteContextDelegateWithState<byte, TState> callback, ref TState state)
    {
        GetMappedRange<byte, TState>(offset, size, callback, ref state);
    }

    public unsafe TResult GetMappedRange<TResult, T, TState>(nuint offset, nuint size, ReadWriteContextDelegateWithState<TResult, T, TState> callback, ref TState state)
        where T : unmanaged
    {
        readWriteStateChangeLock.AddReadWriteLock();
        try
        {
            void* ptr = Handle.GetMappedRange(offset, size);
            var span = ptr == null ? [] : new Span<T>(ptr, (int)size);
            return callback(span, ref state);
        }
        finally
        {
            readWriteStateChangeLock.RemoveReadWriteLock();
        }
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

    public void SetLabel(WGPURefText label)
    {
        Handle.SetLabel(label);
    }

    public static void DoReadWriteOperation(
        ReadOnlySpan<BufferBase> buffers,
        ReadWriteOperationCallback callback
    )
    {
        try
        {
            foreach (BufferBase buffer in buffers)
            {
                buffer.readWriteStateChangeLock.AddReadWriteLock();
            }
            using BufferReadWriteContext context = new(buffers, ArrayPool<object>.Shared);
            callback(context);
        }
        finally
        {
            foreach (BufferBase buffer in buffers)
            {
                buffer.readWriteStateChangeLock.RemoveReadWriteLock();
            }
        }
    }

    public static T DoReadWriteOperation<T>(
        ReadOnlySpan<BufferBase> buffers,
        ReadWriteOperationCallback<T> callback
    )
    {

        int i = 0;
        try
        {
            for (; i < buffers.Length; i++)
            {
                buffers[i].readWriteStateChangeLock.AddReadWriteLock();
            }

            foreach (BufferBase buffer in buffers)
            {
                buffer.readWriteStateChangeLock.AddReadWriteLock();
            }
            using BufferReadWriteContext context = new(buffers, ArrayPool<object>.Shared);
            return callback(context);
        }
        finally
        {
            for (; i >= 0; i--)
            {
                buffers[i].readWriteStateChangeLock.RemoveReadWriteLock();
            }
        }
    }


    public static void DoReadWriteOperation<TUserdata>(
        ReadOnlySpan<BufferBase> buffers,
        ref TUserdata state,
        ReadWriteOperationCallbackWithData<TUserdata> callback
    )
    {
        int i = 0;
        try
        {
            for (; i < buffers.Length; i++)
            {
                buffers[i].readWriteStateChangeLock.AddReadWriteLock();
            }

            using BufferReadWriteContext context = new(buffers, ArrayPool<object>.Shared);
            callback(context, ref state);
        }
        finally
        {
            for (; i >= 0; i--)
            {
                buffers[i].readWriteStateChangeLock.RemoveReadWriteLock();
            }
        }
    }

    public static TReturnData DoReadWriteOperation<TReturnData, TUserdata>(
        ReadOnlySpan<BufferBase> buffers,
        ref TUserdata state,
        ReadWriteOperationCallbackWithData<TReturnData, TUserdata> callback
    )
    {
        int i = 0;
        try
        {
            for (; i < buffers.Length; i++)
            {
                buffers[i].readWriteStateChangeLock.AddReadWriteLock();
            }
            using BufferReadWriteContext context = new(buffers, ArrayPool<object>.Shared);
            return callback(context, ref state);
        }
        finally
        {
            for (; i >= 0; i--)
            {
                buffers[i].readWriteStateChangeLock.RemoveReadWriteLock();
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