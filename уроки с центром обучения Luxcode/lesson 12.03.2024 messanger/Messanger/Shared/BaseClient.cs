using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Shared.Messages;

namespace Shared
{
    public abstract class BaseClient
    {
        NetworkStream stream;
        protected NetworkStream __stream {
            get
            {
                return stream;
            }
            set
            {
                stream = value;
                binaryWriter = new BinaryWriter(stream);
                reader = new BinaryReader(stream);
            } 
        }
        BinaryWriter binaryWriter;
        protected BinaryReader reader;
        public void SendMessage(BaseMessage message)
        {
            string json = JsonSerializer.Serialize(message);
            byte[] jsonAsUTF8 = Encoding.UTF8.GetBytes(json);
            binaryWriter.Write(jsonAsUTF8.Length);
            __stream.Write(jsonAsUTF8);

            __stream.Flush();
        }

    }
}
