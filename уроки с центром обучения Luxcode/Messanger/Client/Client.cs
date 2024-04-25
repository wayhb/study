using Shared;
using Shared.Messages;

namespace Client {
  class Client : BaseClient {
    public void Activate() {
      Active = true;
      Console.WriteLine("Клиент: активируется.");
    connect:
      try {
        _Activate(new("localhost", 4444));
      } catch {
        if(Active)
          goto connect;
      }
      while(Active)
        if(!Tick())
          goto connect;
      _stream.Dispose();
      _tcp_client.Dispose();
    }

    public delegate void OnSignInHandler(SignInResponse response);
    public event OnSignInHandler OnSignIn;
    public delegate void OnSignUpHandler(SignUpResponse response);
    public event OnSignUpHandler OnSignUp;
    public delegate void OnSendTextHandler(SendTextResponse response);
    public event OnSendTextHandler OnSendText;
    public delegate void OnSendTextMessageHandler(SendTextMessage message);
    public event OnSendTextMessageHandler OnSendTextMessage;

    protected override void _ReceiveMessage(BaseMessage message) {
      if(message is SignInResponse sign_in && OnSignIn != null)
        OnSignIn(sign_in);
      else if(message is SignUpResponse sign_up && OnSignUp != null)
        OnSignUp(sign_up);
      else if(message is SendTextResponse send_text && OnSendText != null)
        OnSendText(send_text);
      else if(message is SendTextMessage send_text_message && OnSendTextMessage != null)
        OnSendTextMessage(send_text_message);
    }
  }
}
