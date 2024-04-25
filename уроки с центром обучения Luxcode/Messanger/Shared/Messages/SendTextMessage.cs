namespace Shared.Messages {
  public class SendTextMessage : BaseMessage {
    public string Sender { get; init; } = "";
    public string Text { get; init; } = "";
  }
}
