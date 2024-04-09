using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Shared.Messages
{
    //запрос клиента к серверу, зарегистрироваться
    public class SignUpRequest : BaseMessage
    {
        [JsonInclude]
        public string username;
        [JsonInclude]
        public string password;
    }
}
