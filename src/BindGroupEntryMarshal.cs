using System.Diagnostics;
using System.Runtime.CompilerServices;
using WebGpuSharp.FFI;
using static WebGpuSharp.WebGPUMarshal;

namespace WebGpuSharp.Internal;

public unsafe class BindGroupEntryCollectionMarshal :
    IWebGPUCollectionMarshal<BindGroupEntry, BindGroupEntryFFI, BindGroupEntryCollectionMarshal.Cache>
{
    private BindGroupEntryCollectionMarshal() { }

    public struct Cache { }

    public static void MarshalTo(in BindGroupEntry item, ref BindGroupEntryFFI ffiItem)
    {
        ToFFI(item, out ffiItem);
    }


    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool NeedsCache() => false;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void MarkDirty(ref BindGroupEntry newItem, in BindGroupEntry oldItem, ref Cache cache) { }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void MarkDirty(ref BindGroupEntry newItem, in BindGroupEntry oldItem) { }

    public static void MarshalTo(in BindGroupEntry item, ref BindGroupEntryFFI ffiItem, ref Cache cache)
    {
        MarshalTo(item, ref ffiItem);
    }

    public static void MarshalTemporaryTo(in BindGroupEntry item, ref BindGroupEntryFFI ffiItem, WebGpuAllocatorHandle allocator)
    {
        MarshalTo(item, ref ffiItem);
    }

    public static void MarshalTemporaryTo(ReadOnlySpan<BindGroupEntry> items, Span<BindGroupEntryFFI> ffiItems, WebGpuAllocatorHandle allocator)
    {
        Debug.Assert(items.Length == ffiItems.Length);
        for (var i = 0; i < items.Length; i++)
        {
            MarshalTemporaryTo(items[i], ref ffiItems[i], allocator);
        }
    }

    public static void MarshalTo(ReadOnlySpan<BindGroupEntry> items, Span<BindGroupEntryFFI> ffiItems)
    {
        Debug.Assert(items.Length == ffiItems.Length);
        for (var i = 0; i < items.Length; i++)
        {
            MarshalTo(items[i], ref ffiItems[i]);
        }
    }

    public static void MarshalTo(ReadOnlySpan<BindGroupEntry> items, Span<BindGroupEntryFFI> ffiItems, Span<Cache> caches)
    {
        MarshalTo(items, ffiItems);
    }
}