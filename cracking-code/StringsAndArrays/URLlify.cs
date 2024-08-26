namespace StringsAndArrays
{

    public partial class StringsAndArrays
    {
        public static string URLify(string s1, int trueLength)
        {
            //replace all spaces with %20
            for (int i = 0; i < trueLength; i++)
            {
                if (s1[i] == ' ')
                {
                    s1 = s1.Substring(0, i) + "%20" + s1.Substring(i + 1);
                }
            }
            return s1;

        }

        public static string URLifyV1(string s, int trueLength)
        {
            char[] s1 = s.ToCharArray();
            //replace all spaces with %20
            int spaceCount = 0;
            for (int i = 0; i < trueLength; i++)
            {
                if (s1[i] == ' ')
                {
                    spaceCount++;
                }
            }

            int index = trueLength + spaceCount * 2; //there is already one place for each space and moreover it is considered in the trueLength

            //lets start from the end of the string as it is trueLength 
            for (int i = trueLength - 1; i >= 0; i--)
            {
                if (s1[i] == ' ')
                {
                    s1[index - 1] = '0';
                    s1[index - 2] = '2';
                    s1[index - 3] = '%';
                    index -= 3;
                }
                else
                {
                    s1[index - 1] = s1[i];
                    index--;
                }
            }

            return new String(s1);

        }

    }
}
