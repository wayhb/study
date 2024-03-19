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
        public delegate void OnSignInHandler();
        public event OnSignInHandler OnSignIn;
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
                                            Console.WriteLine("Это SignUpResponse");
                                            SignUpResponse message = (SignUpResponse)mes;
                                            if (message.Success == true)
                                            {
                                                Console.WriteLine("success");
                                                OnSignIn?.Invoke();

                                                
                                            }
                                                
                                            else
                                                Console.WriteLine("failure");
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
