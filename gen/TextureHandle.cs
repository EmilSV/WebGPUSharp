using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public readonly unsafe partial struct TextureHandle : IEquatable<TextureHandle>
{
    private readonly nuint _ptr;
    public static TextureHandle Null
    {
        get => new(nuint.Zero);
    }

    public TextureHandle(nuint ptr) => _ptr = ptr;

    public static explicit operator nuint(TextureHandle handle) => handle._ptr;

    public static bool operator ==(TextureHandle left, TextureHandle right) => left._ptr == right._ptr;

    public static bool operator !=(TextureHandle left, TextureHandle right) => left._ptr != right._ptr;

    public static bool operator ==(TextureHandle left, TextureHandle? right) => left._ptr == right.GetValueOrDefault()._ptr;

    public static bool operator !=(TextureHandle left, TextureHandle? right) => left._ptr != right.GetValueOrDefault()._ptr;

    public static bool operator ==(TextureHandle left, nuint right) => left._ptr == right;

    public static bool operator !=(TextureHandle left, nuint right) => left._ptr != right;

    public nuint GetAddress() => _ptr;

    public bool Equals(TextureHandle other) => _ptr == other._ptr;

    public override bool Equals(object? other) => other is TextureHandle h && Equals(h) || other is null && _ptr == UIntPtr.Zero;

    public override int GetHashCode() => _ptr.GetHashCode();

    /// <summary>
    /// Creates a  <see cref="WebGpuSharp.TextureView"/>.
    /// </summary>
    /// <param name="descriptor">Description of the  <see cref="WebGpuSharp.TextureView"/> to create.</param>
    public TextureViewHandle CreateView(TextureViewDescriptorFFI* descriptor) => WebGPU_FFI.TextureCreateView(this, descriptor);

    /// <summary>
    /// Destroys the  <see cref="WebGpuSharp.Texture"/>.
    /// </summary>
    public void Destroy() => WebGPU_FFI.TextureDestroy(this);

    public uint GetDepthOrArrayLayers() => WebGPU_FFI.TextureGetDepthOrArrayLayers(this);

    public TextureDimension GetDimension() => WebGPU_FFI.TextureGetDimension(this);

    public TextureFormat GetFormat() => WebGPU_FFI.TextureGetFormat(this);

    public uint GetHeight() => WebGPU_FFI.TextureGetHeight(this);

    public uint GetMipLevelCount() => WebGPU_FFI.TextureGetMipLevelCount(this);

    public uint GetSampleCount() => WebGPU_FFI.TextureGetSampleCount(this);

    public TextureUsage GetUsage() => WebGPU_FFI.TextureGetUsage(this);

    public uint GetWidth() => WebGPU_FFI.TextureGetWidth(this);

    public void SetLabel(StringViewFFI label) => WebGPU_FFI.TextureSetLabel(this, label);

    public void AddRef() => WebGPU_FFI.TextureAddRef(this);

    public void Release() => WebGPU_FFI.TextureRelease(this);

}
