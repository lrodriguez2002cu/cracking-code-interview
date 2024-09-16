using System;
using System.Collections.Generic;
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

    }

}
