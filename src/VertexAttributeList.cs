using System.Runtime.CompilerServices;
using WebGpuSharp.Internal;

namespace WebGpuSharp;

[CollectionBuilder(typeof(VertexAttributeList), "Create")]
public sealed class VertexAttributeList : PinnedList<VertexAttribute>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static VertexAttributeList Create(ReadOnlySpan<VertexAttribute> vertexAttributes) =>
        new(vertexAttributes);

    public VertexAttributeList() : base()
    {
    }

    public VertexAttributeList(int capacity) : base(capacity)
    {
    }

    public VertexAttributeList(ReadOnlySpan<VertexAttribute> vertexAttributes) : base(vertexAttributes)
    {
    }
}