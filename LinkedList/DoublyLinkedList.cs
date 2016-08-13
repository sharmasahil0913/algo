using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    public class DoublyLinkedList<T> : IEnumerable<DoublyLinkedListNode<T>>, ICollection<T>
    {
        public DoublyLinkedListNode<T> First { get; private set; }
        public DoublyLinkedListNode<T> Last { get; private set; }

        public void AddFirst(DoublyLinkedListNode<T> newNode)
        {
            if (newNode != null)
            {
                newNode.Next = First;
                newNode.Previous = null;
                if (First != null)
                {
                    First.Previous = newNode;
                }
                else
                {
                    Last = newNode;
                }
                First = newNode;
                Count++;
            }
        }

        public void AddFirst(T newValue)
        {
            AddFirst(new DoublyLinkedListNode<T>(newValue));
        }

        public void AddLast(DoublyLinkedListNode<T> newNode)
        {
            if (newNode != null)
            {
                newNode.Next = null;
                newNode.Previous = Last;

                if (Last != null)
                {
                    Last.Next = newNode;
                }
                else
                {
                    First = newNode;
                }
                Last = newNode;
                Count++;
            }
        }

        public void AddLast(T newValue)
        {
            AddLast(new DoublyLinkedListNode<T>(newValue));
        }

        public DoublyLinkedListNode<T> RemoveFirst()
        {
            if (First != null)
            {
                DoublyLinkedListNode<T> firstNode = First;
                First = First.Next;
                if (First != null)
                {
                    First.Previous = null;
                }
                else
                {
                    Last = null;
                }
                Count--;
                return firstNode;
            }
            return null;
        }

        public DoublyLinkedListNode<T> RemoveLast()
        {
            if (Last != null)
            {
                DoublyLinkedListNode<T> lastNode = Last;
                Last = Last.Previous;
                if (Last != null)
                {
                    Last.Next = null;
                }
                else
                {
                    First = null;
                }
                Count--;
                return lastNode;
            }
            return null;
        }

        public bool Remove(DoublyLinkedListNode<T> newNode)
        {
            if (newNode != null)
            {
                return Remove(newNode.Value);
            }
            else
            {
                return false;
            }
        }

        //public void Remove(T newValue) already in ICollection
        //{
        //    throw new NotImplementedException();
        //}

        public DoublyLinkedListNode<T> Find(T value)
        {
            DoublyLinkedListNode<T> current = First;

            while (current != null)
            {
                if (current.Value.Equals(value)) //CHECK HOW WOULD THIS EQUALITY WORK, FOR STANDARD AND FOR COMPLEX TYPES
                {
                    return current;
                }
                current = current.Next;
            }
            return null;
        }

        public DoublyLinkedListNode<T> FindLast(T value)
        {
            //One and best way is to use same as "DoublyLinkedListNode<T> Find(T value)" except assign Last to current.
            DoublyLinkedListNode<T> current = First;
            DoublyLinkedListNode<T> element = null;

            while (current != null)
            {
                if (current.Value.Equals(value))
                {
                    element = current;
                }
                current = current.Next;
            }
            return element;
        }


        //ICollection starts
        public int Count { get; private set; }

        public bool IsReadOnly
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void Add(T item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            DoublyLinkedListNode<T> node = Find(item);
            if (node != null)
            {
                if (node.Previous != null)
                {
                    node.Previous = node.Previous.Previous;
                    if (node.Previous != null)
                    {
                        node.Previous.Next = node;
                    }
                }

                if (node.Next != null)
                {
                    node.Next = node.Next.Next;
                    if (node.Next != null)
                    {
                        node.Next.Previous = node;
                    }
                }
                return true;
            }
            return false;
        }
        //ICollection ends



        //IEnumerable starts
        public IEnumerator<DoublyLinkedListNode<T>> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
        //IEnumerable ends


    }
}
