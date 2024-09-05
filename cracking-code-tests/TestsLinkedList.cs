using LinkedLists;
using System.Xml.Linq;

namespace cracking_code_tests
{
    [TestClass]
    public class LinkedListsTests
    {

        [TestMethod]
        //[DataRow("abc", "bca", true)]
        //[DataRow("abc", "b ca", true)]
        //[DataRow("abc", "eca", false)]

        public void TestRemoveDups()
        {
            var linkedList = LinkedLists.LinkedLists.ListOf(new int[] { 1, 2, 2, 4, 3, 4 });


            var original = LinkedLists.LinkedLists.ToList(linkedList);

            LinkedLists.LinkedLists.RemoveDups(linkedList);

            var after = LinkedLists.LinkedLists.ToList(linkedList);

            CollectionAssert.AreNotEqual(original, after);
            CollectionAssert.AreEqual(new List<int>() { 1, 2, 4, 3 }, after);

            //Assert.AreEqual(StringsAndArrays.StringsAndArrays.CheckPermutation(s1, s2, true), expected);
        }

        [TestMethod]
        public void TestRemoveDupsNoBuffer()
        {
            var linkedList = LinkedLists.LinkedLists.ListOf(new int[] { 1, 2, 2, 4, 3, 4 });


            var original = LinkedLists.LinkedLists.ToList(linkedList);

            LinkedLists.LinkedLists.RemoveDupsNoBuffer(linkedList);

            var after = LinkedLists.LinkedLists.ToList(linkedList);

            CollectionAssert.AreNotEqual(original, after);
            CollectionAssert.AreEqual(new List<int>() { 1, 2, 4, 3 }, after);

            //Assert.AreEqual(StringsAndArrays.StringsAndArrays.CheckPermutation(s1, s2, true), expected);
        }

        [TestMethod]
        public void TestKtoLast()
        {
            var linkedList = LinkedLists.LinkedLists.ListOf(new int[] { 1, 2, 2, 4, 3, 4 });

            var knode = LinkedLists.LinkedLists.KtoLast(linkedList, 3);

            var after = LinkedLists.LinkedLists.ToList(knode);

            CollectionAssert.AreEqual(new List<int>() { 4, 3, 4 }, after);


            /// a second
            var knode1 = LinkedLists.LinkedLists.KtoLast(linkedList, 5);

            var after1 = LinkedLists.LinkedLists.ToList(knode1);

            CollectionAssert.AreEqual(new List<int>() { 2, 2, 4, 3, 4 }, after1);



            var knode2 = LinkedLists.LinkedLists.KtoLast(linkedList, 15);

            var after2 = LinkedLists.LinkedLists.ToList(knode2);

            CollectionAssert.AreEqual(new List<int>() { 1, 2, 2, 4, 3, 4 }, after2);



            var knode3 = LinkedLists.LinkedLists.KtoLast(linkedList, 0);

            var after3 = LinkedLists.LinkedLists.ToList(knode3);

            Assert.AreEqual(0, after3.Count);


        }

        [TestMethod]
        public void TestDeleteMiddleNode()
        {
            var linkedList = LinkedLists.LinkedLists.ListOf(new int[] { 1, 2, 4, 5, 6 });

            var knode = LinkedLists.LinkedLists.DeleteMiddleNode(linkedList!);

            var after = LinkedLists.LinkedLists.ToList(knode);

            CollectionAssert.AreEqual(new List<int>() { 1, 2, 5, 6 }, after);
        }

        [TestMethod]
        public void TestDeleteMiddleNode1()
        {
            var linkedList = LinkedLists.LinkedLists.ListOf(new int[] { 1, 2, 4, 5, 6, 7 });

            var knode = LinkedLists.LinkedLists.DeleteMiddleNode(linkedList!);

            var after = LinkedLists.LinkedLists.ToList(knode);

            CollectionAssert.AreEqual(new List<int>() { 1, 2, 4, 6, 7 }, after);
        }

