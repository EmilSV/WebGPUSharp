namespace WebGpuSharp;

public ref struct ComputePipelineDescriptor
{
    public WGPURefText Label;
    public PipelineLayoutBase? Layout;
    public required ProgrammableStageDescriptor Compute;
}