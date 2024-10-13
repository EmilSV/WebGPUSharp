using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using WebGpuSharp.FFI;

namespace WebGpuSharp.Internal;

public unsafe class ConstantEntryCollectionMarshal :
    IWebGPUCollectionMarshal<ConstantEntry, ConstantEntryFFI, ConstantEntryCollectionMarshal.Cache>
{
    public struct Cache
    {
        public byte[]? keyAsUtf8;
        public bool dirty;
    }

    private const int MinKeyAsUtf8Length = 16;

    public static void MarshalTemporaryTo(in ConstantEntry item, ref ConstantEntryFFI ffiItem, WebGpuAllocatorHandle allocator)
    {
        ffiItem = new()
        {
            Key = WebGPUMarshal.ToFFI(item.Key, allocator),
            Value = item.Value
        };
    }

    public static void MarshalTemporaryTo(ReadOnlySpan<ConstantEntry> items, Span<ConstantEntryFFI> ffiItems, WebGpuAllocatorHandle allocator)
    {
        Debug.Assert(items.Length == ffiItems.Length);

        for (var i = 0; i < items.Length; i++)
        {
            MarshalTemporaryTo(items[i], ref ffiItems[i], allocator);
        }
    }

    public static void MarshalTo(in ConstantEntry item, ref ConstantEntryFFI ffiItem, ref Cache cache)
    {
        StringViewFFI key;
        if (cache.keyAsUtf8 == null || cache.dirty)
        {
            int newUtf8Size = Encoding.UTF8.GetByteCount(item.Key);
            int allocSize = Math.Max(newUtf8Size, MinKeyAsUtf8Length);
            byte[]? utf8Bytes = cache.keyAsUtf8;
            if (utf8Bytes == null || utf8Bytes.Length < allocSize)
            {
                utf8Bytes = GC.AllocateUninitializedArray<byte>(allocSize, pinned: true);
                cache.keyAsUtf8 = utf8Bytes;
            }
            key = new((byte*)Unsafe.AsPointer(ref cache.keyAsUtf8![0]), (uint)cache.keyAsUtf8.Length);
            cache.dirty = false;
        }
        else
        {
            key = new((byte*)Unsafe.AsPointer(ref cache.keyAsUtf8![0]), (uint)cache.keyAsUtf8.Length);
        }

        ffiItem = new()
        {
            Key = key,
            Value = item.Value
        };
    }

    public static void MarshalTo(in ConstantEntry item, ref ConstantEntryFFI ffiItem)
    {
        throw new NotSupportedException();
    }

    public static void MarshalTo(ReadOnlySpan<ConstantEntry> items, Span<ConstantEntryFFI> ffiItems, Span<Cache> caches)
    {
        Debug.Assert(items.Length == ffiItems.Length);

        for (var i = 0; i < items.Length; i++)
        {
            MarshalTo(items[i], ref ffiItems[i]);
        }
    }

    public static void MarshalTo(ReadOnlySpan<ConstantEntry> items, Span<ConstantEntryFFI> ffiItems)
    {
        throw new NotSupportedException();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool NeedsCache()
    {
        return true;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void MarkDirty(ref ConstantEntry newItem, in ConstantEntry oldItem, ref Cache cache)
    {
        cache.dirty &= newItem.Key != oldItem.Key;
    }

    public static void MarkDirty(ref ConstantEntry newItem, in ConstantEntry oldItem)
    {
        throw new NotSupportedException();
    }

    public static void UpdateFFIBeforeWebGpuCall(ReadOnlySpan<ConstantEntry> items, Span<ConstantEntryFFI> ffiItems, Span<Cache> caches, WebGpuAllocatorHandle allocator)
    { return; }
}