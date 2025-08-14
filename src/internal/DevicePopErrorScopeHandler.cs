using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using WebGpuSharp.FFI;
using static WebGpuSharp.Marshalling.WebGPUMarshal;

namespace WebGpuSharp.Internal;

internal unsafe static class DevicePopErrorScopeHandler
{
    public static void DevicePopErrorScope(DeviceHandle device, Action<ErrorType, ReadOnlySpan<byte>> callback)
    {
        WebGPU_FFI.DevicePopErrorScope(
           device: device,
           callbackInfo: new()
           {
               NextInChain = null,
               Mode = CallbackMode.AllowSpontaneous,
               Callback = &OnDevicePopErrorScopeDelegate,
               Userdata1 = AllocUserData(callback),
               Userdata2 = null
           }
        );
    }

    public static Task<(ErrorType errorType, string message)> DevicePopErrorScope(DeviceHandle device)
    {
        TaskCompletionSource<(ErrorType errorType, string message)> taskCompletionSource = new();

        WebGPU_FFI.DevicePopErrorScope(
            device: device,
            callbackInfo: new()
            {
                NextInChain = null,
                Mode = CallbackMode.AllowSpontaneous,
                Callback = &OnDevicePopErrorScopeTask,
                Userdata1 = AllocUserData(taskCompletionSource),
                Userdata2 = null
            }
        );
        return taskCompletionSource.Task;
    }


    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static void OnDevicePopErrorScopeDelegate(
        PopErrorScopeStatus errorScopeStatus, ErrorType errorType, StringViewFFI message,
        void* userdata, void* _)
    {
        try
        {
            var callback = (Action<ErrorType, ReadOnlySpan<byte>>?)ConsumeUserDataIntoObject(userdata);
            ReadOnlySpan<byte> messageSpan = message.AsSpan();
            callback?.Invoke(errorType, messageSpan);
        }
        catch (Exception)
        {

        }
    }
    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static void OnDevicePopErrorScopeTask(
        PopErrorScopeStatus errorScopeStatus, ErrorType errorType, StringViewFFI message,
        void* userdata, void* _)
    {
        try
        {
            var callback = (TaskCompletionSource<(ErrorType errorType, string message)>?)ConsumeUserDataIntoObject(userdata);
            ReadOnlySpan<byte> messageSpan = message.AsSpan();
            callback?.SetResult((errorType, Encoding.UTF8.GetString(messageSpan)));
        }
        catch (Exception)
        {

        }
    }
}
