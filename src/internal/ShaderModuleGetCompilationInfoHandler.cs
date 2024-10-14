using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using WebGpuSharp.FFI;
using WebGpuSharp.Internal;

namespace WebGpuSharp;

public unsafe static class ShaderModuleGetCompilationInfoHandler
{
    public static void GetCompilationInfo(ShaderModuleHandle handle, CompilationInfoCallback callback)
    {
        CallbackUserDataHandle callbackHandle = CallbackUserDataHandle.Alloc(callback);
        WebGPU_FFI.ShaderModuleGetCompilationInfo(handle, &OnCallback, (void*)callbackHandle);
    }

    public static Task<T> GetCompilationInfoAsync<T>(ShaderModuleHandle handle, CompilationInfoCallback<T> callback)
    {
        TaskCompletionSource<T> tcs = new();
        void innerCallback(CompilationInfoRequestStatus status, CompilationInfo info)
        {
            try
            {
                tcs.SetResult(callback(status, info));
            }
            catch (Exception ex)
            {
                tcs.SetException(ex);
            }
        }
        GetCompilationInfo(handle, innerCallback);
        return tcs.Task;
    }

    public static Task GetCompilationInfoAsync(ShaderModuleHandle handle, CompilationInfoCallback callback)
    {
        TaskCompletionSource tcs = new();
        void innerCallback(CompilationInfoRequestStatus status, CompilationInfo info)
        {
            try
            {
                callback(status, info);
                tcs.SetResult();
            }
            catch (Exception ex)
            {
                tcs.SetException(ex);
            }
        }
        GetCompilationInfo(handle, innerCallback);
        return tcs.Task;
    }

    [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static void OnCallback(
        CompilationInfoRequestStatus status, CompilationInfoFFI* compilationInfo, void* userdata)
    {
        using CallbackUserDataHandle handle = (CallbackUserDataHandle)userdata;
        CompilationInfoCallback? callback = null;
        callback = (CompilationInfoCallback?)handle.GetObject();
        if (callback == null)
        {
            return;
        }

        callback(status, new CompilationInfo(in (*compilationInfo)));
    }
}
