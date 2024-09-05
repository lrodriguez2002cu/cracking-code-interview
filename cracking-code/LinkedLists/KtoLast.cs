using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedLists
{
    public partial class LinkedLists
    {
        public static Node<int>? KtoLast(Node<int> head, int number)
        {

            if (head == null) return null;

            var p1 = head;
            var p2 = head;
            int k = number;
            while (p1 != null)
            {
                p1 = p1.Next;
                k--;
                if (k < 0) { 
                  p2 = p2.Next;
                }
            }

            return p2;
        }

    }

}
