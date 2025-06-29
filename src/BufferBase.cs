using System;
using System.Buffers;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Transactions;
using WebGpuSharp.FFI;
using WebGpuSharp.Internal;
using static WebGpuSharp.FFI.WebGPUMarshal;

namespace WebGpuSharp;

/// <inheritdoc cref="BufferHandle"/>
public abstract class BufferBase : WebGPUHandleWrapperBase<BufferHandle>
{
    protected abstract ReadWriteStateChangeHandleLock ReadWriteStateChangeLock { get; }


    /// <inheritdoc cref="BufferHandle.MapAsync(MapMode, nuint, nuint, BufferMapCallbackInfoFFI)"/> 
    public unsafe void MapAsync(
       MapMode mode,
       nuint offset,
       nuint size,
       Action<MapAsyncStatus> callbackInfo)
    {
        ReadWriteStateChangeLock.AddStateChangeLock();
        void* bufferBaseUserData = null;
        void* callbackUserData = null;
        try
        {
            bufferBaseUserData = AllocUserData(this);
            callbackUserData = AllocUserData(callbackInfo);

            Handle.MapAsync(
                mode: mode,
                offset: offset,
                size: size,
                callbackInfo: new()
                {
                    Callback = &BufferCallbackHandler.OnBufferMapCallback_Action,
                    Userdata1 = bufferBaseUserData,
                    Userdata2 = callbackUserData,
                    Mode = CallbackMode.AllowSpontaneous,
                }
            );
        }
        catch (Exception)
        {
            FreeUserData(bufferBaseUserData);
            FreeUserData(callbackUserData);
            ReadWriteStateChangeLock.RemoveStateChangeLock();
            throw;
        }
    }


    /// <inheritdoc cref="BufferHandle.MapAsync(MapMode, nuint, nuint, BufferMapCallbackInfoFFI)"/> 
    public void MapAsync(MapMode mode, nuint offset, Action<MapAsyncStatus> callbackInfo)
    {
        MapAsync(mode, offset, (nuint)GetSize() - offset, callbackInfo);
    }

    /// <inheritdoc cref="BufferHandle.MapAsync(MapMode, nuint, nuint, BufferMapCallbackInfoFFI)"/> 
    public void MapAsync(MapMode mode, Action<MapAsyncStatus> callbackInfo)
    {
        MapAsync(mode, 0, (nuint)GetSize(), callbackInfo);
    }

    /// <inheritdoc cref="BufferHandle.MapAsync(MapMode, nuint, nuint, BufferMapCallbackInfoFFI)"/>
    public unsafe Task<MapAsyncStatus> MapAsync(
        MapMode mode,
        nuint offset,
        nuint size)
    {
        ReadWriteStateChangeLock.AddStateChangeLock();
        TaskCompletionSource<MapAsyncStatus> taskCompletionSource = new();
        void* bufferBaseHandle = null;
        void* taskCompletionSourceHandle = null;
        try
        {
            bufferBaseHandle = AllocUserData(this);
            taskCompletionSourceHandle = AllocUserData(taskCompletionSource);

            Handle.MapAsync(
                mode: mode,
                offset: offset,
                size: size,
                callbackInfo: new()
                {
                    Callback = &BufferCallbackHandler.OnBufferMapCallback_TaskCompletionSource,
                    Userdata1 = bufferBaseHandle,
                    Userdata2 = taskCompletionSourceHandle,
                    Mode = CallbackMode.AllowSpontaneous,
                }
            );

            return taskCompletionSource.Task;
        }
        catch (Exception)
        {
            FreeUserData(bufferBaseHandle);
            FreeUserData(taskCompletionSourceHandle);
            ReadWriteStateChangeLock.RemoveStateChangeLock();
            throw;
        }
    }

    /// <inheritdoc cref="BufferHandle.MapAsync(MapMode, nuint, nuint, BufferMapCallbackInfoFFI)"/>
    public Task<MapAsyncStatus> MapAsync(MapMode mode, nuint offset = 0)
    {
        return MapAsync(mode, offset, (nuint)GetSize() - offset);
    }

