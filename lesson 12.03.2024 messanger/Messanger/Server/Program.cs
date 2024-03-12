using System.Text;

namespace Server {
  class Program {
    static void Main(string[] args) {
      Console.OutputEncoding = Encoding.UTF8;
      Console.InputEncoding = Encoding.UTF8;
      new Server().active = true;
    }
  }
}
