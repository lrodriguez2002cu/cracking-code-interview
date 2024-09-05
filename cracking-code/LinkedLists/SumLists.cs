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
        public static Node<int>? SumLists(Node<int> l1, Node<int> l2)
        {
            var p1 = l1;
            var p2 = l2;
            Node<int>? result = null;
            Node<int>? head = null;
            var inc = 0;

            while (p1!= null || p2!= null) {
               
                var value = (p1?.Value?? 0 ) + (p2?.Value??0) + inc;

                if (value >10) inc = 1; 
                else inc = 0;
                value = value % 10;

                if (result == null)
                {
                    result = new Node<int>(value);
                    head = result;

                }
                else { 
                   result.Next = new Node<int>(value);
                   result = result.Next;
                }

                p1 = p1?.Next;
                p2 = p2?.Next;
            }

            return head;
        }

        public static Node<int>? SumListsNormalOrder(Node<int> l1, Node<int> l2)
        {
            
            return null;
        }


        public static Node<int>? SumListsRecursive(Node<int> l1, Node<int> l2)
        {

            return SumListsRecursive(l1, l2, 0);
        }

        public static Node<int>? SumListsRecursive(Node<int>? l1, Node<int>? l2, int increment)
        {

            var val = (l1?.Value ?? 0) + (l2?.Value ?? 0) + increment;
            
            increment = val > 10 ? 1 : 0;                
            val %= 10;

            var res = new Node<int>(val);


            if (l1?.Next != null || l2?.Next != null) { 
               res.Next =  SumListsRecursive(l1?.Next, l2?.Next, increment);
            }
            return res;
        }


    }

}
