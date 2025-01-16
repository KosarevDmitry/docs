# diagnostics, Metrics

- FIRST как инициируется meter 

- SECOND 
упрощает типизацию генерик 
Meter  как Resource создает counter counter пишет  s_hatsSold.Add
а в стандартном варианте Resource пишет

MeterProvider аналог Listener он регистрирует Resource by AddMeter
как EventListener.EnableEvents

AddPrometheusHttpListener инкапсулирует webclient
и работает как EventListener.OnEventWritten  

- ML
MeterListener вместо MeterProvider и пишет в console
