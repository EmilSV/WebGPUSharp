namespace WebGpuSharp;

public ref struct InstanceDescriptor
{
    public ReadOnlySpan<InstanceFeatureName> RequiredFeatures = [];
    public InstanceLimits? RequiredLimits = null;

    public InstanceDescriptor()
    {
    }
}
