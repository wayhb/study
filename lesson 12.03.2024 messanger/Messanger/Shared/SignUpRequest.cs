using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Shared
{
    public class SignUpRequest: NetMessage
    {
        [JsonInclude]
        public string username;
        [JsonInclude]
        public string password;
    }
}
