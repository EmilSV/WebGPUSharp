using System.Runtime.CompilerServices;
using WebGpuSharp.Marshalling;
using static WebGpuSharp.Marshalling.WebGPUMarshal;

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

    /// <inheritdoc cref="SetLabel(StringViewFFI)"/>
    public readonly void SetLabel(WGPURefText label)
    {
        WebGpuAllocatorLogicBlock allocatorLogicBlock = default;
        const int stackAllocSize = 16 * sizeof(byte);
        byte* stackAllocPtr = stackalloc byte[stackAllocSize];

        using var allocator = WebGpuMarshallingMemory.GetAllocatorHandle(
            ref allocatorLogicBlock,
            stackAllocPtr,
            stackAllocSize
        );

        var labelUtf8Span = ToUtf8Span(label, allocator, addNullTerminator: false);
        fixed (byte* labelPtr = labelUtf8Span)
        {
            WebGPU_FFI.BindGroupSetLabel(this, StringViewFFI.CreateExplicitlySized(labelPtr, labelUtf8Span.Length));
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

    public BindGroup? ToSafeHandle() => ToSafeHandle<BindGroup, BindGroupHandle>(this);
}
