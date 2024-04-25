//клиент обрабатывается бесконечно
using System.Net.Sockets;
using System.Text;

namespace Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var client = new TcpClient())
            {
                while (true)
                {
                    try
                    {
                        Console.WriteLine("Попытка подключения...");
                        client.Connect("127.0.0.1", 2020);
                        Console.WriteLine("Подключение успешно!");
                        break;
                    }
                    catch (SocketException)
                    {
                        Console.WriteLine("Подключение провалилось! Следующая попытка подключения через 5 секунд.");
                        Thread.Sleep(5000);
                    }
                }
                using (var s = client.GetStream())
                {
                    while(true)
                    {
                        // преобразуем строку(формат utf16) в utf8 и даем на вход потоку s
                        s.Write(Encoding.UTF8.GetBytes(Console.ReadLine()));
                    }
                    
                    //Console.WriteLine(s.ReadByte());
                    //s.WriteByte(255);
                }
            }
        }
        }
}




