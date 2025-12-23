using WebGpuSharp.FFI;
using WebGpuSharp.Marshalling;


namespace WebGpuSharp;

public readonly unsafe ref struct BufferReadWriteContext
{
    private readonly ReadOnlySpan<Buffer> _buffersUsedInContext;

    internal BufferReadWriteContext(ReadOnlySpan<Buffer> buffersUsedInContext)
    {
        _buffersUsedInContext = buffersUsedInContext;
    }

    public readonly bool HasBuffer(Buffer buffer)
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
    public readonly ReadOnlySpan<T> GetConstMappedRange<T>(Buffer buffer, nuint offset, nuint size)
        where T : unmanaged
    {
        nuint offsetInBytes = offset * (nuint)sizeof(T);
        nuint sizeInBytes = size * (nuint)sizeof(T);

        foreach (Buffer item in _buffersUsedInContext)
        {
            if (item == buffer)
            {
                void* ptr = WebGPUMarshal.GetHandle(buffer).GetConstMappedRange(offsetInBytes, sizeInBytes);
                if (ptr == null)
                {
                    return [];
                }

                return new ReadOnlySpan<T>(ptr, (int)size);
            }
        }

        throw new WebGPUNotInReadWriteContextException("Buffer is not in read/write context");
    }


    /// <param name="buffer">The buffer to get const mapped range from.</param>
    /// <inheritdoc cref="BufferHandle.GetConstMappedRange(nuint, nuint)"/>
    public readonly ReadOnlySpan<T> GetConstMappedRange<T>(Buffer buffer)
        where T : unmanaged
    {
        ulong bufferSize = buffer.GetSize();

        foreach (Buffer item in _buffersUsedInContext)
        {
            if (item == buffer)
            {
                void* ptr = WebGPUMarshal.GetHandle(buffer).GetConstMappedRange(0, (nuint)bufferSize);
                if (ptr == null)
                {
                    return [];
                }

                return new ReadOnlySpan<T>(ptr, (int)bufferSize / sizeof(T));
            }
        }

        throw new WebGPUNotInReadWriteContextException("Buffer is not in read/write context");
    }

    /// <param name="buffer">The buffer to get mapped range from.</param>
    /// <inheritdoc cref="BufferHandle.GetMappedRange(nuint, nuint)"/>
    public readonly Span<T> GetMappedRange<T>(Buffer buffer, nuint offset, nuint size)
        where T : unmanaged
    {
        nuint offsetInBytes = offset * (nuint)sizeof(T);
        nuint sizeInBytes = size * (nuint)sizeof(T);

        foreach (var item in _buffersUsedInContext)
        {
            if (item == buffer)
            {
                void* ptr = WebGPUMarshal.GetHandle(buffer).GetMappedRange(offsetInBytes, sizeInBytes);
                if (ptr == null)
                {
                    return [];
                }

                return new Span<T>(ptr, (int)size);
            }
        }

        throw new WebGPUNotInReadWriteContextException("Buffer is not in read/write context");
    }

    /// <param name="buffer">The buffer to get mapped range from.</param>
    /// <inheritdoc cref="BufferHandle.GetMappedRange(nuint, nuint)"/>
    public readonly Span<T> GetMappedRange<T>(Buffer buffer)
        where T : unmanaged
    {
        ulong bufferSize = buffer.GetSize();
        foreach (var item in _buffersUsedInContext)
        {
            if (item == buffer)
            {
                void* ptr = WebGPUMarshal.GetHandle(buffer).GetMappedRange(0, (nuint)bufferSize);
                if (ptr == null)
                {
                    return [];
                }

                return new Span<T>(ptr, (int)bufferSize / sizeof(T));
            }
        }

        throw new WebGPUNotInReadWriteContextException("Buffer is not in read/write context");
    }
}