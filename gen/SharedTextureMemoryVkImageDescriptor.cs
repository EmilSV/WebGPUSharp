using System;
using System.Runtime.InteropServices;
using WebGpuSharp.FFI;

namespace WebGpuSharp;

[StructLayout(LayoutKind.Sequential)]
public partial struct SharedTextureMemoryVkImageDescriptor
{
	public ChainedStruct Chain;
	public int VkFormat;
	public int VkUsageFlags;
	public Extent3D VkExtent3D;

	public SharedTextureMemoryVkImageDescriptor()
	{
		this.Chain = default;
		this.VkFormat = default;
		this.VkUsageFlags = default;
		this.VkExtent3D = default;
	}

	public SharedTextureMemoryVkImageDescriptor(ChainedStruct chain = default, int vkFormat = default, int vkUsageFlags = default, Extent3D vkExtent3D = default)
	{
		this.Chain = chain;
		this.VkFormat = vkFormat;
		this.VkUsageFlags = vkUsageFlags;
		this.VkExtent3D = vkExtent3D;
	}
}

