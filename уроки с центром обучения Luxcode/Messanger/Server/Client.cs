using System.Net.Sockets;
using Shared;
using Shared.Messages;

namespace Server {
  class Client : BaseClient {
    public Server Server { get; private init; }
    public User? User { get; private set; }

    public Client(Server server, TcpClient tcp_client) {
      Server = server;
      Active = true;
      _Activate(tcp_client);
    }

    protected override void _ReceiveMessage(BaseMessage message) {
      if(message is SignUpRequest sign_up) {
        try {
          var user = new User(sign_up.Name, sign_up.Password);
          user.Save();
          User = user;
          SendMessage(new SignUpResponse { Success = true });
        } catch {
          SendMessage(new SignUpResponse { Success = false });
        }
      } else if(message is SignInRequest sign_in) {
        var user = User.TryFindUser(sign_in.Name);
        if(user != null && sign_in.Password.Equals(user.Password)) {
          User = user;
          SendMessage(new SignInResponse { Success = true });
        } else
          SendMessage(new SignInResponse { Success = false });
      } else if(User != null) {
        if(message is SignOutRequest)
          User = null;
        else if(message is UserDeleteRequest) {
          User.Delete();
          User = null;
        } else if(message is SendTextRequest send_text) {
          var receiver = User.TryFindUser(send_text.Receiver);
          Client? receiver_client;
          if(receiver != null && (receiver_client = Server.TryFindClient(receiver)) != null) {
            receiver_client.SendMessage(new SendTextMessage { Sender = User.Name, Text = send_text.Text });
            SendMessage(new SendTextResponse { Success = true });
          } else
            SendMessage(new SendTextResponse { Success = false });
        }
      }
    }
  }
}
