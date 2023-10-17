using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

[StructLayout(LayoutKind.Sequential)]
public partial struct ComputePassTimestampWriteFFI
{
	public QuerySetHandle QuerySet;
	public uint QueryIndex;
	public ComputePassTimestampLocation Location;

	public ComputePassTimestampWriteFFI()
	{
		this.QuerySet = default;
		this.QueryIndex = default;
		this.Location = default;
	}

	public ComputePassTimestampWriteFFI(QuerySetHandle querySet = default, uint queryIndex = default, ComputePassTimestampLocation location = default)
	{
		this.QuerySet = querySet;
		this.QueryIndex = queryIndex;
		this.Location = location;
	}
}

