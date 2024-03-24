using System;
using System.Net;
using System.Net.Sockets;
using App;

namespace App
{
    public class MessageReceiver
    {
        private static Socket _socket;

        public static Action<Message>? OnMessageReceived { get; set; } // Trigered when a message is received

        public MessageReceiver(Socket socket)
        {
            _socket = socket;
            byte[] buffer = new byte[1024]; // Buffer for receiving data
            EndPoint remoteEndPoint = new IPEndPoint(IPAddress.Any, 0); // Store the sender's endpoint
            socket.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref remoteEndPoint, ReceiveCallback, (buffer, socket));
        }

        static void ReceiveCallback(IAsyncResult result)
        {
            //Here wrap as a Message and call received
            (byte[] buffer, Socket udpSocket) = ((byte[], Socket))result.AsyncState;
            EndPoint remoteEndPoint = new IPEndPoint(IPAddress.Any, 0); // Store the sender's endpoint

            Console.WriteLine("Received message from " + remoteEndPoint);

            // Message message = new Message();
            // OnMessageReceived?.Invoke(message);

            _socket.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref remoteEndPoint, ReceiveCallback, (buffer, _socket));
        }
    }

}
