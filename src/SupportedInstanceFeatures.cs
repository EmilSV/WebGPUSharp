namespace WebGpuSharp;


public readonly struct SupportedInstanceFeatures
{
    public ReadOnlySpan<InstanceFeatureName> Features => _features;

    private readonly InstanceFeatureName[] _features;
    internal SupportedInstanceFeatures(InstanceFeatureName[] features)
    {
        _features = features;
    }
}