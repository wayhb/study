using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exForEvents5
{
    internal class po83
    {
        // экземпляр делегата как значение выражения до 83

        //int x = 12;
        //MyClass my = new(4);
        //for(int y = 0; y <= 2; y++)
        //{
        //    Console.WriteLine($"my({y})({x}) = {my[y](x)}");
        //}

    delegate int Method(int n);
    class MyClass
    {
        private int Num { get; }
        private int Num1 { get => 6; }
        public MyClass(int n)
        {
            Num = n;
        }
        private int first(int n)
        {
            return n + Num;
        }
        private int second(int n)
        { return n - Num + Num1; }
        private int third(int n)
        {
            return n * Num;
        }
        public Method this[int k]
        {
            get
            {
                switch (k)
                {
                    case 0:
                        return first;
                    case 1:
                        return second;
                    default:
                        return third;

                }
            }
        }
    }
}
}
