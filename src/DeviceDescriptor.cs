namespace WebGpuSharp;

public ref partial struct DeviceDescriptor
{
    public DeviceDescriptor() { }

    public WGPURefText Label;
    public Span<FeatureName> RequiredFeatures;
    public WGPUNullableRef<RequiredLimits> RequiredLimits;
    public QueueDescriptor DefaultQueue;
    public CallbackMode DeviceLostCallbackMode = CallbackMode.WaitAnyOnly;
    public DeviceLostCallbackDelegate? DeviceLostCallback;
    public UncapturedErrorDelegate? UncapturedErrorCallback;
}