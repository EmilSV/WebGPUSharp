namespace WebGpuSharp;

public struct VertexBufferLayout
{
    public required ulong ArrayStride;
    public VertexStepMode StepMode = VertexStepMode.Vertex;
    public required VertexAttributeList Attributes;

    public VertexBufferLayout()
    {

    }

    public VertexBufferLayout(
        ulong arrayStride,
        VertexStepMode stepMode,
        VertexAttributeList attributes
    )
    {
        this.ArrayStride = arrayStride;
        this.StepMode = stepMode;
        this.Attributes = attributes;
    }
}