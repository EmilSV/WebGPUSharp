using System.Diagnostics;
using System.Runtime.CompilerServices;
using WebGpuSharp.Marshalling;

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

    /// <inheritdoc cref="SetLabel(StringViewFFI)"/>
    public void SetLabel(WGPURefText label)
    {
        WebGpuAllocatorLogicBlock allocatorLogicBlock = default;
        const int stackAllocSize = 16 * sizeof(byte);
        byte* stackAllocPtr = stackalloc byte[stackAllocSize];

        using var allocator = WebGpuMarshallingMemory.GetAllocatorHandle(
            ref allocatorLogicBlock,
            stackAllocPtr,
            stackAllocSize
        );

        var labelUtf8Span = WebGPUMarshal.ToUtf8Span(label, allocator, addNullTerminator: false);

        fixed (byte* labelPtr = labelUtf8Span)
        {
            WebGPU_FFI.CommandBufferSetLabel(this, StringViewFFI.CreateExplicitlySized(labelPtr, labelUtf8Span.Length));
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
