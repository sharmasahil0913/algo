using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LinkedList;

namespace UnitTestProject
{
    [TestClass]
    public class LinkedListTest
    {
        [TestMethod]
        public void TestMethod1()
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
    }
}
