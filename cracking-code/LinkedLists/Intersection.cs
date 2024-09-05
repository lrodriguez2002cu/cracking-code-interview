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

        public static Node<int>? Intersects(Node<int> l1, Node<int> l2)
        {
            var p = l1;
            while (p != null)
            {
                var p1 = l2;
                while (p1 != null) { 
                  
                    if (p == p1) { return p; } ;
                    p1 = p1.Next;
                }
                p = p.Next;
            }

            return null;
        }

    }

}
