using System.Collections.Concurrent;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading.Channels;
using WebGpuSharp;
using WebGpuSharp.FFI;
using WebGpuSharp.Marshalling;

namespace WebGPUSharp.Internal;

internal class WebGPUEventHandler : IDisposable
{
    private enum FutureWaitType
    {
        Cpu,
        Queue
    }

    private Channel<(FutureWaitType, Future)> _futureChannel = Channel.CreateUnbounded<(FutureWaitType, Future)>();
    private ChannelWriter<(FutureWaitType, Future)> _futureWriter;
    private ChannelReader<(FutureWaitType, Future)> _futureReader;

    private List<FutureWaitInfo> _cpuFutures = [];
    private List<FutureWaitInfo> _queueFutures = [];

    private InstanceHandle _instance;
    private readonly int _timedWaitAnyMaxCount;

    public WebGPUEventHandler(InstanceHandle instance, int timedWaitAnyMaxCount)
    {
        _instance = instance.AddRef();
        _futureWriter = _futureChannel.Writer;
        _futureReader = _futureChannel.Reader;
        _timedWaitAnyMaxCount = timedWaitAnyMaxCount;
    }

    public void Start()
    {
        Task.Run(ProcessFutures);
    }

    public void EnqueueCpuFuture(Future future)
    {
        bool result = _futureWriter.TryWrite((FutureWaitType.Cpu, future));
        Debug.Assert(result, "Failed to write future to CPU future channel");
    }

    public void EnqueueQueueFuture(Future future)
    {
        bool result = _futureWriter.TryWrite((FutureWaitType.Queue, future));
        Debug.Assert(result, "Failed to write future to Queue future channel");
    }

    private async Task ProcessFutures()
    {
        while (true)
        {
            if (_queueFutures.Count == 0 && _cpuFutures.Count == 0)
            {
                bool canRead = await _futureReader.WaitToReadAsync();
                if (!canRead)
                {
                    break;
                }
            }

            while (_futureReader.TryRead(out var item))
            {
                var (waitType, future) = item;
                switch (waitType)
                {
                    case FutureWaitType.Cpu:
                        _cpuFutures.Add(new() { Future = future });
                        break;
                    case FutureWaitType.Queue:
                        _queueFutures.Add(new() { Future = future });
                        break;
                }
            }

            ProcessEvents(_cpuFutures);
            ProcessEvents(_queueFutures);
            Thread.Sleep(1);
        }
    }

    private void ProcessEvents(List<FutureWaitInfo> futures)
    {
        var futuresSpan = CollectionsMarshal.AsSpan(futures);
        while (futuresSpan.Length != 0)
        {
            int batchSize = Math.Min(_timedWaitAnyMaxCount, futuresSpan.Length);
            var batchSpan = futuresSpan[..batchSize];
            unsafe
            {
                fixed (FutureWaitInfo* pFutures = batchSpan)
                {
                    var stat = _instance.WaitAny(
                        (nuint)batchSize,
                        pFutures,
                        0
                    );

                    if (stat != WaitStatus.Success && stat != WaitStatus.TimedOut)
                    {
                        Console.Error.WriteLine($"Error while processing futures: {stat}");
                    }
                }
            }
            futuresSpan = futuresSpan[batchSize..];
        }
        futures.RemoveAll(static f => f.Completed);
    }

    public void Dispose()
    {
        _futureWriter.Complete();
        _instance.Release();
        _instance = default;
    }
}