namespace WebGpuSharp;

public unsafe partial struct BindGroupEntry
{
    public uint Binding;
    public Buffer? Buffer;
    public ulong Offset;
    public ulong Size;
    public Sampler? Sampler;
    public TextureView? TextureView;

    public BindGroupEntry()
    {
        Binding = default;
        Buffer = default;
        Offset = default;
        Size = default;
        Sampler = default;
        TextureView = default;
    }

    public BindGroupEntry(
        uint binding = default, Buffer? buffer = default,
        ulong offset = default, ulong size = default,
        Sampler? sampler = default, TextureView? textureView = default)
    {
        Binding = binding;
        Buffer = buffer;
        Offset = offset;
        Size = size;
        Sampler = sampler;
        TextureView = textureView;
    }
}

