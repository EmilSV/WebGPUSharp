using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WebGpuSharp;

public readonly ref struct WGPUNullableRef<T>
    where T : struct
{
    public struct NullRef { }

    private readonly ref readonly T _value;
    public bool HasValue
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => Unsafe.IsNullRef(ref Unsafe.AsRef(_value));
    }
    public ref readonly T Value
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            if (HasValue)
            {
                throw new InvalidOperationException("Nullable object does not have a value.");
            }
            return ref _value;
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public WGPUNullableRef(in T value)
    {
        _value = ref value;
    }


    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator WGPUNullableRef<T>(in T value)
    {
        return new WGPUNullableRef<T>(value);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator WGPUNullableRef<T>(NullRef? _)
    {
        return default;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public ref readonly T GetPinnableReference()
    {
        return ref _value;
    }

}