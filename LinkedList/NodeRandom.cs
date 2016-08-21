using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    public class NodeRandom<T>
    {
        public T Value { get; set; }

        public NodeRandom(T value)
        {
            Value = value;
        }

        public NodeRandom<T> Next { get; set; }

        public NodeRandom<T> Random { get; set; }

    }
}
