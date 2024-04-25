using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Json
{
    //как этот тип называется в json
    [JsonPolymorphic(TypeDiscriminatorPropertyName ="type")]
    //когда происходит сериализация или десириализация класса netmessage, то в данном случае
    //используется объект SendMessageNetMessage
    //nameof(SendMessageNetMessage) как этот тип называется в json
    [JsonDerivedType(typeof(SendMessageNetMessage),nameof(SendMessageNetMessage))]
    abstract class NetMessage
    {

    }
}
