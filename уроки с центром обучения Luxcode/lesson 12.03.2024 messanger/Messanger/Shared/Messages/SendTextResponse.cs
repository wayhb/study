using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Messages
{
    // сообщение, когда сервер передает свое сообщение конечному получателю
    public class SendTextResponse : BaseMessage
    {
        public string Text { get; set; }
        // отправитель
        public string Sender { get; set; }

    }
}
