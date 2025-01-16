tcp-listener сканирует/слушает все адреса  new IPEndPoint(IPAddress.Any, 13);
 и ждет когда к порту 13 зарегистрируется получатель tcp-client
  `client.ConnectAsync(ipEndPoint)`
 и только тогда отправляет сообщение, по этому в связке с tcp-client, 
 listener должен быть вызван первым. 
 