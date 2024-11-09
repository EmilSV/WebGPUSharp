using System.Runtime.CompilerServices;
using WebGpuSharp.FFI;
using WebGpuSharp.Internal;

namespace WebGpuSharp;

public abstract class DeviceBase : WebGPUHandleWrapperBase<DeviceHandle>
{
    public Queue? GetQueue() =>
        Handle.GetQueue().ToSafeHandle(false);

    public CommandEncoder CreateCommandEncoder(in CommandEncoderDescriptor descriptor) =>
        Handle.CreateCommandEncoder(descriptor).ToSafeHandle();

    public Buffer? CreateBuffer(ref BufferDescriptor descriptor) =>
        Handle.CreateBuffer(descriptor).ToSafeHandle(false);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Buffer? CreateBuffer(BufferDescriptor descriptor) =>
        Handle.CreateBuffer(descriptor).ToSafeHandle(false);

    public ShaderModule? CreateShaderModule(in ShaderModuleDescriptor descriptor) =>
        Handle.CreateShaderModule(descriptor).ToSafeHandle(false);

    public ShaderModule? CreateShaderModuleWGSL(in ShaderModuleWGSLDescriptor descriptor) =>
        CreateShaderModule(new ShaderModuleDescriptor(in descriptor));

    public SupportedLimits GetLimits() => Handle.GetLimits();
    public void GetLimits(ref SupportedLimits supportedLimits) => Handle.GetLimits(ref supportedLimits);

    public Texture? CreateTexture(in TextureDescriptor textureDescriptor) =>
        Handle.CreateTexture(textureDescriptor).ToSafeHandle(false);

    public Sampler? CreateSampler(ref SamplerDescriptor descriptor)
    {
        return Handle.CreateSampler(ref descriptor).ToSafeHandle(false);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Sampler? CreateSampler(SamplerDescriptor descriptor)
    {
        return Handle.CreateSampler(descriptor).ToSafeHandle(false);
    }

    public BindGroupLayout? CreateBindGroupLayout(in BindGroupLayoutDescriptor descriptor)
    {
        return Handle.CreateBindGroupLayout(descriptor).ToSafeHandle(false);
    }

    public PipelineLayout? CreatePipelineLayout(in PipelineLayoutDescriptor descriptor)
    {
        return Handle.CreatePipelineLayout(descriptor).ToSafeHandle(false);
    }

    public RenderPipeline? CreateRenderPipeline(in RenderPipelineDescriptor descriptor)
    {
        return Handle.CreateRenderPipeline(descriptor).ToSafeHandle(false);
    }

    public ShaderModule? LoadShaderModuleFromFile(string path, WGPURefText label = default)
    {
        return Handle.LoadShaderModuleFromFile(path, label).ToSafeHandle(false);
    }

    public BindGroup? CreateBindGroup(in BindGroupDescriptor descriptor)
    {
        return Handle.CreateBindGroup(descriptor).ToSafeHandle(false);
    }
}