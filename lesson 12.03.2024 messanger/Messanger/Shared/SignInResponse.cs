using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    //ответ сервера успешно или нет вошел пользователь
    public class SignInResponse : NetMessage
    {
        public bool Success { get; set; }
    }
}
