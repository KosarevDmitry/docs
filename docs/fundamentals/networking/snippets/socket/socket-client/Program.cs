﻿// Socket client example
Console.OutputEncoding = Encoding.UTF8;
Console.WriteLine("Socket client starting...");

var ipEndPoint = await NetworkDiscovery.GetSocketEndPointAsync();

// <socketclient>
using Socket client = new(
    ipEndPoint.AddressFamily,
    SocketType.Stream,
    ProtocolType.Tcp);

await client.ConnectAsync(ipEndPoint);
int count = 0;
bool needResponse = false;
while (true)
{
    // Send message.
   var message = $" Hi {++count} 👋!<|EOM|>";
    var messageBytes = Encoding.UTF8.GetBytes(message);
    _ = await client.SendAsync(messageBytes, SocketFlags.None);
    Console.WriteLine($"Socket client sent message: \"{message}\"");

    if (needResponse)
    {
        // Receive ack.
        var buffer = new byte[1_024];
        var received = await client.ReceiveAsync(buffer, SocketFlags.None);
        var response = Encoding.UTF8.GetString(buffer, 0, received);
        if (response == "<|ACK|>")
        {
            Console.WriteLine(
                $"Socket client received acknowledgment: \"{response}\"");
            //  break;
        }
    }

    await Task.Delay(TimeSpan.FromSeconds(3));
    // Sample output:
    //     Socket client sent message: "Hi friends 👋!<|EOM|>"
    //     Socket client received acknowledgment: "<|ACK|>"
}

client.Shutdown(SocketShutdown.Both);
// </socketclient>

Console.WriteLine("Press ENTER to continue...");
Console.Read();
