using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

[StructLayout(LayoutKind.Sequential)]
public unsafe partial struct FragmentStateFFI
{
	public ChainedStruct* NextInChain;
	public ShaderModuleHandle Module;
	public byte* EntryPoint;
	public nuint ConstantCount;
	public ConstantEntryFFI* Constants;
	public nuint TargetCount;
	public ColorTargetStateFFI* Targets;

	public FragmentStateFFI()
	{
		this.NextInChain = default;
		this.Module = default;
		this.EntryPoint = default;
		this.ConstantCount = default;
		this.Constants = default;
		this.TargetCount = default;
		this.Targets = default;
	}

	public FragmentStateFFI(ShaderModuleHandle module = default, byte* entryPoint = default, nuint constantCount = default, ConstantEntryFFI* constants = default, nuint targetCount = default, ColorTargetStateFFI* targets = default)
	{
		this.Module = module;
		this.EntryPoint = entryPoint;
		this.ConstantCount = constantCount;
		this.Constants = constants;
		this.TargetCount = targetCount;
		this.Targets = targets;
	}

	public FragmentStateFFI(ChainedStruct* nextInChain = default, ShaderModuleHandle module = default, byte* entryPoint = default, nuint constantCount = default, ConstantEntryFFI* constants = default, nuint targetCount = default, ColorTargetStateFFI* targets = default)
	{
		this.NextInChain = nextInChain;
		this.Module = module;
		this.EntryPoint = entryPoint;
		this.ConstantCount = constantCount;
		this.Constants = constants;
		this.TargetCount = targetCount;
		this.Targets = targets;
	}
}

