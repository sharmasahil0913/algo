using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LinkedList;
using System.Collections.Generic;

namespace UnitTestProject
{
    [TestClass]
    public class LinkedListTest
    {
        [TestMethod,TestCategory("Add")]
        public void AddFirstTest1()
        {
            DoublyLinkedList<int> dll = new DoublyLinkedList<int>();
            dll.AddFirst(5);
            dll.AddFirst(4);
            dll.AddFirst(3);
            dll.AddFirst(2);
            dll.AddFirst(1);

            Node<int> first = dll.First;
            Node<int> second = dll.First.Next;
            Node<int> third = dll.Last.Previous.Previous;
            Node<int> fourth = dll.Last.Previous;
            Node<int> fifth = dll.Last;


            Assert.AreEqual(first.Value, 1);
            Assert.AreEqual(first.Previous, null);
            Assert.AreEqual(first.Next, second);

            Assert.AreEqual(second.Value, 2);
            Assert.AreEqual(second.Previous, first);
            Assert.AreEqual(second.Next, third);

            Assert.AreEqual(third.Value, 3);
            Assert.AreEqual(third.Previous, second);
            Assert.AreEqual(third.Next, fourth);

            Assert.AreEqual(fourth.Value, 4);
            Assert.AreEqual(fourth.Previous, third);
            Assert.AreEqual(fourth.Next, fifth);

            Assert.AreEqual(fifth.Value, 5);
            Assert.AreEqual(fifth.Previous, fourth);
            Assert.AreEqual(fifth.Next, null);

            Assert.AreEqual(dll.Last.Value, 5);
            Assert.AreEqual(dll.First.Previous, null);
            Assert.AreEqual(dll.Last.Next, null);
            Assert.AreEqual(dll.First.Next.Value, 2);
        }

        [TestMethod,TestCategory("Add")]
        public void AddFirstTest2()
        {
            DoublyLinkedList<int> dll = new DoublyLinkedList<int>();
            dll.AddFirst(1);

            Node<int> first = dll.First;
            Node<int> fifth = dll.Last;


            Assert.AreEqual(first.Value, 1);
            Assert.AreEqual(first.Previous, null);
            Assert.AreEqual(first.Next, null);

            Assert.AreEqual(dll.Last.Value, 1);
            Assert.AreEqual(dll.First.Previous, null);
            Assert.AreEqual(dll.Last.Next, null);
        }

        [TestMethod, TestCategory("Add")]
        public void AddFirstTest3()
        {
            DoublyLinkedList<int> dll = new DoublyLinkedList<int>();
            dll.AddFirst(2);
            dll.AddFirst(1);

            Node<int> first = dll.First;
            Node<int> second = dll.First.Next;
            


            Assert.AreEqual(first.Value, 1);
            Assert.AreEqual(first.Previous, null);
            Assert.AreEqual(first.Next, second);

            Assert.AreEqual(second.Value, 2);
            Assert.AreEqual(second.Previous, first);
            Assert.AreEqual(second.Next, null);

            Assert.AreEqual(dll.Last.Value, 2);
            Assert.AreEqual(dll.First.Previous, null);
            Assert.AreEqual(dll.Last.Next, null);
            Assert.AreEqual(dll.First.Next.Value, 2);
        }



        [TestMethod, TestCategory("Add")]
        public void AddLastTest4()
        {
            DoublyLinkedList<int> dll = new DoublyLinkedList<int>();
            dll.AddLast(1);
            dll.AddLast(2);
            dll.AddLast(3);
            dll.AddLast(4);
            dll.AddLast(5);

            Node<int> first = dll.First;
            Node<int> second = dll.First.Next;
            Node<int> third = dll.Last.Previous.Previous;
            Node<int> fourth = dll.Last.Previous;
            Node<int> fifth = dll.Last;


            Assert.AreEqual(first.Value, 1);
            Assert.AreEqual(first.Previous, null);
            Assert.AreEqual(first.Next, second);

            Assert.AreEqual(second.Value, 2);
            Assert.AreEqual(second.Previous, first);
            Assert.AreEqual(second.Next, third);

            Assert.AreEqual(third.Value, 3);
            Assert.AreEqual(third.Previous, second);
            Assert.AreEqual(third.Next, fourth);

            Assert.AreEqual(fourth.Value, 4);
            Assert.AreEqual(fourth.Previous, third);
            Assert.AreEqual(fourth.Next, fifth);

            Assert.AreEqual(fifth.Value, 5);
            Assert.AreEqual(fifth.Previous, fourth);
            Assert.AreEqual(fifth.Next, null);

            Assert.AreEqual(dll.Last.Value, 5);
            Assert.AreEqual(dll.First.Previous, null);
            Assert.AreEqual(dll.Last.Next, null);
            Assert.AreEqual(dll.First.Next.Value, 2);
        }

