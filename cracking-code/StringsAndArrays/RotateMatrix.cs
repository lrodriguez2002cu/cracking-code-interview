namespace StringsAndArrays
{

    public partial class StringsAndArrays
    {
        //rotate a matrix by 90 degrees
        public static void RotateMatrix(int[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = i + 1; j < matrix[0].Length; j++)
                {
                    var temp = matrix[i][j];
                    matrix[i][j] = matrix[j][i];
                    matrix[j][i] = temp;
                }
            }

        }

        public static void PrintMatrix(int[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[0].Length; j++)
                {
                    var sep = (j != matrix[0].Length - 1) ? " " : "";
                    Console.Write(matrix[i][j] + sep);
                }
                Console.WriteLine();
            }

        }

        public static bool RotateMatrixV1(int[][] m, int layer)
        {

            // it must be a square m
            if (m.Length != m[0].Length)
            {
                return false;
            }

            int len = m.Length;

            for (int k = 0; k < m.Length; k++)
            {
                var topv = m[layer][k];
                var leftv = m[len - k - 1][layer];
                var bottomv = m[len - layer-1][len - layer - k - 1];
                var rightv = m[len - k - layer - 1][len - layer-1];

                Console.WriteLine(string.Format("k: %d,layer: %d, topv: %d, leftv: %d, bottomv: %d, rightv: %d",
                 k, layer, topv, leftv, bottomv, rightv));
            }

            return true;
        }




    }

}