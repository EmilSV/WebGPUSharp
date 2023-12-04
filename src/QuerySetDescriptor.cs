namespace WebGpuSharp;

public ref struct QuerySetDescriptor
{
    public WGPURefText Label;
    public required QueryType Type;
    public required uint Count;
    public ReadOnlySpan<PipelineStatisticName> PipelineStatistics;
}