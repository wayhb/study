using System.Xml.Linq;

namespace NetMessanger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("У вас уже есть аккаунт? y or n?");
            while(true) 
            {
                switch (Console.ReadLine())
                {
                    case "y":
                        SignIn();
                        break;
                    case "n":
                        Registration();
                        break;
                    default:
                        Console.WriteLine("Введите другой символ!");
                        break;
                }
            }
            
        }
        static void SignIn()
        {
            Console.WriteLine("Введите имя и пароль: ");
            string name = Console.ReadLine();
            string password = Console.ReadLine();
            var user = User.FindUser(name);
            if (null == user)
            {
                Console.WriteLine("Неверное имя пользователя или пароль");
            }
            else
            {
                if(user.Password.Equals(password) )
                {
                    Console.WriteLine($"Вы вошли в аккаунт {name}");
                }
                else
                    Console.WriteLine("Неверное имя пользователя или пароль");
            }

        }
        static void Registration()
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
