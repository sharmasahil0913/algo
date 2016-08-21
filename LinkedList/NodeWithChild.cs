using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    public class NodeWithChild<T>
    {
        public T Value { get; set; }

        public NodeWithChild(T value)
        {
            Value = value;
        }

        public Node<T> Next { get; set; }

        public Node<T> Child { get; set; }
    }
}
