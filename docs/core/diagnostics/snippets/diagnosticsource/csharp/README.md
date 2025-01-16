# diagnostics, diagnosticsource

DiagnosticListener is Observable и в то же время DiagnosticSource то есть Resource
>Понятия `DiagnosticSource` и `logger`  у microsoft разработчиков одно и тоже

_Процедура_
 
Статический метод добавляет класс `A`, реализующий IObserver<T> ко всем Listeners   
`DiagnosticListener.AllListeners.Subscribe(A);`  
`A` объявляется с делагатом  `B` `Action<DiagnosticListener>`    
Каждый  загруженный  Listener  
`DiagnosticSource logger = new DiagnosticListener("Boo");`  
 вызывает `B`  
задача `B` - выбрать только, тот listener, который ему нужен   
по имени listener `Boo`  
и подписать к нему  класс `C` тоже  IObserver,  инициированный с   
`D` delegate  `Action<KeyValuePair<string, object>>`  
каждый вызов   
logger.Write("SomeEvent", new { Url = url });  
logger.Write("SomeEvent1", new string []{"A","B"});  
будет вызывать `D`  