        [TestMethod,TestCategory("Remove")]
        public void RemoveFirstTest1()
        {
            DoublyLinkedList<int> dll = new DoublyLinkedList<int>();
            dll.RemoveFirst();

            Assert.AreEqual(dll.First, null);
            Assert.AreEqual(dll.Last, null);

            dll.AddLast(1);
            Assert.AreEqual(dll.First.Value, 1);
            Assert.AreEqual(dll.Last.Value, 1);

            dll.AddLast(2);
            Assert.AreEqual(dll.Last.Value, 2);

            dll.RemoveFirst();
            Assert.AreEqual(dll.First.Value,2);
            Assert.AreEqual(dll.Last.Value, 2);

        }

        //[test]
        [TestMethod,TestCategory("Remove")]
        public void RemoveLastTest1()
        {
            DoublyLinkedList<int> dll = Get0ElemDoublyLinkedList();
            dll.RemoveLast();
            Assert.AreEqual(dll.First, null);
            Assert.AreEqual(dll.Last, null);

            dll = Get1ElemDoublyLinkedList();
            dll.RemoveLast();
            Assert.AreEqual(dll.First, null);

            dll = Get2ElemDoublyLinkedList();
            dll.RemoveLast();
            Assert.AreEqual(dll.First.Value, 1);
            Assert.AreEqual(dll.Last.Value, 1);

            dll = Get3ElemDoublyLinkedList();
            dll.RemoveLast();
            Assert.AreEqual(dll.First.Value, 1);
            Assert.AreEqual(dll.Last.Value, 3);
        }

        [TestMethod, TestCategory("Remove")]
        public void RemoveTest1()
        {
            DoublyLinkedList<int> dll = Get0ElemDoublyLinkedList();
            dll.Remove(1);
            Assert.AreEqual(dll.First, null);
            Assert.AreEqual(dll.Last, null);

            dll = Get1ElemDoublyLinkedList();
            bool isFoundAndRemoved = dll.Remove(1);
            Assert.AreEqual(dll.First, null);
            Assert.AreEqual(isFoundAndRemoved, true);

            dll = Get1ElemDoublyLinkedList();
            isFoundAndRemoved = dll.Remove(2);
            Assert.AreEqual(dll.First.Value, 1);
            Assert.AreEqual(dll.Last.Value, 1);
            Assert.AreEqual(isFoundAndRemoved, false);

            dll = Get4ElemDoublyLinkedList();
            isFoundAndRemoved = dll.Remove(7);
            Assert.AreEqual(dll.First.Value, 1);
            Assert.AreEqual(dll.Last.Value, 5);
            Assert.AreEqual(dll.First.Next.Value, 3);
        }

        [TestMethod, TestCategory("GetNode")]
        public void GetNthNodeTest1()
        {
            DoublyLinkedList<int> dll = Get0ElemDoublyLinkedList();
            Node<int> node = dll.GetNthNode(0, dll.First);
            Assert.AreEqual(node, null);
            dll.GetNthNode(1, dll.First);
            Assert.AreEqual(node, null);

            dll = Get1ElemDoublyLinkedList();
            node = dll.GetNthNode(1,dll.First);
            Assert.AreEqual(node.Value, 1);

            dll = Get4ElemDoublyLinkedList();
            node = dll.GetNthNode(4, dll.First);
            Assert.AreEqual(node.Value, 7);

            dll = Get3ElemDoublyLinkedList();
            node = dll.GetNthNode(2, dll.First);
            Assert.AreEqual(node.Value, 3);

            node = dll.GetNthNode(3, dll.First);
            Assert.AreEqual(node.Value, 5);

            node = dll.GetNthNode(4, dll.First);
            Assert.AreEqual(node, null);
        }

