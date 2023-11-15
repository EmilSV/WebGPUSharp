using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using WebGpuSharp.FFI;

namespace WebGpuSharp.Internal;

internal unsafe static class QueueOnSubmittedWorkDoneHandler
{
    public static void QueueOnSubmittedWorkDone(
        QueueHandle queue, ulong signalValue, Action<QueueWorkDoneStatus> callback)
    {
        CallbackUserDataHandle callbackHandle = CallbackUserDataHandle.Alloc(callback);

        WebGPU_FFI.QueueOnSubmittedWorkDone(queue, signalValue, &OnQueueOnSubmittedWorkDoneDelegate, (void*)callbackHandle);
    }

    public static Task<QueueWorkDoneStatus> QueueOnSubmittedWorkDone(QueueHandle queue, ulong signalValue)
    {
        TaskCompletionSource<QueueWorkDoneStatus> taskCompletionSource = new();
        CallbackUserDataHandle taskCompletionSourceHandle = CallbackUserDataHandle.Alloc(taskCompletionSource);
        WebGPU_FFI.QueueOnSubmittedWorkDone(queue, signalValue, &OnQueueOnSubmittedWorkDoneTask, (void*)taskCompletionSourceHandle);
        return taskCompletionSource.Task;
    }


    [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
    private static void OnQueueOnSubmittedWorkDoneDelegate(QueueWorkDoneStatus status, void* userdata)
    {
        CallbackUserDataHandle handle = (CallbackUserDataHandle)userdata;
        Action<QueueWorkDoneStatus>? callback;
        try
        {
            callback = (Action<QueueWorkDoneStatus>?)handle.GetObject();
            if (callback != null)
            {
                callback.Invoke(status);
            }
            else
            {
                handle.Dispose();
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


    [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
    private static void OnQueueOnSubmittedWorkDoneTask(QueueWorkDoneStatus status, void* userdata)
    {
        CallbackUserDataHandle handle = (CallbackUserDataHandle)userdata;
        TaskCompletionSource<QueueWorkDoneStatus>? taskCompletionSource;
        try
        {
            taskCompletionSource = (TaskCompletionSource<QueueWorkDoneStatus>?)handle.GetObject();
            if (taskCompletionSource != null)
            {
                taskCompletionSource.SetResult(status);
            }
            else
            {
                handle.Dispose();
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