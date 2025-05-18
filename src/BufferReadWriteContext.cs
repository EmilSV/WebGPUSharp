using System;
using System.Buffers;
using WebGpuSharp.FFI;
using GPUBuffer = WebGpuSharp.BufferBase;

namespace WebGpuSharp;

public unsafe ref struct BufferReadWriteContext
{
    private readonly ArrayPool<object?> _pool;
    private object?[]? _buffersUsedInContext;
    private ReadOnlySpan<object?> _buffersUsedInContextSpan;

    internal BufferReadWriteContext(ReadOnlySpan<GPUBuffer> buffersUsedInContext, ArrayPool<object?> pool)
    {
        _pool = pool;
        _buffersUsedInContext = pool.Rent(buffersUsedInContext.Length);
        for (int i = 0; i < buffersUsedInContext.Length; i++)
        {
            _buffersUsedInContext[i] = buffersUsedInContext[i];
        }
        _buffersUsedInContextSpan = _buffersUsedInContext.AsSpan(0, buffersUsedInContext.Length);
    }

    internal void Dispose()
    {
        if (_buffersUsedInContext != null)
        {
            _pool.Return(_buffersUsedInContext);
            _buffersUsedInContextSpan = default;
            _buffersUsedInContext = null;
        }
    }

    public readonly bool HasBuffer(GPUBuffer buffer)
    {
        return _buffersUsedInContext != null && _buffersUsedInContext.Contains(buffer);
    }

    /// <param name="buffer">The buffer to get const mapped range from.</param>
    /// <inheritdoc cref="BufferHandle.GetConstMappedRange(nuint, nuint)"/>
    public readonly ReadOnlySpan<T> GetConstMappedRange<T>(GPUBuffer buffer, nuint offset, nuint size)
        where T : unmanaged
    {
        if (_buffersUsedInContext == null)
        {
            throw new ObjectDisposedException(nameof(BufferReadWriteContext));
        }

        nuint offsetInBytes = offset * (nuint)sizeof(T);
        nuint sizeInBytes = size * (nuint)sizeof(T);

        foreach (GPUBuffer? item in _buffersUsedInContextSpan)
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
    public readonly Span<T> GetMappedRange<T>(GPUBuffer buffer, nuint offset, nuint size) 
        where T : unmanaged
    {
        if (_buffersUsedInContext == null)
        {
            throw new ObjectDisposedException(nameof(BufferReadWriteContext));
        }

        nuint offsetInBytes = offset * (nuint)sizeof(T);
        nuint sizeInBytes = size * (nuint)sizeof(T);

        foreach (var item in _buffersUsedInContextSpan)
        {
            if ((GPUBuffer)item! == buffer)
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