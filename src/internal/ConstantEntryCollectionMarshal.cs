using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using WebGpuSharp.FFI;
using static WebGpuSharp.FFI.WebGPUMarshal;

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
        var keyUtf8Span = ToUtf8Span(item.Key, allocator, addNullTerminator: false);

        fixed (byte* keyPtr = keyUtf8Span)
        {
            ffiItem = new()
            {
                Key = StringViewFFI.CreateExplicitlySized(keyPtr, keyUtf8Span.Length),
                Value = item.Value
            };
        }
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
        if (cache.keyAsUtf8 == null || cache.dirty)
        {
            int newUtf8Size = Encoding.UTF8.GetByteCount(item.Key);
            int allocSize = Math.Max(newUtf8Size + 1, MinKeyAsUtf8Length);
            byte[]? utf8Bytes = cache.keyAsUtf8;
            if (utf8Bytes == null || utf8Bytes.Length < allocSize)
            {
                utf8Bytes = GC.AllocateUninitializedArray<byte>(allocSize, pinned: true);
                cache.keyAsUtf8 = utf8Bytes;
            }
            utf8Bytes[newUtf8Size] = 0;

            cache.dirty = false;
        }

        ffiItem = new()
        {
            Key = StringViewFFI.CreateExplicitlySized((byte*)Unsafe.AsPointer(ref cache.keyAsUtf8![0]), cache.keyAsUtf8.Length),
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