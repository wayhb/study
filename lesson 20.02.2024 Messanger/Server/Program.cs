//создание сервера, который слушает клиентов на определенном порте
//он принимает клиентов бесконечно. для каждого клиента он создает его поток обработки
//необязательно обработать клиента, чтобы принять следующего
using System.Net.Sockets;
using System.Text;

static void HandleClient(TcpClient client)
{
    //каждый раз сервер читает байты от пользователя
    while(true)
    {
        // пусть поток прочтет 12 байт, т е слово привет
        var s = client.GetStream();
        byte[] buffer = new byte[12];
        s.ReadExactly(buffer);

        Console.WriteLine(Encoding.UTF8.GetString(buffer));
    }

}
using (var server = new TcpListener(2020))
{
    server.Start();
    while (true)
    {
        var client = server.AcceptTcpClient();
        //поток принимает функцию, которая ничего не принимает и не возвращает
        new Thread(() =>{ HandleClient(client); }).Start();
    }
}

