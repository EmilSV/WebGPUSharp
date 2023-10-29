namespace WebGpuSharp;

public ref partial struct DeviceDescriptor
{
    public WGPURefText Label;
    public Span<FeatureName> RequiredFeatures;
    public WGPUNullableRef<RequiredLimits> RequiredLimits;
    public QueueDescriptor DefaultQueue;
}