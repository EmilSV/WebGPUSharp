using System.Runtime.CompilerServices;
using WebGpuSharp.Internal;

namespace WebGpuSharp.FFI
{
    public unsafe readonly partial struct DeviceHandle
    {
        public readonly RenderPipelineHandle CreateRenderPipeline(
            PipelineLayout layout,
            in VertexState vertex,
            in PrimitiveState primitive,
            WGPUNullableRef<DepthStencilState> depthStencil,
            in MultisampleState multisample,
            WGPUNullableRef<FragmentState> fragment
        )
        {
            return CreateRenderPipeline(default, layout, vertex, primitive, depthStencil, multisample, fragment);
        }


        public readonly RenderPipelineHandle CreateRenderPipeline(
            WGPURefText label,
            PipelineLayout layout,
            in VertexState vertex,
            in PrimitiveState primitive,
            WGPUNullableRef<DepthStencilState> depthStencil,
            in MultisampleState multisample,
            WGPUNullableRef<FragmentState> fragment
        )
        {
            using WebGpuAllocatorHandle allocator = WebGpuAllocatorHandle.Get();

            Unsafe.SkipInit(out FragmentStateFFI fragmentStateFFI);
            WGPUNullableRef<FragmentStateFFI> fragmentFFI = fragmentStateFFI;

            if (fragment.HasValue)
            {
                ref readonly var fragmentValue = ref fragment.Value;
                nuint constantCount = 0;
                ConstantEntryFFI* constants = null;
                nuint targetCount = 0;
                ColorTargetStateFFI* targets = null;

                if (fragmentValue.Constants != null && fragmentValue.Constants.Count > 0)
                {
                    constantCount = (uint)fragmentValue.Constants.Count;
                    constants = fragmentValue.Constants.GetPointerToFFIItems(allocator);
                }

                if (fragmentValue.Targets != null && fragmentValue.Targets.Count > 0)
                {
                    targetCount = (uint)fragmentValue.Targets.Count;
                    targets = fragmentValue.Targets.GetPointerToPinedArray();
                }


                fragmentStateFFI = new(
                    module: fragment.Value.Module,
                    entryPoint: UFT8CStrFactory.Create(fragment.Value.EntryPoint, allocator),
                    constantCount: constantCount,
                    constants: constants,
                    targetCount: targetCount,
                    targets: targets
                );
            }
            else
            {
                fragmentFFI = default;
            }

            nuint bufferCount;
            VertexBufferLayoutFFI* buffers;

            nuint vertexConstantCount;
            ConstantEntryFFI* vertexConstants;

            if (vertex.Buffers != null && vertex.Buffers.Count > 0)
            {
                bufferCount = (uint)vertex.Buffers.Count;
                buffers = vertex.Buffers.GetPointerToFFIItems(allocator);
            }
            else
            {
                bufferCount = 0;
                buffers = null;
            }


            if (vertex.Constants != null && vertex.Constants.Count > 0)
            {
                vertexConstantCount = (uint)vertex.Constants.Count;
                vertexConstants = vertex.Constants.GetPointerToFFIItems(allocator);
            }
            else
            {
                vertexConstantCount = 0;
                vertexConstants = null;
            }

            VertexStateFFI vertexStateFFI = new(
                module: vertex.Module,
                entryPoint: UFT8CStrFactory.Create(vertex.EntryPoint, allocator),
                constantCount: vertexConstantCount,
                constants: vertexConstants,
                bufferCount: bufferCount,
                buffers: buffers
            );

            return CreateRenderPipeline(
                label: label,
                layout: layout.GetHandle(),
                vertex: vertexStateFFI,
                primitive: primitive,
                depthStencil: depthStencil,
                multisample: multisample,
                fragment: fragmentFFI,
                allocator: allocator
            );
        }

        public readonly RenderPipelineHandle CreateRenderPipeline(
            PipelineLayoutHandle layout,
            in VertexStateFFI vertex,
            in PrimitiveState primitive,
            WGPUNullableRef<DepthStencilState> depthStencil,
            in MultisampleState multisample,
            WGPUNullableRef<FragmentStateFFI> fragment
        )
        {
            using WebGpuAllocatorHandle allocator = WebGpuAllocatorHandle.Get();
            return CreateRenderPipeline(default, layout, vertex, primitive, depthStencil, multisample, fragment, allocator);
        }

        public readonly RenderPipelineHandle CreateRenderPipeline(
            WGPURefText label,
            PipelineLayoutHandle layout,
            in VertexStateFFI vertex,
            in PrimitiveState primitive,
            WGPUNullableRef<DepthStencilState> depthStencil,
            in MultisampleState multisample,
            WGPUNullableRef<FragmentStateFFI> fragment
        )
        {
            using WebGpuAllocatorHandle allocator = WebGpuAllocatorHandle.Get();
            return CreateRenderPipeline(label, layout, vertex, primitive, depthStencil, multisample, fragment, allocator);
        }


        private readonly RenderPipelineHandle CreateRenderPipeline(
            WGPURefText label,
            PipelineLayoutHandle layout,
            in VertexStateFFI vertex,
            in PrimitiveState primitive,
            WGPUNullableRef<DepthStencilState> depthStencil,
            in MultisampleState multisample,
            WGPUNullableRef<FragmentStateFFI> fragment,
            WebGpuAllocatorHandle allocator
        )
        {
            fixed (byte* labelPtr = label)
            fixed (DepthStencilState* depthStencilPtr = depthStencil)
            fixed (FragmentStateFFI* fragmentPtr = fragment)
            {
                RenderPipelineDescriptorFFI descriptor = new()
                {
                    Label = UFT8CStrFactory.Create(
                        text: labelPtr,
                        is16BitSize: label.Is16BitSize,
                        length: label.Length,
                        allowPassthrough: true,
                        allocator: allocator
                    ),
                    Layout = layout,
                    Vertex = vertex,
                    Primitive = primitive,
                    DepthStencil = depthStencilPtr,
                    Multisample = multisample,
                    Fragment = fragmentPtr,
                };

                return WebGPU_FFI.DeviceCreateRenderPipeline(this, &descriptor);
            }
        }
    }
}

namespace WebGpuSharp
{
    public partial class Device
    {
        public RenderPipeline? CreateRenderPipeline(
            PipelineLayout layout,
            in VertexState vertex,
            in PrimitiveState primitive,
            WGPUNullableRef<DepthStencilState> depthStencil,
            in MultisampleState multisample,
            WGPUNullableRef<FragmentState> fragment
        )
        {
            return RenderPipeline.FromHandle(_handle.CreateRenderPipeline(
                layout,
                vertex,
                primitive,
                depthStencil,
                multisample,
                fragment
            ));
        }

        public RenderPipeline? CreateRenderPipeline(
            WGPURefText label,
            PipelineLayout layout,
            in VertexState vertex,
            in PrimitiveState primitive,
            WGPUNullableRef<DepthStencilState> depthStencil,
            in MultisampleState multisample,
            WGPUNullableRef<FragmentState> fragment
        )
        {
            return RenderPipeline.FromHandle(_handle.CreateRenderPipeline(
                label,
                layout,
                vertex,
                primitive,
                depthStencil,
                multisample,
                fragment
            ));
        }
    }
}