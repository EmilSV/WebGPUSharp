using WebGpuSharp.FFI;
using WebGpuSharp.Internal;

namespace WebGpuSharp;

public struct RenderPassTimestampWrites: 
	IWebGpuFFIConvertible<RenderPassTimestampWrites,RenderPassTimestampWritesFFI>
{
	public required QuerySet QuerySet;
	public uint BeginningOfPassWriteIndex;
	public uint EndOfPassWriteIndex;

    static void IWebGpuFFIConvertible<RenderPassTimestampWrites, RenderPassTimestampWritesFFI>.UnsafeConvertToFFI(
		in RenderPassTimestampWrites input, out RenderPassTimestampWritesFFI dest)
    {
        dest = new RenderPassTimestampWritesFFI(
			querySet: WebGPUMarshal.GetBorrowHandle(input.QuerySet),
			beginningOfPassWriteIndex: input.BeginningOfPassWriteIndex,
			endOfPassWriteIndex: input.EndOfPassWriteIndex
		);
    }

    static void IWebGpuFFIConvertibleAlloc<RenderPassTimestampWrites, RenderPassTimestampWritesFFI>.UnsafeConvertToFFI(
		in RenderPassTimestampWrites input, WebGpuAllocatorHandle allocator, out RenderPassTimestampWritesFFI dest)
    {
        WebGPUMarshal.ToFFI(in input, allocator, out dest);
    }
}