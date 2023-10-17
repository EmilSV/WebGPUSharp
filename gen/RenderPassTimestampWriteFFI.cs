using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

[StructLayout(LayoutKind.Sequential)]
public partial struct RenderPassTimestampWriteFFI
{
	public QuerySetHandle QuerySet;
	public uint QueryIndex;
	public RenderPassTimestampLocation Location;

	public RenderPassTimestampWriteFFI()
	{
		this.QuerySet = default;
		this.QueryIndex = default;
		this.Location = default;
	}

	public RenderPassTimestampWriteFFI(QuerySetHandle querySet = default, uint queryIndex = default, RenderPassTimestampLocation location = default)
	{
		this.QuerySet = querySet;
		this.QueryIndex = queryIndex;
		this.Location = location;
	}
}

