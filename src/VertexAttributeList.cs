using WebGpuSharp.Internal;

namespace WebGpuSharp;


public sealed class VertexAttributeList : PinnedList<VertexAttribute>
{

    public VertexAttributeList() : base()
    {
    }

    public VertexAttributeList(int capacity) : base(capacity)
    {
    }
}