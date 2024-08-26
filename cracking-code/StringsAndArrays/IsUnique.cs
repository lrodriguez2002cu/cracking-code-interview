
namespace StringsAndArrays
{
/*
  Exercise 1.1 (Cracking the coding interview)
*/
public partial class StringsAndArrays
{
    public static bool IsUnique(string s1)
    {
        for (int i = 0; i < s1.Length; i++)
        {
            for (int j = i + 1; j < s1.Length; j++)
            {
                if (s1[i] == s1[j])
                {
                    return false;
                }
            }
        }

        return true;
    }

    public static bool IsUniqueV1(string s1)
    {
        var dict = new Dictionary<char, int>();

        for (int i = 0; i < s1.Length; i++)
        {
            if (dict.ContainsKey(s1[i]))
            {
                return false;
            }

            dict.Add(s1[i], 1);
        }

        return true;
    }
}



}

