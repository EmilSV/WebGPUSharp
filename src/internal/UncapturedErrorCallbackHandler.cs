using System.Buffers;
using System.Collections.Concurrent;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using WebGpuSharp.FFI;

namespace WebGpuSharp.Internal;

internal unsafe static class UncapturedErrorCallbackHandler
{
    public static void AddUncapturedErrorCallback(DeviceHandle device ,UncapturedErrorDelegate callback)
    {
        bool addSuccess = UncapturedErrorCallbackHandler.uncapturedErrorCallbacks.TryAdd(callback, 0);
        if (!addSuccess)
        {
            return;
        }

        if (Interlocked.Increment(ref UncapturedErrorCallbackHandler.uncapturedErrorCallbackSetupCount) == 1)
        {
            WebGPU_FFI.DeviceSetUncapturedErrorCallback(
                device: device,
                callback: &OnUncapturedErrorCallback,
                userdata: null
            );
        }
    }

    public static void RemoveUncapturedErrorCallback(DeviceHandle device, UncapturedErrorDelegate callback)
    {
        bool removeSuccess = UncapturedErrorCallbackHandler.uncapturedErrorCallbacks.TryRemove(callback, out _);
        if (!removeSuccess)
        {
            return;
        }

        if (Interlocked.Decrement(ref UncapturedErrorCallbackHandler.uncapturedErrorCallbackSetupCount) == 0)
        {
            WebGPU_FFI.DeviceSetUncapturedErrorCallback(
                device: device,
                callback: null,
                userdata: null
            );
        }
    }

    private static readonly ConcurrentDictionary<object, byte> uncapturedErrorCallbacks = new();
    private static volatile uint uncapturedErrorCallbackSetupCount = 0;

    [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
    private static unsafe void OnUncapturedErrorCallback(ErrorType type, byte* message, void* _)
    {
        ReadOnlySpan<byte> messageSpan;
        if (message != null)
        {
            messageSpan = MemoryMarshal.CreateReadOnlySpanFromNullTerminated(message);
        }
        else
        {
            messageSpan = ReadOnlySpan<byte>.Empty;
        }
        object[]? array = null;

        try
        {
            int count = uncapturedErrorCallbacks.Count;
            array = ArrayPool<object>.Shared.Rent(count);
            int nextIndex = 0;
            foreach (var item in uncapturedErrorCallbacks)
            {
                if (nextIndex < array.Length)
                {
                    array[nextIndex] = item.Key;
                    nextIndex++;
                }
                else
                {
                    break;
                }
            }

            foreach (var item in array.AsSpan(0, nextIndex))
            {
                Unsafe.As<UncapturedErrorDelegate>(item).Invoke(type, messageSpan);
            }
        }
        finally
        {
            if (array != null)
            {
                ArrayPool<object>.Shared.Return(array, true);
            }
        }
    }
}