        [TestMethod]
        public void TestPartition()
        {
            var linkedList = LinkedLists.LinkedLists.ListOf(new int[] { 3, 5, 8, 5, 10, 2, 1});

            var partitioned = LinkedLists.LinkedLists.Partition(linkedList!, 5);

            var after = LinkedLists.LinkedLists.ToList(partitioned!);

            CollectionAssert.AreEqual(new List<int>() { 3,2, 1, 5, 8, 5, 10 }, after);
        }

        [TestMethod]
        public void TestPartition1()
        {
            var linkedList = LinkedLists.LinkedLists.ListOf(new int[] { 1, 2, 3,  10, 11, 12 });

            var partitioned = LinkedLists.LinkedLists.Partition(linkedList!, 5);

            var after = LinkedLists.LinkedLists.ToList(partitioned!);

            CollectionAssert.AreEqual(new List<int>() { 1, 2, 3, 10, 11, 12 }, after);
        }

        [TestMethod]
        public void TestPartition2()
        {
            var linkedList = LinkedLists.LinkedLists.ListOf(new int[] { 1 });

            var partitioned = LinkedLists.LinkedLists.Partition(linkedList!, 5);

            var after = LinkedLists.LinkedLists.ToList(partitioned!);

            CollectionAssert.AreEqual(new List<int>() { 1 }, after);
        }


        [TestMethod]
        public void TestPartition3()
        {
            var linkedList = LinkedLists.LinkedLists.ListOf(new int[] {  });

            var partitioned = LinkedLists.LinkedLists.Partition(linkedList!, 5);

            var after = LinkedLists.LinkedLists.ToList(partitioned!);

            CollectionAssert.AreEqual(new List<int>() { }, after);
        }

        [TestMethod]
        public void TestPartition4()
        {
            var linkedList = LinkedLists.LinkedLists.ListOf(new int[] { 5, 6, 7 });

            var partitioned = LinkedLists.LinkedLists.Partition(linkedList!, 5);

            var after = LinkedLists.LinkedLists.ToList(partitioned!);

            CollectionAssert.AreEqual(new List<int>() { 5, 6, 7}, after);
        }

        [TestMethod]
        public void TestSumLists()
        {
            var linkedList = LinkedLists.LinkedLists.ListOf(new int[] { 5, 9, 2 });
            var linkedList1 = LinkedLists.LinkedLists.ListOf(new int[] { 7, 1, 6 });

            var sumList = LinkedLists.LinkedLists.SumLists(linkedList!, linkedList1!);

            var after = LinkedLists.LinkedLists.ToList(sumList!);

            CollectionAssert.AreEqual(new List<int>() { 2, 1, 9}, after);
        }

        [TestMethod]
        public void TestSumListsRecursive()
        {
            var linkedList = LinkedLists.LinkedLists.ListOf(new int[] { 5, 9, 2 });
            var linkedList1 = LinkedLists.LinkedLists.ListOf(new int[] { 7, 1, 6 });

            var sumList = LinkedLists.LinkedLists.SumListsRecursive(linkedList!, linkedList1!);

            var after = LinkedLists.LinkedLists.ToList(sumList!);

            CollectionAssert.AreEqual(new List<int>() { 2, 1, 9 }, after);
        }


        [TestMethod]
        [DataRow(new int[] { 5, 9, 2 }, new int[] { 7, 1, 6 }, new int[] { 2, 1, 9 })]
        public void TestSumListsRecursive(int[] l1, int[] l2, int[] expected)
        {
            var linkedList = LinkedLists.LinkedLists.ListOf(l1);
            var linkedList1 = LinkedLists.LinkedLists.ListOf(l2);

            var sumList = LinkedLists.LinkedLists.SumListsRecursive(linkedList!, linkedList1!);

            var sumArr = LinkedLists.LinkedLists.ToList(sumList!);

            CollectionAssert.AreEqual(new List<int>(expected), sumArr);
        }


