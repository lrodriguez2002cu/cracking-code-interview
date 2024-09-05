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

        public static int Count<T>(Node<T> l1) {
            int count = 0;
            var l = l1;
            while (l != null)
            {
                count ++;
                l = l?.Next;
            }

            return count;
        }

        public static Node<int>? SumLists(Node<int> l1, Node<int> l2)
        {
            var p1 = l1;
            var p2 = l2;
            Node<int>? result = null;
            Node<int>? head = null;
            var inc = 0;

            while (p1!= null || p2!= null) {
               
                var value = (p1?.Value?? 0 ) + (p2?.Value??0) + inc;

                if (value >=10) inc = 1; 
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
            var l1count = Count(l1);
            var l2count = Count(l2);
            var diff = l1count - l2count;
            var result = SumListsNormalOrderInternal(l1, l2, diff);

            return result.Increment > 0? CreatePartialSum(0, 0, result.Increment, result.Node).Node : result.Node;
        }

        public record PartialSum(Node<int>? Node, int Increment);

        public static PartialSum SumListsNormalOrderInternal(Node<int> l1, Node<int> l2, int diff)
        {
            if (diff == 0)
            {
                if (l1.Next == null && l2.Next == null)
                {  
                    //start sum as alignment was achieved
                    return CreatePartialSum(l1.Value, l2.Value, 0, null);
                }
                else
                {
                    var result = SumListsNormalOrderInternal(l1.Next!, l2.Next!, 0);
                    return CreatePartialSum(l1.Value, l2.Value, result.Increment, result.Node);
                }
            }
            else
            if (diff > 0)
            {
                var result = SumListsNormalOrderInternal(l1.Next!, l2, diff - 1);
                return CreatePartialSum(l1.Value, 0, result.Increment, result.Node);
            }                
            else {
                var result = SumListsNormalOrderInternal(l1, l2.Next!, diff + 1);
                return CreatePartialSum(l2.Value, 0, result.Increment, result.Node);
            }
        }

        private static PartialSum CreatePartialSum(int val1, int val2, int inc, Node<int>? nextNode) {
            var val = val1 + val2 + inc;

            var increment = val >= 10 ? 1 : 0;

            return new PartialSum(new Node<int>(val % 10)
            {
                Next = nextNode
            }, increment);
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
