using System.Text;
using System.Threading.Channels;
using Shared;
namespace Client
{
    internal class Program
    {
        static void SignUp()
        {
            Console.WriteLine("Введите имя и пароль: ");

            SignUpRequest signUpMessage = new SignUpRequest();
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
            Client.OnSignUp += (m) =>
            {
                if(m.Success) 
                {
                    Console.WriteLine("Регистрация успешна!");
                    Client.SendMessage(new SignOutRequest());
                }
                else
                {
                    Console.WriteLine("Регистрация неуспешна!");
                    Client.SendMessage(new SignInRequest { username = "Adel", password = "jfdh" });
                }
                
            };
            Client.OnSignIn += (m) =>
            {
                if (m.Success)
                {
                    Console.WriteLine("success");
                }
                else
                    Console.WriteLine("failure");
            };
            Client.SendMessage(new SignUpRequest { username = "Adel", password = "jfdh"});
            
            
            /*
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
            */
        }
    }
}
