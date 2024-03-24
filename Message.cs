
using System.Net;
using System.ComponentModel.DataAnnotations;
using System;
using App;

namespace App
{
    public enum MessageType
    {
        UPDATE,
        FILE,
        ADD,
        REMOVE
    }

    public class Message
    {
        public MessageType MessageType { get; set; } = MessageType.UPDATE;
        public int SequenceNumber { get; set; } = 0;

        public byte[] Data { get; set; } = new byte[1024];
        public IPAddress Source { get; set; } = IPAddress.Any;
        public byte[] ToBytes()
        {
            byte[] bytes = new byte[1024];
            // BitConverter.GetBytes((ushort)this.MessageType).CopyTo(bytes, 0);
            // BitConverter.GetBytes(SequenceNumber).CopyTo(bytes, 2);
            // Data.CopyTo(bytes, 6);
            return bytes;
        }

        public static Message FromBytes(byte[] bytes)
        {
            Message message = new Message();
            //To Do
            return message;
        }
    }

}
