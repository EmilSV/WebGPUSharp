using System.Runtime.CompilerServices;

namespace WebGpuSharp.FFI;

public readonly partial struct SwapChainHandle :
    IDisposable, IWebGpuHandle<SwapChainHandle, SwapChain>
{
    public TextureViewHandle GetCurrentTextureView() => WebGPU_FFI.SwapChainGetCurrentTextureView(this);
    public TextureHandle GetCurrentTexture() => WebGPU_FFI.SwapChainGetCurrentTexture(this);
    public void Present() => WebGPU_FFI.SwapChainPresent(this);

    public void Dispose()
    {
        if (_ptr != UIntPtr.Zero)
        {
            WebGPU_FFI.SwapChainRelease(this);
        }
    }

    public SwapChain? ToSafeHandle(bool incrementReferenceCount) =>
         SwapChain.FromHandle(this, incrementReferenceCount);


    public static ref nuint AsPointer(ref SwapChainHandle handle)
    {
        return ref Unsafe.AsRef(handle._ptr);
    }

    public static SwapChainHandle GetNullHandle()
    {
        return Null;
    }

    public static bool IsNull(SwapChainHandle handle)
    {
        return handle == Null;
    }

    public static SwapChainHandle UnsafeFromPointer(nuint pointer)
    {
        return new SwapChainHandle(pointer);
    }

    public static void Reference(SwapChainHandle handle)
    {
        WebGPU_FFI.SwapChainReference(handle);
    }

    public static void Release(SwapChainHandle handle)
    {
        WebGPU_FFI.SwapChainRelease(handle);
    }
}