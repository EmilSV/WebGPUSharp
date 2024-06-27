using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct ComputePassTimestampWritesFFI
{
    public QuerySetHandle QuerySet;
    public uint BeginningOfPassWriteIndex;
    public uint EndOfPassWriteIndex;

    public ComputePassTimestampWritesFFI()
    {
    }


    public ComputePassTimestampWritesFFI(QuerySetHandle querySet = default, uint beginningOfPassWriteIndex = default, uint endOfPassWriteIndex = default)
    {
        this.QuerySet = querySet;
        this.BeginningOfPassWriteIndex = beginningOfPassWriteIndex;
        this.EndOfPassWriteIndex = endOfPassWriteIndex;
    }

}
