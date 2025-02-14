﻿using System.Diagnostics.Tracing;

namespace EventCounters_client;

public class MyEventListener : EventListener
{
    public MyEventListener()
    {
    }

    protected override void OnEventSourceCreated(EventSource source)
    {
        if (!source.Name.Equals("Sample.EventCounter.Minimal"))
        {
            return;
        }

        EnableEvents(source, EventLevel.Verbose, EventKeywords.All,
            new Dictionary<string, string>() { ["EventCounterIntervalSec"] = "1" });
    }

    protected override void OnEventWritten(EventWrittenEventArgs eventData)
    {
        if (!eventData.EventName.Equals("EventCounters"))
        {
            return;
        }

        for (int i = 0; i < eventData.Payload.Count; ++i)
        {
            if (eventData.Payload[i] is IDictionary<string, object> eventPayload)
            {
                var (counterName, counterValue) = GetRelevantMetric(eventPayload);

                if (counterValue != "0")
                    Console.WriteLine($"{counterName} : {counterValue}");
            }
        }
    }

    private static (string counterName, string counterValue) GetRelevantMetric(
        IDictionary<string, object> eventPayload)
    {
        var counterName = "";
        var counterValue = "";

        if (eventPayload.TryGetValue("DisplayName", out object displayValue))
        {
            counterName = displayValue.ToString();
        }

        if (eventPayload.TryGetValue("Mean", out object value)) // || eventPayload.TryGetValue("Increment", out value))
        {
            counterValue = value.ToString();
        }

        return (counterName, counterValue);
    }
}
