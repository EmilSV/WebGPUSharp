using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

[StructLayout(LayoutKind.Sequential)]
public unsafe partial struct CompilationInfoFFI
{
	public ChainedStruct* NextInChain;
	public nuint MessageCount;
	public CompilationMessageFFI* Messages;

	public CompilationInfoFFI()
	{
		this.NextInChain = default;
		this.MessageCount = default;
		this.Messages = default;
	}

	public CompilationInfoFFI(nuint messageCount = default, CompilationMessageFFI* messages = default)
	{
		this.MessageCount = messageCount;
		this.Messages = messages;
	}

	public CompilationInfoFFI(ChainedStruct* nextInChain = default, nuint messageCount = default, CompilationMessageFFI* messages = default)
	{
		this.NextInChain = nextInChain;
		this.MessageCount = messageCount;
		this.Messages = messages;
	}
}

