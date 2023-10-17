using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public readonly partial struct BufferHandle : IDisposable, IWebGpuHandle<BufferHandle>
{
    public void MapAsync(
        MapMode mode,
        nuint offset,
        nuint size,
        Action<BufferMapAsyncStatus> callback)
    {
        unsafe
        {
            CallbackUserDataHandle handle = default;
            try
            {
                handle = CallbackUserDataHandle.Alloc(callback);
                WebGPU_FFI.BufferMapAsync(
                    buffer: this,
                    mode: mode,
                    offset: offset,
                    size: size,
                    callback: &BufferHandelCallbacks.OnBufferMapCallback_Action,
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
    }

    public Task<BufferMapAsyncStatus> MapAsync(
        MapMode mode,
        nuint offset,
        nuint size)
    {
        unsafe
        {
            TaskCompletionSource<BufferMapAsyncStatus> taskCompletionSource;
            CallbackUserDataHandle handle = default;
            try
            {
                taskCompletionSource = new TaskCompletionSource<BufferMapAsyncStatus>();
                handle = CallbackUserDataHandle.Alloc(taskCompletionSource);
                WebGPU_FFI.BufferMapAsync(
                    buffer: this,
                    mode: mode,
                    offset: offset,
                    size: size,
                    callback: &BufferHandelCallbacks.OnBufferMapCallback_TaskCompletionSource,
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
    }



    public void Dispose()
    {
        if (_ptr != UIntPtr.Zero)
        {
            WebGPU_FFI.BufferRelease(this);
        }
    }

    public static ref nuint AsPointer(ref BufferHandle handle)
    {
        return ref Unsafe.AsRef(handle._ptr);
    }

    public static BufferHandle GetNullHandle()
    {
        return Null;
    }

    public static bool IsNull(BufferHandle handle)
    {
        return handle == Null;
    }

    public static BufferHandle UnsafeFromPointer(nuint pointer)
    {
        return new BufferHandle(pointer);
    }
}

file static class BufferHandelCallbacks
{
    [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
    public unsafe static void OnBufferMapCallback_Action(BufferMapAsyncStatus status, void* userdata)
    {
        CallbackUserDataHandle handle = (CallbackUserDataHandle)userdata;
        Action<BufferMapAsyncStatus>? callback = null;

        try
        {
            callback = (Action<BufferMapAsyncStatus>)handle.GetObject()!;
            callback(status);
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

    [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
    public unsafe static void OnBufferMapCallback_TaskCompletionSource(
        BufferMapAsyncStatus status, void* userdata)
    {
        CallbackUserDataHandle handle = (CallbackUserDataHandle)userdata;
        TaskCompletionSource<BufferMapAsyncStatus>? taskCompletionSource = null;

        try
        {
            taskCompletionSource = (TaskCompletionSource<BufferMapAsyncStatus>)handle.GetObject()!;
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