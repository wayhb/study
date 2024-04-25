using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Shared.Messages
{
    //как этот тип называется в json
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
    //когда происходит сериализация или десириализация класса netmessage, то в данном случае
    //используется объект SendMessageNetMessage
    //nameof(SendMessageNetMessage) как этот тип называется в json
    [JsonDerivedType(typeof(SignUpRequest), nameof(SignUpRequest))]
    [JsonDerivedType(typeof(SignUpResponse), nameof(SignUpResponse))]
    [JsonDerivedType(typeof(SignInRequest), nameof(SignInRequest))]
    [JsonDerivedType(typeof(SignInResponse), nameof(SignInResponse))]
    [JsonDerivedType(typeof(SendTextRequest), nameof(SendTextRequest))]
    [JsonDerivedType(typeof(SendTextResponse), nameof(SendTextResponse))]
    [JsonDerivedType(typeof(DeleteUserRequest), nameof(DeleteUserRequest))]
    [JsonDerivedType(typeof(DeleteUserResponse), nameof(DeleteUserResponse))]
    public abstract class BaseMessage
    {

    }
}
