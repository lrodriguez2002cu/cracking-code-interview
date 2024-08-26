
namespace StringsAndArrays
{

    public partial class StringsAndArrays
    {
        public static void permutation(string str, string ans)
        {
            if (str.Length == 0)
            {
                Console.WriteLine(ans);
                return;
            }

            for (int i = 0; i < str.Length; i++)
            {
                char ch = str[i];
                string ros = str.Substring(0, i) + str.Substring(i + 1);
                permutation(ros, ans + ch);
            }
        }

    }
}




