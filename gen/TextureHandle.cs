using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

/// <summary>
/// Handle to a texture on the GPU.
/// 
/// It can be created with <see cref="DeviceHandle.CreateTexture" />.
/// </summary>
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
    /// Creates a  <see cref="TextureView"/>.
    /// </summary>
    /// <param name="descriptor">Description of the  <see cref="TextureView"/> to create.</param>
    public TextureViewHandle CreateView(TextureViewDescriptorFFI* descriptor) => WebGPU_FFI.TextureCreateView(this, descriptor);

    /// <summary>
    /// Destroys the  <see cref="Texture"/>.
    /// </summary>
    public void Destroy() => WebGPU_FFI.TextureDestroy(this);

    /// <summary>
    /// Returns the depth or layer count of this Texture.
    /// 
    /// This is always equal to the <see cref="TextureDescriptorFFI.Size.DepthOrArrayLayers" /> that was specified when creating the texture.
    /// </summary>
    public uint GetDepthOrArrayLayers() => WebGPU_FFI.TextureGetDepthOrArrayLayers(this);

    /// <summary>
    /// Returns the dimension of this Texture.
    /// 
    /// This is always equal to the <see cref="TextureDescriptorFFI.Dimension" /> that was specified when creating the texture.
    /// </summary>
    public TextureDimension GetDimension() => WebGPU_FFI.TextureGetDimension(this);

    /// <summary>
    /// Returns the format of this Texture.
    /// 
    /// This is always equal to the <see cref="TextureDescriptorFFI.Format" /> that was specified when creating the texture.
    /// </summary>
    public TextureFormat GetFormat() => WebGPU_FFI.TextureGetFormat(this);

    /// <summary>
    /// Returns the height of this Texture.
    /// 
    /// This is always equal to the <see cref="TextureDescriptorFFI.Size.Height" /> that was specified when creating the texture.
    /// </summary>
    public uint GetHeight() => WebGPU_FFI.TextureGetHeight(this);

    /// <summary>
    /// Returns the number of mip levels in the texture.
    /// </summary>
    public uint GetMipLevelCount() => WebGPU_FFI.TextureGetMipLevelCount(this);

    /// <summary>
    /// Returns the number of samples in the texture.
    /// </summary>
    public uint GetSampleCount() => WebGPU_FFI.TextureGetSampleCount(this);

    /// <summary>
    /// Returns the allowed usages of this Texture.
    /// 
    /// This is always equal to the usage that was specified when creating the texture.
    /// </summary>
    public TextureUsage GetUsage() => WebGPU_FFI.TextureGetUsage(this);

    /// <summary>
    /// Returns the width of this Texture.
    /// 
    /// This is always equal to the <see cref="TextureDescriptorFFI.Size.Width" /> that was specified when creating the texture.
    /// </summary>
    public uint GetWidth() => WebGPU_FFI.TextureGetWidth(this);

    /// <summary>
    /// Sets the debug label of texture.
    /// </summary>
    /// <param name="label">The new label.</param>
    public void SetLabel(StringViewFFI label) => WebGPU_FFI.TextureSetLabel(this, label);

    public void AddRef() => WebGPU_FFI.TextureAddRef(this);

    public void Release() => WebGPU_FFI.TextureRelease(this);

}
