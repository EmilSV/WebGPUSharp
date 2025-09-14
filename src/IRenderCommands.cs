namespace WebGpuSharp;

public interface IRenderCommands : IBindingCommands
{
    void SetPipeline(RenderPipeline pipeline);

    void SetIndexBuffer(Buffer buffer, IndexFormat format, ulong offset, ulong size);
    void SetIndexBuffer(Buffer buffer, IndexFormat format, ulong offset = 0);

    void SetVertexBuffer(uint slot, Buffer buffer, ulong offset, ulong size);
    void SetVertexBuffer(uint slot, Buffer buffer, ulong offset = 0);

    void Draw(
      uint vertexCount, uint instanceCount = 1,
      uint firstVertex = 0, uint firstInstance = 0);

    void DrawIndexed(
        uint indexCount, uint instanceCount = 1,
        uint firstIndex = 0, int baseVertex = 0, uint firstInstance = 0);

    void DrawIndirect(
        Buffer indirectBuffer, ulong indirectOffset);

    void DrawIndexedIndirect(
        Buffer indirectBuffer, ulong indirectOffset);
}