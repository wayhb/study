using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    internal class Server
    {
        TcpListener listener = new TcpListener(2020);
        List <Client> clients = new List <Client> ();
        public void Listen()
        {
            Console.WriteLine("Запускаем сервер");
            listener.Start();
            while (true)
            {
                while(listener.Pending())
                {
                    clients.Add(new Client(listener.AcceptTcpClient()));
                    Console.WriteLine("Новое подключение");
                }
                byte[] netmes = new byte[128];
                foreach (Client client in clients)
                {
                    var stream = client.client.GetStream();
                    if (stream.Read(netmes) > 0)
                    {
                        Console.WriteLine("Есть новое сообщение)");
                    }

                }
            }
        }
    }
}
