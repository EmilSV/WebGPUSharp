using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using WebGpuSharp.FFI;
using static WebGpuSharp.FFI.WebGPUMarshal;

namespace WebGpuSharp.Internal;

internal unsafe static class DeviceCreateComputePipelineAsyncHandler
{
    public static void DeviceCreateComputePipelineAsync(
        DeviceHandle device,
        in ComputePipelineDescriptorFFI descriptor,
        CreateComputePipelineAsyncDelegate<ComputePipelineHandle> callback)
    {
        fixed (ComputePipelineDescriptorFFI* descriptorPtr = &descriptor)
        {
            WebGPU_FFI.DeviceCreateComputePipelineAsync(
                device: device,
                descriptor: descriptorPtr,
                callbackInfo: new()
                {
                    Mode = CallbackMode.AllowSpontaneous,
                    Callback = &OnCallbackDelegate,
                    Userdata1 = AllocUserData(callback),
                    Userdata2 = null
                }
            );
        }
    }

    public static Task<ComputePipelineHandle> DeviceCreateComputePipelineAsync(
        DeviceHandle device,
        in ComputePipelineDescriptorFFI descriptor)
    {
        fixed (ComputePipelineDescriptorFFI* descriptorPtr = &descriptor)
        {
            TaskCompletionSource<ComputePipelineHandle> taskCompletionSource = new();
            WebGPU_FFI.DeviceCreateComputePipelineAsync(
                device: device,
                descriptor: descriptorPtr,
                callbackInfo: new()
                {
                    Mode = CallbackMode.AllowSpontaneous,
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
            CreatePipelineAsyncStatus status, ComputePipelineHandle computePipelineHandle,
            StringViewFFI message, void* userdata, void* _)
    {
        TaskCompletionSource<ComputePipelineHandle>? taskCompletionSource = null;
        try
        {
            taskCompletionSource = (TaskCompletionSource<ComputePipelineHandle>?)ConsumeUserDataIntoObject(userdata);
            ReadOnlySpan<byte> messageSpan = message.AsSpan();

            if (status != CreatePipelineAsyncStatus.Success)
            {
                taskCompletionSource?.SetResult(ComputePipelineHandle.Null);
                return;
            }

            if (taskCompletionSource != null)
            {
                taskCompletionSource.SetResult(computePipelineHandle);
            }
            else
            {
                computePipelineHandle.Dispose();
            }
        }
        catch (Exception e)
        {
            computePipelineHandle.Dispose();
            taskCompletionSource?.SetException(e);
        }
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static void OnCallbackDelegate(
        CreatePipelineAsyncStatus status, ComputePipelineHandle computePipelineHandle,
        StringViewFFI message, void* userdata, void* _)
    {
        try
        {

            var callback = (CreateComputePipelineAsyncDelegate<ComputePipelineHandle>?)ConsumeUserDataIntoObject(userdata);
            ReadOnlySpan<byte> messageSpan = message.AsSpan();
            if (callback != null)
            {
                callback.Invoke(status, computePipelineHandle, messageSpan);
            }
            else
            {
                computePipelineHandle.Dispose();
            }
        }
        catch (Exception)
        {
            computePipelineHandle.Dispose();
        }
    }
}