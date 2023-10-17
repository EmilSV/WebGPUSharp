namespace WebGpuSharp;

public enum BufferMapAsyncStatus : int
{
	Success = 0,
	ValidationError = 1,
	Unknown = 2,
	DeviceLost = 3,
	DestroyedBeforeCallback = 4,
	UnmappedBeforeCallback = 5,
	MappingAlreadyPending = 6,
	OffsetOutOfRange = 7,
	SizeOutOfRange = 8,
}

