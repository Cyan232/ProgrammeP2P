using System;
using System.Net;
using System.Net.Sockets;
using App;

namespace App
{
    public class SessionMaster
    {
        public string Port { get; private set; }

        private Socket socket;

        public SessionMaster(string port)
        {
            Port = port;
        }

        public void Start()
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPEndPoint localEndPoint = new IPEndPoint(IPAddress.Any, int.Parse(Port));
            socket.Bind(localEndPoint);

            MessageReceiver receiver = new MessageReceiver(socket);
            MessageSender sender = new MessageSender(socket, int.Parse(Port));

            Program.SessionType = SessionType.Master;
            Console.WriteLine("Binded to " + Port + " ready to receive...");
            // while (true)
            // {

            // }
        }
    }
}
