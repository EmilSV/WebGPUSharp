using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using WebGpuSharp.FFI;

namespace WebGpuSharp;

public readonly ref struct WGPURefCStrUTF8
{
    private readonly ref readonly byte _reference;

    internal unsafe WGPURefCStrUTF8(WGPURefText text, WebGpuAllocatorHandle allocator)
    {
        int length = text.Length;
        if (length == 0)
        {
            _reference = ref Unsafe.NullRef<byte>();
            return;
        }

        if (text.Is16BitSize)
        {
            ref byte refChar = ref Unsafe.AsRef(in text._reference);
            ReadOnlySpan<char> charTextSpan = MemoryMarshal.CreateReadOnlySpan(ref Unsafe.As<byte, char>(ref refChar), length);
            int newSize = Encoding.UTF8.GetByteCount(charTextSpan) + 1;
            byte* result = allocator.Alloc<byte>((nuint)newSize);
            Span<byte> resultSpan = new(result, newSize);
            Encoding.UTF8.GetBytes(charTextSpan, new(result, newSize));
            resultSpan[^1] = 0;
            _reference = ref Unsafe.AsRef<byte>(result);
        }
        else
        {
            ReadOnlySpan<byte> utf8TextSpan = MemoryMarshal.CreateReadOnlySpan(ref Unsafe.AsRef(in text._reference), length);
            if (utf8TextSpan[^1] == 0)
            {
                _reference = ref Unsafe.AsRef(in text._reference);
            }
            else
            {
                int newSize = length + 1;
                byte* result = allocator.Alloc<byte>((nuint)newSize);
                Span<byte> resultSpan = new(result, newSize);
                utf8TextSpan.CopyTo(resultSpan);
                resultSpan[^1] = 0;
                _reference = ref Unsafe.AsRef<byte>(result);
            }
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public ref readonly byte GetPinnableReference()
    {
        return ref _reference;
    }
}