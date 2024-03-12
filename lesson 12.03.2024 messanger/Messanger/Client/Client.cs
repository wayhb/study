using Shared;
using System.Net.Sockets;
using System.Text.Json;

namespace Client
{
    class Client
    {
        readonly TcpClient __tcp_client = new();
        NetworkStream? __stream;
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
                            while (true)
                            {

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
        public void SendMessage(NetMessage message)
        {
            JsonSerializer.Serialize(__stream, message);
            __stream.Flush();
        }
    }
}
