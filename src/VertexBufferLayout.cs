namespace WebGpuSharp;

public partial struct VertexBufferLayout
{
    public ulong ArrayStride;
    public VertexStepMode StepMode;
    public VertexAttributeList? Attributes;

    public VertexBufferLayout(
        ulong arrayStride = default,
        VertexStepMode stepMode = default,
        VertexAttributeList? attributes = default
    )
    {
        this.ArrayStride = arrayStride;
        this.StepMode = stepMode;
        this.Attributes = attributes;
    }
}