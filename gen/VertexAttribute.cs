using System;
using System.Runtime.InteropServices;
using WebGpuSharp.FFI;

namespace WebGpuSharp;

[StructLayout(LayoutKind.Sequential)]
public partial struct VertexAttribute
{
	public VertexFormat Format;
	public ulong Offset;
	public uint ShaderLocation;

	public VertexAttribute()
	{
		this.Format = default;
		this.Offset = default;
		this.ShaderLocation = default;
	}

	public VertexAttribute(VertexFormat format = default, ulong offset = default, uint shaderLocation = default)
	{
		this.Format = format;
		this.Offset = offset;
		this.ShaderLocation = shaderLocation;
	}
}

