﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    public class DoublyLinkedList<T> : IEnumerable<Node<T>>, ICollection<T> where T :IComparable
    {
        public Node<T> First { get;  set; }
        public Node<T> Last { get;  set; }

        public void AddFirst(Node<T> newNode)
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
            AddFirst(new Node<T>(newValue));
        }

        public void AddLast(Node<T> newNode)
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
            AddLast(new Node<T>(newValue));
        }

        public Node<T> RemoveFirst()
        {
            if (First != null)
            {
                Node<T> firstNode = First;
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

        public Node<T> RemoveLast()
        {
            if (Last != null)
            {
                Node<T> lastNode = Last;
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

        public bool Remove(Node<T> newNode)
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

        public Node<T> Find(T value)
        {
            Node<T> current = First;

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

        public Node<T> FindLast(T value)
        {
            //One and best way is to use same as "DoublyLinkedListNode<T> Find(T value)" except assign Last to current.
            Node<T> current = First;
            Node<T> element = null;

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
            Node<T> node = Find(item);
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

                //Missed case: added after unit test failed. (if not class based we need to pass first and last pointers with ref)
                if (node.Next == null && node.Previous == null)
                {
                    First = null;Last = null;
                }
                return true;
            }
            return false;
        }
        //ICollection ends



        //IEnumerable starts
        public IEnumerator<Node<T>> GetEnumerator()
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



        //Geeks For Geeks > 100 comments problems starts here

        public Node<T> GetNthNode(int n, Node<T> first) // Node<T> GetNthNode(Node<T> first, int n)
        {
            if (n == 0) //added after unit test writing. otherwise first returned.
            {
                return null;
            }

            for (int i = 0; i < n-1 && first != null; i++)
            {
                first = first.Next;
            }

            return first;
        }

        public void DeleteNodeThroughPointerSinglyLL(ref Node<T> node)
        {
            if (node != null)
            {
                if (node.Next != null)
                {
                    node.Value = node.Next.Value;
                    node.Next = node.Next.Next; //added after unit test
                }
                else
                {
                    node = null;
                }
            }
        }

        public Node<T> GetMiddleNode(Node<T> first) //Node<T> GetMiddleNode(Node<T> first)
        {
            int count = GetCount(first);

            for (int i = 0; i < (count-1)/2; i++)
            {
                first = first.Next;
            }
            return first;
        }

        public int GetCount(Node<T> first)
        {
            int count = 0;
            while (first!=null)
            {
                count++;
                first = first.Next;
            }
            return count;
        }

        public Node<T> GetNthNodeFromLast(int n, Node<T> first) //Node<T> GetNthNodeFromLast(Node<T> first, int n)
        {
            int count = GetCount(first);
            return GetNthNode(count - n + 1, first);
        }

        public void DeleteLinkedList(ref Node<T> first)
        {
            Node<T> current = first;
            Node<T> save;
            while (current!=null && current.Next!=null)
            {
                save = current.Next;
                current.Next = null;
                current = save;
            }
            first = null;
        }

        public void Reverse(ref Node<T> node)//added ref after unit tests
        {
            Node<T> nodePtr = node;//added after unit test
            Node<T> reversedFirst = null;
            Node<T> save;
            while (nodePtr != null)
            {
                save = nodePtr.Next;
                nodePtr.Next = reversedFirst;
                reversedFirst = nodePtr;
                nodePtr = save;
            }
            node = reversedFirst;//added after unit test
        }

        public Node<T> IsLoopPresent(Node<T> node)
        {
            HashSet<Node<T>> hashSet = new HashSet<Node<T>>();
            while (node != null)
            {
                if (hashSet.Contains(node))
                {
                    return node;
                }
                else
                {
                    hashSet.Add(node);
                }
                node = node.Next;
            }
            return null;
        }

        public bool IsSinglyLLPalindrome(Node<T> first)
        {
            Node<T> middle = GetMiddleNode(first);
            if (middle != null)
            {
                middle = middle.Next;
            }

            while (first!=null && middle!=null)
            {
                if (first.Value.Equals(middle.Value))
                {
                    return false;
                }
            }
            return true;
        }

        public static NodeRandom<T> Clone(NodeRandom<T> node)
        {
            NodeRandom<T> firstNode = node;
            NodeRandom<T> newNode = null;
            NodeRandom<T> lastNodeCopy = null;
            NodeRandom<T> firstNodeCopy = null;
            NodeRandom<T> save = null;

            while (node != null)
            {
                newNode = new NodeRandom<T>(node.Value);

                if (lastNodeCopy!=null)
                {
                    lastNodeCopy.Next = newNode;
                }
                else
                {
                    firstNodeCopy = newNode;
                }
                lastNodeCopy = newNode;

                save = node.Next;
                node.Next = newNode;
                lastNodeCopy.Random = node;
                node = save;
            }

            NodeRandom<T> iteratorOriginal = firstNode;
            NodeRandom<T> iteratorCopy = firstNodeCopy;

            while (iteratorCopy != null)
            {
                if (iteratorCopy.Random.Random != null)
                {
                    iteratorCopy.Random = iteratorCopy.Random.Random.Next;
                }
                else
                {
                    iteratorCopy.Random = null;
                }

                if (iteratorOriginal.Next.Next != null)
                {
                    iteratorOriginal.Next = iteratorOriginal.Next.Next.Random;
                }
                else
                {
                    iteratorOriginal.Next = null;
                }

                iteratorOriginal = iteratorOriginal.Next;
                iteratorCopy = iteratorCopy.Next;
            }
            return firstNodeCopy;
        }

        /// <summary>
        /// Todo: Check how hashset comparison works here
        /// Better solution by not using this hashset
        /// </summary>
        /// <param name="node1"></param>
        /// <param name="node2"></param>
        /// <returns></returns>
        public static Node<T> GetIntersetion(Node<T> node1, Node<T> node2)
        {
            HashSet<Node<T>> hashset = new HashSet<Node<T>>();

            while (node1 != null)
            {
                hashset.Add(node1);
                node1 = node1.Next;
            }
            
            while (node2 != null)
            {
                if (hashset.Contains(node2))
                {
                    return node2;
                }
                else
                {
                    hashset.Add(node2);
                }
                node2 = node2.Next;
            }
            return null;
        }

        public void RemoveDuplicatesSortedList(Node<T> node)
        {
            while (node != null && node.Next != null)
            {
                if (node.Value.Equals(node.Next.Value))
                {
                    node.Next = node.Next.Next;
                }
                else
                {
                    node = node.Next;
                }
            }
        }

        public void RemoveDuplicates(Node<T> node) //Todo check when T is non-int to check how comparison done for complex type
        {
            if (node==null)
            {
                return;
            }
            HashSet<T> hashSet = new HashSet<T>();
            hashSet.Add(node.Value);
            while (node.Next != null)
            {
                if (!hashSet.Contains(node.Next.Value))
                {
                    hashSet.Add(node.Next.Value);
                    node = node.Next;
                }
                else
                {
                    node.Next = node.Next.Next;
                }
            }
        }

        public void PairwiseSwap(Node<T> node)
        {
            throw new NotImplementedException();
        }

        public Node<T> GetIntersectionSortedList(Node<T> node1, Node<T> node2)
        {
            HashSet<Node<T>> hashSet = new HashSet<Node<T>>();
            while (node1 != null)
            {
                hashSet.Add(node1);
                node1 = node1.Next;
            }

            while (node2!=null)
            {
                if (hashSet.Contains(node2))
                {
                    return node2;
                }
                node2 = node2.Next;
            }
            return null;
        }

        //changed to ref input while writing unit test
        //check why we need ref and out
        public void AlternateSplit(Node<T> node, out Node<T> first, out Node<T> second)
        {
            throw new NotImplementedException();
        }

        //-------------------------------------To do 15/08/2016
        //-------------------------------------Read stanford notes.
        public static Node<T> MergeSortedLL(Node<T> first, Node<T> second)
        {
            Node<T> result = null, tail = null;

            if (first == null)
            {
                return second;
            }
            if (second == null)
            {
                return first;
            }
            while (first != null && second != null)
            {
                if (first.Value.CompareTo(second.Value) < 0) //CompareTo accessible due to where T: IComparable
                {
                    if (result == null)
                    {
                        result = first;
                        tail = first;
                    }
                    else
                    {
                        tail.Next = first;
                        tail = first;
                    }
                    first = first.Next;
                }
                else
                {
                    if (result == null)
                    {
                        result = second;
                        tail = second;
                    }
                    else
                    {
                        tail.Next = second;
                        tail = second;
                    }
                    second = second.Next;
                }
            }

            if (first != null)
            {
                tail.Next = first;
                tail = first;
            }
            else if (second != null)
            {
                tail.Next = second;
                tail = second;
            }
            return result;
        }

        public void MergeSort(ref Node<T> node)
        {
            if (node == null || node.Next == null)
            {
                return;
            }
            Node<T> firstHalf = null, secondHalf = null;
            FrontBackSplit(node, ref firstHalf, ref secondHalf);
            MergeSort(ref firstHalf);
            MergeSort(ref secondHalf);
            node = MergeSortedLL(firstHalf, secondHalf);
        }

        public void FrontBackSplit(Node<T> node, ref Node<T> firstHalf, ref Node<T> secondHalf)
        {
            if (node == null || node.Next == null)
            {
                firstHalf = node;
                secondHalf = null;
                return;
            }
            Node<T> oneMovePtr = node;
            Node<T> twoMovePtr = node.Next;
            while (twoMovePtr != null && twoMovePtr.Next != null)
            {
                twoMovePtr = twoMovePtr.Next.Next;
                oneMovePtr = oneMovePtr.Next;
            }
            secondHalf = oneMovePtr.Next;
            oneMovePtr.Next = null;
            firstHalf = node;
            
        }

        public void ReverseLLInGroups(ref Node<T> node, int k)
        {
            if (node == null)
            {
                return;
            }
            Node<T> ptr = node, result = null, resultFinal = null, save = null;
            int ctr = 0;

            while (ptr != null)
            {
                while (ptr != null && ctr < k)
                {
                    save = ptr.Next;
                    if (result == null)
                    {
                        result = ptr;
                        result.Next = null;
                    }
                    else
                    {
                        ptr.Next = result;
                        result = ptr;
                    }
                    ptr = save;
                    ctr++;
                }
            }

        }

        public void DeleteNodesWithGreaterValueOnRight(Node<T> node)
        {
            throw new NotImplementedException();
        }

        public void EvenNumberFirstLL(Node<T> node)
        {
            throw new NotImplementedException();
        }

        public void DetectAndRemoveLoop(Node<T> node)
        {
            throw new NotImplementedException();
        }

        public Node<T> Add(Node<T> first, Node<T> second)
        {
            throw new NotImplementedException();
        }

        public void Sort012LL(Node<T> node)
        {
            throw new NotImplementedException();
        }

        public void FlattenMultiLevelList(NodeWithChild<T> node)
        {
            throw new NotImplementedException();
        }

        public void PairwiseSwapByChangingLinks(Node<T> node) //useful when too many data fields to copy
        {
            throw new NotImplementedException();
        }

        public void ReverseAlternateAppendEnd(Node<T> node)
        {
            throw new NotImplementedException();
        }




        //2 left as related to trees ll combination
        //Geeks For Geeks > 100 comments problems ends here


    }
}
