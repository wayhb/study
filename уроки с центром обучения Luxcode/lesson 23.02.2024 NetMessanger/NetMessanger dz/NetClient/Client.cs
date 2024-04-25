using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace NetClient
{
    internal class Client
    {
        public TcpClient client = new TcpClient();
        public void Listen()
        {
            while(true)
            {
                try
                {
                    client.Connect("127.0.0.1", 2020);
                    Console.WriteLine("Соединение установлено!");
                    var stream = client.GetStream();
                    stream.WriteByte(128);
                    break;
                }
                catch
                {
                    Console.WriteLine("Подключение неуспешно. Следующая попытка через 5 сек...");
                    Thread.Sleep(5000);
                }
            }
        }
    }
}
