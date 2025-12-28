using System.Collections.Concurrent;
using System.Runtime.CompilerServices;

namespace WebGpuSharp.Internal;

//Unused for now
internal sealed class PooledCallbackObjects<TValue, TInvokeData>
{
    [Flags]
    private enum StateFlags
    {
        PastFastCall = 1 << 0,
        HasInvokeData = 1 << 1,
        InvokeDataSet = 1 << 2,
    }

    private static readonly ConcurrentQueue<PooledCallbackObjects<TValue, TInvokeData>> _pool = new();

    private int _state = 0;
    public TInvokeData InvokeData = default!;
    public TValue Value = default!;

    public static PooledCallbackObjects<TValue, TInvokeData> Get(in TValue value)
    {
        if (_pool.TryDequeue(out var result))
        {
            result._state = 0;
            result.Value = value;
            return result;
        }

        return new PooledCallbackObjects<TValue, TInvokeData> { Value = value };
    }

    public static void Return(PooledCallbackObjects<TValue, TInvokeData> pooledObject)
    {
        pooledObject._state = 0;
        pooledObject.Value = default!;
        pooledObject.InvokeData = default!;
        _pool.Enqueue(pooledObject);
    }

    public bool MarkPastFastCall()
    {
        var lastState = Interlocked.Or(ref _state, (int)StateFlags.PastFastCall);
        return (lastState & (int)StateFlags.HasInvokeData) != 0;
    }

    public bool SetInvokeData(in TInvokeData invokeData)
    {
        var lastState = Interlocked.Or(ref _state, (int)StateFlags.HasInvokeData);
        if ((lastState & (int)StateFlags.PastFastCall) != 0)
        {
            // Already past fast call, no need to set invoke data
            return true;
        }
        Interlocked.MemoryBarrier();
        InvokeData = invokeData;
        Interlocked.MemoryBarrier();
        Interlocked.Or(ref _state, (int)StateFlags.InvokeDataSet);
        return false;
    }


    public void WaitForInvokeData()
    {
        while (true)
        {
            var state = Volatile.Read(ref _state);
            if ((state & (int)StateFlags.InvokeDataSet) != 0)
            {
                return;
            }

            Thread.SpinWait(1);
        }
    }
}