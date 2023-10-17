using SafeFileHandle = Microsoft.Win32.SafeHandles.SafeFileHandle;
using System.Diagnostics;
using WebGpuSharp.Internal;

namespace WebGpuSharp.FFI
{
    public readonly unsafe partial struct DeviceHandle
    {
        public readonly ShaderModuleHandle LoadShaderModuleFromFile(string path, WGPURefText label = default)
        {
            if (label.Length == 0)
            {
                label = path;
            }

            using WebGpuAllocatorHandle allocator = WebGpuAllocatorHandle.Get();
            UFT8CStrFactory utf8Factory = new(allocator);

            var (data, dataPtrAllocType) = FileReaderUtils.ReadAllBytesUnsafe(path, allocator);

            if (dataPtrAllocType != ResultType.Success)
            {
                return ShaderModuleHandle.Null;
            }

            fixed (byte* dataPtr = data)
            fixed (byte* labelPtr = label)
            {
                ShaderModuleWGSLDescriptorFFI shaderModuleWGSLDescriptor = new()
                {
                    Chain = new()
                    {
                        Next = null,
                        SType = SType.ShaderModuleWGSLDescriptor
                    },
                    Code = dataPtr
                };

                ShaderModuleDescriptorFFI shaderModuleDescriptor = new()
                {
                    Label = utf8Factory.Create(
                        text: labelPtr,
                        is16BitSize: label.Is16BitSize,
                        length: label.Length,
                        allowPassthrough: true
                    ),
                    NextInChain = &shaderModuleWGSLDescriptor.Chain,
                };
                return WebGPU_FFI.DeviceCreateShaderModule(this, &shaderModuleDescriptor);
            }
        }
    }
}

namespace WebGpuSharp
{
    public partial class Device
    {
        public ShaderModule? LoadShaderModuleFromFile(string path, WGPURefText label = default)
        {
            return ShaderModule.FromHandle(_handle.LoadShaderModuleFromFile(path, label));
        }
    }
}


file enum ResultType : sbyte
{
    Success = 1,
    NotSet = 0,
    FailedUnexpectedEndOfFile = -1,
    FailedFileToBig = -2,
    FailedUnknownException = -3,
}

file static class FileReaderUtils
{
    public readonly unsafe ref struct Result
    {
        public readonly Span<byte> Buffer;
        public readonly ResultType AllocType;

        public Result(Span<byte> buffer, ResultType allocType)
        {
            Buffer = buffer;
            AllocType = allocType;
        }

        public void Deconstruct(out Span<byte> buffer, out ResultType allocType)
        {
            buffer = Buffer;
            allocType = AllocType;
        }
    }

    public static unsafe Result ReadAllBytesUnsafe(
        string path, WebGpuAllocatorHandle allocator)
    {
        FileOptions options = OperatingSystem.IsWindows() ? FileOptions.SequentialScan : FileOptions.None;
        using var sfh = File.OpenHandle(path, FileMode.Open, FileAccess.Read, FileShare.Read, options);
        using FileStream fs = new(sfh, FileAccess.Read);

        long fileLength = 0;
        if (fs.CanSeek && (fileLength = fs.Length) > Array.MaxLength)
        {
            return new(null, ResultType.FailedFileToBig);
        }

        if (fileLength == 0)
        {
            // Some file systems (e.g. procfs on Linux) return 0 for length even when there's content; also there are non-seekable files.
            // Thus we need to assume 0 doesn't mean empty.
            return ReadAllBytesUnknownLength(sfh, allocator);
        }

        int index = 0;
        int count = (int)fileLength;
        uint allocSize = (uint)count + 1;
        byte* bufferPtr = null;
        try
        {
            Span<byte> bytes = allocator.AllocAsSpan<byte>(allocSize);

            while (count > 0)
            {
                int n = RandomAccess.Read(sfh, bytes.Slice(index, count), index);
                if (n == 0)
                {
                    return new(default, ResultType.FailedUnexpectedEndOfFile);
                }

                index += n;
                count -= n;
            }

            bytes[^1] = 0;

            return new(bytes, ResultType.Success);
        }
        catch (Exception)
        {
            return new(default, ResultType.FailedUnknownException);
        }
    }

    static unsafe Result ReadAllBytesUnknownLength(
       SafeFileHandle sfh, WebGpuAllocatorHandle allocator)
    {
        try
        {
            Span<byte> buffer = allocator.AllocAsSpan<byte>(512);
            int bytesRead = 0;
            while (true)
            {
                if (bytesRead == buffer.Length)
                {
                    uint oldLength = (uint)buffer.Length;
                    uint newLength = oldLength + 512;
                    if (newLength > Array.MaxLength)
                    {
                        return new(default, ResultType.FailedFileToBig);
                    }

                    allocator.ReallocSpan(ref buffer, newLength);
                }

                Debug.Assert(bytesRead < buffer.Length);
                int n = RandomAccess.Read(sfh, buffer[bytesRead..], bytesRead);
                if (n == 0)
                {
                    if (bytesRead + 1 < buffer.Length)
                    {
                        buffer[bytesRead] = 0;

                        return new(buffer[..(bytesRead + 1)], ResultType.Success);
                    }
                    else
                    {
                        uint oldLength = (uint)buffer.Length;
                        uint newLength = oldLength + 1;
                        if (newLength > Array.MaxLength)
                        {
                            return new(default, ResultType.FailedFileToBig);
                        }
                        allocator.ReallocSpan(ref buffer, newLength);

                        buffer[^1] = 0;
                    }

                    return new(buffer, ResultType.Success);
                }
                bytesRead += n;
            }
        }
        catch (Exception)
        {
            return new(null, ResultType.FailedUnknownException);
        }
    }
}