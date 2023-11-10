namespace WebGpuSharp;

public ref struct QuerySetDescriptor
{
    public WGPURefText Label;
    public QueryType Type;
    public uint Count;
    public ReadOnlySpan<PipelineStatisticName> PipelineStatistics;
}