using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

/// <summary>
/// Handle to a rendering (graphics) pipeline.
/// 
/// A RenderPipeline object represents a graphics pipeline and its stages, bindings, vertex buffers and targets.
/// It can be created with <see cref="DeviceHandle.CreateRenderPipeline" />.
/// </summary>
public readonly unsafe partial struct RenderPipelineHandle : IEquatable<RenderPipelineHandle>
{
    private readonly nuint _ptr;
    public static RenderPipelineHandle Null
    {
        get => new(nuint.Zero);
    }

    public RenderPipelineHandle(nuint ptr) => _ptr = ptr;

    public static explicit operator nuint(RenderPipelineHandle handle) => handle._ptr;

    public static bool operator ==(RenderPipelineHandle left, RenderPipelineHandle right) => left._ptr == right._ptr;

    public static bool operator !=(RenderPipelineHandle left, RenderPipelineHandle right) => left._ptr != right._ptr;

    public static bool operator ==(RenderPipelineHandle left, RenderPipelineHandle? right) => left._ptr == right.GetValueOrDefault()._ptr;

    public static bool operator !=(RenderPipelineHandle left, RenderPipelineHandle? right) => left._ptr != right.GetValueOrDefault()._ptr;

    public static bool operator ==(RenderPipelineHandle left, nuint right) => left._ptr == right;

    public static bool operator !=(RenderPipelineHandle left, nuint right) => left._ptr != right;

    public nuint GetAddress() => _ptr;

    public bool Equals(RenderPipelineHandle other) => _ptr == other._ptr;

    public override bool Equals(object? other) => other is RenderPipelineHandle h && Equals(h) || other is null && _ptr == UIntPtr.Zero;

    public override int GetHashCode() => _ptr.GetHashCode();

    /// <summary>
    /// Get an object representing the bind group layout at a given index.
    /// 
    /// If this pipeline was created with a default layout, then bind groups created with the returned BindGroupLayout can only be used with this pipeline.
    /// 
    /// This method will raise a validation error if there is no bind group layout at index.
    /// </summary>
    public BindGroupLayoutHandle GetBindGroupLayout(uint groupIndex) => WebGPU_FFI.RenderPipelineGetBindGroupLayout(this, groupIndex);

    /// <summary>
    /// Set the debug label of this RenderPipelineHandle.
    /// </summary>
    public void SetLabel(StringViewFFI label) => WebGPU_FFI.RenderPipelineSetLabel(this, label);

    public void AddRef() => WebGPU_FFI.RenderPipelineAddRef(this);

    public void Release() => WebGPU_FFI.RenderPipelineRelease(this);

}
