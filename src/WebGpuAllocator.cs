using System.Buffers;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
namespace WebGpuSharp.Internal;

internal unsafe class WebGpuAllocator
{
    internal static class StructInfo
    {
        // See :https://stackoverflow.com/questions/364483/determining-the-alignment-of-c-c-structures-in-relation-to-its-members
        [StructLayout(LayoutKind.Sequential)]
        private struct AlignmentFinder<T>
            where T : unmanaged
        {
            public byte a;
            public T b;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static nint GetAlignmentOf<T>()
            where T : unmanaged
        {
            unsafe
            {
                return sizeof(AlignmentFinder<T>) - sizeof(T);
            }
        }
    }

    private enum BufferType : byte
    {
        Regular,
        Rental
    }

    private struct BufferStruct
    {
        public readonly UIntPtr Buffer;
        public readonly long Size;
        public readonly BufferType Type;

        public BufferStruct(UIntPtr buffer, long size, BufferType type)
        {
            Buffer = buffer;
            Size = size;
            Type = type;
        }

        public Span<byte> AsSpan()
        {
            unsafe
            {
                return new((void*)Buffer, (int)Size);
            }
        }
    }

    private struct InnerData
    {
        private fixed ulong _buffers[16];
        private fixed long _bufferSize[16];
        private fixed byte _bufferType[16];

        public uint BufferCount
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => 16;
        }

        public BufferStruct GetBuffer(int index)
        {
            unsafe
            {
                return new((UIntPtr)_buffers[index], _bufferSize[index], (BufferType)_bufferType[index]);
            }
        }

        public BufferStruct SetBuffer(int index, BufferStruct buffer)
        {
            unsafe
            {
                _buffers[index] = buffer.Buffer;
                _bufferSize[index] = buffer.Size;
                _bufferType[index] = (byte)buffer.Type;
            }

            return buffer;
        }
    }

    private const uint REUSE_BUFFER_SIZE = 1_048_576; // 1 MB
    private const uint NORMAL_BUFFER_SIZE = 1_048_576 / 2; // 0.5MB
    private const uint MAX_BUFFER_COUNT = 8;

    private static volatile uint bufferCreatedCount = 0;
    private static readonly ConcurrentQueue<UIntPtr> globalBufferQueue = new();
    private static readonly ConcurrentQueue<WebGpuAllocator> allocators = new();
    private static BufferStruct GetBuffer(long size)
    {
        if (size > REUSE_BUFFER_SIZE)
        {
            return new((UIntPtr)NativeMemory.Alloc((nuint)size), size, BufferType.Regular);
        }

        if (globalBufferQueue.TryDequeue(out var webGpuBuffer))
        {
            return new(webGpuBuffer, REUSE_BUFFER_SIZE, BufferType.Rental);
        }
        else
        {
            if (bufferCreatedCount <= MAX_BUFFER_COUNT)
            {
                var count = Interlocked.Increment(ref bufferCreatedCount);
                if (count <= MAX_BUFFER_COUNT)
                {
                    return new((UIntPtr)NativeMemory.Alloc(REUSE_BUFFER_SIZE), REUSE_BUFFER_SIZE, BufferType.Rental);
                }
            }

            size = Math.Max(NORMAL_BUFFER_SIZE, size);
            return new((UIntPtr)NativeMemory.Alloc((nuint)size), size, BufferType.Regular);
        }
    }

    private InnerData _innerDataBuffer;
    private BufferStruct[]? _buffers;

    private int _currentBufferIndex = 0;
    private bool _isUsingInnerDataBuffer = true;
    private BufferStruct _currentBuffer = default;
    private long _currentBufferOffset = 0;

    private void UpdateCurrentBufferAllocRecord()
    {
        if (_isUsingInnerDataBuffer)
        {
            _innerDataBuffer.SetBuffer(_currentBufferIndex, _currentBuffer);
        }
        else
        {
            _buffers![_currentBufferIndex] = _currentBuffer;
        }
    }

    private void UseNewBuffer(long newSize)
    {
        _currentBufferIndex++;
        if (_isUsingInnerDataBuffer)
        {
            if (_currentBufferIndex < _innerDataBuffer.BufferCount)
            {
                _currentBuffer = _innerDataBuffer.SetBuffer(_currentBufferIndex, GetBuffer(newSize));
                _currentBufferOffset = 0;
                return;
            }
            else
            {
                _isUsingInnerDataBuffer = false;
                _currentBufferIndex = 0;
                _buffers = ArrayPool<BufferStruct>.Shared.Rent(8);
            }
        }

        if (_currentBufferIndex >= _buffers!.Length)
        {
            var oldBuffer = _buffers;
            _buffers = ArrayPool<BufferStruct>.Shared.Rent(_buffers.Length * 2);
            Array.Copy(oldBuffer, _buffers, oldBuffer.Length);
        }

        _currentBuffer = _buffers[_currentBufferIndex] = GetBuffer(newSize);
        _currentBufferOffset = 0;
    }

