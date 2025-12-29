using WebGpuSharp.FFI;
using WebGpuSharp.Internal;
using WebGpuSharp.Marshalling;
using static WebGpuSharp.Marshalling.WebGPUMarshal;

namespace WebGpuSharp;

/// <inheritdoc cref="BindGroupEntryFFI"/>
public struct BindGroupEntry : IWebGpuMarshallable<BindGroupEntry, BindGroupEntryFFI>
{
    /// <inheritdoc cref="BindGroupEntryFFI.Binding"/>
    public required uint Binding;
    /// <inheritdoc cref="BindGroupEntryFFI.Buffer"/>
    public Buffer? Buffer;
    /// <inheritdoc cref="BindGroupEntryFFI.Offset"/>
    public ulong Offset = 0;
    /// <inheritdoc cref="BindGroupEntryFFI.Size"/>
    public ulong? Size;
    /// <inheritdoc cref="BindGroupEntryFFI.Sampler"/>
    public Sampler? Sampler;
    /// <inheritdoc cref="BindGroupEntryFFI.TextureView"/>
    public TextureView? TextureView;

    public BindGroupEntry()
    {
    }

    static void IWebGpuMarshallable<BindGroupEntry, BindGroupEntryFFI>.MarshalToFFI(in BindGroupEntry input, out BindGroupEntryFFI dest)
    {
        ulong size = 0;
        if (input.Size.HasValue)
        {
            size = input.Size.Value;
        }
        else if (input.Buffer != null)
        {
            size = input.Buffer.GetSize() - input.Offset;
        }

        dest = new()
        {
            Binding = input.Binding,
            Buffer = GetHandle(input.Buffer),
            Offset = input.Offset,
            Size = size,
            Sampler = GetHandle(input.Sampler),
            TextureView = GetHandle(input.TextureView)
        };
    }
}

