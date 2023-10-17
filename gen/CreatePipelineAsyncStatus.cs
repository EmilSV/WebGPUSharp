namespace WebGpuSharp;

public enum CreatePipelineAsyncStatus : int
{
	Success = 0,
	ValidationError = 1,
	InternalError = 2,
	DeviceLost = 3,
	DeviceDestroyed = 4,
	Unknown = 5,
}

