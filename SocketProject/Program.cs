using System.Net;
using System.Net.Sockets;
do
{
    IPAddress IP = IPAddress.Parse("192.168.113.2");
    IPEndPoint ep = new IPEndPoint(IP, 80);
    Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream,
        ProtocolType.IP);
    try
    {
        s.Connect(ep);
        if (s.Connected)
        {
            string strEnd = Console.ReadLine()!;
            s.Send(System.Text.Encoding.Unicode.GetBytes(strEnd));
            byte[] buffer = new byte[1024];
            int l;
            do
            {
                l = s.Receive(buffer);
                Console.WriteLine(System.Text.Encoding.Unicode.
                    GetString(buffer, 0, l));
            }
            while (l > 0);
        }
        else
        {
            Console.WriteLine("Соединения нет");
        }
    }
    catch (SocketException ex)
    {
        Console.WriteLine(ex.Message);
    }
    finally
    {
        s.Shutdown(SocketShutdown.Both);
        s.Close();
    }
} while (true);
