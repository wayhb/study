﻿using Shared;
using System.Diagnostics.SymbolStore;
using System.IO;
using System.Net.Sockets;
using System.Reflection.Metadata;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Server
{
    class Client
    {
        readonly TcpClient __tcp_client;
        readonly NetworkStream __stream;
        public void Deactivate()
          => __tcp_client.Close();
        static byte[] __buffer = new byte[256];
        public bool Tick()
        {
            try
            {
                // TODO: send messages.
                __stream.WriteByte(0);
                __stream.Flush();
            }
            catch
            {
                return false;
            }
            int bytesCount;
            if (__stream.DataAvailable )
            {
                //Console.WriteLine("Сервер: получение");
                var bytes = __stream.Read(__buffer);
                try
                {
                    var mes = JsonSerializer.Deserialize<NetMessage>(__buffer.AsSpan(0,bytes));
                    if(mes is SignUpMessage)
                    {
                        Console.WriteLine("Это SignUpMessage");
                        SignUpMessage message = (SignUpMessage)mes;
                        var user = new User(message.username);
                        user.Password = message.password;
                        SendMessage(new SignUpResponse() { Success = true });
                    }
                }
                catch(Exception ex)
                {
                    //Console.WriteLine(ex.Message);
                }

            }
            return true;
        }
        public Client(TcpClient tcp_client)
        {
            __tcp_client = tcp_client;
            __stream = __tcp_client.GetStream();
        }
        public void SendMessage(NetMessage message)
        {
            JsonSerializer.Serialize(__stream, message);
            __stream.Flush();
        }
    }
    
}
