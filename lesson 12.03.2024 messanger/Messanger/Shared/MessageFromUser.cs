using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    // сообщение, когда сервер передает свое сообщение конечному получателю
    public class MessageFromUser : NetMessage
    {
        public string Text { get; set; }
        // отправитель
        public string Sender { get; set; }

    }
}
