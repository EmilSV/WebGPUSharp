using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace WebGpuSharp.FFI;

public readonly unsafe partial struct CommandBufferHandle :
    IWebGpuHandle<CommandBufferHandle>, IDisposable
{
    public static ref nuint AsPointer(ref CommandBufferHandle handle)
    {
        Debug.Assert(sizeof(CommandBufferHandle) == sizeof(nuint));
        return ref Unsafe.As<CommandBufferHandle, UIntPtr>(ref handle);
    }

    public static CommandBufferHandle GetNullHandle()
    {
        return Null;
    }

    public static bool IsNull(CommandBufferHandle handle)
    {
        return handle == Null;
    }

    public static void Reference(CommandBufferHandle handle)
    {
        WebGPU_FFI.CommandBufferAddRef(handle);
    }

    public static void Release(CommandBufferHandle handle)
    {
        WebGPU_FFI.CommandBufferRelease(handle);
    }

    public static CommandBufferHandle UnsafeFromPointer(nuint pointer)
    {
        return new CommandBufferHandle(pointer);
    }

    public void SetLabel(WGPURefText label)
    {
        using WebGpuAllocatorHandle allocator = WebGpuAllocatorHandle.Get();

        var labelUtf8Span = WebGPUMarshal.ToUtf8Span(label, allocator, addNullTerminator: false);

        fixed (byte* labelPtr = labelUtf8Span)
        {
            WebGPU_FFI.CommandBufferSetLabel(this, new(labelPtr, labelUtf8Span.Length));
        }
    }

    public void Dispose()
    {
        if (_ptr != UIntPtr.Zero)
        {
            WebGPU_FFI.CommandBufferRelease(this);
        }
    }

    public CommandBuffer ToSafeHandle()
    {
        return CommandBuffer.FromHandle(this);
    }
}
