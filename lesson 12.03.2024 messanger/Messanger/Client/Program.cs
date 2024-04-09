using System.Text;
using System.Threading.Channels;
using Shared.Messages;
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
            SendTextTest();
        }

        static void SendTextTest()
        {
            Client = new Client();
            Client.active = true;
            int CountSignUp = 0;
            Client.OnSignUp += (m) =>
            {
                CountSignUp++;
                Console.WriteLine("sign up");
                Client.SendMessage(new SendTextRequest() {  Receiver = "rita", Text = "hi" });
            };
            Client.OnMessageFromUser += (m) =>
            {
                Console.WriteLine($"получено сообщение {m.Text} от {m.Sender}");
             };

            Client.SendMessage(new SignUpRequest() { username = "rita", password = "fg" });


        }
        static void DeleteTest()
        {
            Client = new Client();
            Client.active = true;
            Client.OnDelete += (m) =>
            {
                Console.WriteLine("delete");

            };
            Client.OnSignUp += (m) =>
            {
                Console.WriteLine("sign up");
                Client.SendMessage(new DeleteUserRequest());
                
            };
            SignUp();
        }
        public void DopFunction()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            Client = new Client();

            Client.active = true;
            Client.OnSignUp += (m) =>
            {
                if (m.Success)
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
                    Console.WriteLine("Вход успешен");
                    Client.SendMessage(new SendTextRequest { Text = "отправляю сообщение", Receiver = "Adel" });
                }
                else
                    Console.WriteLine("failure");
            };
            Client.OnMessageFromUser += (m) =>
            {
                Console.WriteLine($"сообщение {m.Text} пришло от {m.Sender}");
            };
            Client.SendMessage(new SignUpRequest { username = "Adel", password = "jfdh" });


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
