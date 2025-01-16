# asynchronous-programming, async-return-types

`async-returns3.cs` good example TaskCompletionSource
как выглядит использование  
```
static readonly TaskCompletionSource<bool> s_tcs = new TaskCompletionSource<bool>();
s_tcs.SetResult(true);
Task<bool> secondHandlerFinished = s_tcs.Task;
return secondHandlerFinished
```

`async-valuetask.cs` ValueTask
<https://devblogs.microsoft.com/dotnet/understanding-the-whys-whats-and-whens-of-valuetask/>
 Это обертка вокруг Task, предпочтительно использовать когда 
1. будет использован только `await`, один раз повторно нельзя;
2. возможно синхронная операция, то есть вероятно выполнится быстро, так что не потребуется создания Task с  отложенным выполнением;  


`AsyncStreams.cs`
 показывает использование `StringReader.ReadLineAsync();`  и `await foreach`  
