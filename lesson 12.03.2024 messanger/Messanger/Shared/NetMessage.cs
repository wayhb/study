using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Shared
{
    //как этот тип называется в json
    [JsonPolymorphic(TypeDiscriminatorPropertyName ="type")]
    //когда происходит сериализация или десириализация класса netmessage, то в данном случае
    //используется объект SendMessageNetMessage
    //nameof(SendMessageNetMessage) как этот тип называется в json
    [JsonDerivedType(typeof(SignUpRequest),nameof(SignUpRequest))]
    [JsonDerivedType(typeof(SignUpResponse), nameof(SignUpResponse))]
    [JsonDerivedType(typeof(SignInRequest), nameof(SignInRequest))]
    [JsonDerivedType(typeof(SignInResponse), nameof(SignInResponse))]
    [JsonDerivedType(typeof(MessageToUser), nameof(MessageToUser))]
    public abstract class NetMessage
    {

    }
}
