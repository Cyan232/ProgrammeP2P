using System;
using System.Net;
using System.Net.Sockets;
using App;

namespace App
{
    public class Session
    {
        public string EndPointIP { get; private set; }
        public string Port { get; private set; }

        private Socket socket;

        public Session(string endPointIP, string port)
        {
            EndPointIP = endPointIP;
            Port = port;
        }

        public void Start()
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPEndPoint localEndPoint = new IPEndPoint(IPAddress.Any, int.Parse(Port));
            socket.Bind(localEndPoint);

            MessageReceiver receiver = new MessageReceiver(socket);

            IPAddress endIp = IPAddress.Parse(EndPointIP);
            IPEndPoint endPoint = new IPEndPoint(endIp, int.Parse(Port));

            MessageSender sender = new MessageSender(socket, int.Parse(Port));

            Program.SessionType = SessionType.Node;
            Console.WriteLine("Binded to " + Port + " ready to receive...");
            // while (true)
            // {

            // }
        }
    }
}
