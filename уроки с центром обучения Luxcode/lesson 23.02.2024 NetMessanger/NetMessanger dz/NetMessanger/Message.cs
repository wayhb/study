using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NetMessanger
{
    class Message
    {
        public Message(string text)
        {
            dateTime = DateTime.Now;
            this.text = text;
        }
        [JsonConstructor]
        public Message(DateTime dateTime, string text)
        {
            this.dateTime = dateTime;
            this.text = text;
        }

        [JsonInclude]
        public readonly DateTime dateTime;
        [JsonInclude]
        public readonly string text;
        public User Sender { get; set; }
        public User Receiver {  get; set; }
    }
}
