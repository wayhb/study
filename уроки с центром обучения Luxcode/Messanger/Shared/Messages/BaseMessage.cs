using System.Text.Json.Serialization;

namespace Shared.Messages {
  [JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
  [JsonDerivedType(typeof(SignUpRequest), nameof(SignUpRequest))]
  [JsonDerivedType(typeof(SignUpResponse), nameof(SignUpResponse))]
  [JsonDerivedType(typeof(SignInRequest), nameof(SignInRequest))]
  [JsonDerivedType(typeof(SignInResponse), nameof(SignInResponse))]
  [JsonDerivedType(typeof(SignOutRequest), nameof(SignOutRequest))]
  [JsonDerivedType(typeof(UserDeleteRequest), nameof(UserDeleteRequest))]
  [JsonDerivedType(typeof(SendTextRequest), nameof(SendTextRequest))]
  [JsonDerivedType(typeof(SendTextResponse), nameof(SendTextResponse))]
  [JsonDerivedType(typeof(SendTextMessage), nameof(SendTextMessage))]
  public abstract class BaseMessage {
  }
}