    /// <inheritdoc cref="BufferHandle.Destroy"/>
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


    /// <param name="callback">The callback to be called with the mapped range.</param>
    /// <inheritdoc cref="BufferHandle.GetConstMappedRange(nuint, nuint)"/>
    public unsafe void GetConstMappedRange<T>(nuint offset, nuint size, Action<ReadOnlySpan<T>> callback)
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

    /// <inheritdoc cref="GetConstMappedRange{T}(nuint, nuint, Action{ReadOnlySpan{T}})"/>
    public unsafe void GetConstMappedRange(nuint offset, nuint size, Action<ReadOnlySpan<byte>> callback)
    {
        GetConstMappedRange<byte>(offset, size, callback);
    }



    /// <inheritdoc cref="GetConstMappedRange{T}(nuint, nuint, Action{ReadOnlySpan{T}})"/>
    public unsafe TResult GetConstMappedRange<TResult, T>(nuint offset, nuint size, Func<ReadOnlySpan<T>, TResult> callback)
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

    /// <param name="state"> The state to be passed to the callback.</param>
    /// <inheritdoc cref="GetConstMappedRange{T}(nuint, nuint, Action{ReadOnlySpan{T}})"/>
    public unsafe void GetConstMappedRange<T, TState>(nuint offset, nuint size, Action<ReadOnlySpan<T>, TState> callback, TState state)
        where T : unmanaged
        where TState : allows ref struct
    {
        ReadWriteStateChangeLock.AddReadWriteLock();
        try
        {
            void* ptr = Handle.GetConstMappedRange(offset, size * (nuint)sizeof(T));
            var span = ptr == null ? [] : new ReadOnlySpan<T>(ptr, (int)size);
            callback(span, state);
        }
        finally
        {
            ReadWriteStateChangeLock.RemoveReadWriteLock();
        }
    }

    /// <inheritdoc cref="GetConstMappedRange{T, TState}(nuint, nuint, Action{ReadOnlySpan{T}, TState}, TState)"/>
    public unsafe void GetConstMappedRange<TState>(nuint offset, nuint size, Action<ReadOnlySpan<byte>, TState> callback, TState state)
        where TState : allows ref struct
    {
        GetConstMappedRange<byte, TState>(offset, size, callback, state);
    }

    /// <inheritdoc cref="GetConstMappedRange{T, TState}(nuint, nuint, ReadContextDelegateWithState{T, TState}, ref TState)"/>
    public unsafe TResult GetConstMappedRange<TResult, T, TState>(nuint offset, nuint size, Func<ReadOnlySpan<T>, TState, TResult> callback, TState state)
        where T : unmanaged
    {
        ReadWriteStateChangeLock.AddReadWriteLock();
        try
        {
            void* ptr = Handle.GetConstMappedRange(offset, size * (nuint)sizeof(T));
            var span = ptr == null ? [] : new ReadOnlySpan<T>(ptr, (int)size);
            return callback(span, state);
        }
        finally
        {
            ReadWriteStateChangeLock.RemoveReadWriteLock();
        }
    }

    /// <param name="callback">The callback to be called with the mapped range.</param>
    /// <inheritdoc cref="BufferHandle.GetMappedRange(nuint, nuint)"/>
    public unsafe void GetMappedRange<T>(nuint offset, nuint size, Action<Span<T>> callback)
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

    /// <inheritdoc cref="GetMappedRange{T}(nuint, nuint, Action{Span{T}})"/>
    public unsafe void GetMappedRange(nuint offset, nuint size, Action<Span<byte>> callback)
    {
        GetMappedRange<byte>(offset, size, callback);
    }

    /// <inheritdoc cref="GetMappedRange{T}(nuint, nuint, ReadWriteContextDelegate{T})"/>
    public unsafe TResult GetMappedRange<TResult, T>(nuint offset, nuint size, Func<Span<T>, TResult> callback)
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

    /// <inheritdoc cref="GetMappedRange{T}(nuint, nuint, Action{Span{T}})"/>
    public unsafe void GetMappedRange<T>(Action<Span<T>> callback)
        where T : unmanaged
    {
        GetMappedRange(0, (nuint)(GetSize() / (ulong)sizeof(T)), callback);
    }

