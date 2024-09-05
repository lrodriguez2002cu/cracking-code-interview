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
        public static Node<int>? Partition(Node<int> head, int byX)
        {

            if (head == null) return null;

            var p1 = default(Node<int>); //pointing to head once head is analyzed
            var prevP2 = default(Node<int>); //used for moving the element
            var p2 = head; //pointing to the current analyzed element

            while (p2 != null)
            {
                bool inserted = false;
                var p2Next = p2.Next;
                
                if (p2.Value < byX)
                {
                    if (p1 == null)
                    {
                        head = p2;
                        p1 = p2;
                    }
                    else {
                        // move the element p2 to the position after p1
                        if (p1.Next != p2) {
                            
                            if (prevP2 != null)
                            {
                                prevP2.Next = p2Next;
                            }

                            var temp = p1.Next;

                            // insert p2 after p1
                            p1.Next = p2;
                            p2.Next = temp; // the next of p1

                            //move p1 forward
                            p1 = p1.Next;
                            inserted = true;
                        }
                        else {
                            // no need to move as are already next to each
                            // move p1 so it changes the insertion point of the existing elements 
                            p1 = p1.Next; 
                        }
                    }
                }
                

                if (!inserted) { 
                   prevP2 = p2;                
                }

                p2 = p2Next;
            }
            return head;
        }

    }

}
