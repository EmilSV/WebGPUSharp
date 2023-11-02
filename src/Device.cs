using WebGpuSharp.FFI;
using WebGpuSharp.Internal;

namespace WebGpuSharp;

public sealed unsafe partial class Device : BaseWebGpuSafeHandle<Device, DeviceHandle>
{
    private Device(DeviceHandle handle) : base(handle)
    {
    }

    internal static Device? FromHandle(DeviceHandle handle, bool isOwnedHandle)
    {
        var newDevice = WebGpuSafeHandleCache.GetOrCreate(handle, static (handle) => new Device(handle));
        if (isOwnedHandle)
        {
            newDevice?.AddReference(false);
        }
        return newDevice;
    }


    public void AddUncapturedErrorCallback(UncapturedErrorDelegate callback) =>
        _handle.AddUncapturedErrorCallback(callback);

    public void RemoveUncapturedErrorCallback(UncapturedErrorDelegate callback) =>
        _handle.RemoveUncapturedErrorCallback(callback);

    public void AddDeviceLostCallback(DeviceLostCallbackDelegate callback) =>
        _handle.AddDeviceLostCallback(callback);



    public Queue? GetQueue() =>
        _handle.GetQueue().ToSafeHandle(true);

    public CommandEncoder? CreateCommandEncoder(in CommandEncoderDescriptor descriptor) =>
        _handle.CreateCommandEncoder(descriptor).ToSafeHandle(true);

    public void Tick() => _handle.Tick();

    public Buffer? CreateBuffer(in BufferDescriptor descriptor) =>
        _handle.CreateBuffer(descriptor).ToSafeHandle(true);

    public SwapChain? CreateSwapChain(Surface surface, in SwapChainDescriptor descriptor) =>
        _handle.CreateSwapChain(surface.GetHandle(), descriptor).ToSafeHandle(true);

    public ShaderModule? CreateShaderModule(in ShaderModuleDescriptor descriptor) =>
        _handle.CreateShaderModule(descriptor).ToSafeHandle(true);

    public SupportedLimits GetLimits() => _handle.GetLimits();
    public void GetLimits(ref SupportedLimits supportedLimits) => _handle.GetLimits(ref supportedLimits);

    public Texture? CreateTexture(in TextureDescriptor textureDescriptor) =>
        _handle.CreateTexture(textureDescriptor).ToSafeHandle(true);
}
