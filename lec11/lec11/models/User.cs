using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lec11.models
{
    internal class User
    {
        public int user_id { get; set; }
        public string last_name { get; set; }
        public string first_name { get; set; }

        public int gender_id { get; set; }
    }
}
