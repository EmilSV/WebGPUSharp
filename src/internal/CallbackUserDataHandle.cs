using System.Collections.Concurrent;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace WebGpuSharp.Internal;

internal unsafe struct CallbackUserDataHandle :
    IDisposable
{
    private readonly static ConcurrentDictionary<nuint, object> _handlesToObject = new();
    private static nuint _nextId = 0;
    public static nuint GetNextId()
    {
        if (sizeof(nuint) == sizeof(ulong))
        {
            var value = (nuint)Interlocked.Increment(ref Unsafe.As<nuint, ulong>(ref _nextId));
            if (value == 0)
            {
                value = (nuint)Interlocked.Increment(ref Unsafe.As<nuint, ulong>(ref _nextId));
            }

            return value;
        }
        else if (sizeof(nuint) == sizeof(uint))
        {
            var value = (nuint)Interlocked.Increment(ref Unsafe.As<nuint, uint>(ref _nextId));
            if (value == 0)
            {
                value = Interlocked.Increment(ref Unsafe.As<nuint, uint>(ref _nextId));
            }

            return value;
        }
        else
        {
            throw new NotSupportedException("nuint size is not supported");
        }
    }

    private readonly nuint id;

    private CallbackUserDataHandle(nuint id)
    {
        this.id = (nuint)id;
    }

    public bool IsValid()
    {
        return id != 0;
    }

    public object? GetObject()
    {
        if (!_handlesToObject.TryGetValue(id, out var obj))
        {
            return null;
        }

        return obj;
    }

    public static CallbackUserDataHandle Alloc(object value)
    {
        Debug.Assert(sizeof(CallbackUserDataHandle) == sizeof(nuint));

        nuint id = GetNextId();
        if (!_handlesToObject.TryAdd(id, value))
        {
            Environment.FailFast("Failed to add handle to dictionary");
        }

        return new CallbackUserDataHandle(id);
    }

    public void Dispose()
    {
        if (id != 0)
        {
            _handlesToObject.TryRemove(id, out _);
        }
    }

    public static unsafe explicit operator CallbackUserDataHandle(void* value) => new((nuint)value);
    public static unsafe explicit operator void*(CallbackUserDataHandle value) => (void*)value.id;
}