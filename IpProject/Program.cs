using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

IPAddress localIP = new IPAddress(new byte[] {127,0,0,1});
Console.WriteLine(localIP);
IPAddress someIP = new IPAddress(0X0100007F);
Console.WriteLine(someIP);
IPAddress ip1 = IPAddress.Parse("127.0.0.1");
IPAddress.TryParse("127.0.0.1", out IPAddress? ip2);
Console.WriteLine(ip1);
Console.WriteLine(ip2);
IPAddress anyIP = IPAddress.Any;
Console.WriteLine(anyIP);
IPAddress loopback = IPAddress.Loopback;
Console.WriteLine(loopback);
IPAddress broadcast = IPAddress.Broadcast;
Console.WriteLine(broadcast);
Console.WriteLine(loopback);
IPEndPoint endPoint = new IPEndPoint(loopback, 8080);
Console.WriteLine(endPoint);

var adapters = NetworkInterface.GetAllNetworkInterfaces();
Console.WriteLine("Сетевых адресов:"+adapters.Length);
foreach(NetworkInterface adapter in adapters)
{
    Console.WriteLine("ID:"+adapter.Id);
    Console.WriteLine("Name:"+adapter.Name);
    Console.WriteLine("Description:"+adapter.Description);
    Console.WriteLine("Type:"+adapter.NetworkInterfaceType);
    Console.WriteLine("mac:"+adapter.GetPhysicalAddress());
    Console.WriteLine("Status:"+adapter.OperationalStatus);
    Console.WriteLine("Speed:"+adapter.Speed);
    IPInterfaceStatistics stats = adapter.GetIPStatistics();
    Console.WriteLine("Send:"+stats.BytesSent);
    Console.WriteLine("Recieve:"+stats.BytesReceived);
    Console.WriteLine();
}