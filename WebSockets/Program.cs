using System.Net.Sockets;
using System.Net;
using System.Text;
using WebSockets;

Server s = new Server("127.0.0.1", 80);

Thread serverThread = new Thread(s.StartListening);
serverThread.Start();

// for test and POC sake i create my own client to test with
Thread clientThread = new Thread(StartClientSide);
clientThread.Start();

static void StartClientSide()
{
    TcpClient clientCreate = new TcpClient();
    clientCreate.Connect(IPAddress.Parse("127.0.0.1"), 80);

    NetworkStream otherStream = clientCreate.GetStream();

    while (true)
    {
        Console.WriteLine("Enter Message: ");
        string? message = Console.ReadLine();
        if (message is not null) SendMessage(otherStream, message);
    }
}

static void SendMessage(NetworkStream stream, string message)
{
    byte[] bytesToSend = ASCIIEncoding.ASCII.GetBytes(message);
    stream.Write(bytesToSend, 0, bytesToSend.Length);
}