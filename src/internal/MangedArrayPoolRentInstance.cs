using System.Buffers;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace WebGpuSharp.Internal;

internal readonly struct MangedArrayPoolRentInstance<T> : IDisposable
    where T : class
{
    private readonly ArrayPool<object?> _pool;
    private readonly object?[] _array;

    public MangedArrayPoolRentInstance(ArrayPool<object?> pool, int size)
    {
        _pool = pool;
        _array = pool.Rent(size);
    }

    public Span<T> Span => MemoryMarshal.CreateSpan(ref Unsafe.As<object, T>(ref _array[0]!), _array.Length);

    public void Dispose()
    {
        _pool.Return(_array, clearArray: true);
    }
}