    private void ReallocBuffer(void* ptr, long newSize)
    {
        Debug.Assert(ptr == (void*)_currentBuffer.Buffer);

        if (_currentBuffer.Type == BufferType.Regular)
        {
            ptr = NativeMemory.Realloc((void*)_currentBuffer.Buffer, (nuint)newSize);
            _currentBuffer = new((UIntPtr)ptr, newSize, BufferType.Regular);
            UpdateCurrentBufferAllocRecord();
            return;
        }
        if (_currentBuffer.Type == BufferType.Rental)
        {
            BufferStruct newBuffer = GetBuffer(newSize);
            _currentBuffer.AsSpan().CopyTo(newBuffer.AsSpan());
            globalBufferQueue.Enqueue(_currentBuffer.Buffer);
            _currentBuffer = newBuffer;
            UpdateCurrentBufferAllocRecord();
        }

        throw new InvalidOperationException();
    }


    private void* Alloc(nuint size)
    {
        if (size > long.MaxValue)
        {
            throw new ArgumentOutOfRangeException(nameof(size));
        }

        var longSize = (long)size;

        if (_currentBufferOffset + longSize > _currentBuffer.Size)
        {
            UseNewBuffer(longSize);
        }

        var result = (byte*)_currentBuffer.Buffer + _currentBufferOffset;
        _currentBufferOffset += longSize;
        return result;
    }

    private void* Realloc(void* ptr, nuint newSize)
    {
        Debug.Assert(ptr != null);
        Debug.Assert(ptr == (void*)_currentBuffer.Buffer);

        var longSizeIncrease = (long)newSize - _currentBuffer.Size;

        Debug.Assert(longSizeIncrease > 0);

        if (_currentBufferOffset + longSizeIncrease < _currentBuffer.Size)
        {
            _currentBufferOffset += longSizeIncrease;
            return ptr;
        }

        if ((void*)_currentBuffer.Buffer == ptr)
        {
            ReallocBuffer(ptr, (long)newSize);
        }
        else
        {
            UseNewBuffer(longSizeIncrease);
        }

        _currentBufferOffset += longSizeIncrease;

        return (void*)_currentBuffer.Buffer;
    }

    public T* Alloc<T>(nuint amount = 1)
        where T : unmanaged
    {
        var alignment = StructInfo.GetAlignmentOf<T>();
        if (alignment == 1)
        {
            return (T*)Alloc(amount * (uint)sizeof(T));
        }

        var size = amount * (uint)sizeof(T);
        if (size > long.MaxValue)
        {
            throw new ArgumentOutOfRangeException(nameof(amount));
        }

        var longSize = (long)size;

        nint current = (nint)_currentBuffer.Buffer + (nint)_currentBufferOffset;
        var aligned = (current + (alignment - 1)) & ~(alignment - 1);
        _currentBufferOffset = (uint)(aligned - (nint)_currentBuffer.Buffer);

        if (_currentBufferOffset + longSize > _currentBuffer.Size)
        {
            UseNewBuffer(longSize);
        }

        var result = (T*)((byte*)_currentBuffer.Buffer + _currentBufferOffset);
        _currentBufferOffset += longSize;
        return result;
    }

    public T* Realloc<T>(T* ptr, nuint newSize)
        where T : unmanaged
    {
        return (T*)Realloc((void*)ptr, newSize * (uint)sizeof(T));
    }


    private void DisposeAllBuffers()
    {
        if (_isUsingInnerDataBuffer)
        {
            for (int i = 0; i <= _currentBufferIndex; i++)
            {
                var buffer = _innerDataBuffer.GetBuffer(i);
                switch (buffer.Type)
                {
                    case BufferType.Regular:
                        NativeMemory.Free((void*)buffer.Buffer);
                        break;
                    case BufferType.Rental:
                        globalBufferQueue.Enqueue(buffer.Buffer);
                        break;
                    default: throw new ArgumentOutOfRangeException();
                }
            }
        }
        else
        {
            var length = _innerDataBuffer!.BufferCount;
            for (int i = 0; i < length; i++)
            {
                switch (_buffers![i].Type)
                {
                    case BufferType.Regular:
                        NativeMemory.Free((void*)_buffers[i].Buffer);
                        break;
                    case BufferType.Rental:
                        globalBufferQueue.Enqueue(_buffers[i].Buffer);
                        break;
                    default: throw new ArgumentOutOfRangeException();
                }
            }
        }

        _innerDataBuffer = default;

        if (_buffers != null)
        {
            var buffersSpan = _buffers.AsSpan(0, _currentBufferIndex + 1);
            foreach (var buffer in buffersSpan)
            {
                switch (buffer.Type)
                {
                    case BufferType.Regular:
                        NativeMemory.Free((void*)buffer.Buffer);
                        break;
                    case BufferType.Rental:
                        globalBufferQueue.Enqueue(buffer.Buffer);
                        break;
                    default: throw new ArgumentOutOfRangeException();
                }
            }

            ArrayPool<BufferStruct>.Shared.Return(_buffers, true);

            _buffers = null;
        }

        _currentBufferIndex = 0;
        _isUsingInnerDataBuffer = true;
        _currentBuffer = default;
        _currentBufferOffset = 0;
    }

    private WebGpuAllocator()
    {
    }

    public static WebGpuAllocator Rent()
    {
        if (allocators.TryDequeue(out var webGpuBuffer))
        {
            return webGpuBuffer;
        }
        else
        {
            return new WebGpuAllocator();
        }
    }

    public static void Return(WebGpuAllocator webGpuBuffer)
    {
        webGpuBuffer.DisposeAllBuffers();
        allocators.Enqueue(webGpuBuffer);
    }
}