using System.Text;
using Shared;
namespace Client
{
    internal class Program
    {
        static void SignUp()
        {
            Console.WriteLine("Введите имя и пароль: ");

            SignUpMessage signUpMessage = new SignUpMessage();
            signUpMessage.username = Console.ReadLine();
            signUpMessage.password = Console.ReadLine();
            Client.SendMessage(signUpMessage);
            
        }
        static Client Client { get; set; }
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            Client = new Client();
            Client.active = true;
            Console.WriteLine("У вас уже есть аккаунт? y or n?");
            while (true)
            {
                switch (Console.ReadLine())
                {
                    case "y":
                        //SignIn();
                        break;
                    case "n":
                        SignUp();
                        break;
                    default:
                        Console.WriteLine("Введите другой символ!");
                        break;
                }
            }

        }
    }
}
