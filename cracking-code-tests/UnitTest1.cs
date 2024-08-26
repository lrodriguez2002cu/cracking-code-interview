using StringsAndArrays;

namespace cracking_code_tests
{
    [TestClass]
    public class StringsAndArraysTests
    {

        [TestMethod]
        [DataRow("abc", "bca", true)]
        [DataRow("abc", "b ca", true)]
        [DataRow("abc", "eca", false)]

        public void TestIgnoreSpaces(string s1, string s2, bool expected)
        {
            Assert.AreEqual(StringsAndArrays.StringsAndArrays.CheckPermutation(s1, s2, true), expected);
        }


        [TestMethod]
        [DataRow("abc", "b ca", false)]

        public void TestNoIgnoreSpaces(string s1, string s2, bool expected)
        {
            Assert.AreEqual(StringsAndArrays.StringsAndArrays.CheckPermutation(s1, s2, false), expected);
        }



        [TestMethod]
        [DataRow("abc", "cab", true)]
        [DataRow("abc", "acb", false)]
        public void TestIsSubString(string s1, string s2, bool expected)
        {
            Assert.AreEqual(StringsAndArrays.StringsAndArrays.IsSubstring(s1, s2), expected);
        }



        [TestMethod]
        [DataRow("abc", "cab", true)]
        [DataRow("abc", "acb", false)]
        public void TestIsSubStringV1(string rs1, string s2, bool expected)
        {
            Assert.AreEqual(StringsAndArrays.StringsAndArrays.IsSubstringV1(rs1, s2), expected);
        }


        [TestMethod]
        [DataRow("abc", true)]
        [DataRow("abb", false)]
        public void TestIsUnique(string s1, bool expected)
        {
            Assert.AreEqual(StringsAndArrays.StringsAndArrays.IsUnique(s1), expected);
        }


        [TestMethod]
        [DataRow("abc", true)]
        [DataRow("a", true)]
        [DataRow("", true)]
        [DataRow(" ", true)]
        [DataRow("abb", false)]
        public void TestIsUniqueV1(string s1, bool expected)
        {
            Assert.AreEqual(StringsAndArrays.StringsAndArrays.IsUniqueV1(s1), expected);
        }

        [TestMethod]
        [DataRow("ab c   ", 4, "ab%20c")]
        public void TestURLify(string s1, int trueLength, string expected)
        {
            Assert.AreEqual(expected, StringsAndArrays.StringsAndArrays.URLify(s1, trueLength).Trim());
        }

        [TestMethod]
        [DataRow("ab c   ", 4, "ab%20c")]
        public void TestURLifyV1(string s1, int trueLength, string expected)
        {
            Assert.AreEqual(expected, StringsAndArrays.StringsAndArrays.URLifyV1(s1, trueLength).Trim());
        }


        [TestMethod]
        [DataRow("cbc", true)]
        [DataRow("Tact Coa", true)]
        [DataRow("Taco Cat", true)]
        public void TestPalindromePermutation(string s1, bool expected)
        {
            Assert.AreEqual(expected, StringsAndArrays.StringsAndArrays.PalindromePermutation(s1));
        }

    }

}


