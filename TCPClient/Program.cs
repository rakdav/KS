using System.Net;
using System.Net.Sockets;
using System.Text;

int port = 54321;
IPAddress address = IPAddress.Parse("127.0.0.1");
Console.WriteLine("Введите сообщение");
var messages = new string[] { "Hello server| Connect me",
    "Work mith me! Trust", "TERMINATE" };
var i = 0;
while (i < messages.Length)
{
    using (TcpClient client=new TcpClient())
    {
        client.Connect(address,port);
        if (client.Connected)
        {
            Console.WriteLine("Connected");
        }
        var bytes = Encoding.UTF8.GetBytes(messages[i++]);
        using (var requestStream = client.GetStream())
        {
            await requestStream.WriteAsync(bytes, 0, bytes.Length);
            var responseBytes = new byte[256];
            await requestStream.ReadAsync(responseBytes, 0, responseBytes.Length);
            var responseMessage = Encoding.UTF8.GetString(responseBytes);
            Console.WriteLine();
            Console.WriteLine("Response from server:");
            Console.WriteLine(responseMessage);
        }
    }
    var sleepDuration = new Random().Next(2000, 10000);
    Console.WriteLine($"Generaytion a new request in {sleepDuration/1000} seconds");
    Thread.Sleep(sleepDuration);
}
