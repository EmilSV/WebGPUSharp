using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using WebGpuSharp.FFI;

namespace WebGpuSharp.Internal;

internal unsafe static class DevicePopErrorScopeHandler
{
    public static void DevicePopErrorScope(DeviceHandle device, DevicePopErrorScopeDelegate callback)
    {
        CallbackUserDataHandle callbackHandle = CallbackUserDataHandle.Alloc(callback);

        WebGPU_FFI.DevicePopErrorScope(device, &OnDevicePopErrorScopeDelegate, (void*)callbackHandle);
    }

    public static Task<(ErrorType errorType, string message)> DevicePopErrorScope(DeviceHandle device)
    {
        TaskCompletionSource<(ErrorType errorType, string message)> taskCompletionSource = new();
        CallbackUserDataHandle taskCompletionSourceHandle = CallbackUserDataHandle.Alloc(taskCompletionSource);
        WebGPU_FFI.DevicePopErrorScope(device, &OnDevicePopErrorScopeTask, (void*)taskCompletionSourceHandle);
        return taskCompletionSource.Task;
    }


    [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
    private static void OnDevicePopErrorScopeDelegate(ErrorType errorType, byte* message, void* userdata)
    {
        CallbackUserDataHandle handle = (CallbackUserDataHandle)userdata;
        DevicePopErrorScopeDelegate? callback = null;
        try
        {

            callback = (DevicePopErrorScopeDelegate?)handle.GetObject();
            ReadOnlySpan<byte> messageSpan = message != null ?
                MemoryMarshal.CreateReadOnlySpanFromNullTerminated(message) :
                ReadOnlySpan<byte>.Empty;

            if (callback != null)
            {
                callback.Invoke(errorType, messageSpan);
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
    private static void OnDevicePopErrorScopeTask(ErrorType errorType, byte* message, void* userdata)
    {
        CallbackUserDataHandle handle = (CallbackUserDataHandle)userdata;
        TaskCompletionSource<(ErrorType errorType, string message)>? callback = null;
        try
        {

            callback = (TaskCompletionSource<(ErrorType errorType, string message)>?)handle.GetObject();
            ReadOnlySpan<byte> messageSpan = message != null ?
                MemoryMarshal.CreateReadOnlySpanFromNullTerminated(message) :
                ReadOnlySpan<byte>.Empty;

            if (callback != null)
            {
                callback.SetResult((errorType, Encoding.UTF8.GetString(messageSpan)));
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
