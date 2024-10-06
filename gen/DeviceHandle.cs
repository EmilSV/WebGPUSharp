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
    public void CreateComputePipelineAsync(ComputePipelineDescriptorFFI* descriptor, delegate* unmanaged[Cdecl]<CreatePipelineAsyncStatus, ComputePipelineHandle, byte*, void*, void> callback, void* userdata) => WebGPU_FFI.DeviceCreateComputePipelineAsync(this, descriptor, callback, userdata);
    public PipelineLayoutHandle CreatePipelineLayout(PipelineLayoutDescriptorFFI* descriptor) => WebGPU_FFI.DeviceCreatePipelineLayout(this, descriptor);
    public QuerySetHandle CreateQuerySet(QuerySetDescriptorFFI* descriptor) => WebGPU_FFI.DeviceCreateQuerySet(this, descriptor);
    public RenderBundleEncoderHandle CreateRenderBundleEncoder(RenderBundleEncoderDescriptorFFI* descriptor) => WebGPU_FFI.DeviceCreateRenderBundleEncoder(this, descriptor);
    public RenderPipelineHandle CreateRenderPipeline(RenderPipelineDescriptorFFI* descriptor) => WebGPU_FFI.DeviceCreateRenderPipeline(this, descriptor);
    public void CreateRenderPipelineAsync(RenderPipelineDescriptorFFI* descriptor, delegate* unmanaged[Cdecl]<CreatePipelineAsyncStatus, RenderPipelineHandle, byte*, void*, void> callback, void* userdata) => WebGPU_FFI.DeviceCreateRenderPipelineAsync(this, descriptor, callback, userdata);
    public SamplerHandle CreateSampler(SamplerDescriptorFFI* descriptor) => WebGPU_FFI.DeviceCreateSampler(this, descriptor);
    public ShaderModuleHandle CreateShaderModule(ShaderModuleDescriptorFFI* descriptor) => WebGPU_FFI.DeviceCreateShaderModule(this, descriptor);
    public TextureHandle CreateTexture(TextureDescriptorFFI* descriptor) => WebGPU_FFI.DeviceCreateTexture(this, descriptor);
    public void Destroy() => WebGPU_FFI.DeviceDestroy(this);
    public nuint EnumerateFeatures(FeatureName* features) => WebGPU_FFI.DeviceEnumerateFeatures(this, features);
    public Status GetLimits(SupportedLimits* limits) => WebGPU_FFI.DeviceGetLimits(this, limits);
    public QueueHandle GetQueue() => WebGPU_FFI.DeviceGetQueue(this);
    public WebGPUBool HasFeature(FeatureName feature) => WebGPU_FFI.DeviceHasFeature(this, feature);
    public void PopErrorScope(delegate* unmanaged[Cdecl]<ErrorType, byte*, void*, void> oldCallback, void* userdata) => WebGPU_FFI.DevicePopErrorScope(this, oldCallback, userdata);
    public void PushErrorScope(ErrorFilter filter) => WebGPU_FFI.DevicePushErrorScope(this, filter);
    public void SetLabel(byte* label) => WebGPU_FFI.DeviceSetLabel(this, label);
    public void SetLabel(StringViewFFI label) => WebGPU_FFI.DeviceSetLabel2(this, label);
    public void SetUncapturedErrorCallback(delegate* unmanaged[Cdecl]<ErrorType, byte*, void*, void> callback, void* userdata) => WebGPU_FFI.DeviceSetUncapturedErrorCallback(this, callback, userdata);
    public void AddRef() => WebGPU_FFI.DeviceAddRef(this);
    public void Release() => WebGPU_FFI.DeviceRelease(this);
}
