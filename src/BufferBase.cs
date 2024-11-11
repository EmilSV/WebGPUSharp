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

    protected abstract ReadWriteStateChangeHandleLock ReadWriteStateChangeLock { get; }


    public unsafe void MapAsync(
       MapMode mode,
       nuint offset,
       nuint size,
       Action<MapAsyncStatus> callback)
    {

        ReadWriteStateChangeLock.AddStateChangeLock();
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
            ReadWriteStateChangeLock.RemoveStateChangeLock();
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
        ReadWriteStateChangeLock.AddStateChangeLock();
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
            ReadWriteStateChangeLock.RemoveStateChangeLock();
            throw;
        }
    }

    public Task<MapAsyncStatus> MapAsync(MapMode mode, nuint offset = 0)
    {
        return MapAsync(mode, offset, (nuint)GetSize() - offset);
    }

    public void Destroy()
    {
        ReadWriteStateChangeLock.AddStateChangeLock();
        try
        {
            Handle.Destroy();
        }
        finally
        {
            ReadWriteStateChangeLock.RemoveStateChangeLock();
        }
    }


    public unsafe void GetConstMappedRange<T>(nuint offset, nuint size, ReadContextDelegate<T> callback)
        where T : unmanaged
    {
        ReadWriteStateChangeLock.AddReadWriteLock();
        try
        {
            void* ptr = Handle.GetConstMappedRange(offset, size * (nuint)sizeof(T));
            var span = ptr == null ? [] : new ReadOnlySpan<T>(ptr, (int)size);
            callback(span);
        }
        finally
        {
            ReadWriteStateChangeLock.RemoveReadWriteLock();
        }
    }

    public unsafe void GetConstMappedRange(nuint offset, nuint size, ReadContextDelegate<byte> callback)
    {
        GetConstMappedRange<byte>(offset, size, callback);
    }



    public unsafe TResult GetConstMappedRange<TResult, T>(nuint offset, nuint size, ReadContextDelegate<TResult, T> callback)
        where T : unmanaged
    {
        ReadWriteStateChangeLock.AddReadWriteLock();
        try
        {
            void* ptr = Handle.GetConstMappedRange(offset, size * (nuint)sizeof(T));
            var span = ptr == null ? [] : new ReadOnlySpan<T>(ptr, (int)size);
            return callback(span);
        }
        finally
        {
            ReadWriteStateChangeLock.RemoveReadWriteLock();
        }
    }


    public unsafe void GetConstMappedRange<T, TState>(nuint offset, nuint size, ReadContextDelegateWithState<T, TState> callback, ref TState state)
        where T : unmanaged
    {
        ReadWriteStateChangeLock.AddReadWriteLock();
        try
        {
            void* ptr = Handle.GetConstMappedRange(offset, size * (nuint)sizeof(T));
            var span = ptr == null ? [] : new ReadOnlySpan<T>(ptr, (int)size);
            callback(span, ref state);
        }
        finally
        {
            ReadWriteStateChangeLock.RemoveReadWriteLock();
        }
    }

    public unsafe void GetConstMappedRange<TState>(nuint offset, nuint size, ReadContextDelegateWithState<byte, TState> callback, ref TState state)
    {
        GetConstMappedRange<byte, TState>(offset, size, callback, ref state);
    }

    public unsafe TResult GetConstMappedRange<TResult, T, TState>(nuint offset, nuint size, ReadContextDelegateWithState<TResult, T, TState> callback, ref TState state)
        where T : unmanaged
    {
        ReadWriteStateChangeLock.AddReadWriteLock();
        try
        {
            void* ptr = Handle.GetConstMappedRange(offset, size * (nuint)sizeof(T));
            var span = ptr == null ? [] : new ReadOnlySpan<T>(ptr, (int)size);
            return callback(span, ref state);
        }
        finally
        {
            ReadWriteStateChangeLock.RemoveReadWriteLock();
        }
    }

    public unsafe void GetMappedRange<T>(nuint offset, nuint size, ReadWriteContextDelegate<T> callback)
    where T : unmanaged
    {
        ReadWriteStateChangeLock.AddReadWriteLock();
        try
        {
            void* ptr = Handle.GetMappedRange(offset, size * (nuint)sizeof(T));
            var span = ptr == null ? [] : new Span<T>(ptr, (int)size);
            callback(span);
        }
        finally
        {
            ReadWriteStateChangeLock.RemoveReadWriteLock();
        }
    }

    public unsafe void GetMappedRange(nuint offset, nuint size, ReadWriteContextDelegate<byte> callback)
    {
        GetMappedRange<byte>(offset, size, callback);
    }



    public unsafe TResult GetMappedRange<TResult, T>(nuint offset, nuint size, ReadWriteContextDelegate<TResult, T> callback)
        where T : unmanaged
    {
        ReadWriteStateChangeLock.AddReadWriteLock();
        try
        {
            void* ptr = Handle.GetMappedRange(offset, size * (nuint)sizeof(T));
            var span = ptr == null ? [] : new Span<T>(ptr, (int)size);
            return callback(span);
        }
        finally
        {
            ReadWriteStateChangeLock.RemoveReadWriteLock();
        }
    }

    public unsafe void GetMappedRange<T>(ReadWriteContextDelegate<T> callback)
        where T : unmanaged
    {
        GetMappedRange<T>(0, (nuint)(GetSize() / (ulong)sizeof(T)), callback);
    }

    public void GetMappedRange(ReadWriteContextDelegate<byte> callback)
    {
        GetMappedRange<byte>(callback);
    }

    public unsafe void GetMappedRange<T, TState>(nuint offset, nuint size, ReadWriteContextDelegateWithState<T, TState> callback, ref TState state)
        where T : unmanaged
    {
        ReadWriteStateChangeLock.AddReadWriteLock();
        try
        {
            void* ptr = Handle.GetMappedRange(offset, size * (nuint)sizeof(T));
            var span = ptr == null ? [] : new Span<T>(ptr, (int)size);
            callback(span, ref state);
        }
        finally
        {
            ReadWriteStateChangeLock.RemoveReadWriteLock();
        }
    }

    public unsafe void GetMappedRange<TState>(nuint offset, nuint size, ReadWriteContextDelegateWithState<byte, TState> callback, ref TState state)
    {
        GetMappedRange<byte, TState>(offset, size, callback, ref state);
    }

    public unsafe TResult GetMappedRange<TResult, T, TState>(nuint offset, nuint size, ReadWriteContextDelegateWithState<TResult, T, TState> callback, ref TState state)
        where T : unmanaged
    {
        ReadWriteStateChangeLock.AddReadWriteLock();
        try
        {
            void* ptr = Handle.GetMappedRange(offset, size * (nuint)sizeof(T));
            var span = ptr == null ? [] : new Span<T>(ptr, (int)size);
            return callback(span, ref state);
        }
        finally
        {
            ReadWriteStateChangeLock.RemoveReadWriteLock();
        }
    }

    public BufferMapState GetMapState() => Handle.GetMapState();
    public ulong GetSize() => Handle.GetSize();
    public BufferUsage GetUsage() => Handle.GetUsage();

    public void Unmap()
    {
        ReadWriteStateChangeLock.AddStateChangeLock();
        try
        {
            Handle.Unmap();
            ReadWriteStateChangeLock.RemoveStateChangeLock();
        }
        finally
        {
            ReadWriteStateChangeLock.RemoveStateChangeLock();
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
                buffer.ReadWriteStateChangeLock.AddReadWriteLock();
            }
            using BufferReadWriteContext context = new(buffers, ArrayPool<object>.Shared);
            callback(context);
        }
        finally
        {
            foreach (BufferBase buffer in buffers)
            {
                buffer.ReadWriteStateChangeLock.RemoveReadWriteLock();
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
                buffers[i].ReadWriteStateChangeLock.AddReadWriteLock();
            }

            foreach (BufferBase buffer in buffers)
            {
                buffer.ReadWriteStateChangeLock.AddReadWriteLock();
            }
            using BufferReadWriteContext context = new(buffers, ArrayPool<object>.Shared);
            return callback(context);
        }
        finally
        {
            do
            {
                i--;
                buffers[i].ReadWriteStateChangeLock.RemoveReadWriteLock();
            } while (i != 0);
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
                buffers[i].ReadWriteStateChangeLock.AddReadWriteLock();
            }

            using BufferReadWriteContext context = new(buffers, ArrayPool<object>.Shared);
            callback(context, ref state);
        }
        finally
        {
            do
            {
                i--;
                buffers[i].ReadWriteStateChangeLock.RemoveReadWriteLock();
            } while (i != 0);
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
                buffers[i].ReadWriteStateChangeLock.AddReadWriteLock();
            }
            using BufferReadWriteContext context = new(buffers, ArrayPool<object>.Shared);
            return callback(context, ref state);
        }
        finally
        {
            do
            {
                i--;
                buffers[i].ReadWriteStateChangeLock.RemoveReadWriteLock();
            } while (i != 0);
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

                bufferBase.ReadWriteStateChangeLock.RemoveStateChangeLock();
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

                bufferBase.ReadWriteStateChangeLock.RemoveStateChangeLock();
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