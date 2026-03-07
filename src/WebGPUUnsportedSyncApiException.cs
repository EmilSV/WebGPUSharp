using WebGpuSharp;

public class WebGPUUnsupportedApiException : WebGPUException
{
    public WebGPUUnsupportedApiException(string message) : base(message)
    {
    }
}