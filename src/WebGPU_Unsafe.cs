using WebGpuSharp.FFI;
using WebGpuSharp.Internal;

namespace WebGpuSharp;

public static partial class WebGPU
{
    public static unsafe class Unsafe
    {
        public static void Marshal<TSelf, TFFI>(in TSelf input, ref TFFI dest)
            where TSelf : IUnsafeMarshal<TSelf, TFFI>
        {
            TSelf.UnsafeMarshalTo(in input, ref dest);
        }

        public static void Marshal<TSelf, TFFI>(in TSelf input, WebGpuAllocatorHandle allocator, ref TFFI dest)
            where TSelf : IUnsafeMarshalAlloc<TSelf, TFFI>
        {
            TSelf.UnsafeMarshalTo(in input, allocator, ref dest);
        }

        public static unsafe void Marshal(string input, WebGpuAllocatorHandle allocator, out byte* dest)
        {
            dest = UFT8CStrFactory.Create(input, allocator);
        }

        public static unsafe byte* Marshal(string input, WebGpuAllocatorHandle allocator)
        {
            return UFT8CStrFactory.Create(input, allocator);
        }

        public static void Marshal<T, TFFI>(
            T? input, WebGpuAllocatorHandle allocator,
            out TFFI* dest, out nuint outCount)
            where T : IUnsafeMarshalCollectionAlloc<TFFI>
            where TFFI : unmanaged
        {
            if (input is null)
            {
                dest = null;
                outCount = 0;
                return;
            }

            input.GetPointerToFFIItems(allocator, out dest, out outCount);
        }

        public static void MarshalCollection<T, TFFI>(
            T? input, WebGpuAllocatorHandle allocator,
             out TFFI* dest, out uint outCount)
            where T : IUnsafeMarshalCollectionAlloc<TFFI>
            where TFFI : unmanaged
        {
            if (input is null)
            {
                dest = null;
                outCount = 0;
                return;
            }

            input.GetPointerToFFIItems(allocator, out dest, out outCount);
        }


        public static void Marshal<T, TFFI>(
            T? input,
            out TFFI* dest, out nuint outCount)
            where T : IUnsafeMarshalCollection<TFFI>
            where TFFI : unmanaged
        {
            if (input is null)
            {
                dest = null;
                outCount = 0;
                return;
            }

            input.GetPointerToFFIItems(out dest, out outCount);
        }


        public static void MarshalCollection<T, TFFI>(
            T? input,
            out TFFI* dest, out uint outCount)
            where T : IUnsafeMarshalCollection<TFFI>
            where TFFI : unmanaged
        {
            if (input is null)
            {
                dest = null;
                outCount = 0;
                return;
            }

            input.GetPointerToFFIItems(out dest, out outCount);
        }

        public static T GetBorrowHandle<T>(WebGpuSafeHandle<T> safeHandle)
            where T : unmanaged, IWebGpuHandle<T>
        {
            return safeHandle.GetHandle();
        }

        public static void GetBorrowHandle<T>(WebGpuSafeHandle<T> safeHandle, out T handle)
            where T : unmanaged, IWebGpuHandle<T>
        {
            handle = safeHandle.GetHandle();
        }

        public static void Marshal<T>(WebGpuSafeHandle<T> safeHandle, out T handle)
             where T : unmanaged, IWebGpuHandle<T>
        {
            handle = safeHandle.GetHandle();
        }

        public static T GetOwnedHandle<T>(WebGpuSafeHandle<T> safeHandle)
             where T : unmanaged, IWebGpuHandle<T>
        {
            var handle = safeHandle.GetHandle();
            T.Reference(handle);
            return handle;
        }
    }
}