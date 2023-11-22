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
