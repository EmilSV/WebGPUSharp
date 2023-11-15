using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace WebGpuSharp;


public readonly ref struct WGPURefText
{
    private const int SIGNED_BIT = 1 << 31;
    private const int SIGNED_BIT_MASK = ~SIGNED_BIT;

    internal readonly ref readonly byte _reference;
    private readonly int _lengthInfo;

    public int Length
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => _lengthInfo & SIGNED_BIT_MASK;
    }

    public bool Is16BitSize
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (_lengthInfo & SIGNED_BIT) != 0;
    }

    public unsafe WGPURefText(ReadOnlySpan<byte> text)
    {
        _reference = ref Unsafe.NullRef<byte>();
        int length = text.Length;
        if (length != 0)
        {
            _reference = ref MemoryMarshal.GetReference(text);
        }
        Debug.Assert((length & SIGNED_BIT_MASK) == length);
        _lengthInfo = length;
    }

    public WGPURefText(ReadOnlySpan<char> text)
    {
        _reference = ref Unsafe.NullRef<byte>();
        int length = text.Length;
        if (length != 0)
        {
            _reference = ref Unsafe.As<char, byte>(ref MemoryMarshal.GetReference(text));
        }
        Debug.Assert((length & SIGNED_BIT_MASK) == length);
        _lengthInfo = length | SIGNED_BIT;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public ref readonly byte GetPinnableReference()
    {
        ref readonly byte ret = ref Unsafe.NullRef<byte>();
        if (Length != 0) ret = ref _reference;
        return ref ret;
    }

    public bool TryGetCharSpan(out ReadOnlySpan<char> outSpan)
    {
        if (Is16BitSize)
        {
            ref var refChar = ref Unsafe.AsRef(in _reference);
            outSpan = MemoryMarshal.CreateReadOnlySpan(ref Unsafe.As<byte, char>(ref refChar), Length);
            return true;
        }
        else
        {
            outSpan = default;
            return false;
        }
    }

    public bool TryGetByteSpan(out ReadOnlySpan<byte> outSpan)
    {
        if (Is16BitSize)
        {
            ref var refChar = ref Unsafe.AsRef(in _reference);
            outSpan = MemoryMarshal.CreateReadOnlySpan(in _reference, Length);
            return true;
        }
        else
        {
            outSpan = default;
            return false;
        }
    }

    public static implicit operator WGPURefText(ReadOnlySpan<byte> value)
    {
        return new WGPURefText(value);
    }

    public static implicit operator WGPURefText(ReadOnlySpan<char> value)
    {
        return new WGPURefText(value);
    }

    public static implicit operator WGPURefText(Span<byte> value)
    {
        return new WGPURefText(value);
    }

    public static implicit operator WGPURefText(Span<char> value)
    {
        return new WGPURefText(value);
    }

    public static implicit operator WGPURefText(byte[] value)
    {
        return value is null ? default : new WGPURefText(value);
    }

    public static implicit operator WGPURefText(char[] value)
    {
        return value is null ? default : new WGPURefText(value);
    }

    public static implicit operator WGPURefText(string value)
    {
        return value is null ? default : new WGPURefText(value);
    }

}