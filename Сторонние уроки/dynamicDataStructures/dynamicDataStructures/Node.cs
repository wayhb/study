using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dynamicDataStructures
{
    internal class Node<T> : IComparable<T>
        where T : IComparable // этот интерфейс позволяет нам выполнять сравнения
    {
        public T Data { get; private set; } // дерево
        public Node<T> Left { get; private set; }
        public Node<T> Right { get; private set; }
        public Node(T data) { Data = data; }
        public Node(T data, Node<T> left, Node<T> right) 
        {
            Data = data;
            Left = left;
            Right = right;
        }

        public void Add(T data)
        {
            var node = new Node<T>(data);
            if(node.Data.CompareTo(Data) == -1)
            {
                if(Left == null)
                {
                    Left = new Node<T>(data);
                }
                else
                    Left.Add(data);
            }
            else
            {
                if(Right == null)
                {
                    Right = new Node<T>(data);

                }
                else
                    Right.Add(data);
            }
        }

        public int CompareTo(object? obj)
        {
            if (obj is Node<T> item)// если объект удалось привести к Node<T>
            {
                return Data.CompareTo(item); //то оно сразу будет помещено в item
            }
            else
                throw new Exception("Несовпадение типов");
        }

        public int CompareTo(T? other)
        {
            return Data.CompareTo(other);
        }
    }

}
