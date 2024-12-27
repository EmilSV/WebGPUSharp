namespace WebGpuSharp;

public interface IRenderCommands : IBindingCommands
{
    void SetPipeline(RenderPipelineBase pipeline);

    void SetIndexBuffer(BufferBase buffer, IndexFormat format, ulong offset, ulong size);
    void SetIndexBuffer(BufferBase buffer, IndexFormat format, ulong offset = 0);

    void SetVertexBuffer(uint slot, BufferBase buffer, ulong offset, ulong size);
    void SetVertexBuffer(uint slot, BufferBase buffer, ulong offset = 0);

    void Draw(
      uint vertexCount, uint instanceCount = 1,
      uint firstVertex = 0, uint firstInstance = 0);

    void DrawIndexed(
        uint indexCount, uint instanceCount = 1,
        uint firstIndex = 0, int baseVertex = 0, uint firstInstance = 0);

    void DrawIndirect(
        BufferBase indirectBuffer, ulong indirectOffset);

    void DrawIndexedIndirect(
        BufferBase indirectBuffer, ulong indirectOffset);
}