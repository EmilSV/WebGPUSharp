using System.Runtime.CompilerServices;

namespace WebGpuSharp;

public readonly partial struct WebGPUBool
{
    public static WebGPUBool True
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            return new(1);
        }
    }

    public static WebGPUBool False
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            return new(0);
        }
    }

    private WebGPUBool(uint value)
    {
        _value = value;
    }

    public WebGPUBool(bool value)
    {
        _value = value ? 1u : 0u;
    }

    public static implicit operator WebGPUBool(bool value)
    {
        return new WebGPUBool(value);
    }

    public static implicit operator bool(WebGPUBool value)
    {
        return value._value != 0;
    }

    public override string ToString()
    {
        return (_value != 0).ToString();
    }
}