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
    }

}


