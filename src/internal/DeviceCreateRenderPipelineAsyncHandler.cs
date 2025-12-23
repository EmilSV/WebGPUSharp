using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using WebGpuSharp.FFI;
using static WebGpuSharp.Marshalling.WebGPUMarshal;

namespace WebGpuSharp.Internal;

internal unsafe static class DeviceCreateRenderPipelineAsyncHandler
{
    public static void DeviceCreateRenderPipelineAsync(
        DeviceHandle device,
        in RenderPipelineDescriptorFFI descriptor,
        Action<CreatePipelineAsyncStatus, RenderPipelineHandle, ReadOnlySpan<byte>> callback,
        CallbackMode mode)
    {
        fixed (RenderPipelineDescriptorFFI* descriptorPtr = &descriptor)
        {
            WebGPU_FFI.DeviceCreateRenderPipelineAsync(
                device: device,
                descriptor: descriptorPtr,
                callbackInfo: new()
                {
                    Mode = mode,
                    Callback = &OnCallbackDelegate,
                    Userdata1 = AllocUserData(callback),
                    Userdata2 = null
                }
            );
        }
    }

    public static Task<RenderPipelineHandle> DeviceCreateRenderPipelineAsync(
        DeviceHandle device,
        in RenderPipelineDescriptorFFI descriptor,
        CallbackMode mode)
    {
        fixed (RenderPipelineDescriptorFFI* descriptorPtr = &descriptor)
        {
            TaskCompletionSource<RenderPipelineHandle> taskCompletionSource = new();
            WebGPU_FFI.DeviceCreateRenderPipelineAsync(
                device: device,
                descriptor: descriptorPtr,
                callbackInfo: new()
                {
                    Mode = mode,
                    Callback = &OnCallbackTask,
                    Userdata1 = AllocUserData(taskCompletionSource),
                    Userdata2 = null
                }
            );

            return taskCompletionSource.Task;
        }
    }


    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static void OnCallbackTask(
            CreatePipelineAsyncStatus status, RenderPipelineHandle renderPipelineHandle,
            StringViewFFI message, void* userdata, void* _)
    {
        TaskCompletionSource<RenderPipelineHandle>? taskCompletionSource = null;
        try
        {

            taskCompletionSource = (TaskCompletionSource<RenderPipelineHandle>?)ConsumeUserDataIntoObject(userdata);
            ReadOnlySpan<byte> messageSpan = message.AsSpan();
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
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static void OnCallbackDelegate(
        CreatePipelineAsyncStatus status, RenderPipelineHandle renderPipelineHandle,
        StringViewFFI message, void* userdata, void* _)
    {
        try
        {
            var callback = (Action<CreatePipelineAsyncStatus, RenderPipelineHandle, ReadOnlySpan<byte>>?)ConsumeUserDataIntoObject(userdata);
            ReadOnlySpan<byte> messageSpan = message.AsSpan();
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
    }
}