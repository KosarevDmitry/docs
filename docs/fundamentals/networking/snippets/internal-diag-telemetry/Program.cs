using System.Diagnostics.Tracing;

var path = $"D:\\temp\\snippets-{AppDomain.CurrentDomain.FriendlyName}-EventListener.log";
if (File.Exists(path))
    File.Delete(path);

var stream=  File.Open(path, FileMode.Create);
StreamWriter sw = new (stream) {AutoFlush = true};
using var listener = new SystemDotNetListener(sw);

using var client = new HttpClient();
string? json = await client.GetStringAsync("https://httpbin.org/get");

sw.Close();
sealed file class SystemDotNetListener : EventListener
{
    private StreamWriter sw;
    public SystemDotNetListener(StreamWriter sw)=> this.sw = sw;

    protected override void OnEventSourceCreated(EventSource eventSource)
    {
        if (eventSource.Name.Contains("System.Net"))
        {
            EnableEvents(eventSource, EventLevel.Verbose);
        }
    }

    protected override void OnEventWritten(EventWrittenEventArgs eventData)
    {
        sw.WriteLine($"{DateTime.UtcNow:ss:fff} {eventData.EventSource.Name}/{eventData.EventName}: " +
            string.Join(' ', eventData.PayloadNames!.Zip(eventData.Payload!)
            .Select(pair => $"{pair.First}={(pair.Second is byte[] buffer ? Convert.ToHexString(buffer) : $"{pair.Second}")}")));
    }
}
