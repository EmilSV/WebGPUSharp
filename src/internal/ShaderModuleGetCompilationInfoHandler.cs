using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using WebGpuSharp.FFI;
using WebGpuSharp.Internal;
using static WebGpuSharp.FFI.WebGPUMarshal;

namespace WebGpuSharp;

public unsafe static class ShaderModuleGetCompilationInfoHandler
{
    public static void GetCompilationInfo(ShaderModuleHandle handle, CompilationInfoCallback callback)
    {
        WebGPU_FFI.ShaderModuleGetCompilationInfo2(handle, new()
        {
            Mode = CallbackMode.AllowSpontaneous,
            Callback = &OnCallback,
            Userdata1 = AllocUserData(callback),
            Userdata2 = null
        });
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

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    public static void OnCallback(
        CompilationInfoRequestStatus status, CompilationInfoFFI* compilationInfo, void* userdata, void* _)
    {
        try
        {
            CompilationInfoCallback? callback = (CompilationInfoCallback?)GetObjectFromUserData(userdata);
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
        finally
        {
            FreeUserData(userdata);
        }
    }
}
