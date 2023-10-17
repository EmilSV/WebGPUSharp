namespace WebGpuSharp;

public ref partial struct DeviceDescriptor
{
    public WGPURefText Label;
    public ref RequiredLimits RequiredLimits;
    public Span<FeatureName> RequiredFeatures;
    public QueueDescriptor DefaultQueue;
}