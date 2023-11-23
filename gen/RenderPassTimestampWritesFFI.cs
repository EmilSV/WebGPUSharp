using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

[StructLayout(LayoutKind.Sequential)]
public partial struct RenderPassTimestampWritesFFI
{
	public QuerySetHandle QuerySet;
	public uint BeginningOfPassWriteIndex;
	public uint EndOfPassWriteIndex;

	public RenderPassTimestampWritesFFI()
	{
		this.QuerySet = default;
		this.BeginningOfPassWriteIndex = default;
		this.EndOfPassWriteIndex = default;
	}

	public RenderPassTimestampWritesFFI(QuerySetHandle querySet = default, uint beginningOfPassWriteIndex = default, uint endOfPassWriteIndex = default)
	{
		this.QuerySet = querySet;
		this.BeginningOfPassWriteIndex = beginningOfPassWriteIndex;
		this.EndOfPassWriteIndex = endOfPassWriteIndex;
	}
}

