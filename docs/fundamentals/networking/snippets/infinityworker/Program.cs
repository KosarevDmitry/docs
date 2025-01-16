using System.Diagnostics;
using System.Net.Sockets;
using infinityworker;

int port = 9000;
int i=0;
int message = 0;

// using var listener = new SystemDotNetListener();

using var httpClient = new HttpClient();
string? json = await httpClient.GetStringAsync("https://httpbin.org/get");

// return;

// the same
//var s = new Socket(AddressFamily.InterNetworkV6,SocketType.Stream, ProtocolType.Tcp){ DualMode = true};

var client = new TcpClient();
await client.ConnectAsync("192.168.1.70", port);
Process proc = Process.GetCurrentProcess();

while (true)
{
	string eom = "<|EOM|>";

    // this way server get just a first message
    // если создать client то  server получит только первое сообщение
    // видимо появляется id для канала и все clients создают свой

   // var client = new TcpClient();
	Console.WriteLine($"send {++i}");

   Console.WriteLine(proc.PrivateMemorySize64 / (1024*1024));
   var t = GC.GetGCMemoryInfo();

    // При втором запросе в цикле
    // Unhandled exception. System.Net.Sockets.SocketException (10056): A connect request was made on an already connected socket.
   // await client.ConnectAsync("192.168.1.70", port);

    await client.Client.SendAsync(Encoding.UTF8.GetBytes($"{++message} boo {eom}"));

    await Task.Delay(TimeSpan.FromSeconds(5));
}
