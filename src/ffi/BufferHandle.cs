using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using WebGpuSharp.Internal;

namespace WebGpuSharp.FFI;

public unsafe readonly partial struct BufferHandle :
    IDisposable, IWebGpuHandle<BufferHandle, Buffer>
{
    public void Destroy()
    {
        WebGPU_FFI.BufferDestroy(this);
    }

    public void* GetConstMappedRange(nuint offset, nuint size)
    {
        return WebGPU_FFI.BufferGetConstMappedRange(this, offset, size);
    }

    public BufferMapState GetMapState()
    {
        return WebGPU_FFI.BufferGetMapState(this);
    }

    public void* GetMappedRange(nuint offset, nuint size)
    {
        return WebGPU_FFI.BufferGetMappedRange(this, offset, size);
    }

    public ulong GetSize()
    {
        return WebGPU_FFI.BufferGetSize(this);
    }

    public BufferUsage GetUsage()
    {
        return WebGPU_FFI.BufferGetUsage(this);
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

    public void Unmap()
    {
        WebGPU_FFI.BufferUnmap(this);
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
        return ref Unsafe.AsRef(in handle._ptr);
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

    public static void Reference(BufferHandle handle)
    {
        WebGPU_FFI.BufferReference(handle);
    }

    public static void Release(BufferHandle handle)
    {
        WebGPU_FFI.BufferRelease(handle);
    }

    public Buffer? ToSafeHandle(bool isOwnedHandle)
    {
        return Buffer.FromHandle(this, isOwnedHandle);
    }
}

file static class BufferHandelCallbacks
{
    [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
    public unsafe static void OnBufferMapCallback_Action(BufferMapAsyncStatus status, void* userdata)
    {
        CallbackUserDataHandle handle = (CallbackUserDataHandle)userdata;
        Action<BufferMapAsyncStatus>? callback;

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
        TaskCompletionSource<BufferMapAsyncStatus>? taskCompletionSource;

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