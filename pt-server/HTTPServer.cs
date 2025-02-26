using System.Net;
using System.Net.Sockets;



public class HTTPServer
{
    private bool running = false;
    private TcpListener listener;

    public HTTPServer(int port)
    {
        listener = new TcpListener(IPAddress.Parse("127.0.0.1"), port);
    }
    public void Start()
    {
        Thread serverThread = new Thread(new ThreadStart(Run));
        serverThread.Start();
    }

    private void Run()
    {
        running = true;
        listener.Start();
        while (running)
        {
            System.Console.WriteLine("Connecting...");
            TcpClient client = listener.AcceptTcpClient();
            System.Console.WriteLine("Connected...");
            HandleClient(client);
            client.Close();
        }

        running = false;

        listener.Stop();
    }
    private void HandleClient(TcpClient client)
    {   
        byte[] buffer = new byte[1024];
        var cStream = client.GetStream();
        cStream.Read(buffer);
        Request request = new Request(System.Text.Encoding.Default.GetString(buffer));

        System.Console.WriteLine(request);
    }
}