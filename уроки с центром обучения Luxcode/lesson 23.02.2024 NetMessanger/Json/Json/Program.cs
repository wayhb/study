using System.Text.Json;

namespace Json
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Message message = new Message("Hello");
            //message.dateTime = DateTime.Now;
            //message.text = "Hello";

            JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions();
            jsonSerializerOptions.WriteIndented = true;
            //серилизация - это приведение объекта платформы к формату json 
            //writeindented(true) - на каждой строке имя - значение переменной
            // преобразование объекта c# в строку
            string json = JsonSerializer.Serialize(message, jsonSerializerOptions);
            Console.WriteLine(json);

            message = JsonSerializer.Deserialize<Message>(json);
            Console.WriteLine($"{message.dateTime},{message.text}");

            using (var s = File.Create("message.json"))
            {
                // записали объект c#, при этом переведя его в строку,в файл 
                JsonSerializer.Serialize(s, message, jsonSerializerOptions);
                
            }
            using(var s = File.OpenRead("message.json"))
            {
                message = JsonSerializer.Deserialize<Message>(s);
                Console.WriteLine($"{message.dateTime},{message.text}");
            }

            SendMessageNetMessage send = new();
            send.Message= new Message("Hello");
            Console.WriteLine(JsonSerializer.Serialize<NetMessage>(send));
            Console.WriteLine(JsonSerializer.Deserialize<NetMessage>(JsonSerializer.Serialize<NetMessage>(send)));
        }
    }
}
