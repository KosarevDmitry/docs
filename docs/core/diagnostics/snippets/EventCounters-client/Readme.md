Это мой клиент 
Добавляю reference на dll в /bin/
["EventCounterIntervalSec"] = "3" // настройка позволяет дергать  `OnEventWritten`  с заданной периодичностью
в отличии от listener в repo, MyEventListener сообщение выводит только if (counterValue != "0")

Загружаю  
_ = new	MyEventListener();


если пользоваться dotnet-counters то свой listener не нужен
dotnet-counters  сам создает listener
комментирую  
`// _ = new	MyEventListener();`

- описание опций
https://learn.microsoft.com/en-us/dotnet/core/diagnostics/dotnet-counters

- описание metrics  `dotnet-counters list`  
https://learn.microsoft.com/en-us/dotnet/core/diagnostics/built-in-metrics

Канва процесса  

запустить `EventCounters-client`

Получить код процесса `EventCounters-client`:
`dotnet-counters ps`

Вывести на экран:
`dotnet-counters monitor --process-id 13320 --refresh-interval 1 --counters Sample.EventCounter.Minimal`

Записать в файл, (при нажатии Q  в текущую папку в qsv формате): 
`dotnet-counters collect   --process-id 13320 --refresh-interval 1 --counters Sample.EventCounter.Minimal`


