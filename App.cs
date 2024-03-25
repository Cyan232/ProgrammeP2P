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
            //Hardcoded for testing
            if (args.Length > 0 && args[0] == "start" && args[1] == "node")
            {
                Console.WriteLine("Starting Application as a node...");
                Session session = new Session(args[2], args[3]);
                session.Start();
                await Task.Delay(200);
                MessageSender.SendMessage(new Message() { Source = IPAddress.Parse(args[2]) });
            }
            //Normal user behavior here
            else
            {
                Console.WriteLine("Starting Application...");
                App.CommandReader.Run();
            }
        }
    }
}
