namespace WebGpuSharp
{
    public delegate void CreateComputePipelineAsyncDelegate<T>(
        CreatePipelineAsyncStatus status, T Handle, ReadOnlySpan<byte> message
    );
}