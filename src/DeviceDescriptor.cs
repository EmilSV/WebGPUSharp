namespace WebGpuSharp;

public ref partial struct DeviceDescriptor
{
    public DeviceDescriptor() { }

    public WGPURefText Label;
    public Span<FeatureName> RequiredFeatures;
    public WGPUNullableRef<Limits> RequiredLimits;
    public QueueDescriptor DefaultQueue;
    public CallbackMode DeviceLostCallbackMode = CallbackMode.AllowProcessEvents;
    public DeviceLostCallbackDelegate? DeviceLostCallback;
    public UncapturedErrorDelegate? UncapturedErrorCallback;
}