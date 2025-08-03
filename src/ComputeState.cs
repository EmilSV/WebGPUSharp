namespace WebGpuSharp;

/// <inheritdoc cref="FFI.ComputeStateFFI" />
public ref partial struct ComputeState
{
    /// <inheritdoc cref="FFI.ComputeStateFFI.Module" />
    public required ShaderModuleBase Module;
    /// <inheritdoc cref="FFI.ComputeStateFFI.EntryPoint" />
    public required WGPURefText EntryPoint;
    /// <inheritdoc cref="FFI.ComputeStateFFI.Constants" />
    public required WebGpuManagedSpan<ConstantEntry> Constants;
}