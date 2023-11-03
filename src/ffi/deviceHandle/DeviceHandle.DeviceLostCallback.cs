using System.Buffers;
using System.Collections.Concurrent;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using WebGpuSharp;

namespace WebGpuSharp.FFI
{
    public unsafe readonly partial struct DeviceHandle
    {
        public readonly void AddDeviceLostCallback(DeviceLostCallbackDelegate callback)
        {
            bool addSuccess = DeviceLostCallbackHandler.deviceLostCallbacks.TryAdd(callback, 0);
            if (!addSuccess)
            {
                return;
            }

            if (Interlocked.Increment(ref DeviceLostCallbackHandler.deviceLostCallbackSetupCount) == 1)
            {
                WebGPU_FFI.DeviceSetDeviceLostCallback(
                    device: this,
                    callback: &DeviceLostCallbackHandler.OnDeviceLostCallback,
                    userdata: null
                );
            }
        }

        public readonly void RemoveDeviceLostCallback(DeviceLostCallbackDelegate callback)
        {
            bool removeSuccess = DeviceLostCallbackHandler.deviceLostCallbacks.TryRemove(callback, out _);
            if (!removeSuccess)
            {
                return;
            }

            if (Interlocked.Decrement(ref DeviceLostCallbackHandler.deviceLostCallbackSetupCount) == 0)
            {
                WebGPU_FFI.DeviceSetDeviceLostCallback(
                    device: this,
                    callback: null,
                    userdata: null
                );
            }
        }
    }
}

namespace WebGpuSharp
{
    public delegate void DeviceLostCallbackDelegate(DeviceLostReason lostReason, ReadOnlySpan<byte> message);
}


file static class DeviceLostCallbackHandler
{
    public static readonly ConcurrentDictionary<object, byte> deviceLostCallbacks = new();
    public static volatile uint deviceLostCallbackSetupCount = 0;

    [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static unsafe void OnDeviceLostCallback(DeviceLostReason lostReason, byte* message, void* _)
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