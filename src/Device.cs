using System.Runtime.CompilerServices;
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

    public CommandEncoder CreateCommandEncoder(in CommandEncoderDescriptor descriptor) =>
        _handle.CreateCommandEncoder(descriptor).ToSafeHandle();

    public void Tick() => _handle.Tick();

    public Buffer? CreateBuffer(ref BufferDescriptor descriptor) =>
        _handle.CreateBuffer(descriptor).ToSafeHandle(true);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Buffer? CreateBuffer(BufferDescriptor descriptor) =>
        _handle.CreateBuffer(descriptor).ToSafeHandle(true);

    public SwapChain? CreateSwapChain(Surface surface, in SwapChainDescriptor descriptor) =>
        _handle.CreateSwapChain(surface.GetHandle(), descriptor).ToSafeHandle(true);

    public ShaderModule? CreateShaderModule(in ShaderModuleDescriptor descriptor) =>
        _handle.CreateShaderModule(descriptor).ToSafeHandle(true);

    public SupportedLimits GetLimits() => _handle.GetLimits();
    public void GetLimits(ref SupportedLimits supportedLimits) => _handle.GetLimits(ref supportedLimits);

    public Texture? CreateTexture(in TextureDescriptor textureDescriptor) =>
        _handle.CreateTexture(textureDescriptor).ToSafeHandle(true);

    public Sampler? CreateSampler(ref SamplerDescriptor descriptor)
    {
        return _handle.CreateSampler(ref descriptor).ToSafeHandle(true);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Sampler? CreateSampler(SamplerDescriptor descriptor)
    {
        return _handle.CreateSampler(descriptor).ToSafeHandle(true);
    }

    public BindGroupLayout? CreateBindGroupLayout(in BindGroupLayoutDescriptor descriptor)
    {
        return _handle.CreateBindGroupLayout(descriptor).ToSafeHandle(true);
    }

    public PipelineLayout? CreatePipelineLayout(in PipelineLayoutDescriptor descriptor)
    {
        return _handle.CreatePipelineLayout(descriptor).ToSafeHandle(true);
    }

    public RenderPipeline? CreateRenderPipeline(in RenderPipelineDescriptor descriptor)
    {
        return _handle.CreateRenderPipeline(descriptor).ToSafeHandle(true);
    }

    public ShaderModule? LoadShaderModuleFromFile(string path, WGPURefText label = default)
    {
        return _handle.LoadShaderModuleFromFile(path, label).ToSafeHandle(true);
    }

    public BindGroup? CreateBindGroup(in BindGroupDescriptor descriptor)
    {
        return _handle.CreateBindGroup(descriptor).ToSafeHandle(true);
    }
}
