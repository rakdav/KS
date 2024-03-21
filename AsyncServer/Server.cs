using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace AsyncServer
{
    internal class Server
    {
        delegate void ConnectDelegate (Socket s);
        delegate void StartNetwork ( Socket s );
        Socket? socket;
        IPEndPoint? endP;

        public Server ( string strAddr, int port)
        {
            this.endP = new IPEndPoint(IPAddress.Parse(strAddr), port); 
        }
        void Server_Connect (Socket s)
        {
            s.Send(System.Text.Encoding.Unicode.GetBytes(DateTime.Now.ToString()));
            s.Shutdown(SocketShutdown.Both);
            s.Close();
        }
        void Server_Begin(Socket s )
        {
            while (true)
            {

            }
        }
    }
}
