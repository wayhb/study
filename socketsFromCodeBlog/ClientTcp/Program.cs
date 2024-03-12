using System.Net.Sockets;
using System.Net;
using System.Text;

namespace ClientTcp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string api = "127.0.0.1";
            const int port = 8080;

            var tcpEndPoint = new IPEndPoint(IPAddress.Parse(api), port);
            var tcpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            Console.WriteLine("Введите сообщение: ");
            var data = Encoding.UTF8.GetBytes(Console.ReadLine());
            tcpSocket.Connect(tcpEndPoint);
            tcpSocket.Send(data);


            var buffer = new byte[256];
            var size = 0;
            var answer = new StringBuilder();
            // остановилась на 1.02.00
        }
    }
}
