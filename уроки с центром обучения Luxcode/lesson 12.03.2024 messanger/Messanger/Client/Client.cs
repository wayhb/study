using Shared;
using Shared.Messages;
using System;
using System.Linq.Expressions;
using System.Net.Sockets;
using System.Text.Json;

namespace Client
{
    class Client : BaseClient
    {
        readonly TcpClient __tcp_client = new();
        public delegate void OnSignInHandler(SignInResponse response);
        public event OnSignInHandler OnSignIn;
        public delegate void OnSignUpHandler(SignUpResponse response);
        public event OnSignUpHandler OnSignUp;
        public delegate void OnDeleteHandler(DeleteUserResponse response);
        public event OnDeleteHandler OnDelete;
        public delegate void OnMessageFromUserHandler(SendTextResponse message);
        public event OnMessageFromUserHandler OnMessageFromUser;
        public bool active
        {
            get
              => __tcp_client.Connected;
            set
            {
                if (active != value)
                {
                    if (value)
                    {
                        __tcp_client.Connect("127.0.0.1", 2020);
                        Console.WriteLine("Клиент: активирован.");
                        __stream = __tcp_client.GetStream();

                        new Thread(() =>
                        {
                            var __buffer = new byte[256];
                            while (true)
                            {
                                if (__stream.DataAvailable)
                                {

                                    int length;
                                    BinaryReader reader = new(__stream);
                                    length = reader.ReadInt32();

                                    //чтение из потока сообщения в буфер(возвращает длину сообщения)
                                    __stream.ReadExactly(__buffer, 0, length);


                                    try
                                    {

                                        var mes = JsonSerializer.Deserialize<BaseMessage>(__buffer.AsSpan(0,length));
                                        if (mes is SignUpResponse)
                                        {
                                            SignUpResponse message = (SignUpResponse)mes;
                                            OnSignUp?.Invoke(message);
                                        }
                                        else if(mes is SignInResponse)
                                        {
                                            SignInResponse message = (SignInResponse)mes;
                                            OnSignIn?.Invoke(message);
                                        }
                                        else if(mes is SendTextResponse)
                                        {
                                            SendTextResponse message = (SendTextResponse)mes;
                                            OnMessageFromUser?.Invoke(message);
                                        }
                                        else if (mes is DeleteUserResponse)
                                        {
                                            DeleteUserResponse message = (DeleteUserResponse)mes;
                                            OnDelete?.Invoke(message);
                                        }
                                    }

                                    catch
                                    {

                                    }
                                }
                                
                                try
                                {
                                    //__stream.WriteByte(0);
                                    //__stream.Flush();
                                    //Console.WriteLine("Клиент: отправка.");
                                }
                                catch
                                {
                                    Console.WriteLine("Клиент: деактивирован.");
                                    break;
                                }
                                Thread.Sleep(1000);
                            }


                        }).Start();

                    }
                    else
                        __tcp_client.Close();
                }
            }
        }

    }
}
