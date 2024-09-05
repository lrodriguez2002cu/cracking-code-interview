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


    }

}


