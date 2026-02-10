using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

/// <summary>
/// Handle to a texture on the GPU.
/// 
/// It can be created with <see cref="DeviceHandle.CreateTexture" />.
/// </summary>
public unsafe partial struct TextureHandle : IEquatable<TextureHandle>
{
    private readonly nuint _ptr;
    /// <summary>
    /// Get a null handle.
    /// </summary>
    public static TextureHandle Null
    {
        get => new(nuint.Zero);
    }

    public TextureHandle(nuint ptr) => _ptr = ptr;

    /// <summary>
    /// Convert a handle to a pointer.
    /// </summary>
    /// <param name="handle">The handle to convert.</param>
    public static explicit operator nuint(TextureHandle handle) => handle._ptr;

    /// <summary>
    /// Check if two handles are equal.
    /// </summary>
    /// <param name="left">The left handle.</param>
    /// <param name="right">The right handle.</param>
    public static bool operator ==(TextureHandle left, TextureHandle right) => left._ptr == right._ptr;

    /// <summary>
    /// Check if two handles are not equal.
    /// </summary>
    /// <param name="left">The left handle.</param>
    /// <param name="right">The right handle.</param>
    public static bool operator !=(TextureHandle left, TextureHandle right) => left._ptr != right._ptr;

    /// <summary>
    /// Check if two handles are equal.
    /// </summary>
    /// <param name="left">The left handle.</param>
    /// <param name="right">The right handle.</param>
    public static bool operator ==(TextureHandle left, TextureHandle? right) => left._ptr == right.GetValueOrDefault()._ptr;

    /// <summary>
    /// Check if two handles are not equal.
    /// </summary>
    /// <param name="left">The left handle.</param>
    /// <param name="right">The right handle.</param>
    public static bool operator !=(TextureHandle left, TextureHandle? right) => left._ptr != right.GetValueOrDefault()._ptr;

    /// <summary>
    /// Check if a handle is equal to a pointer.
    /// </summary>
    /// <param name="left">The left handle.</param>
    /// <param name="right">The right pointer.</param>
    public static bool operator ==(TextureHandle left, nuint right) => left._ptr == right;

    /// <summary>
    /// Check if a handle is not equal to a pointer.
    /// </summary>
    /// <param name="left">The left handle.</param>
    /// <param name="right">The right pointer.</param>
    public static bool operator !=(TextureHandle left, nuint right) => left._ptr != right;

    /// <summary>
    /// Get the address of the handle.
    /// </summary>
    public nuint GetAddress() => _ptr;

    /// <summary>
    /// Indicates whether the current object is equal to another object of the same type.
    /// </summary>
    /// <param name="other">The other handle to compare with</param>
    public bool Equals(TextureHandle other) => _ptr == other._ptr;

    /// <summary>
    /// Returns a value indicating whether this instance is equal to a specified object.
    /// </summary>
    /// <param name="other">The other object to compare with</param>
    public override bool Equals(object? other) => other is TextureHandle h && Equals(h) || other is null && _ptr == UIntPtr.Zero;

    /// <summary>
    /// Returns the hash code for this instance.
    /// </summary>
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
    /// This is always equal to the <see cref="TextureDescriptorFFI.Size" />.<see cref="Extent3D.DepthOrArrayLayers">DepthOrArrayLayers</see> that was specified when creating the texture.
    /// </summary>
    public uint GetDepthOrArrayLayers() => WebGPU_FFI.TextureGetDepthOrArrayLayers(this);

    /// <summary>
    /// Returns the dimension of this Texture.
    /// 
    /// This is always equal to the <see cref="TextureDescriptorFFI" />.<see cref="Extent3D.Dimension">Dimension</see> that was specified when creating the texture.
    /// </summary>
    public TextureDimension GetDimension() => WebGPU_FFI.TextureGetDimension(this);

    /// <summary>
    /// Returns the format of this Texture.
    /// 
    /// This is always equal to the <see cref="TextureDescriptorFFI" />.<see cref="Extent3D.Format">Format</see> that was specified when creating the texture.
    /// </summary>
    public TextureFormat GetFormat() => WebGPU_FFI.TextureGetFormat(this);

    /// <summary>
    /// Returns the height of this Texture.
    /// 
    /// This is always equal to the <see cref="TextureDescriptorFFI" />.<see cref="Extent3D.Height">Height</see> that was specified when creating the texture.
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

    public TextureViewDimension GetTextureBindingViewDimension() => WebGPU_FFI.TextureGetTextureBindingViewDimension(this);

    /// <summary>
    /// Returns the allowed usages of this Texture.
    /// 
    /// This is always equal to the usage that was specified when creating the texture.
    /// </summary>
    public TextureUsage GetUsage() => WebGPU_FFI.TextureGetUsage(this);

    /// <summary>
    /// Returns the width of this Texture.
    /// 
    /// This is always equal to the <see cref="TextureDescriptorFFI.Size" />.<see cref="Extent3D.Width">Width</see> that was specified when creating the texture.
    /// </summary>
    public uint GetWidth() => WebGPU_FFI.TextureGetWidth(this);

    /// <summary>
    /// Sets the debug label of texture.
    /// </summary>
    /// <param name="label">The new label.</param>
    public void SetLabel(StringViewFFI label) => WebGPU_FFI.TextureSetLabel(this, label);

    /// <summary>
    /// Increments the reference count of the <see cref="TextureHandle"/>.
    /// </summary>
    /// <remarks>
    /// WebGPU objects are refcounted. Each call to <see cref="AddRef"/> must be balanced with a corresponding
    /// call to <see cref="Release"/> when the reference is no longer needed. Objects returned directly from
    /// the API start with a reference count of 1.
    /// 
    /// Applications don't need to maintain refs to WebGPU objects that are internally used by other 
    /// WebGPU objects, as the implementation maintains internal references as needed.
    /// </remarks>
    /// <returns>The same <see cref="TextureHandle"/> instance with an incremented reference count.</returns>
    public TextureHandle AddRef()
    {
        WebGPU_FFI.TextureAddRef(this);
        return this;
    }

    /// <summary>
    /// Decrements the reference count of the <see cref="TextureHandle"/>. When the reference count reaches zero, the <see cref="TextureHandle"/> and associated resources may be freed.
    /// </summary>
    /// <remarks>
    /// It's unsafe to use an object after its reference count has reached zero, even if other
    /// WebGPU objects internally reference it.
    /// 
    /// Applications must call <see cref="Release"/> on all <see cref="TextureHandle"/> references they own before losing the pointer.
    /// Failing to balance <see cref="AddRef"/> and <see cref="Release"/> calls will result in memory leaks or use-after-free errors.
    /// </remarks>
    public void Release() => WebGPU_FFI.TextureRelease(this);

}
