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
                callback: &OnCallbackDelegate,
                userdata: AllocUserData(callback)
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
                callback: &OnCallbackTask,
                userdata: AllocUserData(taskCompletionSource)
            );

            return taskCompletionSource.Task;
        }
    }


    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static void OnCallbackTask(
            CreatePipelineAsyncStatus status, ComputePipelineHandle computePipelineHandle,
            StringViewFFI message, void* userdata)
    {
        TaskCompletionSource<ComputePipelineHandle>? taskCompletionSource = null;
        try
        {
            taskCompletionSource = (TaskCompletionSource<ComputePipelineHandle>?)GetObjectFromUserData(userdata);
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
        finally
        {
            FreeUserData(userdata);
        }
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static void OnCallbackDelegate(
        CreatePipelineAsyncStatus status, ComputePipelineHandle computePipelineHandle,
        StringViewFFI message, void* userdata)
    {
        try
        {

            var callback = (CreateComputePipelineAsyncDelegate<ComputePipelineHandle>?)GetObjectFromUserData(userdata);
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
        finally
        {
            FreeUserData(userdata);
        }
    }
}