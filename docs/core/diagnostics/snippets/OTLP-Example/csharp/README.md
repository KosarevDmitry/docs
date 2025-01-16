# diagnostics, OTLP-Example

<https://learn.microsoft.com/en-us/dotnet/core/diagnostics/observability-otlp-example>
https://learn.microsoft.com/en-us/dotnet/aspire/fundamentals/dashboard/explore
в качестве получателя определен web client  aspire-dashboard
то есть теперь всю инфо логи, кастомные counter,  и runtime статистику  принято отправлять в web
все это только для разработчика
Порядок такой 
1.  запустить  контейнер
```powershell
docker run --rm -it `
-p 18888:18888 `
-p 4317:18889 `
--name aspire-dashboard `
mcr.microsoft.com/dotnet/aspire-dashboard:latest
```

2. открываю ссылку появившуюся в консоли с одноразовым паролем

3. запустить приложение
