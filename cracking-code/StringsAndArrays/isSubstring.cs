

namespace StringsAndArrays
{

    public partial class StringsAndArrays
    {
        public static bool IsSubstring(string rs1, string s2)
        {
            if (rs1.Length != s2.Length)
            {
                return false;
            }

            var s1s1 = rs1 + rs1;
            return s1s1.Contains(s2);
        }

        public static bool IsSubstringV1(string rs1, string s2)
        {
            if (rs1.Length != s2.Length)
            {
                return false;
            }

            for (int i = 0; i < rs1.Length; i++)
            {
                if (rs1[i] == s2[0])
                {
                    int j = 0;
                    while (j < s2.Length && rs1[(i + j) % rs1.Length] == s2[j])
                    {
                        j++;
                    }
                    if (j == s2.Length)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}

