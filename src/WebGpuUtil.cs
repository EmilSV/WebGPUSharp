namespace WebGpuSharp;

public static class WebGpuUtil
{
    public static ref readonly T InlineInit<T>(in T value)
    {
        return ref value;
    }
}