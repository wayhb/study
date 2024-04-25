namespace Shared.Messages {
  public class SignInRequest : BaseMessage {
    public string Name { get; init; } = "";
    public string Password { get; init; } = "";
  }
}
