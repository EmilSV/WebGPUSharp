namespace WebGpuSharp;

public class WebGPUNotInReadWriteContextException(string message) : WebGPUException(message);