        [TestMethod, TestCategory("Delete")]
        public void DeleteNodeThroughPointerSinglyLL()
        {
            DoublyLinkedList<int> dll = Get0ElemDoublyLinkedList();
            Node<int> node = dll.First;
            dll.DeleteNodeThroughPointerSinglyLL(ref node);
            Assert.AreEqual(node, null);

            dll = Get1ElemDoublyLinkedList();
            node = dll.First;
            dll.DeleteNodeThroughPointerSinglyLL(ref node);
            Assert.AreEqual(node, null);

            dll = Get2ElemDoublyLinkedList();
            node = dll.First;
            dll.DeleteNodeThroughPointerSinglyLL(ref node);
            Assert.AreEqual(node.Value, 3);

            dll = Get4ElemDoublyLinkedList();
            node = dll.Last.Previous;
            dll.DeleteNodeThroughPointerSinglyLL(ref node);
            Assert.AreEqual(dll.First.Value, 1);
            Assert.AreEqual(dll.First.Next.Value, 3);
            Assert.AreEqual(node.Value, 7);
            Assert.AreEqual(node.Next, null);
        }

        [TestMethod, TestCategory("GetNode")]
        public void GetMiddleNodeTest1()
        {
            DoublyLinkedList<int> dll = Get0ElemDoublyLinkedList();
            Node<int> node = dll.GetMiddleNode(dll.First);
            Assert.AreEqual(node, null);

            dll = Get1ElemDoublyLinkedList();
            node = dll.GetMiddleNode(dll.First);
            Assert.AreEqual(node.Value, 1);

            dll = Get2ElemDoublyLinkedList();
            node = dll.GetMiddleNode(dll.First);
            Assert.AreEqual(node.Value, 1);

            dll = Get3ElemDoublyLinkedList();
            node = dll.GetMiddleNode(dll.First);
            Assert.AreEqual(node.Value, 3);

            dll = Get4ElemDoublyLinkedList();
            node = dll.GetMiddleNode(dll.First);
            Assert.AreEqual(node.Value, 3);
        }

        [TestMethod, TestCategory("GetNode")]
        public void GetNthNodeFromLastTest1()
        {
            DoublyLinkedList<int> dll = Get0ElemDoublyLinkedList();
            Node<int> node = dll.GetNthNodeFromLast(0,dll.First);
            Assert.AreEqual(node, null);

            dll = Get0ElemDoublyLinkedList();
            node = dll.GetNthNodeFromLast(1, dll.First);
            Assert.AreEqual(node, null);

            dll = Get1ElemDoublyLinkedList();
            node = dll.GetNthNodeFromLast(0, dll.First);
            Assert.AreEqual(node, null);

            dll = Get1ElemDoublyLinkedList();
            node = dll.GetNthNodeFromLast(2, dll.First);
            Assert.AreEqual(node, null);

            dll = Get1ElemDoublyLinkedList();
            node = dll.GetNthNodeFromLast(1, dll.First);
            Assert.AreEqual(node.Value, 1);

            dll = Get2ElemDoublyLinkedList();
            node = dll.GetNthNodeFromLast(2, dll.First);
            Assert.AreEqual(node.Value, 1);

            dll = Get3ElemDoublyLinkedList();
            node = dll.GetNthNodeFromLast(2, dll.First);
            Assert.AreEqual(node.Value, 3);

            dll = Get4ElemDoublyLinkedList();
            node = dll.GetNthNodeFromLast(3, dll.First);
            Assert.AreEqual(node.Value, 3);
        }

        [TestMethod, TestCategory("Delete")]
        public void DeleteLinkedListTest1()
        {
            DoublyLinkedList<int> dll = Get0ElemDoublyLinkedList();
            Node<int> node = dll.First;
            dll.DeleteLinkedList(ref node);
            Assert.AreEqual(node, null);

            dll = Get1ElemDoublyLinkedList();
            node = dll.First;
            dll.DeleteLinkedList(ref node);
            Assert.AreEqual(node, null);

            dll = Get2ElemDoublyLinkedList();
            node = dll.First;
            dll.DeleteLinkedList(ref node);
            Assert.AreEqual(node, null);

            dll = Get3ElemDoublyLinkedList();
            node = dll.First;
            dll.DeleteLinkedList(ref node);
            Assert.AreEqual(node, null);

            dll = Get4ElemDoublyLinkedList();
            node = dll.First;
            dll.DeleteLinkedList(ref node);
            Assert.AreEqual(node, null);
        }

