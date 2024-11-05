using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace WebGpuSharp.Internal;

public class ReadWriteStateChangeLock
{
    [StructLayout(LayoutKind.Explicit)]
    private struct State
    {
        [FieldOffset(0)]
        public ulong value;

        [FieldOffset(0)]
        public uint readWrite;

        [FieldOffset(4)]
        public uint stateChange;
    }

    private State _state;

    private const nuint MAX_TRY_COUNT = 2048;

    public bool TryAddStateChangeLock()
    {
        ref ulong bufferReadWriteStateRef = ref _state.value;
        Unsafe.SkipInit(out State bufferReadWriteStateLocalState);
        ulong currentBufferReadWriteState = Interlocked.Read(ref bufferReadWriteStateRef);

        nuint i = 0;
        do
        {
            bufferReadWriteStateLocalState.value = currentBufferReadWriteState;

            if (bufferReadWriteStateLocalState.readWrite != 0)
            {
                return false;
            }

            bufferReadWriteStateLocalState.stateChange++;

            ulong originalValue = Interlocked.CompareExchange(
                location1: ref bufferReadWriteStateRef,
                value: bufferReadWriteStateLocalState.value,
                comparand: currentBufferReadWriteState
            );

            if (originalValue == currentBufferReadWriteState)
            {
                return true;
            }

            currentBufferReadWriteState = originalValue;
            i++;

        } while (i != MAX_TRY_COUNT);

        return false;
    }

    public void AddStateChangeLock()
    {
        if (!TryAddStateChangeLock())
        {
            throw new WebGPURaceException("Trying to change state while read/write lock is held");
        }
    }

    public void RemoveStateChangeLock()
    {
        Interlocked.Decrement(ref _state.stateChange);
    }

    public bool TryAddReadWriteLock()
    {
        ref ulong bufferReadWriteStateRef = ref _state.value;
        Unsafe.SkipInit(out State bufferReadWriteStateLocal);
        ulong currentBufferReadWriteState = Interlocked.Read(ref bufferReadWriteStateRef);

        nuint i = 0;
        do
        {
            bufferReadWriteStateLocal.value = currentBufferReadWriteState;

            if (bufferReadWriteStateLocal.stateChange != 0)
            {
                return false;
            }

            bufferReadWriteStateLocal.readWrite++;

            ulong originalValue = Interlocked.CompareExchange(
                location1: ref bufferReadWriteStateRef,
                value: bufferReadWriteStateLocal.value,
                comparand: currentBufferReadWriteState
            );

            if (originalValue == currentBufferReadWriteState)
            {
                return true;
            }

            currentBufferReadWriteState = originalValue;
            i++;

        } while (i != MAX_TRY_COUNT);

        return false;
    }

    public void AddReadWriteLock()
    {
        if (!TryAddReadWriteLock())
        {
            throw new WebGPURaceException("Trying to change read/write lock while state lock is held");
        }
    }

    public void RemoveReadWriteLock()
    {
        Interlocked.Decrement(ref _state.stateChange);
    }
}