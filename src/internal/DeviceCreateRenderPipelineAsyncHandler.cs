using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using WebGpuSharp.FFI;
using static WebGpuSharp.FFI.WebGPUMarshal;

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
            WebGPU_FFI.DeviceCreateRenderPipelineAsync(
                device: device,
                descriptor: descriptorPtr,
                callback: &OnCallbackDelegate,
                userdata: AllocUserData(callback)
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
            WebGPU_FFI.DeviceCreateRenderPipelineAsync(
                device: device,
                descriptor: descriptorPtr,
                callback: &OnCallbackTask,
                userdata: AllocUserData(taskCompletionSource)
            );

            return taskCompletionSource.Task;
        }
    }


    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static void OnCallbackTask(
            CreatePipelineAsyncStatus status, RenderPipelineHandle renderPipelineHandle,
            StringViewFFI message, void* userdata)
    {
        TaskCompletionSource<RenderPipelineHandle>? taskCompletionSource = null;
        try
        {

            taskCompletionSource = (TaskCompletionSource<RenderPipelineHandle>?)GetObjectFromUserData(userdata);
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
        finally
        {
            FreeUserData(userdata);
        }
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static void OnCallbackDelegate(
        CreatePipelineAsyncStatus status, RenderPipelineHandle renderPipelineHandle,
        StringViewFFI message, void* userdata)
    {
        try
        {
            var callback = (CreateRenderPipelineAsyncDelegate<RenderPipelineHandle>?)GetObjectFromUserData(userdata);
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
        finally
        {
            FreeUserData(userdata);
        }
    }
}