    /// <inheritdoc cref="GetMappedRange{T}(nuint, nuint, Action{Span{T}})"/>
    public void GetMappedRange(Action<Span<byte>> callback)
    {
        GetMappedRange<byte>(callback);
    }

    /// <param name="state"> The state to be passed to the callback.</param>
    /// <inheritdoc cref="GetMappedRange{T}(nuint, nuint, Action{Span{T}})"/>
    public unsafe void GetMappedRange<T, TState>(nuint offset, nuint size, Action<Span<T>, TState> callback, TState state)
        where T : unmanaged
    {
        ReadWriteStateChangeLock.AddReadWriteLock();
        try
        {
            void* ptr = Handle.GetMappedRange(offset, size * (nuint)sizeof(T));
            var span = ptr == null ? [] : new Span<T>(ptr, (int)size);
            callback(span, state);
        }
        finally
        {
            ReadWriteStateChangeLock.RemoveReadWriteLock();
        }
    }

    /// <inheritdoc cref="GetMappedRange{T, TState}(nuint, nuint, Action{Span{T}, TState}, TState)"/>
    public unsafe void GetMappedRange<TState>(nuint offset, nuint size, Action<Span<byte>, TState> callback, TState state)
    {
        GetMappedRange<byte, TState>(offset, size, callback, state);
    }

    /// <inheritdoc cref="GetMappedRange{T, TState}(nuint, nuint, Action{Span{T}, TState}, TState)"/>
    public unsafe TResult GetMappedRange<TResult, T, TState>(nuint offset, nuint size, Func<Span<T>, TState, TResult> callback, TState state)
        where T : unmanaged
    {
        ReadWriteStateChangeLock.AddReadWriteLock();
        try
        {
            void* ptr = Handle.GetMappedRange(offset, size * (nuint)sizeof(T));
            var span = ptr == null ? [] : new Span<T>(ptr, (int)size);
            return callback(span, state);
        }
        finally
        {
            ReadWriteStateChangeLock.RemoveReadWriteLock();
        }
    }

    /// <inheritdoc cref="BufferHandle.GetMapState"/>
    public BufferMapState GetMapState() => Handle.GetMapState();
    /// <inheritdoc cref="BufferHandle.GetSize"/>
    public ulong GetSize() => Handle.GetSize();
    /// <inheritdoc cref="BufferHandle.GetUsage"/>
    public BufferUsage GetUsage() => Handle.GetUsage();

    /// <inheritdoc cref="BufferHandle.Unmap"/>
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

    /// <inheritdoc cref="BufferHandle.SetLabel(StringViewFFI)"/>
    public void SetLabel(WGPURefText label)
    {
        Handle.SetLabel(label);
    }

    /// <summary>
    /// Performs a read/write operation on a span of buffers.
    /// </summary>
    /// <param name="buffers">The buffers</param>
    /// <param name="callback">The callback to perform the read/write operation in</param>
    public static void DoReadWriteOperation(
        ReadOnlySpan<BufferBase> buffers,
        Action<BufferReadWriteContext> callback
    )
    {
        using MangedArrayPoolRentInstance<BufferBase> rentedBuffers = new(ArrayPool<object?>.Shared, buffers.Length);
        var rentBufferSpan = rentedBuffers.Span;

        int i = 0;
        try
        {
            for (; i < rentBufferSpan.Length; i++)
            {
                rentBufferSpan[i].ReadWriteStateChangeLock.AddReadWriteLock();
            }
            BufferReadWriteContext context = new(rentBufferSpan);
            callback(context);
        }
        finally
        {
            do
            {
                i--;
                rentBufferSpan[i].ReadWriteStateChangeLock.RemoveReadWriteLock();
            } while (i != 0);
        }
    }

