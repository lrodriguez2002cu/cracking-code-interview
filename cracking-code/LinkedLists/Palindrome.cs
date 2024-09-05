using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedLists
{
    public partial class LinkedLists
    {

        public static bool Palindrome(Node<int> l1)
        {
            if (l1.Next == null) //a list with only one element is palindrome
            {
                return true;
            }
            else {
                var val = PalindromeInternal(l1, l1.Next);
                return val.isPal;
            }

        }

        public record Result(bool isPal, Node<int>? head);

        private static Result PalindromeInternal(Node<int> head, Node<int> tail)
        {
            if (tail.Next == null)
            {
                return new Result (head.Value == tail?.Value, head.Next);

            }
            
            var val = PalindromeInternal(head, tail?.Next);

            return new Result(val.isPal && val.head?.Value == tail?.Value , head.Next);


        }

    }

}
