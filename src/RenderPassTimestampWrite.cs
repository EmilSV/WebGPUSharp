namespace WebGpuSharp;

public struct RenderPassTimestampWrite
{
    public required QuerySet QuerySet;
    public uint QueryIndex;
    public RenderPassTimestampLocation Location;
}