using System.Buffers;
using System.Collections.Concurrent;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using WebGpuSharp.FFI;

namespace WebGpuSharp.Internal;

internal unsafe static class DeviceLostCallbackHandler
{
    public static void AddDeviceLostCallback(DeviceHandle device, DeviceLostCallbackDelegate callback)
    {
        bool addSuccess = deviceLostCallbacks.TryAdd(callback, 0);
        if (!addSuccess)
        {
            return;
        }

        if (Interlocked.Increment(ref deviceLostCallbackSetupCount) == 1)
        {
            WebGPU_FFI.DeviceSetDeviceLostCallback(
                device: device,
                callback: &OnDeviceLostCallback,
                userdata: null
            );
        }
    }

    public static void RemoveDeviceLostCallback(DeviceHandle device, DeviceLostCallbackDelegate callback)
    {
        bool removeSuccess = deviceLostCallbacks.TryRemove(callback, out _);
        if (!removeSuccess)
        {
            return;
        }

        if (Interlocked.Decrement(ref deviceLostCallbackSetupCount) == 0)
        {
            WebGPU_FFI.DeviceSetDeviceLostCallback(
                device: device,
                callback: null,
                userdata: null
            );
        }
    }

    private static readonly ConcurrentDictionary<object, byte> deviceLostCallbacks = new();
    private static volatile uint deviceLostCallbackSetupCount = 0;

    [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
    private static unsafe void OnDeviceLostCallback(DeviceLostReason lostReason, byte* message, void* _)
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
            int count = deviceLostCallbacks.Count;
            array = ArrayPool<object>.Shared.Rent(count);
            int nextIndex = 0;
            foreach (var item in deviceLostCallbacks)
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
                Unsafe.As<DeviceLostCallbackDelegate>(item).Invoke(lostReason, messageSpan);
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