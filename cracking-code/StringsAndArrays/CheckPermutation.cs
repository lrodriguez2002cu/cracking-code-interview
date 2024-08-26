
using System.Runtime.InteropServices;

namespace StringsAndArrays
{
    /*
      Exercise 1.1 (Cracking the coding interview)
    */
    public partial class StringsAndArrays
    {
        public static bool CheckPermutation(string s1, string s2, bool ignoreSpaces)
        {
            var dict = new Dictionary<char, int>();
            if (ignoreSpaces)
            {
                s1 = s1.Replace(" ", "");
                s2 = s2.Replace(" ", "");
            }

            for (int i = 0; i < s1.Length; i++)
            {
                char ch = s1[i];
                if (dict.ContainsKey(ch))
                {
                    dict[ch] += 1;
                }
                else
                {
                    dict.Add(ch, 1);
                }
            }

            for (int i = 0; i < s2.Length; i++)
            {
                char ch = s2[i];
                if (dict.ContainsKey(ch))
                {
                    dict[ch] -= 1;
                    if (dict[ch] < 0) return false;
                }
                else
                {
                    return false;
                }
            }

            // Check the entries are zero 

            foreach (var item in dict.Values)
            {
                if (item != 0) return false;
            }

            return true;
        }

    }

}

