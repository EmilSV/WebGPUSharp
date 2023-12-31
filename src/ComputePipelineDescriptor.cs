namespace WebGpuSharp;

public ref struct ComputePipelineDescriptor
{
    public WGPURefText Label;
    public PipelineLayout? Layout;
    public required ProgrammableStageDescriptor Compute;
}