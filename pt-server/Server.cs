using System;
using System.Net;
using System.Net.Sockets;

namespace Server
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HTTPServer server = new HTTPServer(8008);
            server.Start();
            byte[] buffer = new byte[0];
            
            buffer = new byte[1024];
            
        }
    }
}