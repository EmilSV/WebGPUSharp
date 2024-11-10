using System.Collections.Concurrent;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace WebGpuSharp.Internal;

public sealed class ReadWriteStateChangeHandleLock
{
    private static class LockCreate
    {
        private readonly static ConcurrentQueue<UIntPtr> _handlesToRemove = new();
        private readonly static ConcurrentDictionary<UIntPtr, GCHandle> _locks = new();

        public static ReadWriteStateChangeHandleLock Get(UIntPtr handle)
        {
            while (_handlesToRemove.TryDequeue(out var handleToRemove))
            {
                if (_locks.TryRemove(handleToRemove, out var lockObjToRemove))
                {
                    lockObjToRemove.Free();
                }
            }

            ReadWriteStateChangeHandleLock? outLock = null;

            if (_locks.TryGetValue(handle, out var lockObj))
            {
                outLock = (ReadWriteStateChangeHandleLock)lockObj.Target!;
            }

            if (outLock == null)
            {
                outLock = new(handle);
                _locks.TryAdd(handle, GCHandle.Alloc(outLock, GCHandleType.Weak));
            }
            return outLock;
        }

        public static void AddRemoveQueue(UIntPtr handle)
        {
            _handlesToRemove.Enqueue(handle);
        }
    }

    public static ReadWriteStateChangeHandleLock Get(UIntPtr handle)
    {
        return LockCreate.Get(handle);
    }

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
    private readonly UIntPtr _handle;
    private const nuint MAX_TRY_COUNT = 2048;

    private ReadWriteStateChangeHandleLock(UIntPtr handle)
    {
        _handle = handle;
        _state = new();
    }

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

        throw new WebGPUException("failed to change lock state");
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

        throw new WebGPUException("failed to change lock state");
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

    ~ReadWriteStateChangeHandleLock()
    {
        if (_handle != UIntPtr.Zero)
        {
            LockCreate.AddRemoveQueue(_handle);
        }
    }
}