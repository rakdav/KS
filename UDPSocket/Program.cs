﻿using System.Net;
using System.Net.Sockets;
using System.Text;
using Socket udpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
var localIP = new IPEndPoint(IPAddress.Parse("192.168.113.2"), 5555);
udpSocket.Bind(localIP);
Console.WriteLine("UDP-сервер запущен...");
byte[] data = new byte[256];
EndPoint remoteIp = new IPEndPoint(IPAddress.Any, 0);
var result = await udpSocket.ReceiveFromAsync(data, remoteIp);
var message = Encoding.UTF8.GetString(data, 0, result.ReceivedBytes);
Console.WriteLine($"Получено {result.ReceivedBytes} байт");
Console.WriteLine($"Удаленный адрес: {result.RemoteEndPoint}");
Console.WriteLine(message);