        [TestMethod]
        [DataRow(new int[] { 2, 9, 5 }, new int[] { 6, 1, 7 }, new int[] { 9, 1, 2 })]
        [DataRow(new int[] { 9, 5 }, new int[] { 6, 1, 7 }, new int[] { 7, 1, 2 })]
        [DataRow(new int[] { 9, 9, 9 }, new int[] { 1 }, new int[] { 1, 0, 0, 0 })]
        public void TestSumListsNormalOrder(int[] l1, int[] l2, int[] expected)
        {
            var linkedList = LinkedLists.LinkedLists.ListOf(l1);
            var linkedList1 = LinkedLists.LinkedLists.ListOf(l2);

            var sumList = LinkedLists.LinkedLists.SumListsNormalOrder(linkedList!, linkedList1!);

            var sumArr = LinkedLists.LinkedLists.ToList(sumList!);

            CollectionAssert.AreEqual(new List<int>(expected), sumArr);
        }


        [TestMethod]
        [DataRow(new int[] { 2, 9, 2 }, true)]
        [DataRow(new int[] { 2, 9, 9, 2 }, true)]
        [DataRow(new int[] { 2, 9, 3, 2 }, false)]
        [DataRow(new int[] { 2, 9 }, false)]
        [DataRow(new int[] { 2 }, true)]

        public void TestPalindrome(int[] l1, bool expected)
        {
            var linkedList = LinkedLists.LinkedLists.ListOf(l1);
            
            var result = LinkedLists.LinkedLists.Palindrome(linkedList!);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestIntersectsTrue()
        {
            //lets make an intersected list 
            var tail = new int[] { 2, 9, 2 };

            var head1 = new int[] { 3, 4 };
            var head2 = new int[] { 5, 6 };

            var linkedList = LinkedLists.LinkedLists.ListOf(tail);
            var head1List = LinkedLists.LinkedLists.ListOf(head1, out var tail1);
            var head2List = LinkedLists.LinkedLists.ListOf(head2, out var tail2);

            //link the lists so that the join element is the linkedlist node
            tail1!.Next = linkedList;
            tail2!.Next = linkedList;

            var result = LinkedLists.LinkedLists.Intersects(head1List, head2List);

            Assert.AreEqual(linkedList, result);
        }


        [TestMethod]
        public void TestIntersectsFalse()
        {
            //lets make an intersected list 
            var tail = new int[] { 2, 9, 2 };

            var head1 = new int[] { 3, 4 };
            var head2 = new int[] { 5, 6 };

            var linkedList = LinkedLists.LinkedLists.ListOf(tail);
            var head1List = LinkedLists.LinkedLists.ListOf(head1, out var tail1);
            var head2List = LinkedLists.LinkedLists.ListOf(head2, out var tail2);

            //removed the link in the lists so that the join element is the linkedlist node
            //tail1!.Next = linkedList;
            //tail2!.Next = linkedList;

            var result = LinkedLists.LinkedLists.Intersects(head1List, head2List);

            // no node is the intersection so
            Assert.AreEqual(null, result); 
        }


        [TestMethod]
        public void TestLoopDetectionTrue()
        {
            //lets make an intersected list 
            var tail = new int[] { 2, 9, 2 };

            var head1 = new int[] { 3, 4 };
            
            var linkedList = LinkedLists.LinkedLists.ListOf(tail, out var tailnode);
            var head1List = LinkedLists.LinkedLists.ListOf(head1, out var tail1);

            //make the loop
            tailnode.Next = head1List;
            tail1.Next = head1List;

            var result = LinkedLists.LinkedLists.LoopDetection(linkedList);

            Assert.AreEqual(head1List, result);
        }

        [TestMethod]
        public void TestLoopDetectionFalse()
        {
            //lets make an intersected list 
            var tail = new int[] { 2, 9, 2 };

            var head1 = new int[] { 3, 4 };

            var linkedList = LinkedLists.LinkedLists.ListOf(tail, out var tailnode);
            
            var result = LinkedLists.LinkedLists.LoopDetection(linkedList);

            Assert.AreEqual(null, result);
        }
    }

}


