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

    public BindGroupHandle CreateBindGroup(BindGroupDescriptorFFI* descriptor) => WebGPU_FFI.DeviceCreateBindGroup(this, descriptor);

    public BindGroupLayoutHandle CreateBindGroupLayout(BindGroupLayoutDescriptorFFI* descriptor) => WebGPU_FFI.DeviceCreateBindGroupLayout(this, descriptor);

    public BufferHandle CreateBuffer(BufferDescriptorFFI* descriptor) => WebGPU_FFI.DeviceCreateBuffer(this, descriptor);

    public CommandEncoderHandle CreateCommandEncoder(CommandEncoderDescriptorFFI* descriptor) => WebGPU_FFI.DeviceCreateCommandEncoder(this, descriptor);

    public ComputePipelineHandle CreateComputePipeline(ComputePipelineDescriptorFFI* descriptor) => WebGPU_FFI.DeviceCreateComputePipeline(this, descriptor);

    public void CreateComputePipelineAsync(ComputePipelineDescriptorFFI* descriptor, delegate* unmanaged[Cdecl]<CreatePipelineAsyncStatus, ComputePipelineHandle, StringViewFFI, void*, void> callback, void* userdata) => WebGPU_FFI.DeviceCreateComputePipelineAsync(this, descriptor, callback, userdata);

    public Future CreateComputePipelineAsync(ComputePipelineDescriptorFFI* descriptor, CreateComputePipelineAsyncCallbackInfo2FFI callbackInfo) => WebGPU_FFI.DeviceCreateComputePipelineAsync2(this, descriptor, callbackInfo);

    public Future CreateComputePipelineAsyncF(ComputePipelineDescriptorFFI* descriptor, CreateComputePipelineAsyncCallbackInfoFFI callbackInfo) => WebGPU_FFI.DeviceCreateComputePipelineAsyncF(this, descriptor, callbackInfo);

    public BufferHandle CreateErrorBuffer(BufferDescriptorFFI* descriptor) => WebGPU_FFI.DeviceCreateErrorBuffer(this, descriptor);

    public ExternalTextureHandle CreateErrorExternalTexture() => WebGPU_FFI.DeviceCreateErrorExternalTexture(this);

    public ShaderModuleHandle CreateErrorShaderModule(ShaderModuleDescriptorFFI* descriptor, StringViewFFI errorMessage) => WebGPU_FFI.DeviceCreateErrorShaderModule(this, descriptor, errorMessage);

    public TextureHandle CreateErrorTexture(TextureDescriptorFFI* descriptor) => WebGPU_FFI.DeviceCreateErrorTexture(this, descriptor);

    public ExternalTextureHandle CreateExternalTexture(ExternalTextureDescriptorFFI* externalTextureDescriptor) => WebGPU_FFI.DeviceCreateExternalTexture(this, externalTextureDescriptor);

    public PipelineLayoutHandle CreatePipelineLayout(PipelineLayoutDescriptorFFI* descriptor) => WebGPU_FFI.DeviceCreatePipelineLayout(this, descriptor);

    public QuerySetHandle CreateQuerySet(QuerySetDescriptorFFI* descriptor) => WebGPU_FFI.DeviceCreateQuerySet(this, descriptor);

    public RenderBundleEncoderHandle CreateRenderBundleEncoder(RenderBundleEncoderDescriptorFFI* descriptor) => WebGPU_FFI.DeviceCreateRenderBundleEncoder(this, descriptor);

    public RenderPipelineHandle CreateRenderPipeline(RenderPipelineDescriptorFFI* descriptor) => WebGPU_FFI.DeviceCreateRenderPipeline(this, descriptor);

    public void CreateRenderPipelineAsync(RenderPipelineDescriptorFFI* descriptor, delegate* unmanaged[Cdecl]<CreatePipelineAsyncStatus, RenderPipelineHandle, StringViewFFI, void*, void> callback, void* userdata) => WebGPU_FFI.DeviceCreateRenderPipelineAsync(this, descriptor, callback, userdata);

    public Future CreateRenderPipelineAsync(RenderPipelineDescriptorFFI* descriptor, CreateRenderPipelineAsyncCallbackInfo2FFI callbackInfo) => WebGPU_FFI.DeviceCreateRenderPipelineAsync2(this, descriptor, callbackInfo);

    public Future CreateRenderPipelineAsyncF(RenderPipelineDescriptorFFI* descriptor, CreateRenderPipelineAsyncCallbackInfoFFI callbackInfo) => WebGPU_FFI.DeviceCreateRenderPipelineAsyncF(this, descriptor, callbackInfo);

    public SamplerHandle CreateSampler(SamplerDescriptorFFI* descriptor) => WebGPU_FFI.DeviceCreateSampler(this, descriptor);

    public ShaderModuleHandle CreateShaderModule(ShaderModuleDescriptorFFI* descriptor) => WebGPU_FFI.DeviceCreateShaderModule(this, descriptor);

    public TextureHandle CreateTexture(TextureDescriptorFFI* descriptor) => WebGPU_FFI.DeviceCreateTexture(this, descriptor);

    public void Destroy() => WebGPU_FFI.DeviceDestroy(this);

    public void ForceLoss(DeviceLostReason type, StringViewFFI message) => WebGPU_FFI.DeviceForceLoss(this, type, message);

    public Status GetAHardwareBufferProperties(void* handle, AHardwareBufferProperties* properties) => WebGPU_FFI.DeviceGetAHardwareBufferProperties(this, handle, properties);

    public AdapterHandle GetAdapter() => WebGPU_FFI.DeviceGetAdapter(this);

    public Status GetAdapterInfo(AdapterInfoFFI* adapterInfo) => WebGPU_FFI.DeviceGetAdapterInfo(this, adapterInfo);

    public void GetFeatures(SupportedFeaturesFFI* features) => WebGPU_FFI.DeviceGetFeatures(this, features);

    public Status GetLimits(SupportedLimits* limits) => WebGPU_FFI.DeviceGetLimits(this, limits);

    public Future GetLostFuture() => WebGPU_FFI.DeviceGetLostFuture(this);

    public QueueHandle GetQueue() => WebGPU_FFI.DeviceGetQueue(this);

    public WebGPUBool HasFeature(FeatureName feature) => WebGPU_FFI.DeviceHasFeature(this, feature);

    public SharedBufferMemoryHandle ImportSharedBufferMemory(SharedBufferMemoryDescriptorFFI* descriptor) => WebGPU_FFI.DeviceImportSharedBufferMemory(this, descriptor);

    public SharedFenceHandle ImportSharedFence(SharedFenceDescriptorFFI* descriptor) => WebGPU_FFI.DeviceImportSharedFence(this, descriptor);

    public SharedTextureMemoryHandle ImportSharedTextureMemory(SharedTextureMemoryDescriptorFFI* descriptor) => WebGPU_FFI.DeviceImportSharedTextureMemory(this, descriptor);

    public void InjectError(ErrorType type, StringViewFFI message) => WebGPU_FFI.DeviceInjectError(this, type, message);

    public void PopErrorScope(delegate* unmanaged[Cdecl]<ErrorType, StringViewFFI, void*, void> oldCallback, void* userdata) => WebGPU_FFI.DevicePopErrorScope(this, oldCallback, userdata);

    public Future PopErrorScope(PopErrorScopeCallbackInfo2FFI callbackInfo) => WebGPU_FFI.DevicePopErrorScope2(this, callbackInfo);

    public Future PopErrorScopeF(PopErrorScopeCallbackInfoFFI callbackInfo) => WebGPU_FFI.DevicePopErrorScopeF(this, callbackInfo);

    public void PushErrorScope(ErrorFilter filter) => WebGPU_FFI.DevicePushErrorScope(this, filter);

    public void SetLabel(StringViewFFI label) => WebGPU_FFI.DeviceSetLabel(this, label);

    public void SetLoggingCallback(delegate* unmanaged[Cdecl]<LoggingType, StringViewFFI, void*, void> callback, void* userdata) => WebGPU_FFI.DeviceSetLoggingCallback(this, callback, userdata);

    public void Tick() => WebGPU_FFI.DeviceTick(this);

    public void ValidateTextureDescriptor(TextureDescriptorFFI* descriptor) => WebGPU_FFI.DeviceValidateTextureDescriptor(this, descriptor);

    public void AddRef() => WebGPU_FFI.DeviceAddRef(this);

    public void Release() => WebGPU_FFI.DeviceRelease(this);

}
