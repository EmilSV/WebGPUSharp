namespace WebGpuSharp;

public enum ErrorType : int
{
	NoError = 0,
	Validation = 1,
	OutOfMemory = 2,
	Internal = 3,
	Unknown = 4,
	DeviceLost = 5,
}

