using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace WebGpuSharp;


public readonly ref struct WGPURefText
{
    public enum Encoding
    {
        Empty,
        Utf8,
        Utf16
    }

    private const int SIGNED_BIT = 1 << 31;
    private const int SIGNED_BIT_MASK = ~SIGNED_BIT;

    private readonly ref readonly byte _reference;
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
            _lengthInfo = length | SIGNED_BIT;
        }
        else
        {
            _lengthInfo = 0;
        }
        Debug.Assert((length & SIGNED_BIT_MASK) == length);
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

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Encoding OutputToMatchingEncoding(out ReadOnlySpan<byte> outUft8Span, out ReadOnlySpan<char> outUft16Span)
    {
        var length = Length;
        if (length == 0)
        {
            outUft8Span = default;
            outUft16Span = default;
            return Encoding.Empty;
        }

        ref var refFirstChar = ref Unsafe.AsRef(in _reference);
        if (Is16BitSize)
        {
            outUft8Span = default;
            outUft16Span = MemoryMarshal.CreateReadOnlySpan(ref Unsafe.As<byte, char>(ref refFirstChar), length);
            return Encoding.Utf16;
        }
        else
        {
            outUft8Span = MemoryMarshal.CreateReadOnlySpan(ref refFirstChar, length);
            outUft16Span = default;
            return Encoding.Utf8;
        }
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
}