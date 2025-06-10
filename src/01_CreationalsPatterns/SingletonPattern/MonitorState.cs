using System;

namespace SingletonPattern;

public class MonitorState
{
    private int _enqueued;
    private int _processed;
    private int _sent;

    public void IncrementEnqueued() => _enqueued++;
    public void IncrementProcessed() => _processed++;
    public void IncrementSent() => _sent++;

    public void PrintStatus()
    {
        Console.WriteLine($"Enqueued: {_enqueued}, Processed: {_processed}, Sent: {_sent}");
    }
}
