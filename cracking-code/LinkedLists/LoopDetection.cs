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

        public static Node<int>? LoopDetection(Node<int> l1)
        {
            if (l1 == null) return null;
            HashSet<Node<int>> visited = new HashSet<Node<int>>();
            var p = l1;
            while (p != null)
            {
                if (visited.Add(p)==false) return p;
                p = p.Next;
            }

            return null;
        }

    }

}
