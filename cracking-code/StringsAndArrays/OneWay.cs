namespace StringsAndArrays
{

    public partial class StringsAndArrays
    {
        //s the original string and ed the edited
        public static bool OneWay(string s, string ed)
        {

            if (Math.Abs(ed.Length - s.Length) > 1) return false;

            int edits = 0;
            for (int i = 0, j = 0; i < int.Min(s.Length, ed.Length);)
            {
                if (s[i] != ed[j])
                { //there is at least one edition
                    edits++;

                    //it is the case that either is an insert a remove or a replace
                    if (/*(j + 1 < ed.Length) && */s[i] == ed[j + 1]) { j += 2; i++; continue; } // there is an addition in j position
                    if (/*(i + 1 < s.Length) &&*/ s[i + 1] == ed[j]) { i += 2; j++; continue; } //there is potentially a removal of one of the i elements
                    if (/*(j + 1 < ed.Length) && (i + 1 < s.Length)*/? s[i + 1] == ed[j + 1]) { i += 2; j += 2; continue; } //most likely therewas a replacement

                }
                else
                {
                    i++;
                    j++;
                }
            }
            return edits <= 1;
        }

    }

}