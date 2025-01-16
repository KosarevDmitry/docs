# parallel-programming, cs

`asyncculture1.cs` Task could executed in sync mode 

`attached1.cs`  When need `TaskCreationOptions.AttachedToParent ` 

`cancellation1.cs` cancellation applied

`cancellation2.cs`  `ContinueWith` `TaskContinuationOptions.NotOnCanceled ` 

`continuations.cs`  `ContinueWhenAll` and  run fine example Press 'c' to cancel

`continuationstate.cs`  What means AsyncState

`detached1.cs`   if `TaskCreationOptions.DenyChildAttach` then continuation run  
first, then attached tasks do 

`DownloadCache.cs` how to cache

`exception1.cs` exception in `ContinueWith`

`exception2.cs`  exception in first task with using `TaskContinuationOptions.OnlyOnFaulted` in `ContinueWith`

>  The point is that the `ContinueWith` can get a condition of execution  
https://learn.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.TaskContinuationOptions?view=net-8.0
 
`result1.cs` `TaskStatus.OnlyOnRanToCompletion `  

`result2.cs` `TaskStatus.Faulted `

`simple1.cs` very  simple   

`unwrap.cs`  <https://devblogs.microsoft.com/pfxteam/task-run-vs-task-factory-startnew/>  

`whenall1.cs` whenall applied  
