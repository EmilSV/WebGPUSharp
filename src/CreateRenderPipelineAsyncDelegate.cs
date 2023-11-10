namespace WebGpuSharp
{
    public delegate void CreateRenderPipelineAsyncDelegate<T>(
        CreatePipelineAsyncStatus status, T Handle, ReadOnlySpan<byte> message
    );
}