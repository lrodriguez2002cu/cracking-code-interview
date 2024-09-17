using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAndSearching
{
    public class SortingAndSearching
    {

        public static void SortedMerge(int[] A, int lastIndexA, int[] B)
        {
            int currentA = lastIndexA;
            int currentB = B.Length - 1;

            for (int i = lastIndexA + B.Length; i>=0; i--) {

                if ((currentB < 0 || currentA < 0)  && !((currentB < 0 && currentA < 0))) {
                    if (currentB < 0)
                    {
                        A[i] = A[currentA];
                        currentA--;
                    }
                    else if ((currentA < 0))
                    {
                        A[i] = B[currentB];
                        currentB--;
                    }
                }
                else 
                if ((A[currentA]> B[currentB]))
                {
                    A[i] = A[currentA];
                    currentA--;
                }
                else if ((A[currentA] < B[currentB]))
                {
                    A[i] = B[currentB];
                    currentB--;
                }
                else
                if (A[currentA] == B[currentB]) {
                    // I am keeping both values
                    A[i] = B[currentB];
                    i--;
                    A[i] = A[currentA];
                    currentB--;
                    currentA--;
                }
            }

        }


        private record Values(string Value, string? RealValue) { 
        
        }

        public static void GroupAnagrams(string[] strings) {
            //what's an anagram?
            // an anagram is a word or phrase formed by rearranging the letters of a different word or phrase, typically using all the original letters exactly once.
            var values = new Values[strings.Length];

            //assume none of them are anagrams
            for (int i = 0; i< strings.Length; i++)
            {
                values[i] = new Values(strings[i], strings[i]);
            }

            for (int i = 0; i < values.Length; i++)
            {
                var iValue = values[i].Value;
                
                for (int j = i + 1; j < values.Length; j++)
                {
                    var jValue = values[j].Value;

                    if (IsAnagram(iValue, jValue))
                    {
                        //set as the value the one that is less in the alphabet
                        var cmp = string.Compare(iValue, jValue);
                        if (cmp<0)
                        {
                            values[j] = new Values(iValue, values[j].RealValue);
                        }
                        else
                        {
                            if (cmp != 0) { 
                              values[i] = new Values(jValue, values[i].RealValue);
                            }
                        }

                        //now sort based on the real value so the anagrams are ordered internally (not really, it would be necessary to consider other anagrams)
                        var riValue = values[i].RealValue;
                        var rjValue = values[j].RealValue;

                        if (string.Compare(riValue, rjValue) > 0)
                        {
                            var temp = values[i];
                            values[i] = values[j];
                            values[j] = temp;
                        }

                    }
                    else {
                        //swap if the current value is not an anagram
                        if (string.Compare(iValue, jValue) > 0)
                        {
                            var temp = values[i];
                            values[i] = values[j];
                            values[j] = temp;
                        }
                    }
                }

            }

            //fix with the real values after sorting
            for (int i = 0; i < strings.Length; i++)
            {
                if (values[i].RealValue != null)
                {
                    strings[i] = values[i].RealValue!;
                }
                else {
                    strings[i] = values[i].Value!;
                }
            }

        }

        public static bool IsAnagram(string s1, string s2)
        {
            if (s1.Length != s2.Length)
            {
                return false;
            }

            Dictionary<char, int> s1Dict = new ();

            for (int i = 0; i < s1.Length; i++)
            {   var s1Char = s1[i];
                var s2Char = s2[i];

                if (s1Dict.ContainsKey(s1Char)) {
                    s1Dict[s1Char] = s1Dict[s1Char] + 1;
                }
                else
                {
                    s1Dict[s1Char] =  1;
                }

                if (s1Dict.ContainsKey(s2Char))
                {
                    s1Dict[s2Char] = s1Dict[s2Char] - 1;
                }
                else
                {
                    s1Dict[s2Char] = - 1;
                }

            }
        
            for (int i = 0; i < s1Dict.Count; i++)
            {
                if (s1Dict[s1[i]] != 0)
                {
                    return false;
                }
            }

            return true;
        }
    }

}
