namespace WebGpuSharp;


public class WebGPUUsedOnWrongThreadException(string message) : WebGPUException(message)
{
}