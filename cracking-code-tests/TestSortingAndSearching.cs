
namespace cracking_code_tests;

using ThreadsAndLocks;


[TestClass]
public class SortingAndSearchingTests
{

    [TestMethod]    
    public void TestSortedMerge()
    {

        var A = new int[] { 1, 3, 5, 7, 9, 0, 0, 0, 0, 0 };
        var B = new int[] { 2, 4, 6, 8, 10 };
        SortingAndSearching.SortingAndSearching.SortedMerge(A, 4, B);

        CollectionAssert.AreEqual(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, A);
    }

    [TestMethod]
    public void TestSortedMerge1()
    {

        var A = new int[] { 1, 3, 0, 0, 0, 0, 0 };
        var B = new int[] { 2 };

        SortingAndSearching.SortingAndSearching.SortedMerge(A, 1, B);

        CollectionAssert.AreEqual(new int[] { 1, 2, 3, 0, 0, 0, 0}, A);
    }

    [TestMethod]
    public void TestSortedMerge2()
    {

        var A = new int[] { 1, 3, 0, 0, 0, 0, 0 };
        var B = new int[] { 2, 3, 5 };

        SortingAndSearching.SortingAndSearching.SortedMerge(A, 1, B);

        CollectionAssert.AreEqual(new int[] { 1, 2, 3, 3, 5, 0, 0 }, A);
    }

}