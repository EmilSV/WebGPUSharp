using System.Buffers;
using WebGpuSharp.FFI;
using GPUBuffer = WebGpuSharp.Buffer;

namespace WebGpuSharp;

public unsafe ref struct BufferReadWriteContext
{
    private readonly ArrayPool<object> _pool;
    private object[]? _buffersUsedInContext;

    internal BufferReadWriteContext(ReadOnlySpan<GPUBuffer> buffersUsedInContext, ArrayPool<object> pool)
    {
        _pool = pool;
        _buffersUsedInContext = pool.Rent(buffersUsedInContext.Length);
        for (int i = 0; i < buffersUsedInContext.Length; i++)
        {
            _buffersUsedInContext[i] = buffersUsedInContext[i];
        }
    }

    internal void Dispose()
    {
        if (_buffersUsedInContext != null)
        {
            _pool.Return(_buffersUsedInContext);
            _buffersUsedInContext = null;
        }
    }

    public readonly ReadOnlySpan<T> GetConstMappedRange<T>(GPUBuffer buffer, nuint offset, nuint size) where T : unmanaged
    {
        if (_buffersUsedInContext == null)
        {
            throw new ObjectDisposedException(nameof(BufferReadWriteContext));
        }

        nuint offsetInBytes = offset * (nuint)sizeof(T);
        nuint sizeInBytes = size * (nuint)sizeof(T);

        for (int i = 0; i < _buffersUsedInContext.Length; i++)
        {
            if (_buffersUsedInContext[i] == buffer)
            {
                void* ptr = WebGPUMarshal.GetBorrowHandle(buffer).GetConstMappedRange(offsetInBytes, sizeInBytes);
                if (ptr == null)
                {
                    return [];
                }

                return new ReadOnlySpan<T>(ptr, (int)size);
            }
        }

        return [];
    }


    public readonly ReadOnlySpan<T> GetMappedRange<T>(GPUBuffer buffer, nuint offset, nuint size) where T : unmanaged
    {
        if (_buffersUsedInContext == null)
        {
            throw new ObjectDisposedException(nameof(BufferReadWriteContext));
        }

        nuint offsetInBytes = offset * (nuint)sizeof(T);
        nuint sizeInBytes = size * (nuint)sizeof(T);

        for (int i = 0; i < _buffersUsedInContext.Length; i++)
        {
            if (_buffersUsedInContext[i] == buffer)
            {
                void* ptr = WebGPUMarshal.GetBorrowHandle(buffer).GetMappedRange(offsetInBytes, sizeInBytes);
                if (ptr == null)
                {
                    return [];
                }

                return new ReadOnlySpan<T>(ptr, (int)size);
            }
        }

        return [];
    }
}