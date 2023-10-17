namespace WebGpuSharp;

public enum SharedFenceType : int
{
	Undefined = 0,
	VkSemaphoreOpaqueFD = 1,
	VkSemaphoreSyncFD = 2,
	VkSemaphoreZirconHandle = 3,
	DXGISharedHandle = 4,
	MTLSharedEvent = 5,
}

