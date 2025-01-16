ListenForNetworkAddressChanged();
ListenForNetworkAvailabilityChanged();

CanonicalUri();

await PingAsync();
ShowIPGlobalProperties();
// выводит статический список счетчиков
// описание счетчиков здесь https://learn.microsoft.com/en-us/dotnet/core/diagnostics/available-counters
foreach ((string eventSource, IReadOnlyList<string> counters) in RuntimeEventCounters.EventCounters)
{
    foreach (string counter in counters)
    {
        Console.WriteLine($"{eventSource}/{counter}");
    }
}
