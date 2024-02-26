using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace lec9
{
    internal class lec9
    {
        public void Method()
        {
            Class dog = new() { number = 5 };

            Class cat = new() { number = 9 };
            Type type = typeof(Class);
            //поля 
            var filds = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

            foreach (var fild in filds)
            {
                fild.SetValue(cat, 5);
                Console.WriteLine($"{fild.Name} - {fild.GetValue(cat)}");
            }
            //
            var Method = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);
            foreach (var method in Method)
            {
                method.Invoke(cat, new object[] { 4 });
                Console.WriteLine($"{method.Name} - {method.ReturnType}");
            }
            //dog = Format(stroka, arraof(h,j))
            //string.Format("hdadkajshdjk {0} jsadjasdka {1}", 0 - 1st array, 1 - 2 array)
        }
    }
}
