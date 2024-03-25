using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    // сообщение от пользователя через сервер к клиенту
    public class MessageToUser:NetMessage
    {
        public string Text {  get; set; }
        // получатель
        public string Receiver { get; set; }

    }
}
