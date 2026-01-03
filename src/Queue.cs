using System.Buffers;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using WebGpuSharp.FFI;
using WebGpuSharp.Internal;
using WebGpuSharp.Marshalling;
using static WebGpuSharp.Marshalling.WebGPUMarshal;

namespace WebGpuSharp;

/// <inheritdoc cref="QueueHandle" />
public sealed class Queue :
    WebGPUManagedHandleBase<QueueHandle>,
    IFromHandleWithInstance<Queue, QueueHandle>
{
    private readonly Instance _instance;

    private Queue(QueueHandle handle, Instance instance) : base(handle)
    {
        _instance = instance;
    }

    /// <inheritdoc cref="QueueHandle.SetLabel(WGPURefText)" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void SetLabel(WGPURefText label)
    {
        Handle.SetLabel(label);
    }

    /// <inheritdoc cref="QueueHandle.Submit(ReadOnlySpan{CommandBuffer})" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Submit(ReadOnlySpan<CommandBuffer> commands)
    {
        Handle.Submit(commands);
    }

    /// <inheritdoc cref="QueueHandle.Submit(CommandBuffer)" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Submit(CommandBuffer commands)
    {
        Handle.Submit(commands);
    }

    /// <inheritdoc cref="QueueHandle.WriteBuffer{T}(BufferHandle, ulong, List{T})" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void WriteBuffer<T>(Buffer buffer, ulong bufferOffset, List<T> data)
     where T : unmanaged
    {
        Handle.WriteBuffer(WebGPUMarshal.GetHandle(buffer), bufferOffset, (ReadOnlySpan<T>)CollectionsMarshal.AsSpan(data));
    }

    /// <inheritdoc cref="QueueHandle.WriteBuffer{T}(BufferHandle, ulong, T[])" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void WriteBuffer<T>(Buffer buffer, ulong bufferOffset, T[] data)
         where T : unmanaged
    {
        Handle.WriteBuffer(WebGPUMarshal.GetHandle(buffer), bufferOffset, (ReadOnlySpan<T>)data);
    }

    /// <inheritdoc cref="QueueHandle.WriteBuffer{T}(BufferHandle, ulong, Span{T})" />
    [MethodImpl(MethodImplOptions.AggressiveInlining), OverloadResolutionPriority(1)]
    public void WriteBuffer<T>(Buffer buffer, ulong bufferOffset, Span<T> data)
             where T : unmanaged
    {
        Handle.WriteBuffer(WebGPUMarshal.GetHandle(buffer), bufferOffset, (ReadOnlySpan<T>)data);
    }

    /// <inheritdoc cref="QueueHandle.WriteBuffer{T}(BufferHandle, ulong, ReadOnlySpan{T})" />
    [MethodImpl(MethodImplOptions.AggressiveInlining), OverloadResolutionPriority(2)]
    public void WriteBuffer<T>(Buffer buffer, ulong bufferOffset, ReadOnlySpan<T> data)
         where T : unmanaged
    {
        Handle.WriteBuffer(WebGPUMarshal.GetHandle(buffer), bufferOffset, data);
    }

    /// <inheritdoc cref="QueueHandle.WriteBuffer{T}(BufferHandle, ulong, in T)" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void WriteBuffer<T>(Buffer buffer, ulong bufferOffset, in T data)
         where T : unmanaged
    {
        Handle.WriteBuffer(WebGPUMarshal.GetHandle(buffer), bufferOffset, data);
    }

    /// <inheritdoc cref="QueueHandle.WriteBuffer{T}(BufferHandle, ulong, in T)" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void WriteBuffer<T>(Buffer buffer, in T data)
         where T : unmanaged
    {
        Handle.WriteBuffer(WebGPUMarshal.GetHandle(buffer), 0, data);
    }


    /// <inheritdoc cref="QueueHandle.WriteTexture{T}(in TexelCopyTextureInfo, List{T}, in TexelCopyBufferLayout, in Extent3D)" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void WriteTexture<T>(
        in TexelCopyTextureInfo destination,
        List<T> data,
        in TexelCopyBufferLayout dataLayout,
        in Extent3D writeSize
    ) where T : unmanaged
    {
        Handle.WriteTexture(
            destination: destination,
            data: (ReadOnlySpan<T>)CollectionsMarshal.AsSpan(data),
            dataLayout: dataLayout,
            writeSize: writeSize
        );
    }

    /// <inheritdoc cref="QueueHandle.WriteTexture{T}(in TexelCopyTextureInfo, T[], in TexelCopyBufferLayout, in Extent3D)" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void WriteTexture<T>(
        in TexelCopyTextureInfo destination,
        T[] data,
        in TexelCopyBufferLayout dataLayout,
        in Extent3D writeSize
    ) where T : unmanaged
    {
        Handle.WriteTexture(
            destination: destination,
            data: (ReadOnlySpan<T>)data,
            dataLayout: dataLayout,
            writeSize: writeSize
        );
    }

    /// <inheritdoc cref="QueueHandle.WriteTexture{T}(in TexelCopyTextureInfo, Span{T}, in TexelCopyBufferLayout, in Extent3D)" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void WriteTexture<T>(
        in TexelCopyTextureInfo destination,
        Span<T> data,
        in TexelCopyBufferLayout dataLayout,
        in Extent3D writeSize
    ) where T : unmanaged
    {
        Handle.WriteTexture(
            destination: destination,
            data: (ReadOnlySpan<T>)data,
            dataLayout: dataLayout,
            writeSize: writeSize
        );
    }

    /// <inheritdoc cref="QueueHandle.WriteTexture{T}(in TexelCopyTextureInfo, ReadOnlySpan{T}, in TexelCopyBufferLayout, in Extent3D)" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void WriteTexture<T>(
        in TexelCopyTextureInfo destination,
        ReadOnlySpan<T> data,
        in TexelCopyBufferLayout dataLayout,
        in Extent3D writeSize)
        where T : unmanaged
    {
        Handle.WriteTexture(
            destination: destination,
            data: data,
            dataLayout: dataLayout,
            writeSize: writeSize
        );
    }

    static Queue? IFromHandleWithInstance<Queue, QueueHandle>.FromHandle(
        QueueHandle handle, Instance instance)
    {
        if (QueueHandle.IsNull(handle))
        {
            return null;
        }

        QueueHandle.Reference(handle);
        return new(handle, instance);
    }

    static Instance IFromHandleWithInstance<Queue, QueueHandle>.GetOwnerInstance(
        Queue queue)
    {
        return queue._instance;
    }

    /// <inheritdoc cref="QueueHandle.OnSubmittedWorkDone(QueueWorkDoneCallbackInfoFFI)"/>
    public unsafe void OnSubmittedWorkDone(Action<QueueWorkDoneStatus, ReadOnlySpan<byte>> callback)
    {
        void* callbackUserData = AllocUserData(callback);
        var future = WebGPU_FFI.QueueOnSubmittedWorkDone(
           queue: Handle,
           callbackInfo: new()
           {
               Mode = CallbackMode.AllowProcessEvents,
               Callback = &OnSubmittedWorkDoneFunctions.DelegateCallback,
               Userdata1 = callbackUserData,
               Userdata2 = null,
           }
        );
        _instance._eventHandler.EnqueueCpuFuture(future);
    }

    /// <inheritdoc cref="QueueHandle.OnSubmittedWorkDone(QueueWorkDoneCallbackInfoFFI)"/>
    public unsafe void OnSubmittedWorkSync(ulong timeoutNS = ulong.MaxValue)
    {
        Exception? _exception = null;

        void Callback(QueueWorkDoneStatus status, ReadOnlySpan<byte> message)
        {
            if (status == QueueWorkDoneStatus.Success)
            {
                return;
            }
            else
            {
                _exception = new WebGPUException(Encoding.UTF8.GetString(message));
            }
        }

        void* callbackUserData = AllocUserData((Action<QueueWorkDoneStatus, ReadOnlySpan<byte>>)Callback);
        var future = WebGPU_FFI.QueueOnSubmittedWorkDone(
           queue: Handle,
           callbackInfo: new()
           {
               Mode = CallbackMode.AllowProcessEvents,
               Callback = &OnSubmittedWorkDoneFunctions.DelegateCallback,
               Userdata1 = callbackUserData,
               Userdata2 = null,
           }
        );
        _instance.WaitAny(future, timeoutNS);
    }

    /// <inheritdoc cref="QueueHandleOnSubmittedWorkDone(QueueWorkDoneCallbackInfoFFI)"/>
    public unsafe Task OnSubmittedWorkDoneAsync()
    {
        var tsc = new TaskCompletionSource();
        void* tscUserData = AllocUserData(tsc);
        void* instanceUserData = AllocUserData(_instance);
        var future = WebGPU_FFI.QueueOnSubmittedWorkDone(
            queue: Handle,
            callbackInfo: new()
            {
                Mode = CallbackMode.AllowProcessEvents,
                Callback = &OnSubmittedWorkDoneFunctions.TaskCallback,
                Userdata1 = tscUserData,
                Userdata2 = instanceUserData,
            }
        );
        _instance._eventHandler.EnqueueCpuFuture(future);
        return tsc.Task;
    }
}

file unsafe static class OnSubmittedWorkDoneFunctions
{
    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    public static void DelegateCallback(
        QueueWorkDoneStatus status, StringViewFFI message,
        void* userdata1, void* _)
    {
        try
        {
            var callback = (Action<QueueWorkDoneStatus, ReadOnlySpan<byte>>?)ConsumeUserDataIntoObject(userdata1);
            if (callback == null)
            {
                return;
            }

            callback?.Invoke(status, message.AsSpan());
        }
        catch
        {
            // Swallow exceptions to avoid crashing native code.
        }
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    public static void TaskCallback(
            QueueWorkDoneStatus status, StringViewFFI message,
            void* userdata1, void* _)
    {
        try
        {
            var tsc = (TaskCompletionSource?)ConsumeUserDataIntoObject(userdata1);
            if (tsc == null)
            {
                return;
            }
            switch (status)
            {
                case QueueWorkDoneStatus.Success:
                    tsc?.SetResult();
                    break;
                case QueueWorkDoneStatus.Error:
                case QueueWorkDoneStatus.CallbackCancelled:
                default:
                    tsc?.SetException(new WebGPUException(Encoding.UTF8.GetString(message.AsSpan())));
                    break;
            }
        }
        catch { }
    }
}