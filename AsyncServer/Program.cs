﻿using AsyncServer;

//Server s = new Server("192.168.113.2", 1024);
ServerAsync server = new ServerAsync("192.168.113.2", 1024);
server.Start();
Console.Read();
