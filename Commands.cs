using System.Collections.Generic;
using System;
using System.Net;
using App;

namespace App
{
    public static class Commands
    {
        public static List<Command> CommandList = new List<Command>()
    {
        new EchoCommand(),
        new StartCommand(),
        new SendEchoCommand()
    };

        public static void ExecuteByName(string name, string[] args = null)
        {
            bool executed = false;
            foreach (Command cmd in CommandList)
            {
                //if (cmd.Name == name)
                if (string.Equals(cmd.Name, name, StringComparison.OrdinalIgnoreCase))
                {
                    try
                    {
                        cmd.Execute(args);
                        executed = true;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Command executed !");
                        Console.ForegroundColor = ConsoleColor.White;
                        return;
                    }
                    catch (Exception e)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("An error occured in the command : ");
                        Console.WriteLine(e.Message);
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                }

            }
            if (!executed)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No command were found !");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }

    public abstract class Command
    {
        public abstract string Name { get; }
        public string Help { get; set; } = "[???]";
        public abstract void Execute(string[] arg = null);
    }

    public static class CommandReader
    {
        public static bool Stop { get; set; } = false;
        public static void Run()
        {
            string? input;
            while (!Stop)
            {
                input = Console.ReadLine();

                if (input != null)
                {
                    string[] inputArray = input.Split(' ');
                    string commandName = inputArray[0];
                    string[] args = new string[inputArray.Length - 1];
                    Array.Copy(inputArray, 1, args, 0, inputArray.Length - 1);
                    Commands.ExecuteByName(commandName, args);
                }
            }
        }


    }

    public class EchoCommand : Command
    {
        public override string Name => "echo";
        public override void Execute(string[] arg = null)
        {
            if (arg != null)
            {
                Console.WriteLine(string.Join(" ", arg));
            }
            else
            {
                Console.WriteLine("No argument given !");
            }
        }
    }

    public class StartCommand : Command
    {
        public override string Name => "start";
        public override void Execute(string[] arg = null)
        {
            if (arg != null)
            {
                switch (arg[0])
                {
                    case "master":
                        SessionMaster sessionMaster = new SessionMaster(arg[1]);
                        sessionMaster.Start();
                        break;
                    case "node":
                        Session session = new Session(arg[1], arg[2]);
                        session.Start();
                        break;
                    default:
                        Console.WriteLine("Unknown argument !");
                        break;
                }
            }
            else
            {
                Console.WriteLine("No argument given !");
            }
        }

    }

    public class SendEchoCommand : Command
    {
        public override string Name => "sendecho";
        public override void Execute(string[] arg = null)
        {
            if (arg != null)
            {
                switch (Program.SessionType)
                {
                    case SessionType.Master:

                        break;
                    case SessionType.Node:
                        MessageSender.SendMessage(new Message() { Source = IPAddress.Parse(arg[0]) });
                        break;
                    default:
                        Console.WriteLine("Unknown argument !");
                        break;
                }
            }
            else
            {
                Console.WriteLine("No argument given !");
            }
        }
    }

    public class HelpCommand : Command
    {
        public override string Name => "help";
        public override void Execute(string[] arg = null)
        {
            foreach (Command cmd in Commands.CommandList)
            {
                Console.WriteLine(cmd.Name + " : " + cmd.Help);
            }
        }
    }
}
