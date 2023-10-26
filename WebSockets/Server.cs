using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace WebSockets
{
    public class Server
    {
        private static TcpListener? tcpListener { get; set; }

        public Server(string ip, int portNo)
        {
            tcpListener = new TcpListener(IPAddress.Parse(ip), portNo);

            tcpListener.Start();
            Console.WriteLine("Server has started on {0}:{1}, Waiting for a connection…", ip, portNo);
        }

        public void StartListening()
        {
            if(tcpListener is not null)
            {
                while (true)
                {
                    // connect client
                    TcpClient client = tcpListener.AcceptTcpClient();

                    NetworkStream stream = client.GetStream();

                    // enter to an infinite cycle to be able to handle every change in stream
                    while (true)
                    {
                        while (!stream.DataAvailable) ;

                        byte[] bytes = new byte[client.Available];
                        stream.Read(bytes, 0, bytes.Length);
                        string receivedMessage = Encoding.UTF8.GetString(bytes);

                        Console.WriteLine("Message received: " + receivedMessage);
                        Console.WriteLine();
                    }
                }
            }
        }
    }
}
