namespace WebGpuSharp;

public ref partial struct ProgrammableStageDescriptor
{
    public required ShaderModuleBase Module;
    public required WGPURefText EntryPoint;
    public required ConstantEntryList Constants;
}