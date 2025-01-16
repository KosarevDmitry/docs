# diagnostics, EventCounters

SimpleEventListener.cs  ловит только runtime
 

Создаем класс, наследующий EventSource
и с аттрибутом например [EventSource(Name = "Sample.EventCounter.Minimal")]
В конструкторе инициализируется поле типа `EventCounter` 
со свойствами: 
 - Name
 - eventSource:this
 - DisplayName
 - DisplayUnits
теперь  можем вызвать EventCounter?.WriteMetric(a),  
где `a` long, float or double.
можно `override void OnEventCommand`
можно инициализировать `IncrementingPollingCounter` (в `RequestEventSource.cs`)

https://learn.microsoft.com/en-us/dotnet/core/diagnostics/event-counters
Примеры для этих counter есть на странице,  а в коде нет
- IncrementingEventCounter
- PollingCounter



```
var workingSetCounter = new PollingCounter(
"working-set",
this,
() => (double)(Environment.WorkingSet / 1_000_000))
{
DisplayName = "Working Set",
DisplayUnits = "MB"
};
```

```
var monitorContentionCounter = new IncrementingPollingCounter(
"monitor-lock-contention-count",
this,
() => Monitor.LockContentionCount
)
{
DisplayName = "Monitor Lock Contention Count",
DisplayRateTimeScale = TimeSpan.FromSeconds(1)
};

```
