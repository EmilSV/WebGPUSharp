using System.Buffers;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using WebGpuSharp.FFI;
using WebGpuSharp.Internal;
using WebGpuSharp.Marshalling;
using static WebGpuSharp.Marshalling.WebGPUMarshal;

namespace WebGpuSharp;


/// <inheritdoc/>
public sealed class Buffer :
    WebGPUManagedHandleBase<BufferHandle>,
    IFromHandleWithInstance<Buffer, BufferHandle>
{
    internal readonly ReadWriteStateChangeHandleLock _readWriteStateChangeLock;
    private readonly Instance _instance;

    private Buffer(BufferHandle handle, Instance instance) : base(handle)
    {
        _instance = instance;
        _readWriteStateChangeLock = ReadWriteStateChangeHandleLock.Get(handle.GetAddress());
    }

    private unsafe Future Map(
        MapMode mode,
        nuint offset,
        nuint size,
        CallbackMode callbackMode,
        Action<MapAsyncStatus, ReadOnlySpan<byte>>? callback,
        TaskCompletionSource<MapAsyncStatus>? tcs)
    {
        _readWriteStateChangeLock.AddStateChangeLock();
        Future future;
        try
        {
            void* bufferBaseUserData = AllocUserData(this);
            void* userdata2;
            delegate* unmanaged[Cdecl]<MapAsyncStatus, StringViewFFI, void*, void*, void> callbackFunction;
            if (callback != null)
            {
                userdata2 = AllocUserData(callback);
                callbackFunction = &BufferMapAsyncCallbackFunctions.DelegateCallback;
            }
            else
            {
                userdata2 = AllocUserData(tcs!);
                callbackFunction = &BufferMapAsyncCallbackFunctions.TaskCallback;
            }

            future = Handle.MapAsync(
                mode: mode,
                offset: offset,
                size: size,
                callbackInfo: new()
                {
                    Callback = callbackFunction,
                    Userdata1 = bufferBaseUserData,
                    Userdata2 = userdata2,
                    Mode = callbackMode,
                }
            );
        }
        catch (Exception)
        {
            _readWriteStateChangeLock.RemoveStateChangeLock();
            throw;
        }
        return future;
    }

    /// <inheritdoc cref="BufferHandle.MapAsync(MapMode, nuint, nuint, BufferMapCallbackInfoFFI)"/> 
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void MapSync(
       MapMode mode,
       nuint offset = 0,
       nuint? size = null,
       ulong timeoutMilliseconds = ulong.MaxValue)
    {
        Exception? exception = null;
        void Callback(MapAsyncStatus status, ReadOnlySpan<byte> message)
        {
            if (status != MapAsyncStatus.Success)
            {
                exception = new WebGPUException(Encoding.UTF8.GetString(message));
            }
        }

        var future = Map(
            mode: mode,
            offset: offset,
            size: size ?? WebGPU_FFI.WHOLE_MAP_SIZE,
            callbackMode: CallbackMode.AllowProcessEvents,
            callback: Callback,
            tcs: null
        );

        _instance.WaitAny(future, timeoutMilliseconds);
    }

    /// <returns></returns>
    /// <inheritdoc cref="BufferHandle.MapAsync(MapMode, nuint, nuint, BufferMapCallbackInfoFFI)"/> 
    /// <param name="callback">Callback to be called when the buffer is mapped.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Map(
       MapMode mode,
       nuint offset,
       nuint size,
       Action<MapAsyncStatus, ReadOnlySpan<byte>> callback)
    {
        var future = Map(
            mode: mode,
            offset: offset,
            size: size,
            callbackMode: CallbackMode.AllowProcessEvents,
            callback: callback,
            tcs: null
        );
        _instance._eventHandler.EnqueueCpuFuture(future);
    }

    /// <inheritdoc cref="Map(MapMode, nuint, nuint, Action{MapAsyncStatus, ReadOnlySpan{byte}})"/>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Map(MapMode mode, nuint offset, Action<MapAsyncStatus, ReadOnlySpan<byte>> callback)
    {
        Map(mode, offset, WebGPU_FFI.WHOLE_MAP_SIZE, callback);
    }

    /// <inheritdoc cref="BufferHandle.MapAsync(MapMode, nuint, nuint, BufferMapCallbackInfoFFI)"/> 
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Map(MapMode mode, Action<MapAsyncStatus, ReadOnlySpan<byte>> callback)
    {
        Map(mode, 0, WebGPU_FFI.WHOLE_MAP_SIZE, callback);
    }

    /// <inheritdoc cref="BufferHandle.MapAsync(MapMode, nuint, nuint, BufferMapCallbackInfoFFI)"/>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Task<MapAsyncStatus> MapAsync(
        MapMode mode,
        nuint offset,
        nuint size)
    {
        var tcs = new TaskCompletionSource<MapAsyncStatus>(TaskCreationOptions.RunContinuationsAsynchronously);
        var future = Map(
            mode: mode,
            offset: offset,
            size: size,
            callbackMode: CallbackMode.AllowProcessEvents,
            callback: null,
            tcs: tcs
        );
        _instance._eventHandler.EnqueueCpuFuture(future);
        return tcs.Task;
    }

    /// <inheritdoc cref="BufferHandle.MapAsync(MapMode, nuint, nuint, BufferMapCallbackInfoFFI)"/>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Task<MapAsyncStatus> MapAsync(MapMode mode, nuint offset = 0)
    {
        return MapAsync(mode, offset, WebGPU_FFI.WHOLE_MAP_SIZE);
    }

    /// <inheritdoc cref="BufferHandle.Destroy"/>
    public void Destroy()
    {
        _readWriteStateChangeLock.AddStateChangeLock();
        try
        {
            Handle.Destroy();
        }
        finally
        {
            _readWriteStateChangeLock.RemoveStateChangeLock();
        }
    }

    /// <param name="callback">The callback to be called with the mapped range.</param>
    /// <inheritdoc cref="BufferHandle.GetConstMappedRange(nuint, nuint)"/>
    public unsafe void GetConstMappedRange<T>(nuint offset, nuint size, Action<ReadOnlySpan<T>> callback)
        where T : unmanaged
    {
        _readWriteStateChangeLock.AddReadWriteLock();
        try
        {
            void* ptr = Handle.GetConstMappedRange(offset, size * (nuint)sizeof(T));
            var span = ptr == null ? [] : new ReadOnlySpan<T>(ptr, (int)size);
            callback(span);
        }
        finally
        {
            _readWriteStateChangeLock.RemoveReadWriteLock();
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
        _readWriteStateChangeLock.AddReadWriteLock();
        try
        {
            void* ptr = Handle.GetConstMappedRange(offset, size * (nuint)sizeof(T));
            var span = ptr == null ? [] : new ReadOnlySpan<T>(ptr, (int)size);
            return callback(span);
        }
        finally
        {
            _readWriteStateChangeLock.RemoveReadWriteLock();
        }
    }

    /// <param name="state"> The state to be passed to the callback.</param>
    /// <inheritdoc cref="GetConstMappedRange{T}(nuint, nuint, Action{ReadOnlySpan{T}})"/>
    public unsafe void GetConstMappedRange<T, TState>(nuint offset, nuint size, Action<ReadOnlySpan<T>, TState> callback, TState state)
        where T : unmanaged
        where TState : allows ref struct
    {
        _readWriteStateChangeLock.AddReadWriteLock();
        try
        {
            void* ptr = Handle.GetConstMappedRange(offset, size * (nuint)sizeof(T));
            var span = ptr == null ? [] : new ReadOnlySpan<T>(ptr, (int)size);
            callback(span, state);
        }
        finally
        {
            _readWriteStateChangeLock.RemoveReadWriteLock();
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
        where TState : allows ref struct
    {
        _readWriteStateChangeLock.AddReadWriteLock();
        try
        {
            void* ptr = Handle.GetConstMappedRange(offset, size * (nuint)sizeof(T));
            var span = ptr == null ? [] : new ReadOnlySpan<T>(ptr, (int)size);
            return callback(span, state);
        }
        finally
        {
            _readWriteStateChangeLock.RemoveReadWriteLock();
        }
    }

    /// <inheritdoc cref="GetConstMappedRange{T}(nuint, nuint, Action{ReadOnlySpan{T}})"/>
    public unsafe void GetConstMappedRange<T>(Action<ReadOnlySpan<T>> callback)
        where T : unmanaged
    {
        GetConstMappedRange(0, (nuint)(GetSize() / (ulong)sizeof(T)), callback);
    }

    /// <inheritdoc cref="GetConstMappedRange{T}(nuint, nuint, Action{ReadOnlySpan{T}})"/>
    public unsafe void GetConstMappedRange<T, TState>(Action<ReadOnlySpan<T>, TState> callback, TState state)
        where T : unmanaged
        where TState : allows ref struct
    {
        GetConstMappedRange(0, (nuint)(GetSize() / (ulong)sizeof(T)), callback, state);
    }

    /// <param name="callback">The callback to be called with the mapped range.</param>
    /// <inheritdoc cref="BufferHandle.GetMappedRange(nuint, nuint)"/>
    public unsafe void GetMappedRange<T>(nuint offset, nuint size, Action<Span<T>> callback)
        where T : unmanaged
    {
        _readWriteStateChangeLock.AddReadWriteLock();
        try
        {
            void* ptr = Handle.GetMappedRange(offset, size * (nuint)sizeof(T));
            var span = ptr == null ? [] : new Span<T>(ptr, (int)size);
            callback(span);
        }
        finally
        {
            _readWriteStateChangeLock.RemoveReadWriteLock();
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
        _readWriteStateChangeLock.AddReadWriteLock();
        try
        {
            void* ptr = Handle.GetMappedRange(offset, size * (nuint)sizeof(T));
            var span = ptr == null ? [] : new Span<T>(ptr, (int)size);
            return callback(span);
        }
        finally
        {
            _readWriteStateChangeLock.RemoveReadWriteLock();
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
        where TState : allows ref struct
    {
        _readWriteStateChangeLock.AddReadWriteLock();
        try
        {
            void* ptr = Handle.GetMappedRange(offset, size * (nuint)sizeof(T));
            var span = ptr == null ? [] : new Span<T>(ptr, (int)size);
            callback(span, state);
        }
        finally
        {
            _readWriteStateChangeLock.RemoveReadWriteLock();
        }
    }

    /// <inheritdoc cref="GetMappedRange{T, TState}(nuint, nuint, Action{Span{T}, TState}, TState)"/>
    public unsafe void GetMappedRange<TState>(nuint offset, nuint size, Action<Span<byte>, TState> callback, TState state)
        where TState : allows ref struct
    {
        GetMappedRange<byte, TState>(offset, size, callback, state);
    }

    /// <inheritdoc cref="GetMappedRange{T, TState}(nuint, nuint, Action{Span{T}, TState}, TState)"/>
    public unsafe TResult GetMappedRange<TResult, T, TState>(nuint offset, nuint size, Func<Span<T>, TState, TResult> callback, TState state)
        where T : unmanaged
        where TState : allows ref struct
    {
        _readWriteStateChangeLock.AddReadWriteLock();
        try
        {
            void* ptr = Handle.GetMappedRange(offset, size * (nuint)sizeof(T));
            var span = ptr == null ? [] : new Span<T>(ptr, (int)size);
            return callback(span, state);
        }
        finally
        {
            _readWriteStateChangeLock.RemoveReadWriteLock();
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
        _readWriteStateChangeLock.AddStateChangeLock();
        try
        {
            Handle.Unmap();
        }
        finally
        {
            _readWriteStateChangeLock.RemoveStateChangeLock();
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
        ReadOnlySpan<Buffer> buffers,
        Action<BufferReadWriteContext> callback
    )
    {
        using MangedArrayPoolRentInstance<Buffer> rentedBuffers = new(ArrayPool<object?>.Shared, buffers.Length);
        var rentBufferSpan = rentedBuffers.Span[..buffers.Length];
        buffers.CopyTo(rentBufferSpan);

        int i = 0;
        try
        {
            for (; i < rentBufferSpan.Length; i++)
            {
                rentBufferSpan[i]._readWriteStateChangeLock.AddReadWriteLock();
            }
            BufferReadWriteContext context = new(rentBufferSpan);
            callback(context);
        }
        finally
        {
            while (i != 0)
            {
                i--;
                rentBufferSpan[i]._readWriteStateChangeLock.RemoveReadWriteLock();
            }
        }
    }

    /// <summary>
    /// Performs a read/write operation on a span of buffers.
    /// </summary>
    /// <param name="buffers">The buffers</param>
    /// <param name="callback">The callback to perform the read/write operation in</param>
    /// <returns>The result of the callback</returns>
    public static T DoReadWriteOperation<T>(
        ReadOnlySpan<Buffer> buffers,
        Func<BufferReadWriteContext, T> callback
    )
    {
        using MangedArrayPoolRentInstance<Buffer> rentedBuffers = new(ArrayPool<object?>.Shared, buffers.Length);
        var rentBufferSpan = rentedBuffers.Span[..buffers.Length];
        buffers.CopyTo(rentBufferSpan);


        int i = 0;
        try
        {
            for (; i < rentBufferSpan.Length; i++)
            {
                rentBufferSpan[i]._readWriteStateChangeLock.AddReadWriteLock();
            }
            BufferReadWriteContext context = new(rentBufferSpan);
            return callback(context);
        }
        finally
        {
            while (i != 0)
            {
                i--;
                rentBufferSpan[i]._readWriteStateChangeLock.RemoveReadWriteLock();
            }
        }
    }


    /// <summary>
    /// Performs a read/write operation on a span of buffers.
    /// </summary>
    /// <param name="buffers">The buffers</param>
    /// <param name="state">The state to be passed to the callback.</param>
    /// <param name="callback">The callback to perform the read/write operation in</param>
    public static void DoReadWriteOperation<TUserdata>(
        ReadOnlySpan<Buffer> buffers,
        TUserdata state,
        Action<BufferReadWriteContext, TUserdata> callback
    )
     where TUserdata : allows ref struct
    {
        using MangedArrayPoolRentInstance<Buffer> rentedBuffers = new(ArrayPool<object?>.Shared, buffers.Length);
        var rentBufferSpan = rentedBuffers.Span[..buffers.Length];
        buffers.CopyTo(rentBufferSpan);

        int i = 0;
        try
        {
            for (; i < rentBufferSpan.Length; i++)
            {
                rentBufferSpan[i]._readWriteStateChangeLock.AddReadWriteLock();
            }
            BufferReadWriteContext context = new(rentBufferSpan);
            callback(context, state);
        }
        finally
        {
            while (i != 0)
            {
                i--;
                rentBufferSpan[i]._readWriteStateChangeLock.RemoveReadWriteLock();
            }
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
        ReadOnlySpan<Buffer> buffers,
        TUserdata state,
        Func<BufferReadWriteContext, TUserdata, TReturnData> callback
    )
    {
        using MangedArrayPoolRentInstance<Buffer> rentedBuffers = new(ArrayPool<object?>.Shared, buffers.Length);
        var rentBufferSpan = rentedBuffers.Span[..buffers.Length];
        buffers.CopyTo(rentBufferSpan);

        int i = 0;
        try
        {
            for (; i < rentBufferSpan.Length; i++)
            {
                rentBufferSpan[i]._readWriteStateChangeLock.AddReadWriteLock();
            }
            BufferReadWriteContext context = new(rentBufferSpan);
            return callback(context, state);
        }
        finally
        {
            while (i != 0)
            {
                i--;
                rentBufferSpan[i]._readWriteStateChangeLock.RemoveReadWriteLock();
            }
        }
    }

    static Buffer? IFromHandleWithInstance<Buffer, BufferHandle>.FromHandle(BufferHandle handle, Instance instance)
    {
        if (BufferHandle.IsNull(handle))
        {
            return null;
        }

        BufferHandle.Reference(handle);
        return new(handle, instance);
    }

    static Instance IFromHandleWithInstance<Buffer, BufferHandle>.GetOwnerInstance(Buffer buffer)
    {
        return buffer._instance;
    }
}


file static unsafe class BufferMapAsyncCallbackFunctions
{

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    public static void DelegateCallback(
        MapAsyncStatus status,
        StringViewFFI message,
        void* userdata1,
        void* userdata2)
    {
        try
        {
            var bufferBase = (Buffer?)ConsumeUserDataIntoObject(userdata1);
            var callback = (Action<MapAsyncStatus, ReadOnlySpan<byte>>?)ConsumeUserDataIntoObject(userdata2);
            if (bufferBase == null || callback == null)
            {
                Console.Error.WriteLine("Invalid buffer map callback");
                return;
            }
            callback(status, message.AsSpan());
        }
        catch
        {
            // Swallow exceptions to avoid crashing native code
        }
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    public static void TaskCallback(
        MapAsyncStatus status,
        StringViewFFI message,
        void* userdata1,
        void* userdata2)
    {
        try
        {
            var bufferBase = (Buffer?)ConsumeUserDataIntoObject(userdata1);
            var taskCompletionSource = (TaskCompletionSource<MapAsyncStatus>?)ConsumeUserDataIntoObject(userdata2);

            if (bufferBase == null || taskCompletionSource == null)
            {
                Console.Error.WriteLine("Invalid buffer map callback");
                return;
            }
            switch (status)
            {
                case MapAsyncStatus.Success:
                    taskCompletionSource.SetResult(status);
                    break;
                case MapAsyncStatus.Error:
                case MapAsyncStatus.Aborted:
                case MapAsyncStatus.CallbackCancelled:
                default:
                    taskCompletionSource.SetException(new WebGPUException(Encoding.UTF8.GetString(message.AsSpan())));
                    break;
            }
        }
        catch
        {
            // Swallow exceptions to avoid crashing native code
        }
    }
}
