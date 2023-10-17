using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

[StructLayout(LayoutKind.Sequential)]
public unsafe partial struct QuerySetDescriptorFFI
{
	public ChainedStruct* NextInChain;
	public byte* Label;
	public QueryType Type;
	public uint Count;
	public PipelineStatisticName* PipelineStatistics;
	public nuint PipelineStatisticsCount;

	public QuerySetDescriptorFFI()
	{
		this.NextInChain = default;
		this.Label = default;
		this.Type = default;
		this.Count = default;
		this.PipelineStatistics = default;
		this.PipelineStatisticsCount = default;
	}

	public QuerySetDescriptorFFI(byte* label = default, QueryType type = default, uint count = default, PipelineStatisticName* pipelineStatistics = default, nuint pipelineStatisticsCount = default)
	{
		this.Label = label;
		this.Type = type;
		this.Count = count;
		this.PipelineStatistics = pipelineStatistics;
		this.PipelineStatisticsCount = pipelineStatisticsCount;
	}

	public QuerySetDescriptorFFI(ChainedStruct* nextInChain = default, byte* label = default, QueryType type = default, uint count = default, PipelineStatisticName* pipelineStatistics = default, nuint pipelineStatisticsCount = default)
	{
		this.NextInChain = nextInChain;
		this.Label = label;
		this.Type = type;
		this.Count = count;
		this.PipelineStatistics = pipelineStatistics;
		this.PipelineStatisticsCount = pipelineStatisticsCount;
	}
}

