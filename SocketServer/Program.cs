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
            var responseBytes = new byte[512];
            var bytes = ns.Receive(responseBytes);
            string textGet = System.Text.Encoding.Unicode.GetString(responseBytes, 0, bytes);
            Console.WriteLine(textGet);
            ns.Send(System.Text.Encoding.Unicode.GetBytes(textGet));
            //if (text == "time")
            //    ns.Send(System.Text.Encoding.ASCII.GetBytes(DateTime.Now.ToString()));
            //else if (text == "ip")
            //    ns.Send(System.Text.Encoding.ASCII.GetBytes(ip.Address.ToString()));
            //else ns.Send(System.Text.Encoding.Unicode.GetBytes("Иди лесом"));
            ns.Shutdown(SocketShutdown.Both);
            ns.Close();
        }
    }
    catch (SocketException ex)
    {
        Console.WriteLine(ex.Message);
    }
