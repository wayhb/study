using System.Text;

namespace Server {
  static class Program {
    static void Main(string[] args) {
      Console.OutputEncoding = Encoding.UTF8;
      Console.InputEncoding = Encoding.UTF8;
      try {
        Directory.Delete("data/users", true);
      } catch {
      }
      new Server().Activate();
    }
  }
}
