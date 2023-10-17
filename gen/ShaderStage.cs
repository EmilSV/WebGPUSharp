namespace WebGpuSharp;

[System.Flags]
public enum ShaderStage : uint
{
	None = 0,
	Vertex = 1,
	Fragment = 2,
	Compute = 4,
}

