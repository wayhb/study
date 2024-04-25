using Shared.Messages;
using System.Diagnostics;
using System.Reflection;
using System.Text;

namespace Client {
  static class Program {
    static void Main(string[] args) {
      Console.OutputEncoding = Encoding.UTF8;
      Console.InputEncoding = Encoding.UTF8;
      Test();
    }
    static void Test() {
      Client receiver = new();

      receiver.OnSendTextMessage += (res) => {
        Console.WriteLine("Сообщение: получено.");
        Console.WriteLine($"{res.Sender}: {res.Text}");
      };

      receiver.OnSignUp += (res) => {
        static void SenderThread() {
          Client sender = new();

          sender.OnSendText += (res) => {
            Console.WriteLine("Сообщение: отправлено.");
          };

          sender.OnSignUp += (res) => {
            sender.SendMessage(new SendTextRequest {
              Receiver = "receiver",
              Text = "Hi!"
            });
          };

          sender.SendMessage(new SignUpRequest {
            Name = "sender",
            Password = "1234"
          });
          sender.Activate();
        }

        new Thread(SenderThread).Start();
      };

      receiver.SendMessage(new SignUpRequest {
        Name = "receiver",
        Password = "1234"
      });
      receiver.Activate();
    }
  }
}
