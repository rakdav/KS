using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace AsyncServer
{
    internal class ServerAsync
    {
        IPEndPoint? endP;
        Socket? socket;
        public ServerAsync ( string strAddr, int port)
        {
            this.endP = new IPEndPoint(IPAddress.Parse(strAddr),port);
        }
        void MyAcceptCallbackFunction(IAsyncResult ia )
        {
            Socket socket = (Socket)ia.AsyncState!;
            Socket ns = socket.EndAccept(ia);
            Console.WriteLine(ns.RemoteEndPoint!.ToString());
            byte[] sendBuffer = System.Text.Encoding.Unicode.GetBytes(DateTime.Now.ToString());
            ns.BeginSend(sendBuffer, 0, sendBuffer.Length,SocketFlags.None,
                new AsyncCallback(MySendCallbackFunction), socket);
            ns.BeginAccept(new AsyncCallback(MyAcceptCallbackFunction),socket);
        } 
        void MySendCallbackFunction ( IAsyncResult ia)
        {

        }
       
    }
}
