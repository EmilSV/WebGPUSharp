using WebGpuSharp.FFI;
using WebGpuSharp.Internal;
using WebGpuSharp.Marshalling;

namespace WebGpuSharp;

/// <inheritdoc cref="ComputePassEncoderHandle"/>
public readonly struct ComputePassEncoder : 
    IEquatable<ComputePassEncoder>,
    IDebugCommands
{
    private readonly ulong _localToken;
    private readonly ComputePassEncoderHandle _originalHandle;
    private readonly ThreadLockedPooledHandle<ComputePassEncoderHandle> _pooledHandle;


    private ComputePassEncoder(ThreadLockedPooledHandle<ComputePassEncoderHandle> pooledHandle)
    {
        _localToken = pooledHandle.Token;
        _originalHandle = pooledHandle.GetHandle(pooledHandle.Token);
        _pooledHandle = pooledHandle;
    }

    internal static ComputePassEncoder FromHandle(ComputePassEncoderHandle handle)
    {
        var newComputePassEncoderPooledHandle = ThreadLockedPooledHandle<ComputePassEncoderHandle>.Get(handle);
        return new ComputePassEncoder(newComputePassEncoderPooledHandle);
    }

    internal ComputePassEncoderHandle GetHandle()
    {
        return _pooledHandle.GetHandle(_localToken);
    }

    /// <inheritdoc cref="ComputePassEncoderHandle.DispatchWorkgroups(uint, uint, uint)"/>
    public void DispatchWorkgroups(uint workgroupCountX, uint workgroupCountY = 1, uint workgroupCountZ = 1)
    {
        _pooledHandle.VerifyToken(_localToken);
        _originalHandle.DispatchWorkgroups(workgroupCountX, workgroupCountY, workgroupCountZ);
    }

    /// <inheritdoc cref="ComputePassEncoderHandle.DispatchWorkgroupsIndirect(Buffer, ulong)"/>
    public void DispatchWorkgroupsIndirect(Buffer indirectBuffer, ulong indirectOffset)
    {
        _pooledHandle.VerifyToken(_localToken);
        _originalHandle.DispatchWorkgroupsIndirect(indirectBuffer, indirectOffset);
    }

    /// <inheritdoc cref="ComputePassEncoderHandle.End()"/>
    public void End()
    {
        _pooledHandle.VerifyToken(_localToken);
        _originalHandle.End();
        ThreadLockedPooledHandle<ComputePassEncoderHandle>.Return(_pooledHandle);
    }

    /// <inheritdoc cref="ComputePassEncoderHandle.InsertDebugMarker(WGPURefText)"/>
    public void InsertDebugMarker(WGPURefText markerLabel)
    {
        _pooledHandle.VerifyToken(_localToken);
        _originalHandle.InsertDebugMarker(markerLabel);
    }
    /// <inheritdoc cref="ComputePassEncoderHandle.PopDebugGroup()"/>
    public void PopDebugGroup()
    {
        _pooledHandle.VerifyToken(_localToken);
        _originalHandle.PopDebugGroup();
    }

    /// <inheritdoc cref="ComputePassEncoderHandle.PushDebugGroup(WGPURefText)"/>
    public void PushDebugGroup(WGPURefText groupLabel)
    {
        _pooledHandle.VerifyToken(_localToken);
        _originalHandle.PushDebugGroup(groupLabel);
    }

    /// <inheritdoc cref="ComputePassEncoderHandle.SetBindGroup(uint, BindGroup, ReadOnlySpan{uint})"/>
    public void SetBindGroup(uint groupIndex, BindGroup group, ReadOnlySpan<uint> dynamicOffsets)
    {
        _pooledHandle.VerifyToken(_localToken);
        _originalHandle.SetBindGroup(groupIndex, group, dynamicOffsets);
    }

    /// <inheritdoc cref="ComputePassEncoderHandle.SetBindGroup(uint, BindGroup)"/>
    public void SetBindGroup(uint groupIndex, BindGroup group)
    {
        _pooledHandle.VerifyToken(_localToken);
        _originalHandle.SetBindGroup(groupIndex, group);
    }


    /// <inheritdoc cref="ComputePassEncoderHandle.SetLabel(WGPURefText)"/>
    public void SetLabel(WGPURefText label)
    {
        _pooledHandle.VerifyToken(_localToken);
        _originalHandle.SetLabel(label);
    }

    /// <inheritdoc cref="ComputePassEncoderHandle.SetPipeline(ComputePipeline)"/>
    public void SetPipeline(ComputePipeline pipeline)
    {
        _pooledHandle.VerifyToken(_localToken);
        _originalHandle.SetPipeline(pipeline);
    }

    public bool Equals(ComputePassEncoder other)
    {
        _pooledHandle.VerifyToken(_localToken);
        other._pooledHandle.VerifyToken(other._localToken);
        return _originalHandle.Equals(other._originalHandle);
    }

    public override bool Equals(object? obj)
    {
        return false;
    }

    public static bool operator ==(ComputePassEncoder left, ComputePassEncoder right)
    {
        return left._originalHandle == right._originalHandle;
    }

    public static bool operator !=(ComputePassEncoder left, ComputePassEncoder right)
    {
        return left._originalHandle != right._originalHandle;
    }

    public override int GetHashCode()
    {
        return _originalHandle.GetHashCode();
    }
}