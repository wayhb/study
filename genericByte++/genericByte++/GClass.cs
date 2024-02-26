using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace genericByte__
{
    internal class GClass<T>
    {
        public T GPro { get; set; }

        public void GetGpropType()
        {
            Console.WriteLine(GPro.GetType());

        }
    }
}
