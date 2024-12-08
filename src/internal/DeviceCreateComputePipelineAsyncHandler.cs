using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using WebGpuSharp.FFI;

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
            CallbackUserDataHandle userDataHandle = CallbackUserDataHandle.Alloc(callback);
            WebGPU_FFI.DeviceCreateComputePipelineAsync(
                device: device,
                descriptor: descriptorPtr,
                callback: &OnCallbackDelegate,
                userdata: (void*)userDataHandle
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
            CallbackUserDataHandle userDataHandle = CallbackUserDataHandle.Alloc(taskCompletionSource);
            WebGPU_FFI.DeviceCreateComputePipelineAsync(
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
            CreatePipelineAsyncStatus status, ComputePipelineHandle computePipelineHandle,
            StringViewFFI message, void* userdata)
    {
        CallbackUserDataHandle handle = (CallbackUserDataHandle)userdata;
        TaskCompletionSource<ComputePipelineHandle>? taskCompletionSource = null;
        try
        {

            taskCompletionSource = (TaskCompletionSource<ComputePipelineHandle>?)handle.GetObject();
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
            if (handle.IsValid())
            {
                handle.Dispose();
            }
        }
    }

    [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
    private static void OnCallbackDelegate(
        CreatePipelineAsyncStatus status, ComputePipelineHandle computePipelineHandle,
        StringViewFFI message, void* userdata)
    {
        CallbackUserDataHandle handle = (CallbackUserDataHandle)userdata;
        CreateComputePipelineAsyncDelegate<ComputePipelineHandle>? callback = null;
        try
        {

            callback = (CreateComputePipelineAsyncDelegate<ComputePipelineHandle>?)handle.GetObject();
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