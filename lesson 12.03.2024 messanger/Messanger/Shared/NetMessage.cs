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
    [JsonDerivedType(typeof(SignUpMessage),nameof(SignUpMessage))]
    [JsonDerivedType(typeof(SignUpResponse), nameof(SignUpResponse))]
    public abstract class NetMessage
    {

    }
}
