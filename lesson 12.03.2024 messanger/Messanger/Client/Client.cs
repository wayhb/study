using Shared;
using System;
using System.Linq.Expressions;
using System.Net.Sockets;
using System.Text.Json;

namespace Client
{
    class Client : SendAndGetMessage
    {
        readonly TcpClient __tcp_client = new();
        public delegate void OnSignInHandler(SignInResponse sign);
        public event OnSignInHandler OnSignIn;
        public delegate void OnSignUpHandler(SignUpResponse sign);
        public event OnSignUpHandler OnSignUp;
        public delegate void OnMessageFromUserHandler(MessageFromUser message);
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
                                    var bytes = __stream.Read(__buffer);
                                    try
                                    {

                                        var mes = JsonSerializer.Deserialize<NetMessage>(__buffer.AsSpan(0, bytes));
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
                                        else if(mes is MessageFromUser)
                                        {
                                            MessageFromUser message = (MessageFromUser)mes;
                                            OnMessageFromUser?.Invoke(message);
                                        }
                                    }

                                    catch
                                    {

                                    }
                                }
                                
                                try
                                {
                                    __stream.WriteByte(0);
                                    __stream.Flush();
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
