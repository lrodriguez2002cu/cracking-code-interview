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
        [DataRow("Atco Cta", true)]
        public void TestPalindromePermutation(string s1, bool expected)
        {
            Assert.AreEqual(expected, StringsAndArrays.StringsAndArrays.PalindromePermutation(s1));
        }

        [TestMethod]
        [DataRow("pale", "ple", true)]
        [DataRow("pales", "pale", true)]
        [DataRow("pale", "bale", true)]
        [DataRow("pale", "bake", false)]
        public void TestOneWay(string s1, string ed, bool expected)
        {
            Assert.AreEqual(expected, StringsAndArrays.StringsAndArrays.OneWay(s1, ed));
        }


        [TestMethod]
        [DataRow("aabccccdeeeee", "a2bc4de5")]
        [DataRow("abcdee", "abcdee")]

        public void TestStringCompression(string s1, string expected)
        {
            Assert.AreEqual(expected, StringsAndArrays.StringsAndArrays.StringCompression(s1));
        }

        [TestMethod]

        public void TestRotateMatrix()
        {

            int[][] matrix = new int[][] {
                new int[] { 1, 2, 3 },
                new int[] { 4, 5, 6 },
                new int[] { 7, 8, 9 } };

            Console.WriteLine("Original:");
            StringsAndArrays.StringsAndArrays.PrintMatrix(matrix);

            StringsAndArrays.StringsAndArrays.RotateMatrix(matrix);
            Console.WriteLine("Result rotated by 90 degrees:");
            StringsAndArrays.StringsAndArrays.PrintMatrix(matrix);


            int[][] expected = new int[][] {
                new int[] { 1, 2, 3 },
                new int[] { 4, 5, 6 },
                new int[] { 7, 8, 9 } };




        }


        [TestMethod]
        public void TestZeroMatrix()
        {

            int[][] matrix = new int[][] {
                new int[] { 1, 2, 3 },
                new int[] { 4, 0, 6 },
                new int[] { 7, 8, 9 } };

            Console.WriteLine("Original:");
            StringsAndArrays.StringsAndArrays.PrintMatrix(matrix);

            StringsAndArrays.StringsAndArrays.ZeroMatrix(matrix);

            Console.WriteLine("Result zeroed in rows and cols with 0:");
            StringsAndArrays.StringsAndArrays.PrintMatrix(matrix);


            int[][] expected = new int[][] {
                new int[] { 1, 0, 3 },
                new int[] { 0, 0, 0 },
                new int[] { 7, 0, 9 } };

            Assert.IsTrue(StringsAndArrays.StringsAndArrays.CompareMatrix(expected, matrix));



            int[][] matrix1 = new int[][] {
                new int[] { 1, 2, 3 , 4},
                new int[] { 5, 6, 7, 8 },
                new int[] { 9, 10, 11, 12},
                new int[] { 13, 14, 15, 16}

            };

            Console.WriteLine("Original:");
            StringsAndArrays.StringsAndArrays.PrintMatrix(matrix1);

            StringsAndArrays.StringsAndArrays.ZeroMatrix(matrix1);

            Console.WriteLine("Result zeroed in rows and cols with 0:");
            StringsAndArrays.StringsAndArrays.PrintMatrix(matrix1);


            int[][] expected1 = new int[][] {
                new int[] { 1, 2, 3 , 4},
                new int[] { 5, 6, 7, 8 },
                new int[] { 9, 10, 11, 12},
                new int[] { 13, 14, 15, 16}

            };

            Assert.IsTrue(StringsAndArrays.StringsAndArrays.CompareMatrix(expected1, matrix1));


            int[][] matrix2 = new int[][] {
                new int[] { 1, 2, 3 , 4},
                new int[] { 0, 6, 7, 8 },
                new int[] { 9, 10, 11, 12},
                new int[] { 13, 0, 15, 16}

            };

            Console.WriteLine("Original:");
            StringsAndArrays.StringsAndArrays.PrintMatrix(matrix2);

            StringsAndArrays.StringsAndArrays.ZeroMatrix(matrix2);

            Console.WriteLine("Result zeroed in rows and cols with 0:");
            StringsAndArrays.StringsAndArrays.PrintMatrix(matrix2);

            int[][] expected2 = new int[][] {
                new int[] { 0, 0, 3 , 4},
                new int[] { 0, 0, 0, 0},
                new int[] { 0, 0, 11, 12},
                new int[] { 0, 0, 0, 0}

            };


            Assert.IsTrue(StringsAndArrays.StringsAndArrays.CompareMatrix(expected2, matrix2));

        }


        [TestMethod]
        public void TestZeroMatrix1()
        {


            int[][] matrix2 = new int[][] {
                new int[] { 1, 2, 3 , 4},
                new int[] { 0, 6, 7, 8 },
                new int[] { 9, 10, 11, 12},
                new int[] { 13, 0, 15, 16}

            };

            Console.WriteLine("Original:");
            StringsAndArrays.StringsAndArrays.PrintMatrix(matrix2);

            StringsAndArrays.StringsAndArrays.ZeroMatrix(matrix2);

            Console.WriteLine("Result zeroed in rows and cols with 0:");
            StringsAndArrays.StringsAndArrays.PrintMatrix(matrix2);


            int[][] expected2 = new int[][] {
                new int[] { 0, 0, 3 , 4},
                new int[] { 0, 0, 0, 0},
                new int[] { 0, 0, 11, 12},
                new int[] { 0, 0, 0, 0}

            };

            Assert.IsTrue(StringsAndArrays.StringsAndArrays.CompareMatrix(expected2, matrix2));
        }

    }

}


