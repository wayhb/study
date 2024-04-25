namespace Shared.Messages {
  public class SignUpRequest : BaseMessage {
    public string Name { get; init; } = "";
    public string Password { get; init; } = "";
  }
}
