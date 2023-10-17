using WebGpuSharp.FFI;
using WebGpuSharp.Internal;

namespace WebGpuSharp;

public sealed partial class Device : WebGpuSafeHandle<DeviceHandle>
{
    private class CacheFactory :
        WebGpuSafeHandleCache<DeviceHandle>.ISafeHandleFactory
    {
        public static WebGpuSafeHandle<DeviceHandle> Create(DeviceHandle handle)
        {
            return new Device(handle);
        }
    }


    private Device(DeviceHandle handle) : base(handle)
    {
    }

    protected override void WebGpuReference()
    {
        WebGPU_FFI.DeviceReference(_handle);
    }

    protected override void WebGpuRelease()
    {
        WebGPU_FFI.DeviceRelease(_handle);
    }

    internal static Device? FromHandle(DeviceHandle handle)
    {
        return WebGpuSafeHandleCache<DeviceHandle>.GetOrCreate<CacheFactory>(handle) as Device;
    }


    public void AddUncapturedErrorCallback(UncapturedErrorDelegate callback) => _handle.AddUncapturedErrorCallback(callback);
    public void AddDeviceLostCallback(DeviceLostCallbackDelegate callback) => _handle.AddDeviceLostCallback(callback);
    public Queue? GetQueue() => Queue.FromHandle(_handle.GetQueue());
    public CommandEncoder? CreateCommandEncoder(in CommandEncoderDescriptor descriptor) => CommandEncoder.FromHandle(_handle.CreateCommandEncoder(descriptor));
    public void Tick() => _handle.Tick();
    public Buffer? CreateBuffer(in BufferDescriptor descriptor) => Buffer.FromHandle(_handle.CreateBuffer(descriptor));
    public SwapChainHandle CreateSwapChain(Surface surface, in SwapChainDescriptor descriptor) => _handle.CreateSwapChain(surface.GetHandle(), descriptor);
    public ShaderModule? CreateShaderModule(in ShaderModuleDescriptor descriptor) => ShaderModule.FromHandle(_handle.CreateShaderModule(descriptor));
    public SupportedLimits GetLimits() => _handle.GetLimits();
    public void GetLimits(ref SupportedLimits supportedLimits) => _handle.GetLimits(ref supportedLimits);

    public Texture? CreateTexture(in TextureDescriptor textureDescriptor) => Texture.FromHandle(_handle.CreateTexture(textureDescriptor));
}
