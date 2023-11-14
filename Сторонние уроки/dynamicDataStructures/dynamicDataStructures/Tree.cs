using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dynamicDataStructures
{
    internal class Tree<T> 
        where T: IComparable
    {
        // корень
        public Node<T> Root{ get; private set; }   
        public int Count { get; private set; }
        public void Add(T data)
        {

            if(Root == null)
            {
                Root = new Node<T>(data);
                Count = 1;
                return;
            }

            Root.Add(data); 
            Count++;
        }
    }
}
