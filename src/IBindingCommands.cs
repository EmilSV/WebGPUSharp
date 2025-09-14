namespace WebGpuSharp;

public interface IBindingCommands
{
    void SetBindGroup(uint groupIndex, BindGroup group);
    void SetBindGroup(uint groupIndex, BindGroup group, uint dynamicOffset);
    void SetBindGroup(uint groupIndex, BindGroup group, ReadOnlySpan<uint> dynamicOffsets);
}