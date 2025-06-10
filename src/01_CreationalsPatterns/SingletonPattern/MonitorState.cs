using System;
using System.Threading;

namespace SingletonPattern;

public class MonitorState : Singleton<MonitorState>
{
    private int _enqueued;
    private int _processed;
    private int _sent;

    public void IncrementEnqueued() => Interlocked.Increment(ref _enqueued);
    public void IncrementProcessed() => Interlocked.Increment(ref _processed);
    public void IncrementSent() => Interlocked.Increment(ref _sent);

    public void PrintStatus()
    {
        Console.WriteLine($"Enqueued: {_enqueued}, Processed: {_processed}, Sent: {_sent}");
    }
}
