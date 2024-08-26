namespace StringsAndArrays
{

    public partial class StringsAndArrays
    {
        public static bool PalindromePermutation(string s)
        {

            var dict = new Dictionary<char, int>();
            var s1 = s.Replace(" ", "").ToLower();

            for (int i = 0; i < s1.Length; i++)
            {
                if (dict.ContainsKey(s1[i]))
                {
                    dict[s1[i]] += 1;
                }
                else
                {
                    dict.Add(s1[i], 1);
                }
            }

            var countOdd = 0;

            foreach (int val in dict.Values)
            {
                if (val % 2 != 0)
                {
                    ++countOdd;
                    if (countOdd > 1 && (s1.Length % 2 != 0) || s1.Length % 2 == 0) return false;
                }
            }

            return true;

        }

    }

}