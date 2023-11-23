namespace WebGpuSharp;

public enum WaitStatus : int
{
	Success = 0,
	TimedOut = 1,
	UnsupportedTimeout = 2,
	UnsupportedCount = 3,
	UnsupportedMixedSources = 4,
	Unknown = 5,
}

