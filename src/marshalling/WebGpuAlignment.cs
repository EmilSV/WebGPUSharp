using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace WebGpuSharp.Marshalling;


public static class WebGpuAlignment
{

    // See :https://stackoverflow.com/questions/364483/determining-the-alignment-of-c-c-structures-in-relation-to-its-members
    [StructLayout(LayoutKind.Sequential)]
    private struct AlignmentFinder<T>
        where T : unmanaged
    {
        public byte a;
        public T b;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static nuint GetAlignmentOf<T>()
        where T : unmanaged
    {
        unsafe
        {
            return (nuint)sizeof(AlignmentFinder<T>) - (nuint)sizeof(T);
        }
    }


    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe void* GetAlign(nuint alignment, nuint size, void* ptr, out nuint remainingSize)
    {
        nuint intptr = (nuint)ptr;
        nuint aligned = (intptr - 1u + alignment) & ~(alignment - 1);
        nuint moveSize = aligned - intptr;
        nuint hasSpace = moveSize < size ? 1u : 0u;
        remainingSize = (size - moveSize) * hasSpace;
        return (void*)(aligned * hasSpace);
    }
}