using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using WebGpuSharp.FFI;
using WebGpuSharp.Internal;
using static WebGpuSharp.Marshalling.WebGPUMarshal;

namespace WebGpuSharp;

public unsafe static class ShaderModuleGetCompilationInfoHandler
{
    public static void GetCompilationInfo(ShaderModuleHandle handle, Action<CompilationInfoRequestStatus, CompilationInfo> callback)
    {
        WebGPU_FFI.ShaderModuleGetCompilationInfo(handle, new()
        {
            Mode = CallbackMode.AllowSpontaneous,
            Callback = &OnCallback,
            Userdata1 = AllocUserData(callback),
            Userdata2 = null
        });
    }


    public static Task<T> GetCompilationInfoAsync<T>(ShaderModuleHandle handle, Func<CompilationInfoRequestStatus, CompilationInfo, T> callback)
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

    public static Task GetCompilationInfoAsync(ShaderModuleHandle handle, Action<CompilationInfoRequestStatus, CompilationInfo> callback)
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

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static void OnCallback(
        CompilationInfoRequestStatus status, CompilationInfoFFI* compilationInfo, void* userdata, void* _)
    {
        try
        {
            Action<CompilationInfoRequestStatus, CompilationInfo>? callback = (Action<CompilationInfoRequestStatus, CompilationInfo>?)ConsumeUserDataIntoObject(userdata);
            if (callback == null)
            {
                return;
            }
            callback(status, new CompilationInfo(in *compilationInfo));
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine(ex);
        }
    }
}
