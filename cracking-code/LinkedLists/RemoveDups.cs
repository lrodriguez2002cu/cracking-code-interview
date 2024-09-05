
using System.Collections;
using System.Runtime.InteropServices;

namespace LinkedLists
{
    /*
      Exercise 1.1 (Cracking the coding interview)
    */


    public class Node<T> {

        public T Value { get; set; }
        
        public Node<T>? Next { get; set; }

        public Node(T value) { 
           this.Value = value;
        }
    }




    public partial class LinkedLists
    {

        public static Node<T>? ListOf<T>(T[] values) {

            Node <T>? head = null;
            Node <T>? node= null;

            for (int i = 0; i < values.Length; i++)
            {
                var n = new Node<T>(values[i]);
                if (i == 0)
                {
                    head = n;
                    node = n;
                }
                else { 
                    node.Next = n;
                    node = node.Next;
                }
                
            }
            return head;
        }

        public static List<T> ToList<T>(Node<T> node)
        {
            if (node == null) return new List<T>();

            var result = new List<T>();
            
            while (node != null)
            {

                    result.Add(node.Value);
                    // remove
                    node = node.Next;
            }
            return result;
        }

        // using a hashset to identify the dups
        public static void RemoveDups(Node<int> intshead)
        {
            HashSet<int> hashset = new ();
            var node = intshead;

            if (node == null) return;

            var prev = node;

            hashset.Add(node.Value);
            node = node.Next;
            


            while (node != null)
            {

                if (!hashset.Contains(node.Value))
                {
                    hashset.Add(node.Value);
                    prev = node;
                    node = node.Next;
                }
                else { 
                    
                    // remove
                    prev.Next = node.Next;
                    node = node.Next;
                    
                }
            }
        }

        public static void RemoveDupsNoBuffer(Node<int> intshead)
        {
            var node = intshead;
            if (node == null) return;

            var prev = node;

            while (node != null)
            {
                prev = node;
                var next = node.Next;
                while (next != null) {
                    if (next.Value == node.Value)
                    {
                        prev.Next = next.Next;
                        next = next.Next;
                    }
                    else {
                        prev = next;
                        next = next.Next;
                    }
                }
                node = node.Next;
                
            }
        }

    }

}

