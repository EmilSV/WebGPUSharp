using WebGpuSharp.FFI;


namespace WebGpuSharp;

public readonly unsafe ref struct BufferReadWriteContext
{
    private readonly ReadOnlySpan<BufferBase> _buffersUsedInContext;

    internal BufferReadWriteContext(ReadOnlySpan<BufferBase> buffersUsedInContext)
    {
        _buffersUsedInContext = buffersUsedInContext;
    }

    public readonly bool HasBuffer(BufferBase buffer)
    {
        foreach (var item in _buffersUsedInContext)
        {
            if (item == buffer)
            {
                return true;
            }
        }

        return false;
    }

    /// <param name="buffer">The buffer to get const mapped range from.</param>
    /// <inheritdoc cref="BufferHandle.GetConstMappedRange(nuint, nuint)"/>
    public readonly ReadOnlySpan<T> GetConstMappedRange<T>(BufferBase buffer, nuint offset, nuint size)
        where T : unmanaged
    {
        nuint offsetInBytes = offset * (nuint)sizeof(T);
        nuint sizeInBytes = size * (nuint)sizeof(T);

        foreach (BufferBase item in _buffersUsedInContext)
        {
            if (item == buffer)
            {
                void* ptr = WebGPUMarshal.GetBorrowHandle(buffer).GetConstMappedRange(offsetInBytes, sizeInBytes);
                if (ptr == null)
                {
                    return [];
                }

                return new ReadOnlySpan<T>(ptr, (int)size);
            }
        }

        throw new WebGPUNotInReadWriteContext("Buffer is not in read/write context");
    }

    /// <param name="buffer">The buffer to get const mapped range from.</param>
    /// <inheritdoc cref="BufferHandle.GetMappedRange(nuint, nuint)"/>
    public readonly Span<T> GetMappedRange<T>(BufferBase buffer, nuint offset, nuint size)
        where T : unmanaged
    {
        nuint offsetInBytes = offset * (nuint)sizeof(T);
        nuint sizeInBytes = size * (nuint)sizeof(T);

        foreach (var item in _buffersUsedInContext)
        {
            if (item == buffer)
            {
                void* ptr = WebGPUMarshal.GetBorrowHandle(buffer).GetMappedRange(offsetInBytes, sizeInBytes);
                if (ptr == null)
                {
                    return [];
                }

                return new Span<T>(ptr, (int)size);
            }
        }

        throw new WebGPUNotInReadWriteContext("Buffer is not in read/write context");
    }
}