namespace WebGpuSharp;

[System.Flags]
public enum ColorWriteMask : uint
{
	None = 0,
	Red = 1,
	Green = 2,
	Blue = 4,
	Alpha = 8,
	All = 15,
}

