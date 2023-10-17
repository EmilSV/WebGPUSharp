using System.Diagnostics;
using System.Runtime.CompilerServices;
using WebGpuSharp.FFI;

namespace WebGpuSharp.Internal;

public unsafe class VertexBufferLayoutMarshal :
    IWebGPUMarshal<VertexBufferLayout, VertexBufferLayoutFFI, VertexBufferLayoutMarshal.Cache>
{
    public struct Cache { };

    public static void MarshalTo(in VertexBufferLayout item, ref VertexBufferLayoutFFI ffiItem)
    {
        nuint attributeCount = 0;
        VertexAttribute* attributes = null;
        if (item.Attributes != null)
        {
            attributeCount = (nuint)item.Attributes.Count;
            attributes = item.Attributes.GetPointerToPinedArray();
        }

        ffiItem = new VertexBufferLayoutFFI(
            arrayStride: item.ArrayStride,
            stepMode: item.StepMode,
            attributeCount: attributeCount,
            attributes: attributes
        );
    }

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

    public static void MarshalTemporaryTo(
        in VertexBufferLayout item,
        ref VertexBufferLayoutFFI ffiItem, WebGpuAllocatorHandle _)
    {
        MarshalTo(item, ref ffiItem);
    }

    public static void MarshalTemporaryTo(
        ReadOnlySpan<VertexBufferLayout> items,
        Span<VertexBufferLayoutFFI> ffiItems, WebGpuAllocatorHandle allocator)
    {
        MarshalTo(items, ffiItems);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void MarkDirty(ref VertexBufferLayout newItem, in VertexBufferLayout oldItem) { }

    public static void MarkDirty(ref VertexBufferLayout newItem, in VertexBufferLayout oldItem, ref Cache cache)
    {
        MarkDirty(ref newItem, oldItem);
    }

    public static void MarshalTo(in VertexBufferLayout item, ref VertexBufferLayoutFFI ffiItem, ref Cache cache)
    {
        MarshalTo(item, ref ffiItem);
    }

    public static void MarshalTo(ReadOnlySpan<VertexBufferLayout> items, Span<VertexBufferLayoutFFI> ffiItems, Span<Cache> caches)
    {
        MarshalTo(items, ffiItems);
    }
}