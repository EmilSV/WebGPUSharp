namespace WebGpuSharp;

public interface IBindingCommands
{
    void SetBindGroup(uint groupIndex, BindGroupBase group);
    void SetBindGroup(uint groupIndex, BindGroupBase group, uint dynamicOffset);
    void SetBindGroup(uint groupIndex, BindGroupBase group, ReadOnlySpan<uint> dynamicOffsets);
}