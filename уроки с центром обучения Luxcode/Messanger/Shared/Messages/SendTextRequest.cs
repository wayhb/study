namespace Shared.Messages {
  public class SendTextRequest : BaseMessage {
    public string Receiver { get; init; } = "";
    public string Text { get; init; } = "";
  }
}
