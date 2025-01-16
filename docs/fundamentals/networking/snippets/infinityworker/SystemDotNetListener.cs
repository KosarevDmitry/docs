using System.Diagnostics.Tracing;

namespace infinityworker;

sealed class SystemDotNetListener : EventListener
{
    string path = $"D:\\temp\\snippets-{AppDomain.CurrentDomain.FriendlyName}-EventListener.log";
    private readonly StreamWriter _sw;

    public SystemDotNetListener() : base()
    {
        if (File.Exists(path))
            File.Delete(path);
        var stream = File.Open(path, FileMode.Create);
        _sw = new(stream) { AutoFlush = true };
    }

    public SystemDotNetListener(StreamWriter sw) : base()
    {
        _sw = sw;
    }

    new void Dispose()
    {
        _sw.Close();
        base.Dispose();
        GC.SuppressFinalize(this);
    }


    protected override void OnEventSourceCreated(EventSource eventSource)
    {
        if (eventSource.Name.Contains("System.Net"))
        {
            EnableEvents(eventSource, EventLevel.Verbose);
        }
    }

    protected override void OnEventWritten(EventWrittenEventArgs eventData)
    {
        _sw.WriteLine($"{DateTime.UtcNow:ss:fff} {eventData.EventSource.Name}/{eventData.EventName}: " +
                     string.Join(' ', eventData.PayloadNames!.Zip(eventData.Payload!)
                         .Select(pair =>
                             $"{pair.First}={(pair.Second is byte[] buffer ? Convert.ToHexString(buffer) : $"{pair.Second}")}")));
    }
}
