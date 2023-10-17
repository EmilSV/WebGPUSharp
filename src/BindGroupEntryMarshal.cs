using System.Diagnostics;
using System.Runtime.CompilerServices;
using WebGpuSharp.FFI;

namespace WebGpuSharp.Internal;

public unsafe class BindGroupEntryMarshal :
    IWebGPUMarshal<BindGroupEntry, BindGroupEntryFFI, BindGroupEntryMarshal.Cache>
{
    private BindGroupEntryMarshal() { }

    public struct Cache { }

    public static void MarshalTo(in BindGroupEntry item, ref BindGroupEntryFFI ffiItem)
    {
        ffiItem = new BindGroupEntryFFI(
            nextInChain: null,
            binding: item.Binding,
            buffer: item.Buffer?.GetHandle() ?? default,
            offset: item.Offset,
            size: item.Size,
            sampler: item.Sampler?.GetHandle() ?? default,
            textureView: item.TextureView?.GetHandle() ?? default
        );
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