using System.Diagnostics;
using System.Runtime.CompilerServices;
using WebGpuSharp.FFI;

namespace WebGpuSharp.Internal;

public class BindGroupLayoutCollectionMarshal :
    IWebGPUCollectionMarshal<BindGroupLayout, BindGroupLayoutHandle, BindGroupLayoutCollectionMarshal.Cache>
{
    public struct Cache { }

    public static void MarshalTo(in BindGroupLayout item, ref BindGroupLayoutHandle ffiItem)
    {
        ffiItem = item.GetHandle();
    }


    public static void MarshalTo(ReadOnlySpan<BindGroupLayout> items, Span<BindGroupLayoutHandle> ffiItems)
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
    public static void MarkDirty(ref BindGroupLayout newItem, in BindGroupLayout oldItem, ref Cache cache) { }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void MarkDirty(ref BindGroupLayout newItem, in BindGroupLayout oldItem) { }
    public static void MarshalTemporaryTo(in BindGroupLayout item, ref BindGroupLayoutHandle ffiItem, WebGpuAllocatorHandle allocator)
    {
        MarshalTo(item, ref ffiItem);
    }

    public static void MarshalTo(in BindGroupLayout item, ref BindGroupLayoutHandle ffiItem, ref Cache cache)
    {
        MarshalTo(item, ref ffiItem);
    }

    public static void MarshalTemporaryTo(ReadOnlySpan<BindGroupLayout> items, Span<BindGroupLayoutHandle> ffiItems, WebGpuAllocatorHandle allocator)
    {
        MarshalTo(items, ffiItems);
    }

    public static void MarshalTo(ReadOnlySpan<BindGroupLayout> items, Span<BindGroupLayoutHandle> ffiItems, Span<Cache> caches)
    {
        MarshalTo(items, ffiItems);
    }

    public static void UpdateFFIBeforeWebGpuCall(
        ReadOnlySpan<BindGroupLayout> items,
        Span<BindGroupLayoutHandle> ffiItems,
        Span<Cache> caches,
        WebGpuAllocatorHandle allocator)
    { return; }
}