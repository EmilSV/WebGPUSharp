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

    /// <inheritdoc cref="BufferHandle.MapAsync(MapMode, nuint, nuint, BufferMapCallbackInfoFFI)"/> 
    public unsafe void MapAsync(
       MapMode mode,
       nuint offset,
       nuint size,
       Action<MapAsyncStatus> callbackInfo)
    {
        _readWriteStateChangeLock.AddStateChangeLock();
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
                    Callback = &BufferMapAsyncCallbackFunctions.DelegateCallback,
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
            _readWriteStateChangeLock.RemoveStateChangeLock();
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
        void* bufferBaseHandle = null;
        void* taskCompletionSourceHandle = null;
        try
        {
            _readWriteStateChangeLock.AddStateChangeLock();
            TaskCompletionSource<MapAsyncStatus> taskCompletionSource = new();
            bufferBaseHandle = AllocUserData(this);
            taskCompletionSourceHandle = AllocUserData(taskCompletionSource);

            var future = Handle.MapAsync(
                  mode: mode,
                  offset: offset,
                  size: size,
                  callbackInfo: new()
                  {
                      Callback = &BufferMapAsyncCallbackFunctions.TaskCallback,
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
            _readWriteStateChangeLock.RemoveStateChangeLock();
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
        MapAsyncStatus status, StringViewFFI message, void* userdata1, void* userdata2)
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

            byte[]? messageBuffer = null;
            messageBuffer = ArrayPool<byte>.Shared.Rent((int)message.Length);
            var messageBufferArraySegment = new ArraySegment<byte>(messageBuffer, 0, (int)message.Length);
            message.AsSpan().CopyTo(messageBufferArraySegment);

            ThreadPool.UnsafeQueueUserWorkItem(
                state: (status, messageBufferArraySegment, callback!, bufferBase),
                callBack: static state =>
                {
                    var (status, messageBufferArraySegment, callback, bufferBase) = state;
                    bufferBase._readWriteStateChangeLock.RemoveStateChangeLock();
                    try
                    {
                        callback(status, messageBufferArraySegment);
                    }
                    finally
                    {
                        ArrayPool<byte>.Shared.Return(messageBufferArraySegment.Array!);
                    }
                },
                preferLocal: false
            );
        }
        catch { }
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    public static void TaskCallback(
        MapAsyncStatus status, StringViewFFI message, void* userdata1, void* userdata2)
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
            byte[]? messageBuffer = null;
            messageBuffer = ArrayPool<byte>.Shared.Rent((int)message.Length);
            var messageBufferArraySegment = new ArraySegment<byte>(messageBuffer, 0, (int)message.Length);
            message.AsSpan().CopyTo(messageBufferArraySegment);

            ThreadPool.QueueUserWorkItem(
                state: (status, messageBufferArraySegment, taskCompletionSource, bufferBase),
                callBack: static state =>
                {
                    var (status, messageBufferArraySegment, taskCompletionSource, bufferBase) = state;
                    //bufferBase._readWriteStateChangeLock.RemoveStateChangeLock();
                    try
                    {
                        switch (status)
                        {
                            case MapAsyncStatus.Success:
                                taskCompletionSource.SetResult(status);
                                break;
                            case MapAsyncStatus.Error:
                            case MapAsyncStatus.Aborted:
                            case MapAsyncStatus.CallbackCancelled:
                            default:
                                taskCompletionSource.SetException(new WebGPUException(Encoding.UTF8.GetString(messageBufferArraySegment)));
                                break;
                        }
                    }
                    finally
                    {
                        ArrayPool<byte>.Shared.Return(messageBufferArraySegment.Array!);
                    }
                },
                preferLocal: false
            );
        }
        catch { }
    }
}