        [TestMethod, TestCategory("Reverse")]
        public void ReverseTest1()
        {
            DoublyLinkedList<int> dll = Get0ElemDoublyLinkedList();
            Node<int> node = dll.First;
            dll.Reverse(ref node); //cannot be passed as ref
            Assert.AreEqual(dll.First, null);

            dll = Get1ElemDoublyLinkedList();
            node = dll.First;
            dll.Reverse(ref node);
            Assert.AreEqual(node.Value, 1);

            dll = Get2ElemDoublyLinkedList();
            node = dll.First;
            dll.Reverse(ref node);
            Assert.AreEqual(node.Value, 3);

            dll = Get3ElemDoublyLinkedList();
            node = dll.First;
            dll.Reverse(ref node);
            Assert.AreEqual(node.Value, 5);

            dll = Get4ElemDoublyLinkedList();
            node = dll.First;
            dll.Reverse(ref node);
            Assert.AreEqual(node.Value, 7);
            Assert.AreEqual(node.Next.Value, 5);
            Assert.AreEqual(node.Next.Next.Value, 3);
            Assert.AreEqual(node.Next.Next.Next.Value, 1);
        }

        [TestMethod, TestCategory("Loop")]
        public void IsLoopPresentTest1()
        {
            DoublyLinkedList<int> dll = Get0ElemDoublyLinkedList();
            Node<int> node = dll.IsLoopPresent(dll.First);
            Assert.AreEqual(node, null);

            dll = Get1ElemDoublyLinkedList();
            node = dll.IsLoopPresent(dll.First);
            Assert.AreEqual(node, null);

            dll.First.Next = dll.First;
            node = dll.IsLoopPresent(dll.First);
            Assert.AreEqual(node, dll.First);
            Assert.AreEqual(node, dll.Last);

            dll = Get4ElemDoublyLinkedList();
            dll.First.Next.Next.Next = dll.First.Next;
            node = dll.IsLoopPresent(dll.First);
            Assert.AreEqual(node.Value, dll.First.Next.Value);
        }

        [TestMethod, TestCategory("Palindrome")]
        public void IsSinglyLLPalindromeTest1()
        {
            DoublyLinkedList<int> dll = Get0ElemDoublyLinkedList();
            bool b = dll.IsSinglyLLPalindrome(dll.First);
            Assert.AreEqual(b, true);

            dll = Get1ElemDoublyLinkedList();
             b = dll.IsSinglyLLPalindrome(dll.First);
            Assert.AreEqual(b, true);

            dll = Get2ElemDoublyLinkedList();
            b = dll.IsSinglyLLPalindrome(dll.First);
            Assert.AreEqual(b, false);

            dll = Get3ElemDoublyLinkedList();
            b = dll.IsSinglyLLPalindrome(dll.First);
            Assert.AreEqual(b, false);

            dll = Get4ElemDoublyLinkedList();
            b = dll.IsSinglyLLPalindrome(dll.First);
            Assert.AreEqual(b, false);

            dll = Get4ElemDoublyLinkedList();
            dll.Last.Value = 1;
            dll.Last.Previous.Value = 3;
            b = dll.IsSinglyLLPalindrome(dll.First);
            Assert.AreEqual(b, true);
        }

