using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Json
{
    /*
    internal class Message
    {

        [JsonIgnore]
        public DateTime DateTime { get; set; }
        [JsonInclude]
        public string Text { get; set; }


    }
    */
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
    }
}
