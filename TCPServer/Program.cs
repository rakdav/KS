using System.Net;
using System.Net.Sockets;
using System.Text;

bool done = false;
string DILIMETER = "|";
string TERMINATE = "TERMINATE";
int port = 54321;
IPAddress address = IPAddress.Any;
TcpListener server = new TcpListener(address, port);
server.Start();
var loggedNoRequest = false;
while (!done)
{
    if (!server.Pending())
    {
        if (!loggedNoRequest)
        {
            Console.WriteLine();
            Console.WriteLine("No pending request as of yet");
            Console.WriteLine("Server listening...");
            loggedNoRequest = true;
        }
    }
    else
    {
        loggedNoRequest = false;
        byte[] bytes = new byte[256];
        using (var client=await server.AcceptTcpClientAsync())
        {
            using (var tcpStream=client.GetStream())
            {
                await tcpStream.ReadAsync(bytes,0,bytes.Length);
                var requestMessage = Encoding.UTF8.GetString(bytes).
                    Replace("\0", string.Empty);
                if (requestMessage.Equals(TERMINATE))
                {
                    done = true;
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Message from Client:");
                    Console.WriteLine(requestMessage);
                    var payload = requestMessage.Split(DILIMETER).Last();
                    var responseMessage = $"Greeting from the server !|{payload}";
                    var responseBytes = Encoding.UTF8.GetBytes(responseMessage);
                    await tcpStream.WriteAsync(responseBytes, 0, responseBytes.Length);
                }
               
            }
        }
    }
}
server.Stop();
Thread.Sleep(10000);
