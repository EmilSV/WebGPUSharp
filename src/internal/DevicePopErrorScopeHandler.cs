using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using WebGpuSharp.FFI;
using static WebGpuSharp.FFI.WebGPUMarshal;

namespace WebGpuSharp.Internal;

internal unsafe static class DevicePopErrorScopeHandler
{
    public static void DevicePopErrorScope(DeviceHandle device, DevicePopErrorScopeDelegate callback)
    {
        WebGPU_FFI.DevicePopErrorScope(device, &OnDevicePopErrorScopeDelegate, AllocUserData(callback));
    }

    public static Task<(ErrorType errorType, string message)> DevicePopErrorScope(DeviceHandle device)
    {
        TaskCompletionSource<(ErrorType errorType, string message)> taskCompletionSource = new();
        WebGPU_FFI.DevicePopErrorScope(device, &OnDevicePopErrorScopeTask, AllocUserData(taskCompletionSource));
        return taskCompletionSource.Task;
    }


    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static void OnDevicePopErrorScopeDelegate(ErrorType errorType, StringViewFFI message, void* userdata)
    {
        try
        {
            var callback = (DevicePopErrorScopeDelegate?)GetObjectFromUserData(userdata);
            ReadOnlySpan<byte> messageSpan = message.AsSpan();
            callback?.Invoke(errorType, messageSpan);
        }
        catch (Exception)
        {

        }
        finally
        {
            FreeUserData(userdata);
        }
    }
    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static void OnDevicePopErrorScopeTask(ErrorType errorType, StringViewFFI message, void* userdata)
    {
        try
        {
            var callback = (TaskCompletionSource<(ErrorType errorType, string message)>?)GetObjectFromUserData(userdata);
            ReadOnlySpan<byte> messageSpan = message.AsSpan();
            callback?.SetResult((errorType, Encoding.UTF8.GetString(messageSpan)));
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
