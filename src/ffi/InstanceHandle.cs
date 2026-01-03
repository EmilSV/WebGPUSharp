#pragma warning disable CS0162 // Unreachable code detected  

using System.Buffers;
using System.IO.Compression;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Unicode;
using WebGpuSharp.Internal;
using WebGpuSharp.Marshalling;
using static WebGpuSharp.Marshalling.WebGPUMarshal;
namespace WebGpuSharp.FFI;


public readonly unsafe partial struct InstanceHandle :
    IDisposable, IWebGpuHandle<InstanceHandle>
{

    /// <inheritdoc cref="CreateSurface(SurfaceDescriptorFFI*)"/>
    public SurfaceHandle CreateSurface(in SurfaceDescriptorFFI descriptor)
    {
        fixed (SurfaceDescriptorFFI* surfaceDescriptorPtr = &descriptor)
        {
            return WebGPU_FFI.InstanceCreateSurface(this, surfaceDescriptorPtr);
        }
    }

    /// <inheritdoc cref="CreateSurface(SurfaceDescriptorFFI*)"/>
    public SurfaceHandle CreateSurface(SurfaceDescriptor descriptor)
    {
        WebGpuAllocatorLogicBlock allocatorLogicBlock = default;
        const int stackAllocSize = 16 * sizeof(byte);
        byte* stackAllocPtr = stackalloc byte[stackAllocSize];

        using var allocator = WebGpuMarshallingMemory.GetAllocatorHandle(
            ref allocatorLogicBlock,
            stackAllocPtr,
            stackAllocSize
        );

        ref var next = ref descriptor._next;

        var labelUtf8Span = ToUtf8Span(descriptor.Label, allocator, addNullTerminator: true);

        fixed (byte* labelPtr = labelUtf8Span)
        fixed (ChainedStruct* nextPtr = &next)
        {
            SurfaceDescriptorFFI surfaceDescriptor = new()
            {
                NextInChain = nextPtr,
                Label = StringViewFFI.CreateExplicitlySized(labelPtr, labelUtf8Span.Length)
            };
            return WebGPU_FFI.InstanceCreateSurface(this, &surfaceDescriptor);
        }
    }

    public static ref nuint AsPointer(ref InstanceHandle handle)
    {
        return ref Unsafe.AsRef(in handle._ptr);
    }

    public static InstanceHandle GetNullHandle()
    {
        return Null;
    }

    public static bool IsNull(InstanceHandle handle)
    {
        return handle == Null;
    }

    public static InstanceHandle UnsafeFromPointer(nuint pointer)
    {
        return new InstanceHandle(pointer);
    }

    public static void Reference(InstanceHandle handle)
    {
        WebGPU_FFI.InstanceAddRef(handle);
    }

    public static void Release(InstanceHandle handle)
    {
        WebGPU_FFI.InstanceRelease(handle);
    }

    
    public void Dispose()
    {
        if (_ptr != UIntPtr.Zero)
        {
            WebGPU_FFI.InstanceRelease(this);
        }
    }

}