namespace WebGpuSharp;

public ref struct ComputePipelineDescriptor
{
    public WGPURefText Label;
    public PipelineLayout? Layout;
    required public ProgrammableStageDescriptor Compute;
}