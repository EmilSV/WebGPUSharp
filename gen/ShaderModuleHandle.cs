using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

/// <summary>
/// Handle to a compiled shader module.
/// 
/// A ShaderModule represents a compiled shader module on the GPU.
/// It can be created by passing source code to <see cref="DeviceHandle.CreateShaderModule" /> or valid SPIR-V binary to <see cref="DeviceHandle.CreateShaderModuleSpirv" />.
/// Shader modules are used to define programmable stages of a pipeline.
/// </summary>
public readonly unsafe partial struct ShaderModuleHandle : IEquatable<ShaderModuleHandle>
{
    private readonly nuint _ptr;
    public static ShaderModuleHandle Null
    {
        get => new(nuint.Zero);
    }

    public ShaderModuleHandle(nuint ptr) => _ptr = ptr;

    public static explicit operator nuint(ShaderModuleHandle handle) => handle._ptr;

    public static bool operator ==(ShaderModuleHandle left, ShaderModuleHandle right) => left._ptr == right._ptr;

    public static bool operator !=(ShaderModuleHandle left, ShaderModuleHandle right) => left._ptr != right._ptr;

    public static bool operator ==(ShaderModuleHandle left, ShaderModuleHandle? right) => left._ptr == right.GetValueOrDefault()._ptr;

    public static bool operator !=(ShaderModuleHandle left, ShaderModuleHandle? right) => left._ptr != right.GetValueOrDefault()._ptr;

    public static bool operator ==(ShaderModuleHandle left, nuint right) => left._ptr == right;

    public static bool operator !=(ShaderModuleHandle left, nuint right) => left._ptr != right;

    public nuint GetAddress() => _ptr;

    public bool Equals(ShaderModuleHandle other) => _ptr == other._ptr;

    public override bool Equals(object? other) => other is ShaderModuleHandle h && Equals(h) || other is null && _ptr == UIntPtr.Zero;

    public override int GetHashCode() => _ptr.GetHashCode();

    /// <summary>
    /// Returns any messages generated during the <see cref="ShaderModule" />'s compilation.
    /// The locations, order, and contents of messages are implementation-defined
    /// In particular, messages may not be ordered by <see cref="CompilationMessage.LineNum" />.
    /// </summary>
    public Future GetCompilationInfo(CompilationInfoCallbackInfoFFI callbackInfo) => WebGPU_FFI.ShaderModuleGetCompilationInfo(this, callbackInfo);

    /// <summary>
    /// Sets the debug label of the shader module.
    /// </summary>
    public void SetLabel(StringViewFFI label) => WebGPU_FFI.ShaderModuleSetLabel(this, label);

    public void AddRef() => WebGPU_FFI.ShaderModuleAddRef(this);

    public void Release() => WebGPU_FFI.ShaderModuleRelease(this);

}