        [TestMethod, TestCategory("Clone")]
        public void CloneTest1()
        {
            NodeRandom<int> node1 = new NodeRandom<int>(1);
            NodeRandom<int> node2 = new NodeRandom<int>(2);
            NodeRandom<int> node3 = new NodeRandom<int>(3);
            NodeRandom<int> node4 = new NodeRandom<int>(4);

            node1.Next = node2;
            node1.Random = node3;
            node2.Next = node3;
            node2.Random = node4;
            node3.Next = node4;
            node3.Random = node1;
            node4.Next = null;
            node4.Random = node2;

            NodeRandom<int> nodeResult = DoublyLinkedList<int>.Clone(node1);
            Assert.AreEqual(nodeResult.Value, 1);
            Assert.AreEqual(nodeResult.Next.Value, 2);
            Assert.AreEqual(nodeResult.Random.Value, 3);

            Assert.AreEqual(nodeResult.Next.Value, 2);
            Assert.AreEqual(nodeResult.Next.Next.Value, 3);
            Assert.AreEqual(nodeResult.Next.Random.Value, 4);

            Assert.AreEqual(nodeResult.Next.Next.Value, 3);
            Assert.AreEqual(nodeResult.Next.Next.Next.Value, 4);
            Assert.AreEqual(nodeResult.Next.Next.Random.Value, 1);

            Assert.AreEqual(nodeResult.Next.Next.Next.Value, 4);
            Assert.AreEqual(nodeResult.Next.Next.Next.Next.Value, null);
            Assert.AreEqual(nodeResult.Next.Next.Next.Random.Value, 2);
        }

        [TestMethod, TestCategory("Intersection")]
        public void GetIntersetionTest1()
        {
            DoublyLinkedList<int> dllThree = Get3ElemDoublyLinkedList();
            DoublyLinkedList<int> dllFour = Get4ElemDoublyLinkedList();
            
            dllThree.Last.Next = dllFour.Last.Previous;
            Node<int> node = DoublyLinkedList<int>.GetIntersetion(dllThree.First, dllFour.First);
            Assert.AreEqual(node.Value, 5);

            DoublyLinkedList<int> dllZero = Get0ElemDoublyLinkedList();
            DoublyLinkedList<int> dllOne = Get1ElemDoublyLinkedList();
            node = DoublyLinkedList<int>.GetIntersetion(dllZero.First, dllOne.First);
            Assert.AreEqual(node, null);

            dllOne = Get1ElemDoublyLinkedList();
            DoublyLinkedList<int> dllTwo = Get2ElemDoublyLinkedList();
            node = DoublyLinkedList<int>.GetIntersetion(dllOne.First, dllTwo.First);
            Assert.AreEqual(node, null);

            dllOne = Get1ElemDoublyLinkedList();
            dllTwo = Get2ElemDoublyLinkedList();
            dllTwo.Last.Next = dllOne.Last;
            node = DoublyLinkedList<int>.GetIntersetion(dllOne.First, dllOne.First);
            Assert.AreEqual(node.Value, 1);

        }

        [TestMethod, TestCategory("RemoveDuplicate")]
        public void RemoveDuplicatesSortedListTest1()
        {
            DoublyLinkedList<int> dll = new DoublyLinkedList<int>();
            dll.AddFirst(7);
            dll.AddFirst(7);
            dll.AddFirst(7);
            dll.AddFirst(7);

        
            dll.AddFirst(5);
            dll.AddFirst(5);
            dll.AddFirst(5);

            dll.AddFirst(3);
            dll.AddFirst(3);

            dll.AddFirst(1);

            dll.RemoveDuplicatesSortedList(dll.First);
            Assert.AreEqual(dll.First.Value, 1);
            Assert.AreEqual(dll.First.Next.Value, 3);
            Assert.AreEqual(dll.First.Next.Next.Value, 5);
            Assert.AreEqual(dll.First.Next.Next.Next.Value, 7);

            dll = new DoublyLinkedList<int>();
            dll.RemoveDuplicatesSortedList(dll.First);
            Assert.AreEqual(dll.First, null);

            dll = Get1ElemDoublyLinkedList();
            dll.AddFirst(1);
            dll.AddFirst(1);
            dll.RemoveDuplicatesSortedList(dll.First);
            Assert.AreEqual(dll.First.Value, 1);
            Assert.AreEqual(dll.First.Next, null);
        }