    /// <summary>
    /// Performs a read/write operation on a span of buffers.
    /// </summary>
    /// <param name="buffers">The buffers</param>
    /// <param name="callback">The callback to perform the read/write operation in</param>
    /// <returns>The result of the callback</returns>
    public static T DoReadWriteOperation<T>(
        ReadOnlySpan<BufferBase> buffers,
        Func<BufferReadWriteContext, T> callback
    )
    {
        using MangedArrayPoolRentInstance<BufferBase> rentedBuffers = new(ArrayPool<object?>.Shared, buffers.Length);
        var rentBufferSpan = rentedBuffers.Span;

        int i = 0;
        try
        {
            for (; i < rentBufferSpan.Length; i++)
            {
                rentBufferSpan[i].ReadWriteStateChangeLock.AddReadWriteLock();
            }
            BufferReadWriteContext context = new(rentBufferSpan);
            return callback(context);
        }
        finally
        {
            do
            {
                i--;
                rentBufferSpan[i].ReadWriteStateChangeLock.RemoveReadWriteLock();
            } while (i != 0);
        }
    }


    /// <summary>
    /// Performs a read/write operation on a span of buffers.
    /// </summary>
    /// <param name="buffers">The buffers</param>
    /// <param name="state">The state to be passed to the callback.</param>
    /// <param name="callback">The callback to perform the read/write operation in</param>
    public static void DoReadWriteOperation<TUserdata>(
        ReadOnlySpan<BufferBase> buffers,
        TUserdata state,
        Action<BufferReadWriteContext, TUserdata> callback
    )
     where TUserdata : allows ref struct
    {
        using MangedArrayPoolRentInstance<BufferBase> rentedBuffers = new(ArrayPool<object?>.Shared, buffers.Length);
        var rentBufferSpan = rentedBuffers.Span;

        int i = 0;
        try
        {
            for (; i < rentBufferSpan.Length; i++)
            {
                rentBufferSpan[i].ReadWriteStateChangeLock.AddReadWriteLock();
            }
            BufferReadWriteContext context = new(rentBufferSpan);
            callback(context, state);
        }
        finally
        {
            do
            {
                i--;
                rentBufferSpan[i].ReadWriteStateChangeLock.RemoveReadWriteLock();
            } while (i != 0);
        }
    }

    /// <summary>
    /// Performs a read/write operation on a span of buffers.
    /// </summary>
    /// <param name="buffers">The buffers</param>
    /// <param name="state">The state to be passed to the callback.</param>
    /// <param name="callback">The callback to perform the read/write operation in</param>
    /// <returns>The result of the callback</returns>
    public static TReturnData DoReadWriteOperation<TReturnData, TUserdata>(
        ReadOnlySpan<BufferBase> buffers,
        TUserdata state,
        Func<BufferReadWriteContext, TUserdata, TReturnData> callback
    )
    {
        using MangedArrayPoolRentInstance<BufferBase> rentedBuffers = new(ArrayPool<object?>.Shared, buffers.Length);
        var rentBufferSpan = rentedBuffers.Span;

        int i = 0;
        try
        {
            for (; i < rentBufferSpan.Length; i++)
            {
                rentBufferSpan[i].ReadWriteStateChangeLock.AddReadWriteLock();
            }
            BufferReadWriteContext context = new(rentBufferSpan);
            return callback(context, state);
        }
        finally
        {
            do
            {
                i--;
                rentBufferSpan[i].ReadWriteStateChangeLock.RemoveReadWriteLock();
            } while (i != 0);
        }
    }



    private static unsafe class BufferCallbackHandler
    {
        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
        public static void OnBufferMapCallback_TaskCompletionSource(
            MapAsyncStatus status, StringViewFFI _, void* userdata1, void* userdata2)
        {
            try
            {
                var bufferBase = (BufferBase?)ConsumeUserDataIntoObject(userdata1);
                var taskCompletionSource = (TaskCompletionSource<MapAsyncStatus>?)ConsumeUserDataIntoObject(userdata2);

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
            MapAsyncStatus status, StringViewFFI _, void* userdata1, void* userdata2)
        {
            try
            {
                var bufferBase = (BufferBase?)ConsumeUserDataIntoObject(userdata1);
                var callback = (Action<MapAsyncStatus>?)ConsumeUserDataIntoObject(userdata2);
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