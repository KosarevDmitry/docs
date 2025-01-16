using EventCounters_client;
    Console.WriteLine("Wait");

     _ = new	MyEventListener();
    // если добавить SimpleEventListener
    // то выводятся  runtime сообщения  вместе с MinimalEventCounterSource сообщениями
    // SimpleEventListener simpleEventListener = new SimpleEventListener();
    MinimalEventCounterSource d = MinimalEventCounterSource.Log;
    int count = 0;
    while (true)
    {
        Task.Delay(1000).Wait();
        d.Request(@"http://localhost:5000/",++ count);
    }


