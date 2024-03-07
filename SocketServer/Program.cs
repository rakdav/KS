using System.Net;
using System.Net.Sockets;

Socket s = new Socket(AddressFamily.InterNetwork,
    SocketType.Stream, ProtocolType.IP);
IPAddress ip = IPAddress.Parse("192.168.113.2");
IPEndPoint ep = new IPEndPoint(ip, 1024);
s.Bind(ep);
s.Listen(10);
try
{
    while (true)
    {
        Socket ns = s.Accept();
        Console.WriteLine(ns.RemoteEndPoint.ToString());
        ns.Send(System.Text.Encoding.ASCII.GetBytes(DateTime.Now.ToString()));
        ns.Shutdown(SocketShutdown.Both);
        ns.Close();
    }
}
catch(SocketException ex)
{
    Console.WriteLine(ex.Message);
}
