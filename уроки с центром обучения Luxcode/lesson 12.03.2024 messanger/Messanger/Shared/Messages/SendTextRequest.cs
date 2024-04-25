using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Messages
{
    // сообщение от пользователя через сервер к клиенту
    public class SendTextRequest : BaseMessage
    {
        public string Text { get; set; }
        // получатель
        public string Receiver { get; set; }

    }
}