        [TestMethod, TestCategory("RemoveDuplicate")]
        public void RemoveDuplicatesTest1()
        {
            DoublyLinkedList<int> dll = new DoublyLinkedList<int>();
            dll.AddFirst(7);
            dll.AddFirst(5);
            dll.AddFirst(7);
            dll.AddFirst(5);
            dll.AddFirst(6);
            dll.AddFirst(1);
            dll.AddFirst(7);
            dll.AddFirst(2);
            dll.RemoveDuplicates(dll.First);
            Assert.AreEqual(dll.First.Value, 2);
            Assert.AreEqual(dll.First.Next.Value, 7);
            Assert.AreEqual(dll.First.Next.Next.Value, 1);
            Assert.AreEqual(dll.First.Next.Next.Next.Value, 6);
            Assert.AreEqual(dll.First.Next.Next.Next.Next.Value, 5);

            dll = new DoublyLinkedList<int>();
            dll.RemoveDuplicates(dll.First);
            Assert.AreEqual(dll.First, null);

            dll = new DoublyLinkedList<int>();
            dll.AddLast(1);
            dll.AddLast(1);
            dll.RemoveDuplicates(dll.First);
            Assert.AreEqual(dll.First.Value, 1);
            Assert.AreEqual(dll.First.Next, null);


            dll = new DoublyLinkedList<int>();
            dll.AddLast(1);
            dll.AddLast(1);
            dll.AddLast(1);
            dll.AddLast(1);
            dll.AddLast(1);
            dll.AddLast(1);
            dll.AddLast(1);
            dll.AddLast(1);
            dll.RemoveDuplicates(dll.First);
            Assert.AreEqual(dll.First.Value, 1);
            Assert.AreEqual(dll.First.Next, null);

            dll = new DoublyLinkedList<int>();
            dll.AddLast(1);
            dll.AddLast(1);
            dll.AddLast(1);
            dll.AddLast(1);
            dll.AddLast(2);
            dll.AddLast(2);
            dll.AddLast(2);
            dll.AddLast(2);
            dll.RemoveDuplicates(dll.First);
            Assert.AreEqual(dll.First.Value, 1);
            Assert.AreEqual(dll.First.Next.Value, 2);
            Assert.AreEqual(dll.First.Next.Next, null);
        }

        [TestMethod, TestCategory("Swap")]
        public void PairwiseSwapTest1()
        {
            DoublyLinkedList<int> dll = Get0ElemDoublyLinkedList();
            dll.PairwiseSwap(dll.First);
            Assert.AreEqual(dll.First, null);

            dll = Get1ElemDoublyLinkedList();
            dll.PairwiseSwap(dll.First);
            Assert.AreEqual(dll.First.Value, 1);
            Assert.AreEqual(dll.First.Next, null);

            dll = Get2ElemDoublyLinkedList();
            dll.PairwiseSwap(dll.First);
            Assert.AreEqual(dll.First.Value, 2);
            Assert.AreEqual(dll.First.Next.Value, 1);

            dll = Get3ElemDoublyLinkedList();
            dll.PairwiseSwap(dll.First);
            Assert.AreEqual(dll.First.Value, 2);
            Assert.AreEqual(dll.First.Next.Value, 1);
            Assert.AreEqual(dll.First.Next.Next.Value, 3);

            dll = Get4ElemDoublyLinkedList();
            dll.PairwiseSwap(dll.First);
            Assert.AreEqual(dll.First.Value, 2);
            Assert.AreEqual(dll.First.Next.Value, 1);
            Assert.AreEqual(dll.First.Next.Next.Value, 4);
            Assert.AreEqual(dll.First.Next.Next.Next.Value, 3);
        }

        [TestMethod, TestCategory("Split")]
        public void AlternateSplitTest1()
        {
            DoublyLinkedList<int> dll = Get0ElemDoublyLinkedList();
            Node<int> firstNode, secondNode;
            dll.AlternateSplit(dll.First, out firstNode, out secondNode);
            Assert.AreEqual(firstNode, null);
            Assert.AreEqual(secondNode, null);

            firstNode = null;
            secondNode = null;
            dll = Get1ElemDoublyLinkedList();
            dll.AlternateSplit(dll.First, out firstNode, out secondNode);
            Assert.AreEqual(firstNode.Value, 1);
            Assert.AreEqual(firstNode.Next, null);
            Assert.AreEqual(secondNode, null);

            firstNode = null;
            secondNode = null;
            dll = Get2ElemDoublyLinkedList();
            dll.AlternateSplit(dll.First, out firstNode, out secondNode);
            Assert.AreEqual(firstNode.Value, 1);
            Assert.AreEqual(firstNode.Next, null);
            Assert.AreEqual(secondNode.Value, 2);
            Assert.AreEqual(secondNode.Next, null);

            firstNode = null;
            secondNode = null;
            dll = Get4ElemDoublyLinkedList();
            dll.AlternateSplit(dll.First, out firstNode, out secondNode);
            Assert.AreEqual(firstNode.Value, 1);
            Assert.AreEqual(firstNode.Next.Value, 5);
            Assert.AreEqual(firstNode.Next.Next, null);


            Assert.AreEqual(secondNode.Value, 3);
            Assert.AreEqual(secondNode.Next.Value, 7);
            Assert.AreEqual(secondNode.Next.Next, null);
        }

