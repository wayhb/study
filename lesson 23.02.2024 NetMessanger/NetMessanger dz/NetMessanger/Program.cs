using System.Xml.Linq;

namespace NetMessanger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите имя и пароль: ");
            string name = Console.ReadLine();
            string password = Console.ReadLine();
            
            var User = new User(name);
            User.Password = password;
            Console.WriteLine($"Пользователь {name} создан");
            User.Save();
        }
    }
}
