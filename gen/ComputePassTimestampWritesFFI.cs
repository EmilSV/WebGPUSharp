using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

[StructLayout(LayoutKind.Sequential)]
public partial struct ComputePassTimestampWritesFFI
{
	public QuerySetHandle QuerySet;
	public uint BeginningOfPassWriteIndex;
	public uint EndOfPassWriteIndex;

	public ComputePassTimestampWritesFFI()
	{
		this.QuerySet = default;
		this.BeginningOfPassWriteIndex = default;
		this.EndOfPassWriteIndex = default;
	}

	public ComputePassTimestampWritesFFI(QuerySetHandle querySet = default, uint beginningOfPassWriteIndex = default, uint endOfPassWriteIndex = default)
	{
		this.QuerySet = querySet;
		this.BeginningOfPassWriteIndex = beginningOfPassWriteIndex;
		this.EndOfPassWriteIndex = endOfPassWriteIndex;
	}
}

