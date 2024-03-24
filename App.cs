using System;
using System.Net;
using System.Threading.Tasks;
using App;

namespace App
{
    public enum SessionType
    {
        Master,
        Node
    }
    public static class Program
    {
        public static SessionType SessionType { get; set; }

        public static async Task Main(string[] args)
        {

            if (args.Length > 0 && args[0] == "start" && args[1] == "node")
            {
                Console.WriteLine("Starting Application as a node...");
                Session session = new Session(args[2], args[3]);
                session.Start();
                await Task.Delay(200);
                MessageSender.SendMessage(new Message() { Source = IPAddress.Parse(args[2]) });
            }
            // Session session = new Session(args[0], args[1]);
            else
            {

                Console.WriteLine("Starting Application...");
                App.CommandReader.Run();
            }

            //     // string ip = args[0];
            //     // string port = args[1];
            //     string ip = "127.0.0.1";
            //string port = "69";


            //     Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            //     // Bind the socket to the local endpoint and listen for incoming connections
            //     IPAddress ipAddress = IPAddress.Parse(ip);
            //     IPEndPoint localEndPoint = new IPEndPoint(ipAddress, int.Parse(port));
            //     socket.Bind(localEndPoint);

            //     // Start receiving data asynchronously
            //     byte[] buffer = new byte[1024]; // Buffer for receiving data
            //     EndPoint remoteEndPoint = new IPEndPoint(IPAddress.Any, 0); // Store the sender's endpoint
            //     socket.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref remoteEndPoint, ReceiveCallback, (buffer, socket));

            //     Console.WriteLine("Binded to " + ip + ":" + port + " ready to receive...");
            //     // Keep the program running to continue receiving data
            //     Console.ReadLine();
            // }

            // static void ReceiveCallback(IAsyncResult result)
            // {
            //     // Retrieve the buffer and socket from the async result
            //     (byte[] buffer, Socket udpSocket) = ((byte[], Socket))result.AsyncState;

            //     // End the asynchronous receive operation and get the received data
            //     EndPoint remoteEndPoint = new IPEndPoint(IPAddress.Any, 0); // Store the sender's endpoint
            //     int bytesRead = udpSocket.EndReceiveFrom(result, ref remoteEndPoint);

            //     // Convert the received data to a string
            //     string receivedMessage = System.Text.Encoding.UTF8.GetString(buffer, 0, bytesRead);

            //     // Display the received message and the sender's endpoint
            //     Console.WriteLine($"Received: {receivedMessage} from {remoteEndPoint}");

            //     // Continue receiving data asynchronously
            //     udpSocket.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref remoteEndPoint, ReceiveCallback, (buffer, udpSocket));
        }
    }
}
