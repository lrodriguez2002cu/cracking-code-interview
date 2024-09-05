using LinkedLists;

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

            var knode= LinkedLists.LinkedLists.KtoLast(linkedList, 3);

            var after = LinkedLists.LinkedLists.ToList(knode);

            CollectionAssert.AreEqual(new List<int>() {  4, 3, 4 }, after);


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
    }

}