        [TestMethod, TestCategory("Merge")]
        public void MergeSortedLLTest1()
        {
            DoublyLinkedList<int> dll1 = Get0ElemDoublyLinkedList();
            DoublyLinkedList<int> dll2 = Get1ElemDoublyLinkedList();
            Node<int> result;

            result = DoublyLinkedList<int>.MergeSortedLL(dll1.First, dll2.First);
            Assert.AreEqual(result.Value, 1);
            Assert.AreEqual(result.Next, null);

            dll1 = Get1ElemDoublyLinkedList();
            dll2 = Get2ElemDoublyLinkedList();
            result = DoublyLinkedList<int>.MergeSortedLL(dll1.First, dll2.First);
            Assert.AreEqual(result.Value, 1);
            Assert.AreEqual(result.Next.Value, 1);
            Assert.AreEqual(result.Next.Next.Value, 3);
            Assert.AreEqual(result.Next.Next.Next, null);

            dll1 = Get2ElemDoublyLinkedList();
            dll2 = Get3ElemDoublyLinkedList();
            result = DoublyLinkedList<int>.MergeSortedLL(dll1.First, dll2.First);
            Assert.AreEqual(result.Value, 1);
            Assert.AreEqual(result.Next.Value, 1);
            Assert.AreEqual(result.Next.Next.Value, 3);
            Assert.AreEqual(result.Next.Next.Next.Value, 3);
            Assert.AreEqual(result.Next.Next.Next.Next.Value, 5);

            Assert.AreEqual(result.Next.Next.Next.Next.Next, null);
        }

        [TestMethod, TestCategory("Sort")]
        public void MergeSortTest1()
        {
            DoublyLinkedList<int> dll = new DoublyLinkedList<int>();
            Node<int> dllFirstNode = dll.First;
            dll.MergeSort(ref dllFirstNode);
            Assert.AreEqual(dllFirstNode, null);

            dll = new DoublyLinkedList<int>();
            dll.AddLast(1);
            dllFirstNode = dll.First;
            dll.MergeSort(ref dllFirstNode);
            Assert.AreEqual(dllFirstNode.Value, 1);
            Assert.AreEqual(dllFirstNode.Next, null);

            dll = new DoublyLinkedList<int>();
            dll.AddLast(2);
            dll.AddLast(1);
            dllFirstNode = dll.First;
            dll.MergeSort(ref dllFirstNode);
            Assert.AreEqual(dllFirstNode.Value, 1);
            Assert.AreEqual(dllFirstNode.Next.Value, 2);
            Assert.AreEqual(dllFirstNode.Next.Next, null);

            dll = new DoublyLinkedList<int>();
            dll.AddLast(5);
            dll.AddLast(3);
            dll.AddLast(1);
            dllFirstNode = dll.First;
            dll.MergeSort(ref dllFirstNode);
            Assert.AreEqual(dllFirstNode.Value, 1);
            Assert.AreEqual(dllFirstNode.Next.Value, 3);
            Assert.AreEqual(dllFirstNode.Next.Next.Value, 5);
            Assert.AreEqual(dllFirstNode.Next.Next.Next, null);

        }

