using System.Runtime.CompilerServices;

namespace WebGpuSharp.Internal;

public abstract class WebGPUHandleWrapperBase<THandle>
{
    protected abstract THandle Handle { get; }
    protected abstract bool HandleWrapperSameLifetime { get; }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static bool GetHandleWrapperSameLifetime(WebGPUHandleWrapperBase<THandle> handleWrapper)
    {
        return handleWrapper.HandleWrapperSameLifetime;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static THandle GetHandle(WebGPUHandleWrapperBase<THandle> handleWrapper)
    {
        return handleWrapper.Handle;
    }
}
