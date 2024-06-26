﻿using Shared;
using Shared.Messages;
using System.Diagnostics.SymbolStore;
using System.IO;
using System.Net.Sockets;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Server
{
    class Client : BaseClient
    {
        readonly TcpClient __tcp_client;

        public void Deactivate()
          => __tcp_client.Close();
        static byte[] __buffer = new byte[256];
        public User? User { get; set; }
        public bool Tick()
        {
            try
            {
                // TODO: send messages.
                //__stream.WriteByte(0);
                //__stream.Flush();
            }
            catch
            {
                return false;
            }
            // если в потоке есть данные
            if (__stream.DataAvailable )
            {
                //Console.WriteLine("Сервер: получение");
                int length = reader.ReadInt32();
                
                //чтение из потока сообщения в буфер(возвращает длину сообщения)
                __stream.ReadExactly(__buffer, 0, length);
                try
                {
                    // записываем в буфер все кроме пустых ячеек
                    var mes = JsonSerializer.Deserialize<BaseMessage>(__buffer.AsSpan(0,length));
                    //если то, что пришло на вход это SignUpMessage(логин и пароль)
                    if (mes is SignUpRequest)
                    {
                        Console.WriteLine("Это SignUpMessage");
                        SignUpRequest message = (SignUpRequest)mes;
                        try
                        {
                            var user = new User(message.username, message.password);
                            user.Save();
                            User = user;
                            SendMessage(new SignUpResponse() { Success = true });
                        }
                        catch
                        {
                            SendMessage(new SignUpResponse { Success = false });
                        }
                    }
                    else if (mes is SignInRequest)
                    {
                        SignInRequest message = (SignInRequest)mes;
                        var user = User.FindUser(message.username);

                        if (user != null && message.password.Equals(user.Password))
                        {
                            User = user;
                            SendMessage(new SignInResponse() { Success = true });
                        }
                        else
                            SendMessage(new SignInResponse() { Success = false });
                    }
                    else if (mes is SignOutRequest)
                    {

                        SignOutRequest message = (SignOutRequest)mes;
                        User = null;

                    }
                    else if(User != null)
                    {
                        if (mes is SendTextRequest message)
                        {
                            var receiver = User.FindUser(message.Receiver);
                            if (receiver != null)
                            {
                                SendMessage(new SendTextResponse { Text = message.Text, Sender = User.Name });
                            }
                        }
                        else if (mes is DeleteUserRequest deleteUser)
                        {

                            User.Delete();
                            User = null;
                            SendMessage(new DeleteUserResponse() { Success = true });
                        }
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
    }
    
}
