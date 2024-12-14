using System.Runtime.CompilerServices;
using WebGpuSharp.FFI;
using WebGpuSharp.Internal;

namespace WebGpuSharp;

public abstract class DeviceBase : WebGPUHandleWrapperBase<DeviceHandle>
{
    private Queue? _queueCache;

    public BindGroup CreateBindGroup(in BindGroupDescriptor descriptor) =>
        Handle.CreateBindGroup(descriptor).ToSafeHandle(false)!;

    public BindGroupLayout CreateBindGroupLayout(in BindGroupLayoutDescriptor descriptor) =>
        Handle.CreateBindGroupLayout(descriptor).ToSafeHandle(false)!;

    public Buffer CreateBuffer(ref BufferDescriptor descriptor) =>
        Handle.CreateBuffer(descriptor).ToSafeHandle(false)!;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Buffer CreateBuffer(BufferDescriptor descriptor) =>
        Handle.CreateBuffer(descriptor).ToSafeHandle(false)!;

    public CommandEncoder CreateCommandEncoder() =>
        Handle.CreateCommandEncoder(new CommandEncoderDescriptor()).ToSafeHandle();

    public CommandEncoder CreateCommandEncoder(in CommandEncoderDescriptor descriptor) =>
        Handle.CreateCommandEncoder(descriptor).ToSafeHandle();

    public ComputePipeline CreateComputePipeline(in ComputePipelineDescriptor descriptor) =>
        Handle.CreateComputePipeline(descriptor).ToSafeHandle(false)!;

    public PipelineLayout CreatePipelineLayout(in PipelineLayoutDescriptor descriptor) =>
        Handle.CreatePipelineLayout(descriptor).ToSafeHandle(false)!;

    public QuerySet CreateQuerySet(in QuerySetDescriptor descriptor) =>
        Handle.CreateQuerySet(descriptor).ToSafeHandle(false)!;

    public RenderBundleEncoder CreateRenderBundleEncoder(in RenderBundleEncoderDescriptor descriptor) =>
        Handle.CreateRenderBundleEncoder(descriptor).ToSafeHandle(false)!;

    public RenderPipeline CreateRenderPipeline(in RenderPipelineDescriptor descriptor) =>
        Handle.CreateRenderPipeline(descriptor).ToSafeHandle(false)!;

    public Sampler? CreateSampler(ref SamplerDescriptor descriptor) =>
     Handle.CreateSampler(ref descriptor).ToSafeHandle(false);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Sampler? CreateSampler(SamplerDescriptor descriptor) =>
        Handle.CreateSampler(descriptor).ToSafeHandle(false);

    public ShaderModule CreateShaderModule(in ShaderModuleDescriptor descriptor) =>
        Handle.CreateShaderModule(descriptor).ToSafeHandle(false)!;

    public ShaderModule CreateShaderModuleWGSL(in ShaderModuleWGSLDescriptor descriptor) =>
        CreateShaderModule(new ShaderModuleDescriptor(in descriptor));

    public ShaderModule CreateShaderModuleWGSL(WGPURefText label, in ShaderModuleWGSLDescriptor descriptor) =>
    CreateShaderModule(new ShaderModuleDescriptor(in descriptor) { Label = label });

    public Texture CreateTexture(in TextureDescriptor textureDescriptor) =>
        Handle.CreateTexture(textureDescriptor).ToSafeHandle(false)!;

    public unsafe Status GetAdapterInfo(out AdapterInfo adapterInfo) =>
        Handle.GetAdapterInfo(out adapterInfo);

    public FeatureName[] GetFeatures() => Handle.GetFeatures();

    public SupportedLimits GetLimits() => Handle.GetLimits();
    public void GetLimits(ref SupportedLimits supportedLimits) => Handle.GetLimits(ref supportedLimits);

    public Queue GetQueue()
    {
        var queueHandel = Handle.GetQueue();
        if (_queueCache == null)
        {
            return _queueCache = queueHandel.ToSafeHandle(false)!;
        }
        else if (_queueCache.Equals(queueHandel))
        {
            queueHandel.Dispose();
            return _queueCache;
        }
        else
        {
            return _queueCache = queueHandel.ToSafeHandle(false)!;
        }
    }
    public bool HasFeature(FeatureName feature) => Handle.HasFeature(feature);

    public ShaderModule? LoadShaderModuleFromFile(string path, WGPURefText label = default)
    {
        return Handle.LoadShaderModuleFromFile(path, label).ToSafeHandle(false);
    }
}