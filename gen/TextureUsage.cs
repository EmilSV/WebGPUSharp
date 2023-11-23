namespace WebGpuSharp;

[System.Flags]
public enum TextureUsage : uint
{
	None = 0,
	CopySrc = 1,
	CopyDst = 2,
	TextureBinding = 4,
	StorageBinding = 8,
	RenderAttachment = 16,
	TransientAttachment = 32,
	StorageAttachment = 64,
}

