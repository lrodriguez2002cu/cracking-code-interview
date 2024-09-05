namespace StringsAndArrays
{
    public partial class StringsAndArrays
    {
        public static void ZeroMatrix(int[][] matrix)
        {
            HashSet<int> cols = [];
            HashSet<int> rows = [];

            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[0].Length; j++)
                {
                    if (matrix[i][j] == 0)
                    {
                        rows.Add(i);
                        cols.Add(j);
                    }
                }
            }

            foreach (int j in cols)
            {
                for (int i = 0; i < matrix.Length; i++)
                {
                    matrix[i][j] = 0;
                }
            }

            foreach (int i in rows)
            {
                for (int j = 0; j < matrix[0].Length; j++)
                {
                    matrix[i][j] = 0;
                }
            }

        }

        public static bool CompareMatrix(int[][] m1, int[][] m2)
        {

            if ((m1.Length != m2.Length) || (m1[0].Length != m2[0].Length))
            {
                return false;
            }

            for (int i = 0; i < m1.Length; i++)
            {
                for (int j = 0; j < m1.Length; j++)
                {
                    if (m1[i][j] != m2[i][j]) return false;
                }
            }

            return true;
        }
    }

}
