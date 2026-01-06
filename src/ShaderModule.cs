using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using WebGpuSharp.FFI;
using WebGpuSharp.Internal;
using WebGpuSharp.Marshalling;
using static WebGpuSharp.Marshalling.WebGPUMarshal;

namespace WebGpuSharp;

/// <inheritdoc cref="ShaderModuleHandle"/>
public sealed class ShaderModule :
    WebGPUManagedHandleBase<ShaderModuleHandle>,
    IFromHandleWithInstance<ShaderModule, ShaderModuleHandle>
{
    private readonly Instance _instance;

    private ShaderModule(ShaderModuleHandle handle, Instance instance) : base(handle)
    {
        _instance = instance;
    }

    private Future GetCompilationInfo(
        CallbackMode mode,
        Action<CompilationInfoRequestStatus, CompilationInfo> callback
    )
    {
        unsafe
        {
            void* userdata1 = AllocUserData(callback);
            return WebGPU_FFI.ShaderModuleGetCompilationInfo(Handle, new()
            {
                Mode = mode,
                Callback = &GetCompilationInfoCallbackFunctions.DelegateCallback,
                Userdata1 = userdata1,
                Userdata2 = null
            });
        }
    }
    /// <param name="callback">The callback to be invoked when the compilation info is ready.</param>
    /// <inheritdoc cref="ShaderModuleHandle.GetCompilationInfo(CompilationInfoCallbackInfoFFI)"/>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void GetCompilationInfo(Action<CompilationInfoRequestStatus, CompilationInfo> callback)
    {
        var future = GetCompilationInfo(CallbackMode.WaitAnyOnly, callback);
        _instance._eventHandler.EnqueueCpuFuture(future);
    }

    /// <param name="timeoutNS">The timeout in nanoseconds to wait for the compilation info.</param>
    /// <inheritdoc cref="GetCompilationInfo(Action{CompilationInfoRequestStatus, CompilationInfo})"/>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void GetCompilationInfoSync(
        Action<CompilationInfoRequestStatus, CompilationInfo> callback,
        ulong timeoutNS = ulong.MaxValue)
    {
        var future = GetCompilationInfo(CallbackMode.WaitAnyOnly, callback);
        _instance.WaitAny(future, timeoutNS);
    }

    /// <inheritdoc cref="GetCompilationInfo(Action{CompilationInfoRequestStatus, CompilationInfo})"/>
    /// <returns>A task that represents the asynchronous operation. The task result is the value returned by the callback.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Task<T> GetCompilationInfoAsync<T>(Func<CompilationInfoRequestStatus, CompilationInfo, T> callback)
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
        GetCompilationInfo(innerCallback);
        return tcs.Task;
    }

    static ShaderModule? IFromHandleWithInstance<ShaderModule, ShaderModuleHandle>.FromHandle(
        ShaderModuleHandle handle, Instance instance)
    {
        if (ShaderModuleHandle.IsNull(handle))
        {
            return null;
        }

        ShaderModuleHandle.Reference(handle);
        return new(handle, instance);
    }

    static Instance IFromHandleWithInstance<ShaderModule, ShaderModuleHandle>.GetOwnerInstance(
        ShaderModule instance)
    {
        return instance._instance;
    }
}

file unsafe static class GetCompilationInfoCallbackFunctions
{
    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    public static void DelegateCallback(
        CompilationInfoRequestStatus status,
        CompilationInfoFFI* compilationInfo,
        void* userdata1,
        void* _)
    {
        try
        {
            var callback = (Action<CompilationInfoRequestStatus, CompilationInfo>?)ConsumeUserDataIntoObject(userdata1);
            if (callback == null)
            {
                return;
            }
            CompilationInfo info = new(in *compilationInfo);
            callback(status, info);
        }
        catch
        {
            // Swallow exceptions to avoid crashing native code
        }
    }
}