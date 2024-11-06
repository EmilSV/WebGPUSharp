namespace WebGpuSharp;

public class WebGPUNotInReadWriteContext(string message) : WebGPUException(message);