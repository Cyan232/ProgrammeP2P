using System;
using System.Net;
using System.Net.Sockets;
using App;

namespace App
{
    public class MessageSender
    {
        private static Socket? _socket;
        private static int _port;

        public MessageSender(Socket socket, int port)
        {
            _port = port;
            _socket = socket;
        }

        public static void SendMessage(Message message)
        {
            _socket?.SendTo(message.ToBytes(), new IPEndPoint(message.Source, _port));
            Console.WriteLine("Sent message to " + message.Source);
        }
    }
}
