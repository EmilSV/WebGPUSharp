namespace WebGpuSharp;

public interface IDebugCommands
{
    void InsertDebugMarker(WGPURefText label);
    void PopDebugGroup();
    void PushDebugGroup(WGPURefText groupLabel);
}