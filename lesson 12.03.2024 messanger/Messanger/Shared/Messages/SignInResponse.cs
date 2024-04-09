using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Messages
{
    //ответ сервера успешно или нет вошел пользователь
    public class SignInResponse : BaseMessage
    {
        public bool Success { get; set; }
    }
}
