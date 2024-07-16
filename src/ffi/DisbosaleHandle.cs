namespace WebGpuSharp.FFI;

public unsafe readonly struct DisposableHandle : IDisposable
{
    private DisposableHandle(
            UIntPtr handlePtr,
            delegate*<UIntPtr, void> disposeFunc
    )
    {
        _handlePtr = handlePtr;
        _disposeFunc = disposeFunc;
    }

    private readonly UIntPtr _handlePtr;
    private readonly delegate*<UIntPtr, void> _disposeFunc;

    public void Dispose()
    {
        if (_disposeFunc != null)
        {
            _disposeFunc(_handlePtr);
        }
    }

    public static DisposableHandle FromHandle<THandle>(THandle handle)
        where THandle : unmanaged, IWebGpuHandle<THandle>
    {
        return new DisposableHandle(
            THandle.AsPointer(ref handle),
            (delegate*<UIntPtr, void>)(delegate*<THandle, void>)&THandle.Release
        );
    }
}