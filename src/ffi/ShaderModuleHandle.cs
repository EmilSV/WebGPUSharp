using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using static WebGpuSharp.Marshalling.WebGPUMarshal;

namespace WebGpuSharp.FFI;

public unsafe readonly partial struct ShaderModuleHandle :
    IDisposable,
    IWebGpuHandleNeedInstance<ShaderModuleHandle, ShaderModule>
{

    /// <inheritdoc cref="GetCompilationInfo(CompilationInfoCallbackInfoFFI)"/>
    public void GetCompilationInfo(Action<CompilationInfoRequestStatus, CompilationInfo> callback)
    {
        void* callbackUserData = null;
        try
        {
            callbackUserData = AllocUserData(callback);

            WebGPU_FFI.ShaderModuleGetCompilationInfo(this, new()
            {
                Mode = CallbackMode.AllowSpontaneous,
                Callback = &GetCompilationInfoCallbackFunctions.OnCallback,
                Userdata1 = callbackUserData,
                Userdata2 = null
            });
        }
        catch
        {
            if (callbackUserData != null)
            {
                FreeUserData(callbackUserData);
            }
            throw;
        }
    }

    /// <inheritdoc cref="GetCompilationInfo(CompilationInfoCallbackInfoFFI)"/>
    public Task<T> GetCompilationInfo<T>(Func<CompilationInfoRequestStatus, CompilationInfo, T> callback)
    {
        TaskCompletionSource<T> tcs = new();
        void innerCallback(CompilationInfoRequestStatus status, CompilationInfo info)
        {
            try
            {
                tcs.SetResult(callback(status, info));
            }
            catch (Exception ex)
            {
                tcs.SetException(ex);
            }
        }
        GetCompilationInfo(innerCallback);
        return tcs.Task;
    }



    public static ref nuint AsPointer(ref ShaderModuleHandle handle)
    {
        return ref Unsafe.As<ShaderModuleHandle, nuint>(ref handle);
    }

    public static ShaderModuleHandle GetNullHandle()
    {
        return Null;
    }

    public static bool IsNull(ShaderModuleHandle handle)
    {
        return handle == Null;
    }

    public static void Release(ShaderModuleHandle handle)
    {
        WebGPU_FFI.ShaderModuleRelease(handle);
    }

    public static void Reference(ShaderModuleHandle handle)
    {
        WebGPU_FFI.ShaderModuleAddRef(handle);
    }

    public static ShaderModuleHandle UnsafeFromPointer(nuint pointer)
    {
        return new ShaderModuleHandle(pointer);
    }

    public void Dispose()
    {
        if (_ptr != UIntPtr.Zero)
        {
            WebGPU_FFI.ShaderModuleRelease(this);
        }
    }

    public ShaderModule? ToSafeHandle(Instance instance) => ToSafeHandle<ShaderModule, ShaderModuleHandle>(this, instance);
}


file unsafe static class GetCompilationInfoCallbackFunctions
{
    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    public static void OnCallback(
    CompilationInfoRequestStatus status, CompilationInfoFFI* compilationInfo, void* userdata, void* _)
    {
        try
        {
            var callback = (Action<CompilationInfoRequestStatus, CompilationInfo>?)ConsumeUserDataIntoObject(userdata);
            if (callback != null)
            {
                return;
            }

            var infoSize = (nuint)sizeof(CompilationInfoFFI);
            var messageByteSize = compilationInfo->MessageCount * (nuint)sizeof(CompilationMessageFFI);
            var infoPtr = (CompilationInfoFFI*)NativeMemory.Alloc(infoSize);
            *infoPtr = new CompilationInfoFFI
            {
                NextInChain = null,
                MessageCount = compilationInfo->MessageCount,
                Messages = null,
            };

            var messagesPtr = (CompilationMessageFFI*)NativeMemory.Alloc(messageByteSize);
            var messageSpan = new Span<CompilationMessageFFI>(compilationInfo->Messages, (int)compilationInfo->MessageCount);
            var newMessageSpan = new Span<CompilationMessageFFI>(messagesPtr, (int)compilationInfo->MessageCount);
            var stringDataPtr = CopyMessageData(messageSpan, newMessageSpan);
            infoPtr->Messages = messagesPtr;
            ThreadPool.UnsafeQueueUserWorkItem(
                state: (status, (nuint)infoPtr, (nuint)stringDataPtr, (nuint)messagesPtr, callback),
                callBack: static state =>
                {
                    var (status, npInfoPtr, npStringDataPtr, npMessagesPtr, callBack) = state;
                    var infoPtr = (CompilationInfoFFI*)npInfoPtr;
                    var info = new CompilationInfo(in *infoPtr);
                    try
                    {
                        callBack?.Invoke(status, info);
                    }
                    finally
                    {
                        // Free allocated memory
                        if (npStringDataPtr != 0)
                        {
                            NativeMemory.Free((void*)npStringDataPtr);
                        }
                        if (npMessagesPtr != 0)
                        {
                            NativeMemory.Free((void*)npMessagesPtr);
                        }
                        if (npInfoPtr != 0)
                        {
                            NativeMemory.Free((void*)npInfoPtr);
                        }
                    }
                },
                preferLocal: false);
        }
        catch { }
    }

    private static void* CopyMessageData(
        ReadOnlySpan<CompilationMessageFFI> sourceMessages,
        Span<CompilationMessageFFI> targetMessages
    )
    {
        nuint totalMessageStringByteLength = 0;
        byte* stringDataPtr = null;
        foreach (ref readonly var message in sourceMessages)
        {
            //Message as span to deal with null terminated strings
            totalMessageStringByteLength += (nuint)message.Message.AsSpan().Length;
        }
        if (totalMessageStringByteLength > 0)
        {
            stringDataPtr = (byte*)NativeMemory.Alloc(totalMessageStringByteLength);
        }

        Debug.Assert(sourceMessages.Length == targetMessages.Length);
        for (int i = 0; i < sourceMessages.Length; i++)
        {
            ref readonly var sourceMessage = ref sourceMessages[i];
            ref var targetMessage = ref targetMessages[i];
            targetMessage = new CompilationMessageFFI
            {
                NextInChain = default, // Do not copy chained structs
                Type = sourceMessage.Type,
                LineNum = sourceMessage.LineNum,
                LinePos = sourceMessage.LinePos,
                Offset = sourceMessage.Offset,
                Length = sourceMessage.Length,
            };

            if (sourceMessage.Message.Length > 0)
            {
                var messageSpan = sourceMessage.Message.AsSpan();
                var destMessageSpan = new Span<byte>(stringDataPtr, messageSpan.Length);
                messageSpan.CopyTo(destMessageSpan);
                nuint messageLength = (nuint)messageSpan.Length;
                targetMessage.Message = new StringViewFFI
                {
                    Data = stringDataPtr,
                    Length = messageLength
                };
                stringDataPtr += messageLength;
            }
            else
            {
                targetMessage.Message = StringViewFFI.NullValue;
            }
        }

        return stringDataPtr;
    }
}