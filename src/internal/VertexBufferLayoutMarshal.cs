using System.Diagnostics;
using System.Runtime.CompilerServices;
using WebGpuSharp.FFI;

namespace WebGpuSharp.Internal;

public unsafe class VertexBufferLayoutMarshal :
    IWebGPUCollectionMarshal<VertexBufferLayout, VertexBufferLayoutFFI, VertexBufferLayoutMarshal.Cache>
{
    public struct Cache { };

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void MarshalTo(in VertexBufferLayout item, ref VertexBufferLayoutFFI ffiItem)
    {
        nuint attributeCount = 0;
        VertexAttribute* attributes = null;
        if (item.Attributes != null)
        {
            attributeCount = (nuint)item.Attributes.Count;
            attributes = item.Attributes.GetPointerToPinedArray();
        }

        ffiItem = new()
        {
            ArrayStride = item.ArrayStride,
            StepMode = item.StepMode,
            AttributeCount = attributeCount,
            Attributes = attributes
        };
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void MarshalTo(ReadOnlySpan<VertexBufferLayout> items, Span<VertexBufferLayoutFFI> ffiItems)
    {
        Debug.Assert(items.Length == ffiItems.Length);

        for (var i = 0; i < items.Length; i++)
        {
            MarshalTo(items[i], ref ffiItems[i]);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool NeedsCache() => false;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void MarshalTemporaryTo(
        in VertexBufferLayout item,
        ref VertexBufferLayoutFFI ffiItem, WebGpuAllocatorHandle _)
    {
        MarshalTo(item, ref ffiItem);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void MarshalTemporaryTo(
        ReadOnlySpan<VertexBufferLayout> items,
        Span<VertexBufferLayoutFFI> ffiItems, WebGpuAllocatorHandle allocator)
    {
        MarshalTo(items, ffiItems);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void MarkDirty(ref VertexBufferLayout newItem, in VertexBufferLayout oldItem) { }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void MarkDirty(ref VertexBufferLayout newItem, in VertexBufferLayout oldItem, ref Cache _) { }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void MarshalTo(in VertexBufferLayout item, ref VertexBufferLayoutFFI ffiItem, ref Cache _)
    {
        MarshalTo(item, ref ffiItem);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void MarshalTo(ReadOnlySpan<VertexBufferLayout> items, Span<VertexBufferLayoutFFI> ffiItems, Span<Cache> _)
    {
        MarshalTo(items, ffiItems);
    }

    public static void UpdateFFIBeforeWebGpuCall(ReadOnlySpan<VertexBufferLayout> items, Span<VertexBufferLayoutFFI> ffiItems, Span<Cache> caches, WebGpuAllocatorHandle allocator)
    { return; }
}