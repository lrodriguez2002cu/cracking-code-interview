namespace StringsAndArrays
{

    public partial class StringsAndArrays
    {
        //s the original string and ed the edited
        public static string StringCompression(string s)
        {

            if (s.Length == 0) return s;

            int currentCharCount = 0;
            char prevChar = s[0];
            var result = "";
            Console.WriteLine("String is: '" + s + "'");

            foreach (char ch in s)
            {

                if (currentCharCount > 0 && prevChar != ch)
                {
                    result += AddCharCount(currentCharCount, prevChar);
                    currentCharCount = 0;
                }

                prevChar = ch;
                currentCharCount++;
                Console.WriteLine(currentCharCount);
            }

            if (currentCharCount > 0) result += AddCharCount(currentCharCount, prevChar);

            return (result.Length < s.Length) ? result : s;


        }

        private static string AddCharCount(int currentCharCount, char prevChar)
        {
            var charCountPart = (currentCharCount <= 1) ? ("" + prevChar) : ("" + prevChar + currentCharCount);
            Console.WriteLine("charCountPart: " + "'" + charCountPart + "'");
            return charCountPart;
        }

    }

}