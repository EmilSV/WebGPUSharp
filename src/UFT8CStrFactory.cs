using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

namespace WebGpuSharp.Internal;

internal readonly ref struct UFT8CStrFactory
{
    private readonly WebGpuAllocatorHandle _allocator;

    public UFT8CStrFactory(WebGpuAllocatorHandle allocator)
    {
        _allocator = allocator;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public unsafe byte* Create(
        byte* text, int length,
        bool is16BitSize, bool allowPassthrough) =>
        Create(text, length, is16BitSize, allowPassthrough, _allocator);


    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public unsafe byte* Create(ReadOnlySpan<char> text) => Create(text, _allocator);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public unsafe byte* Create(WGPURefText text) => Create(text, _allocator);

    public static unsafe byte* Create(
        byte* text, int length,
        bool is16BitSize, bool allowPassthrough, WebGpuAllocatorHandle allocator)
    {
        if (length == 0 || text == null)
        {
            return null;
        }

        byte* result;

        if (is16BitSize)
        {
            return Create(new ReadOnlySpan<char>(text, length), allocator);
        }
        else if (text[length - 1] == 0 && allowPassthrough)
        {
            result = text;
        }
        else
        {
            var newSize = length + 1;
            result = allocator.Alloc<byte>((nuint)newSize);
            var resultSpan = new Span<byte>(result, newSize);
            new ReadOnlySpan<byte>(text, length).CopyTo(resultSpan);
            resultSpan[^1] = 0;
        }

        return result;
    }

    public static unsafe byte* Create(ReadOnlySpan<char> text, WebGpuAllocatorHandle allocator)
    {
        var newSize = Encoding.UTF8.GetByteCount(text) + 1;
        var result = allocator.Alloc<byte>((nuint)newSize);
        var resultSpan = new Span<byte>(result, newSize);
        Encoding.UTF8.GetBytes(text, new Span<byte>(result, newSize));
        resultSpan[^1] = 0;
        return result;
    }

    public static unsafe byte* Create(WGPURefText text, WebGpuAllocatorHandle allocator)
    {
        fixed (byte* ptr = text)
        {
            return Create(ptr, text.Length, text.Is16BitSize, false, allocator);
        }
    }
}