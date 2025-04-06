using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public readonly unsafe partial struct DeviceHandle : IEquatable<DeviceHandle>
{
    private readonly nuint _ptr;
    public static DeviceHandle Null
    {
        get => new(nuint.Zero);
    }

    public DeviceHandle(nuint ptr) => _ptr = ptr;

    public static explicit operator nuint(DeviceHandle handle) => handle._ptr;

    public static bool operator ==(DeviceHandle left, DeviceHandle right) => left._ptr == right._ptr;

    public static bool operator !=(DeviceHandle left, DeviceHandle right) => left._ptr != right._ptr;

    public static bool operator ==(DeviceHandle left, DeviceHandle? right) => left._ptr == right.GetValueOrDefault()._ptr;

    public static bool operator !=(DeviceHandle left, DeviceHandle? right) => left._ptr != right.GetValueOrDefault()._ptr;

    public static bool operator ==(DeviceHandle left, nuint right) => left._ptr == right;

    public static bool operator !=(DeviceHandle left, nuint right) => left._ptr != right;

    public nuint GetAddress() => _ptr;

    public bool Equals(DeviceHandle other) => _ptr == other._ptr;

    public override bool Equals(object? other) => other is DeviceHandle h && Equals(h) || other is null && _ptr == UIntPtr.Zero;

    public override int GetHashCode() => _ptr.GetHashCode();

    /// <summary>
    /// Creates a BindGroup.
    /// </summary>
    /// <param name="descriptor">The descriptor to use for the BindGroup</param>
    /// <returns>A new BindGroup</returns>
    public BindGroupHandle CreateBindGroup(BindGroupDescriptorFFI* descriptor) => WebGPU_FFI.DeviceCreateBindGroup(this, descriptor);

    /// <summary>
    /// Creates a BindGroupLayout.
    /// </summary>
    /// <param name="descriptor">The descriptor to use for the BindGroupLayout</param>
    /// <returns>A new BindGroupLayout</returns>
    public BindGroupLayoutHandle CreateBindGroupLayout(BindGroupLayoutDescriptorFFI* descriptor) => WebGPU_FFI.DeviceCreateBindGroupLayout(this, descriptor);

    /// <summary>
    /// Creates a Buffer.
    /// </summary>
    /// <param name="descriptor">The descriptor to use for the Buffer</param>
    /// <returns>A new Buffer</returns>
    public BufferHandle CreateBuffer(BufferDescriptorFFI* descriptor) => WebGPU_FFI.DeviceCreateBuffer(this, descriptor);

    /// <summary>
    /// Creates a CommandEncoder.
    /// </summary>
    /// <param name="descriptor">The descriptor to use for the CommandEncoder</param>
    /// <returns>A new CommandEncoder</returns>
    public CommandEncoderHandle CreateCommandEncoder(CommandEncoderDescriptorFFI* descriptor) => WebGPU_FFI.DeviceCreateCommandEncoder(this, descriptor);

    /// <summary>
    /// Creates a ComputePipeline using immediate pipeline creation.
    /// </summary>
    /// <param name="descriptor">The descriptor to use for the ComputePipeline</param>
    /// <returns>A new ComputePipeline</returns>
    public ComputePipelineHandle CreateComputePipeline(ComputePipelineDescriptorFFI* descriptor) => WebGPU_FFI.DeviceCreateComputePipeline(this, descriptor);

    /// <summary>
    /// Creates a GPUComputePipeline using async pipeline creation.
    /// The returned future resolves when the created pipeline is ready to be used without additional delay.
    /// </summary>
    /// <remarks">Use of this method is preferred whenever possible, as it prevents blocking the queue timeline work on pipeline compilation.</remarks>
    /// <param name="callbackInfo">The callbackInfo to use for the ComputePipeline</param>
    /// <param name="descriptor">The descriptor to use for the ComputePipeline</param>
    /// <returns>A future resolving when the pipeline is ready</returns>
    public Future CreateComputePipelineAsync(ComputePipelineDescriptorFFI* descriptor, CreateComputePipelineAsyncCallbackInfoFFI callbackInfo) => WebGPU_FFI.DeviceCreateComputePipelineAsync(this, descriptor, callbackInfo);

    /// <summary>
    /// Creates a PipelineLayout.
    /// </summary>
    public PipelineLayoutHandle CreatePipelineLayout(PipelineLayoutDescriptorFFI* descriptor) => WebGPU_FFI.DeviceCreatePipelineLayout(this, descriptor);

    /// <summary>
    /// Creates a QuerySet.
    /// </summary>
    /// <param name="descriptor">The descriptor to use for the QuerySet</param>
    /// <returns>A new QuerySet</returns>
    public QuerySetHandle CreateQuerySet(QuerySetDescriptorFFI* descriptor) => WebGPU_FFI.DeviceCreateQuerySet(this, descriptor);

    /// <summary>
    /// Creates a RenderBundleEncoder.
    /// </summary>
    /// <param name="descriptor">The descriptor to use for the RenderBundleEncoder</param>
    /// <returns>A new RenderBundleEncoder</returns>
    public RenderBundleEncoderHandle CreateRenderBundleEncoder(RenderBundleEncoderDescriptorFFI* descriptor) => WebGPU_FFI.DeviceCreateRenderBundleEncoder(this, descriptor);

    /// <summary>
    /// Creates a GPURenderPipeline using immediate pipeline creation.
    /// </summary>
    /// <param name="descriptor">The descriptor to use for the RenderPipeline</param>
    /// <returns>A new RenderPipeline</returns>
    public RenderPipelineHandle CreateRenderPipeline(RenderPipelineDescriptorFFI* descriptor) => WebGPU_FFI.DeviceCreateRenderPipeline(this, descriptor);

    /// <summary>
    /// Creates a GPURenderPipeline using async pipeline creation.
    /// The returned future resolves when the created pipeline is ready to be used without additional delay.
    /// </summary>
    /// <remarks">Use of this method is preferred whenever possible, as it prevents blocking the queue timeline work on pipeline compilation.</remarks>
    /// <param name="descriptor">The descriptor to use for the RenderPipeline</param>
    /// <param name="callbackInfo">The callbackInfo to use for the RenderPipeline</param>
    /// <returns>A future resolving when the pipeline is ready</returns>
    public Future CreateRenderPipelineAsync(RenderPipelineDescriptorFFI* descriptor, CreateRenderPipelineAsyncCallbackInfoFFI callbackInfo) => WebGPU_FFI.DeviceCreateRenderPipelineAsync(this, descriptor, callbackInfo);

    /// <summary>
    /// Creates a Sampler.
    /// </summary>
    /// <param name="descriptor">The descriptor to use for the Sampler</param>
    /// <returns>A new Sampler</returns>
    public SamplerHandle CreateSampler(SamplerDescriptorFFI* descriptor) => WebGPU_FFI.DeviceCreateSampler(this, descriptor);

    /// <summary>
    /// Creates a ShaderModule.
    /// </summary>
    /// <param name="descriptor">The descriptor to use for the ShaderModule</param>
    /// <returns>A new ShaderModule</returns>
    public ShaderModuleHandle CreateShaderModule(ShaderModuleDescriptorFFI* descriptor) => WebGPU_FFI.DeviceCreateShaderModule(this, descriptor);

    /// <summary>
    /// Creates a Texture.
    /// </summary>
    /// <param name="descriptor">The descriptor to use for the Texture</param>
    /// <returns>A new Texture</returns>
    public TextureHandle CreateTexture(TextureDescriptorFFI* descriptor) => WebGPU_FFI.DeviceCreateTexture(this, descriptor);

    /// <summary>
    /// Destroys the device, preventing further operations on it. Outstanding asynchronous operations will fail.
    /// </summary>
    /// <remarks">It is valid to destroy a device multiple times.</remarks>
    /// <returns>A future resolving when the device is destroyed</returns>
    public void Destroy() => WebGPU_FFI.DeviceDestroy(this);

    /// <summary>
    /// Information about the physical adapter which created the device that this GPUDevice refers to.
    /// 
    /// For a given GPUDevice, the GPUAdapterInfo values exposed are constant over time.
    /// </summary>
    /// <param name="adapterInfo">The adapterInfo to insert the adapter info into</param>
    /// <returns>the status of the operation</returns>
    public Status GetAdapterInfo(AdapterInfoFFI* adapterInfo) => WebGPU_FFI.DeviceGetAdapterInfo(this, adapterInfo);

    /// <summary>
    /// Get the features supported by the device
    /// </summary>
    /// <param name="features">an pointer to a SupportedFeaturesFFI to insert the supported features into</param>
    public void GetFeatures(SupportedFeaturesFFI* features) => WebGPU_FFI.DeviceGetFeatures(this, features);

    /// <summary>
    /// Get the limits which can be used on this device.
    /// No better limits can be used, even if the underlying adapter can support them.
    /// </summary>
    /// <param name="limits">an pointer to a SupportedLimits to insert the limits into</param>
    /// <returns>Return status of the operation</returns>
    public Status GetLimits(SupportedLimits* limits) => WebGPU_FFI.DeviceGetLimits(this, limits);

    public Future GetLostFuture() => WebGPU_FFI.DeviceGetLostFuture(this);

    /// <summary>
    /// Get the primary Queue for this device.
    /// </summary>
    /// <param name="queue">Get the queue to insert command into</param>
    /// <returns>the queue</returns>
    public QueueHandle GetQueue() => WebGPU_FFI.DeviceGetQueue(this);

    /// <summary>
    /// Check if the feature is supported
    /// </summary>
    /// <param name="feature">The feature to check</param>
    /// <returns>true if the feature is supported false otherwise</returns>
    public WebGPUBool HasFeature(FeatureName feature) => WebGPU_FFI.DeviceHasFeature(this, feature);

    public Future PopErrorScope(PopErrorScopeCallbackInfoFFI callbackInfo) => WebGPU_FFI.DevicePopErrorScope(this, callbackInfo);

    /// <summary>
    /// Pushes a new error scope onto the errorScopeStack for this device
    /// </summary>
    /// <param name="filter">Which class of errors this error scope observes</param>
    public void PushErrorScope(ErrorFilter filter) => WebGPU_FFI.DevicePushErrorScope(this, filter);

    /// <summary>
    /// Set debug label of this device
    /// </summary>
    /// <param name="label">The label to set</param>
    public void SetLabel(StringViewFFI label) => WebGPU_FFI.DeviceSetLabel(this, label);

    public void AddRef() => WebGPU_FFI.DeviceAddRef(this);

    public void Release() => WebGPU_FFI.DeviceRelease(this);

}