        [TestMethod, TestCategory("Reverse")]
        public void ReverseLLInGroupsTest1()
        {
            DoublyLinkedList<int> dll = new DoublyLinkedList<int>();
            dll.AddLast(1);
            dll.AddLast(2);
            dll.AddLast(3);
            dll.AddLast(4);
            dll.AddLast(5);
            dll.AddLast(6);
            dll.AddLast(7);
            dll.AddLast(8);
            dll.AddLast(9);

            Node<int> first = dll.First;
            dll.ReverseLLInGroups(ref first, 3);
            Assert.AreEqual(first.Value, 3);
            Assert.AreEqual(first.Next.Value, 2);
            Assert.AreEqual(first.Next.Next.Value, 1);
            Assert.AreEqual(first.Next.Next.Next.Value, 6);
            Assert.AreEqual(first.Next.Next.Next.Next.Value, 5);
            Assert.AreEqual(first.Next.Next.Next.Next.Next.Value, 4);
            Assert.AreEqual(first.Next.Next.Next.Next.Next.Next.Value, 9);
            Assert.AreEqual(first.Next.Next.Next.Next.Next.Next.Next.Value, 8);
            Assert.AreEqual(first.Next.Next.Next.Next.Next.Next.Next.Next.Value, 7);

            dll = new DoublyLinkedList<int>();
            dll.AddLast(1);
            dll.AddLast(2);
            dll.AddLast(3);
            dll.AddLast(4);
            dll.AddLast(5);
            dll.AddLast(6);
            dll.AddLast(7);
            dll.AddLast(8);

            first = dll.First;
            dll.ReverseLLInGroups(ref first, 3);
            Assert.AreEqual(first.Value, 3);
            Assert.AreEqual(first.Next.Value, 2);
            Assert.AreEqual(first.Next.Next.Value, 1);
            Assert.AreEqual(first.Next.Next.Next.Value, 6);
            Assert.AreEqual(first.Next.Next.Next.Next.Value, 5);
            Assert.AreEqual(first.Next.Next.Next.Next.Next.Value, 4);
            Assert.AreEqual(first.Next.Next.Next.Next.Next.Next.Value, 9);
            Assert.AreEqual(first.Next.Next.Next.Next.Next.Next.Next.Value, 8);

            dll = new DoublyLinkedList<int>();
            dll.AddLast(1);
            dll.AddLast(2);
            dll.AddLast(3);

            first = dll.First;
            dll.ReverseLLInGroups(ref first, 3);
            Assert.AreEqual(first.Value, 3);
            Assert.AreEqual(first.Next.Value, 2);
            Assert.AreEqual(first.Next.Next.Value, 1);

            dll = new DoublyLinkedList<int>();
            dll.AddLast(1);
            dll.AddLast(2);

            first = dll.First;
            dll.ReverseLLInGroups(ref first, 3);
            Assert.AreEqual(first.Value, 2);
            Assert.AreEqual(first.Next.Value, 1);

            dll = new DoublyLinkedList<int>();
            dll.AddLast(1);

            first = dll.First;
            dll.ReverseLLInGroups(ref first, 3);
            Assert.AreEqual(first.Value, 1);

            dll = new DoublyLinkedList<int>();

            first = dll.First;
            dll.ReverseLLInGroups(ref first, 3);
            Assert.AreEqual(first, null);

        }


        DoublyLinkedList<int> Get0ElemDoublyLinkedList()
        {
            return new DoublyLinkedList<int>();
        }

        DoublyLinkedList<int> Get1ElemDoublyLinkedList()
        {
            DoublyLinkedList<int> dll = new DoublyLinkedList<int>();
            dll.AddLast(1);
            return dll;
        }

        DoublyLinkedList<int> Get2ElemDoublyLinkedList()
        {
            DoublyLinkedList<int> dll = new DoublyLinkedList<int>();
            dll.AddLast(1);
            dll.AddLast(3);
            return dll;
        }

        DoublyLinkedList<int> Get3ElemDoublyLinkedList()
        {
            DoublyLinkedList<int> dll = new DoublyLinkedList<int>();
            dll.AddLast(1);
            dll.AddLast(3);
            dll.AddLast(5);
            return dll;
        }

        DoublyLinkedList<int> Get4ElemDoublyLinkedList()
        {
            DoublyLinkedList<int> dll = new DoublyLinkedList<int>();
            dll.AddFirst(7);
            dll.AddFirst(5);
            dll.AddFirst(3);
            dll.AddFirst(1);
            return dll;
        }
    }
}
