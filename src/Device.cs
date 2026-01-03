using System.Runtime.CompilerServices;
using WebGpuSharp.FFI;
using WebGpuSharp.Internal;
using WebGpuSharp.Marshalling;

namespace WebGpuSharp;


/// <inheritdoc cref="DeviceHandle" />
public sealed class Device :
    WebGPUManagedHandleBase<DeviceHandle>,
    IFromHandleWithInstance<Device, DeviceHandle>
{

    private readonly Instance _instance;

    private Device(DeviceHandle handle, Instance instance) : base(handle)
    {
        _instance = instance;
    }

    private Queue? _queueCache;

    /// <inheritdoc cref="DeviceHandle.CreateBindGroup(in BindGroupDescriptor)" />
    public BindGroup CreateBindGroup(in BindGroupDescriptor descriptor) =>
        Handle.CreateBindGroup(descriptor).ToSafeHandle()!;

    /// <inheritdoc cref="DeviceHandle.CreateBindGroupLayout(in BindGroupLayoutDescriptor)" />
    public BindGroupLayout CreateBindGroupLayout(in BindGroupLayoutDescriptor descriptor) =>
        Handle.CreateBindGroupLayout(descriptor).ToSafeHandle()!;

    /// <inheritdoc cref="DeviceHandle.CreateBuffer(ref BufferDescriptor)" />
    public Buffer CreateBuffer(ref BufferDescriptor descriptor) =>
        Handle.CreateBuffer(descriptor).ToSafeHandle(_instance)!;

    /// <inheritdoc cref="DeviceHandle.CreateBuffer(BufferDescriptor)" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Buffer CreateBuffer(BufferDescriptor descriptor) =>
        Handle.CreateBuffer(descriptor).ToSafeHandle(_instance)!;

    /// <inheritdoc cref="DeviceHandle.CreateCommandEncoder" />
    public CommandEncoder CreateCommandEncoder() =>
        Handle.CreateCommandEncoder(new CommandEncoderDescriptor()).ToSafeHandle();

    /// <inheritdoc cref="DeviceHandle.CreateCommandEncoder(in CommandEncoderDescriptor)" />
    public CommandEncoder CreateCommandEncoder(in CommandEncoderDescriptor descriptor) =>
        Handle.CreateCommandEncoder(descriptor).ToSafeHandle();

    /// <inheritdoc cref="DeviceHandle.CreateComputePipeline(in ComputePipelineDescriptor)" />
    public ComputePipeline CreateComputePipeline(in ComputePipelineDescriptor descriptor) =>
        Handle.CreateComputePipeline(descriptor).ToSafeHandle()!;

    /// <inheritdoc cref="DeviceHandle.CreatePipelineLayout(in PipelineLayoutDescriptor)" />
    public PipelineLayout CreatePipelineLayout(in PipelineLayoutDescriptor descriptor) =>
        Handle.CreatePipelineLayout(descriptor).ToSafeHandle()!;

    /// <inheritdoc cref="DeviceHandle.CreateQuerySet(in QuerySetDescriptor)" />
    public QuerySet CreateQuerySet(in QuerySetDescriptor descriptor) =>
        Handle.CreateQuerySet(descriptor).ToSafeHandle()!;

    /// <inheritdoc cref="DeviceHandle.CreateRenderBundleEncoder(in RenderBundleEncoderDescriptor)" />
    public RenderBundleEncoder CreateRenderBundleEncoder(in RenderBundleEncoderDescriptor descriptor) =>
        Handle.CreateRenderBundleEncoder(descriptor).ToSafeHandle();

    /// <inheritdoc cref="DeviceHandle.CreateRenderPipeline(in RenderPipelineDescriptor)" />
    public RenderPipeline CreateRenderPipeline(in RenderPipelineDescriptor descriptor) =>
        Handle.CreateRenderPipeline(descriptor).ToSafeHandle()!;

    /// <inheritdoc cref="DeviceHandle.CreateSampler(ref SamplerDescriptor)" />
    public unsafe Sampler? CreateSampler() =>
     Handle.CreateSampler(null).ToSafeHandle();

    /// <inheritdoc cref="DeviceHandle.CreateSampler(ref SamplerDescriptor)" />
    public Sampler? CreateSampler(ref SamplerDescriptor descriptor) =>
     Handle.CreateSampler(ref descriptor).ToSafeHandle();

    /// <inheritdoc cref="DeviceHandle.CreateSampler(SamplerDescriptor)" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Sampler? CreateSampler(SamplerDescriptor descriptor) =>
        Handle.CreateSampler(descriptor).ToSafeHandle();

    /// <inheritdoc cref="DeviceHandle.CreateShaderModule(in ShaderModuleDescriptor)" />
    public ShaderModule CreateShaderModule(in ShaderModuleDescriptor descriptor) =>
        Handle.CreateShaderModule(descriptor).ToSafeHandle(_instance)!;

    /// <inheritdoc cref="DeviceHandle.CreateShaderModule(ShaderModuleDescriptorFFI*)"/>
    public ShaderModule CreateShaderModuleWGSL(in ShaderModuleWGSLDescriptor descriptor) =>
        CreateShaderModule(new ShaderModuleDescriptor(in descriptor));

    /// <inheritdoc cref="DeviceHandle.CreateShaderModule(ShaderModuleDescriptorFFI*)" />
    public ShaderModule CreateShaderModuleWGSL(WGPURefText label, in ShaderModuleWGSLDescriptor descriptor) =>
    CreateShaderModule(new ShaderModuleDescriptor(in descriptor) { Label = label });

    /// <inheritdoc cref="DeviceHandle.CreateTexture(ref TextureDescriptor)" />
    public Texture CreateTexture(in TextureDescriptor textureDescriptor) =>
        Handle.CreateTexture(textureDescriptor).ToSafeHandle()!;

    /// <inheritdoc cref="DeviceHandle.GetAdapterInfo(out AdapterInfo)" />
    public unsafe Status GetAdapterInfo(out AdapterInfo adapterInfo) =>
        Handle.GetAdapterInfo(out adapterInfo);

    /// <inheritdoc cref="DeviceHandle.GetFeatures()" />
    public FeatureName[] GetFeatures() => Handle.GetFeatures();

    /// <inheritdoc cref="DeviceHandle.GetLimits()" />
    public Limits GetLimits() => Handle.GetLimits();
    /// <inheritdoc cref="DeviceHandle.GetLimits(ref Limits)" />
    public void GetLimits(ref Limits supportedLimits) => Handle.GetLimits(ref supportedLimits);

    /// <inheritdoc cref="DeviceHandle.GetQueue()" />
    public Queue GetQueue()
    {
        var queueHandel = Handle.GetQueue();
        if (_queueCache == null)
        {
            return _queueCache = queueHandel.ToSafeHandle()!;
        }
        else if (_queueCache.Equals(queueHandel))
        {
            queueHandel.Dispose();
            return _queueCache;
        }
        else
        {
            return _queueCache = queueHandel.ToSafeHandle()!;
        }
    }
    /// <inheritdoc cref="DeviceHandle.HasFeature(FeatureName)" />
    public bool HasFeature(FeatureName feature) => Handle.HasFeature(feature);

    [Obsolete("This api will be removed in a future versions, as this method is not part of the official WebGPU specification")]
    /// <inheritdoc cref="DeviceHandle.LoadShaderModuleFromFile(string, WGPURefText)" />
    public ShaderModule? LoadShaderModuleFromFile(string path, WGPURefText label = default)
    {
        return Handle.LoadShaderModuleFromFile(path, label).ToSafeHandle(_instance);
    }

    static Device? IFromHandleWithInstance<Device, DeviceHandle>.FromHandle(DeviceHandle managedHandle, Instance instance)
    {
        if (DeviceHandle.IsNull(managedHandle))
        {
            return null;
        }
        return new(managedHandle, instance);
    }

    static Instance IFromHandleWithInstance<Device, DeviceHandle>.GetOwnerInstance(Device managedHandle)
    {
        return managedHandle._instance;
    }
}