using System.Runtime.CompilerServices;
using WebGpuSharp.FFI;
using WebGpuSharp.Internal;

namespace WebGpuSharp;

public abstract class DeviceBase : WebGPUHandleWrapperBase<DeviceHandle>
{
    public Queue? GetQueue() =>
        Handle.GetQueue().ToSafeHandle(true);

    public CommandEncoder CreateCommandEncoder(in CommandEncoderDescriptor descriptor) =>
        Handle.CreateCommandEncoder(descriptor).ToSafeHandle();

    public Buffer? CreateBuffer(ref BufferDescriptor descriptor) =>
        Handle.CreateBuffer(descriptor).ToSafeHandle(true);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Buffer? CreateBuffer(BufferDescriptor descriptor) =>
        Handle.CreateBuffer(descriptor).ToSafeHandle(true);

    public ShaderModule? CreateShaderModule(in ShaderModuleDescriptor descriptor) =>
        Handle.CreateShaderModule(descriptor).ToSafeHandle(true);

    public ShaderModule? CreateShaderModuleWGSL(in ShaderModuleWGSLDescriptor descriptor) =>
        CreateShaderModule(new ShaderModuleDescriptor(in descriptor));

    public SupportedLimits GetLimits() => Handle.GetLimits();
    public void GetLimits(ref SupportedLimits supportedLimits) => Handle.GetLimits(ref supportedLimits);

    public Texture? CreateTexture(in TextureDescriptor textureDescriptor) =>
        Handle.CreateTexture(textureDescriptor).ToSafeHandle(true);

    public Sampler? CreateSampler(ref SamplerDescriptor descriptor)
    {
        return Handle.CreateSampler(ref descriptor).ToSafeHandle(true);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Sampler? CreateSampler(SamplerDescriptor descriptor)
    {
        return Handle.CreateSampler(descriptor).ToSafeHandle(true);
    }

    public BindGroupLayout? CreateBindGroupLayout(in BindGroupLayoutDescriptor descriptor)
    {
        return Handle.CreateBindGroupLayout(descriptor).ToSafeHandle(true);
    }

    public PipelineLayout? CreatePipelineLayout(in PipelineLayoutDescriptor descriptor)
    {
        return Handle.CreatePipelineLayout(descriptor).ToSafeHandle(true);
    }

    public RenderPipeline? CreateRenderPipeline(in RenderPipelineDescriptor descriptor)
    {
        return Handle.CreateRenderPipeline(descriptor).ToSafeHandle(true);
    }

    public ShaderModule? LoadShaderModuleFromFile(string path, WGPURefText label = default)
    {
        return Handle.LoadShaderModuleFromFile(path, label).ToSafeHandle(true);
    }

    public BindGroup? CreateBindGroup(in BindGroupDescriptor descriptor)
    {
        return Handle.CreateBindGroup(descriptor).ToSafeHandle(true);
    }
}