namespace WebGpuSharp;

public ref partial struct ProgrammableStageDescriptor
{
    public required ShaderModule Module;
    public required WGPURefText EntryPoint;
    public required ConstantEntryList Constants;
}