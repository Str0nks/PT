using System;
using System.Net;
using System.Net.Sockets;

namespace Server
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TcpListener tcpListener = new TcpListener(IPAddress.Parse("127.0.0.1"),8008);
            tcpListener.Start();
            TcpClient tcpClient = new TcpClient();
            byte[] buffer = new byte[0];
            while(true){
                buffer = new byte[1024];
                tcpClient = tcpListener.AcceptTcpClient();
                var cStream = tcpClient.GetStream();
                cStream.Read(buffer);
                Request request = new Request(System.Text.Encoding.Default.GetString(buffer));
                System.Console.WriteLine(request);
            }
        }
    }
}