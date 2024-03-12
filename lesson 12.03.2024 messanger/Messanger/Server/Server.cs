using System.Net;
using System.Net.Sockets;

namespace Server
{
    class Server
    {
        readonly List<Client> __clients = new();
        readonly TcpListener __tcp_listener = new(IPAddress.Parse("127.0.0.1"), 2020);
        bool __active;
        public bool active
        {
            get
              => __active;
            set
            {
                if (active != value)
                {
                    if (value)
                    {
                        __tcp_listener.Start();
                        __active = value;
                        Console.WriteLine("Сервер: активирован.");
                        while (active)
                        {
                            while (__tcp_listener.Pending())
                            {
                                __clients.Add(new(__tcp_listener.AcceptTcpClient()));
                                Console.WriteLine("Сервер: клиент подключён.");
                            }
                            for (int i = __clients.Count - 1; i >= 0; --i)
                                if (!__clients[i].Tick())
                                {
                                    __clients.RemoveAt(i);
                                    Console.WriteLine("Сервер: клиент отключён.");
                                }
                        }
                    }
                    else
                    {
                        __active = false;
                        __tcp_listener.Stop();
                        Console.WriteLine("Сервер: деактивирован.");
                    }
                }
            }
        }
    }
}
