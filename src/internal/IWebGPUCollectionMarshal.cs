using WebGpuSharp.FFI;

namespace WebGpuSharp.Internal;

public interface IWebGPUCollectionMarshal<TManaged, TFFI, TCache>
    where TFFI : unmanaged
    where TCache : struct
{
    public abstract static void MarshalTo(in TManaged item, ref TFFI ffiItem, ref TCache cache);
    public abstract static void MarshalTo(in TManaged item, ref TFFI ffiItem);
    public abstract static void MarshalTemporaryTo(in TManaged item, ref TFFI ffiItem, WebGpuAllocatorHandle allocator);

    public abstract static void MarshalTo(ReadOnlySpan<TManaged> items, Span<TFFI> ffiItems, Span<TCache> caches);
    public abstract static void MarshalTo(ReadOnlySpan<TManaged> items, Span<TFFI> ffiItems);

    public abstract static void MarshalTemporaryTo(ReadOnlySpan<TManaged> items, Span<TFFI> ffiItems, WebGpuAllocatorHandle allocator);

    public abstract static void MarkDirty(ref TManaged newItem, in TManaged oldItem, ref TCache cache);
    public abstract static void MarkDirty(ref TManaged newItem, in TManaged oldItem);

    public abstract static bool NeedsCache();
}

