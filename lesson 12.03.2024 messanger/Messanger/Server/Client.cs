using Shared;
using System.Diagnostics.SymbolStore;
using System.IO;
using System.Net.Sockets;
using System.Reflection.Metadata;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Server
{
    class Client : SendAndGetMessage
    {
        readonly TcpClient __tcp_client;
        public void Deactivate()
          => __tcp_client.Close();
        static byte[] __buffer = new byte[256];
        public bool Tick()
        {
            try
            {
                // TODO: send messages.
                //__stream.WriteByte(0);
                //__stream.Flush();
            }
            catch
            {
                return false;
            }
            // если в потоке есть данные
            if (__stream.DataAvailable )
            {
                //Console.WriteLine("Сервер: получение");

                //чтение из потока сообщения в буфер(возвращает длину сообщения)
                var bytes = __stream.Read(__buffer);
                try
                {
                    // записываем в буфер все кроме пустых ячеек
                    var mes = JsonSerializer.Deserialize<NetMessage>(__buffer.AsSpan(0,bytes));
                    //если то, что пришло на вход это SignUpMessage(логин и пароль)
                    if (mes is SignUpMessage)
                    {
                        Console.WriteLine("Это SignUpMessage");
                        SignUpMessage message = (SignUpMessage)mes;
                        var user = new User(message.username);
                        user.Password = message.password;
                        SendMessage(new SignUpResponse() { Success = true });
                    }
                }
                catch(Exception ex)
                {
                    //Console.WriteLine(ex.Message);
                }

            }
            return true;
        }
        public Client(TcpClient tcp_client)
        {
            __tcp_client = tcp_client;
            __stream = __tcp_client.GetStream();
        }
    }
    
}
