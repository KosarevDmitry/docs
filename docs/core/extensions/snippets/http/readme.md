используем httpClientFactory для генерации запросов 
httpClientFactory.CreateClient
AddRefitClient nuget custom approach 
ConfigureHttpClient
ConfigurePrimaryHttpMessageHandler
builder.Configuration["TodoHttpClientName"];

https://learn.microsoft.com/en-us/dotnet/core/extensions/httpclient-factory

-basic 

```csharp
builder.Services.AddHttpClient();
```

-http3test
```csharp
using var client = new HttpClient
{
    DefaultRequestVersion =  HttpVersion.Version30,
    DefaultVersionPolicy = HttpVersionPolicy.RequestVersionExact
};


```

## typed;  It is not required  to register TodoService yet

```csharp
builder.Services.AddHttpClient<TodoService>(
    client =>
    {
        // Set the base address of the typed client.
        client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");

        // Add a user-agent default request header.
        client.DefaultRequestHeaders.UserAgent.ParseAdd("dotnet-docs");
    });
```


## named; Make several  clients with different configurations 

```csharp
string? httpClientName = builder.Configuration["TodoHttpClientName"];
builder.Services.AddHttpClient(
    httpClientName,
    client =>
    {
        // Set the base address of the named client.
        client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");

        // Add a user-agent default request header.
        client.DefaultRequestHeaders.UserAgent.ParseAdd("dotnet-docs");
    });
```
```csharp
string? httpClientName = _configuration["TodoHttpClientName"];
using HttpClient client = _httpClientFactory.CreateClient(httpClientName ?? "");
```

- generated;  used  Refit nuget
```csharp
- builder.Services.AddRefitClient<ITodoService>()
  .ConfigureHttpClient(client =>
  {
  // Set the base address of the named client.
  client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");

        // Add a user-agent default request header.
        client.DefaultRequestHeaders.UserAgent.ParseAdd("dotnet-docs");
  });

```



- configurehandler
```csharp
builder.Services.AddHttpClient(
name,
client =>
{
// Set the base address of the named client.
client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");

        // Add a user-agent default request header.
        client.DefaultRequestHeaders.UserAgent.ParseAdd("dotnet-docs");
    })
 
    .ConfigurePrimaryHttpMessageHandler(() =>
    {
        return new HttpClientHandler
        {
            AllowAutoRedirect = false,
            UseDefaultCredentials = true
        };
    });
 ```
