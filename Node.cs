using System.Collections.Generic;
using System.Net;
using App;

namespace App
{
    public class Node
    {
        public List<Node> Childrens { get; set; }
        public Node Parent { get; set; }

        IPAddress NodeIpAdress { get; set; }

        public Node(IPAddress nodeIpAdress)
        {
            NodeIpAdress = nodeIpAdress;
            MessageReceiver.OnMessageReceived += Propagate;
        }

        public void Propagate(Message message)
        {
            if (message.MessageType == MessageType.UPDATE) // Propagate if is an update
            {
                foreach (Node child in Childrens)
                {
                    if (message.Source != child.NodeIpAdress) // Not sure check
                        MessageSender.SendMessage(message);
                }
            }

        }
    }
}
