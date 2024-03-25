using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Linq;

namespace ClientTcp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            
            #region TCP
            /*
            const string api = "127.0.0.1";
            const int port = 8081;
            var tcpEndPoint = new IPEndPoint(IPAddress.Parse(api), port);
            var tcpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            Console.WriteLine("Введите сообщение: ");
            var data = Encoding.UTF8.GetBytes(Console.ReadLine());
            tcpSocket.Connect(tcpEndPoint);
            tcpSocket.Send(data);


            var buffer = new byte[256];
            var size = 0;
            var answer = new StringBuilder();

            do
            {
                size = tcpSocket.Receive(buffer);
                answer.Append(Encoding.UTF8.GetString(buffer, 0, size));

            }
            while (tcpSocket.Available > 0);

            Console.WriteLine(answer.ToString());

            tcpSocket.Shutdown(SocketShutdown.Both);
            tcpSocket.Close();

            Console.ReadLine();
            */
            #endregion

            const string api = "127.0.0.1";
            const int port = 8082;
            var udpEndPoint = new IPEndPoint(IPAddress.Parse(api), port);
            var udpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            udpSocket.Bind(udpEndPoint);

            while(true)
            {
                Console.WriteLine("Bведите сообщение");

                var message = Console.ReadLine();
                var serverEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8081);
                udpSocket.SendTo(Encoding.UTF8.GetBytes(message), serverEndPoint);
                var buffer = new byte[256];
                var size = 0;
                var data = new StringBuilder();

                // сюда сохранен адрес клиента, который послал сообщение
                EndPoint senderEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8081);
                do
                {

                    size = udpSocket.ReceiveFrom(buffer, ref senderEndPoint);
                    data.Append(Encoding.UTF8.GetString(buffer));
                }
                while (udpSocket.Available > 0);

                Console.WriteLine(data);
                Console.ReadLine();
                
            }

        }
    }
}
