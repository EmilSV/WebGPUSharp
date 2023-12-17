namespace WebGpuSharp.Internal;

using System.Runtime.CompilerServices;
using GPUBuffer = WebGpuSharp.Buffer;

public static class UnsafeBufferLock
{
    private const nuint MAX_TRY_COUNT = 8;

    public static void AddStateChangeLock(GPUBuffer buffer)
    {
        ref ulong bufferReadWriteStateRef = ref buffer.readWriteStateChange.value;
        Unsafe.SkipInit(out GPUBuffer.ReadWriteStateChange bufferReadWriteStateLocal);
        ulong currentBufferReadWriteState = Interlocked.Read(ref bufferReadWriteStateRef);

        nuint i = 0;
        do
        {
            bufferReadWriteStateLocal.value = currentBufferReadWriteState;

            if (bufferReadWriteStateLocal.readWrite != 0)
            {
                throw new WebGPURaceException("");
            }

            bufferReadWriteStateLocal.stateChange++;

            ulong originalValue = Interlocked.CompareExchange(
                location1: ref bufferReadWriteStateRef,
                value: bufferReadWriteStateLocal.value,
                comparand: currentBufferReadWriteState
            );

            if (originalValue == currentBufferReadWriteState)
            {
                return;
            }

            currentBufferReadWriteState = originalValue;
            i++;

        } while (i != MAX_TRY_COUNT);

        throw new WebGPURaceException("");
    }

    public static void AddReadWriteLock(GPUBuffer buffer)
    {
        ref ulong bufferReadWriteStateRef = ref buffer.readWriteStateChange.value;
        Unsafe.SkipInit(out GPUBuffer.ReadWriteStateChange bufferReadWriteStateLocal);
        ulong currentBufferReadWriteState = Interlocked.Read(ref bufferReadWriteStateRef);

        nuint i = 0;
        do
        {
            bufferReadWriteStateLocal.value = currentBufferReadWriteState;

            if (bufferReadWriteStateLocal.stateChange != 0)
            {
                throw new WebGPURaceException("");
            }

            bufferReadWriteStateLocal.readWrite++;

            ulong originalValue = Interlocked.CompareExchange(
                location1: ref bufferReadWriteStateRef,
                value: bufferReadWriteStateLocal.value,
                comparand: currentBufferReadWriteState
            );

            if (originalValue == currentBufferReadWriteState)
            {
                return;
            }

            currentBufferReadWriteState = originalValue;
            i++;

        } while (i != MAX_TRY_COUNT);

        throw new WebGPURaceException("");
    }

    public static void RemoveStateChangeLock(GPUBuffer buffer)
    {
        Interlocked.Decrement(ref buffer.readWriteStateChange.stateChange);
    }

    public static void RemoveReadWriteLock(GPUBuffer buffer)
    {
        Interlocked.Decrement(ref buffer.readWriteStateChange.readWrite);
    }
}