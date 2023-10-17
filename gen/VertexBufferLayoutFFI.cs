using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

[StructLayout(LayoutKind.Sequential)]
public unsafe partial struct VertexBufferLayoutFFI
{
	public ulong ArrayStride;
	public VertexStepMode StepMode;
	public nuint AttributeCount;
	public VertexAttribute* Attributes;

	public VertexBufferLayoutFFI()
	{
		this.ArrayStride = default;
		this.StepMode = default;
		this.AttributeCount = default;
		this.Attributes = default;
	}

	public VertexBufferLayoutFFI(ulong arrayStride = default, VertexStepMode stepMode = default, nuint attributeCount = default, VertexAttribute* attributes = default)
	{
		this.ArrayStride = arrayStride;
		this.StepMode = stepMode;
		this.AttributeCount = attributeCount;
		this.Attributes = attributes;
	}
}

