using System.Runtime.CompilerServices;

namespace WebGpuSharp.FFI;

public readonly unsafe partial struct BindGroupHandle :
    IDisposable, IWebGpuHandle<BindGroupHandle, BindGroup>
{
    public readonly void Dispose()
    {
        if (_ptr != UIntPtr.Zero)
        {
            WebGPU_FFI.BindGroupRelease(this);
        }
    }

    public readonly void SetLabel(WGPURefText label)
    {
        using WebGpuAllocatorHandle allocator = WebGpuAllocatorHandle.Get();

        fixed (byte* labelPtr = WebGPUMarshal.ToRefCstrUtf8(label, allocator))
        {
            WebGPU_FFI.BindGroupSetLabel(this, labelPtr);
        }
    }

    public static ref UIntPtr AsPointer(ref BindGroupHandle handle)
    {
        return ref Unsafe.AsRef(in handle._ptr);
    }

    public static BindGroupHandle GetNullHandle()
    {
        return Null;
    }

    public static bool IsNull(BindGroupHandle handle)
    {
        return handle == Null;
    }

    public static BindGroupHandle UnsafeFromPointer(nuint pointer)
    {
        return new BindGroupHandle(pointer);
    }

    public static void Reference(BindGroupHandle handle)
    {
        WebGPU_FFI.BindGroupAddRef(handle);
    }

    public static void Release(BindGroupHandle handle)
    {
        WebGPU_FFI.BindGroupRelease(handle);
    }

    public BindGroup? ToSafeHandle(bool isOwnedHandle)
    {
        return BindGroup.FromHandle(this, isOwnedHandle);
    }
}
