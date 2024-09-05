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
        public static Node<int>? DeleteMiddleNode(Node<int> head)
        {

            if (head == null) return null;

            var p1 = head;
            var p2 = head.Next?.Next;
            
            if (p2 == null) {
                return head.Next;
            }


            while (p2 != null)
            {
                var prev = p1;
                p1 = p1?.Next;
                p2 = p2.Next;
                if (p2 == null) {
                    //delete p1
                    prev!.Next = p1?.Next;
                    return head;

                } 
                p2 = p2?.Next;
                
                if (p2 == null) {
                    p1!.Next = p1?.Next?.Next;
                    return head;
                }
            }

            return head;
        }

    }

}
