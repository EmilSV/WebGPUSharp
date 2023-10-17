using System.Runtime.CompilerServices;

namespace WebGpuSharp;

public readonly struct WGPUBool
{
    public static WGPUBool True
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            return new(1);
        }
    }

    public static WGPUBool False
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            return new(0);
        }
    }

    private readonly uint _value;

    private WGPUBool(uint value)
    {
        _value = value;
    }

    public WGPUBool(bool value)
    {
        _value = value ? 1u : 0u;
    }

    public static implicit operator WGPUBool(bool value)
    {
        return new WGPUBool(value);
    }

    public static implicit operator bool(WGPUBool value)
    {
        return value._value != 0;
    }

    public override string ToString()
    {
        return (_value != 0).ToString();
    }
}