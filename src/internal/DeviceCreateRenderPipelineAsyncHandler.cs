using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using WebGpuSharp.FFI;

namespace WebGpuSharp.Internal;

internal unsafe static class DeviceCreateRenderPipelineAsyncHandler
{
    public static void DeviceCreateRenderPipelineAsync(
        DeviceHandle device,
        in RenderPipelineDescriptorFFI descriptor,
        CreateRenderPipelineAsyncDelegate<RenderPipelineHandle> callback)
    {
        fixed (RenderPipelineDescriptorFFI* descriptorPtr = &descriptor)
        {
            CallbackUserDataHandle userDataHandle = CallbackUserDataHandle.Alloc(callback);
            WebGPU_FFI.DeviceCreateRenderPipelineAsync(
                device: device,
                descriptor: descriptorPtr,
                callback: &OnCallbackDelegate,
                userdata: (void*)userDataHandle
            );
        }
    }

    public static Task<RenderPipelineHandle> DeviceCreateRenderPipelineAsync(
        DeviceHandle device,
        in RenderPipelineDescriptorFFI descriptor)
    {
        fixed (RenderPipelineDescriptorFFI* descriptorPtr = &descriptor)
        {
            TaskCompletionSource<RenderPipelineHandle> taskCompletionSource = new();
            CallbackUserDataHandle userDataHandle = CallbackUserDataHandle.Alloc(taskCompletionSource);
            WebGPU_FFI.DeviceCreateRenderPipelineAsync(
                device: device,
                descriptor: descriptorPtr,
                callback: &OnCallbackTask,
                userdata: (void*)userDataHandle
            );

            return taskCompletionSource.Task;
        }
    }


    [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
    private static void OnCallbackTask(
            CreatePipelineAsyncStatus status, RenderPipelineHandle renderPipelineHandle,
            byte* message, void* userdata)
    {
        CallbackUserDataHandle handle = (CallbackUserDataHandle)userdata;
        TaskCompletionSource<RenderPipelineHandle>? taskCompletionSource = null;
        try
        {

            taskCompletionSource = (TaskCompletionSource<RenderPipelineHandle>?)handle.GetObject();
            ReadOnlySpan<byte> messageSpan = message != null ?
                MemoryMarshal.CreateReadOnlySpanFromNullTerminated(message) :
                ReadOnlySpan<byte>.Empty;

            if (status != CreatePipelineAsyncStatus.Success)
            {
                taskCompletionSource?.SetResult(RenderPipelineHandle.Null);
                return;
            }

            if (taskCompletionSource != null)
            {
                taskCompletionSource.SetResult(renderPipelineHandle);
            }
            else
            {
                renderPipelineHandle.Dispose();
            }
        }
        catch (Exception e)
        {
            renderPipelineHandle.Dispose();
            taskCompletionSource?.SetException(e);
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
    private static void OnCallbackDelegate(
        CreatePipelineAsyncStatus status, RenderPipelineHandle renderPipelineHandle,
        byte* message, void* userdata)
    {
        CallbackUserDataHandle handle = (CallbackUserDataHandle)userdata;
        CreateRenderPipelineAsyncDelegate<RenderPipelineHandle>? callback = null;
        try
        {

            callback = (CreateRenderPipelineAsyncDelegate<RenderPipelineHandle>?)handle.GetObject();
            ReadOnlySpan<byte> messageSpan = message != null ?
                MemoryMarshal.CreateReadOnlySpanFromNullTerminated(message) :
                ReadOnlySpan<byte>.Empty;

            if (callback != null)
            {
                callback.Invoke(status, renderPipelineHandle, messageSpan);
            }
            else
            {
                renderPipelineHandle.Dispose();
            }
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