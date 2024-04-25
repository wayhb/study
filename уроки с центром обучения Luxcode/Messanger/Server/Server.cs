using System.Net;
using System.Net.Sockets;

namespace Server {
  class Server {
    readonly TcpListener __tcp_listener = new(IPAddress.Parse("127.0.0.1"), 4444);
    
    readonly List<Client> __clients = new();
    public Client? TryFindClient(User user) {
      foreach(var client in __clients)
        if(client.User == user)
          return client;
      return null;
    }

    public bool Active { get; private set; }
    public void Activate() {
      __tcp_listener.Start();
      Active = true;
      Console.WriteLine("Сервер: активирован.");
      while(Active)
        Tick();
      __tcp_listener.Stop();
      __clients.Clear();
    }
    public void Deactivate() {
      Active = false;
      Console.WriteLine("Сервер: деактивирован.");
    }

    public void Tick() {
      while(__tcp_listener.Pending())
        __clients.Add(new(this, __tcp_listener.AcceptTcpClient()));
      Client client;
      for(int i = __clients.Count - 1; i >= 0; --i) {
        client = __clients[i];
        if(!client.Active || !client.Tick()) {
          client.Dispose();
          __clients.RemoveAt(i);
        }
      }
    }
  }
}
