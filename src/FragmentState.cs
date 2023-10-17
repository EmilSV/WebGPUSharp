using WebGpuSharp.FFI;

namespace WebGpuSharp;

public partial struct FragmentState
{
    public ShaderModuleHandle Module;
    public string EntryPoint;
    public ConstantEntryList? Constants;
    public ColorTargetStateList? Targets;
}