using System.Net;
using System.Net.Sockets;
using System.Text;

namespace socketsFromCodeBlog
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region TCP
            /*
            const string api = "127.0.0.1";
            const int port = 8080;

            var tcpEndPoint = new IPEndPoint(IPAddress.Parse(api), port);
            var tcpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            tcpSocket.Bind(tcpEndPoint);
            tcpSocket.Listen(5);

            while(true)
            {
                var listener = tcpSocket.Accept();
                var buffer = new byte[256];
                var size = 0;
                var data = new StringBuilder();
                // в листенер мы можем записать 256 символов, но к примеру передаем
                // меньше, чем 256, тогда мы то, что получили перекодировали в строку utf8

                do
                {
                    size = listener.Receive(buffer);
                    data.Append(Encoding.UTF8.GetString(buffer, 0, size));

                }
                while(listener.Available > 0);

                Console.WriteLine(data);

                listener.Send(Encoding.UTF8.GetBytes("Успех"));
                listener.Shutdown(SocketShutdown.Both);
                listener.Close();

            }
            */
            #endregion

            const string api = "127.0.0.1";
            const int port = 8081;
            var udpEndPoint = new IPEndPoint(IPAddress.Parse(api), port);
            var udpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            udpSocket.Bind(udpEndPoint);

            while(true)
            {
                var buffer = new byte[256];
                var size = 0;
                var data = new StringBuilder();

                // сюда сохранен адрес клиента, который послал сообщение
                EndPoint senderEndPoint = new IPEndPoint(IPAddress.Any, 0);
                do
                {
                    
                    size = udpSocket.ReceiveFrom(buffer, ref senderEndPoint);
                    data.Append(Encoding.UTF8.GetString(buffer));
                }
                while (udpSocket.Available > 0);


                udpSocket.SendTo(Encoding.UTF8.GetBytes("Сообщение получено"), senderEndPoint);
                Console.WriteLine(data);
            }
            
        }
    }
}
