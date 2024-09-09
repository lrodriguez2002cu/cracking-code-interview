

using LinkedLists;
using System.Diagnostics;
using System.Numerics;

namespace TreesAndGraphs
{
    /*
      Cracking the coding interview)
    */

    public class Node<T> { 
       public T Value { get; set; }
       public Node<T>[]? Children { get; set; }
    
       public Node(T value) { 
         Value = value; 
       }

        public override string ToString() {
            return "[" + Value.ToString() + "]";
        }
    }

    public class MyGraph<T>(Node<T>[] nodes)
    {
        public Node<T>[] Nodes { get; set; } = nodes;
    }

    public class Result { 
       public bool Value { get; set; }
    }

    public partial class TreesAndGraphs
    {
        public static bool RouteBetween<T>(MyGraph<T> graph, Node<T> n1, Node<T> n2) { 
           
           //Depth first seems to be appropriate
           List<Node<T>> currentRoute = new List<Node<T>>();
           
           Result r =  new Result();
           HashSet<Node<T>> visiting = new HashSet<Node<T>>();
           
           DepthFirst(n1, VisitHasRoute(n2, r), visiting);
           
           return r.Value;
        }

        public static Action<Node<T>> VisitHasRoute<T>(Node<T> targetNode, Result result) { 
           return (Node<T>  visitedNode) => {
               result.Value = result.Value || visitedNode == targetNode; 
            };
        }

        public static void DepthFirst<T>(MyGraph<T> graph, Action<Node<T>> visitFn)
        {
            HashSet<Node<T>> visiting =  new HashSet<Node<T>>();
            for (int i = 0; i < graph.Nodes.Length; i++)
            {
                visiting.Clear();
                var n = graph.Nodes[i];
                Debug.WriteLine("");
                Debug.WriteLine("<<<Node: " + n);
                DepthFirst(n, visitFn, visiting);
            }

        }


        public static void DepthFirst<T>(Node<T> n1, Action <Node<T>> visitFn, HashSet<Node<T>> visiting) { 
            
            if (n1 == null) return;
            visiting.Add(n1);

            if (n1.Children != null) {
                for (var i = 0; i < n1.Children.Length; i++)
                {
                    var ch = n1.Children[i];
                    if (!visiting.Contains(ch)) { 
                       DepthFirst(ch, visitFn, visiting);
                    }
                }
            }
            visitFn(n1);
        }


        public static void PrintGraphDepthFirst<T>(MyGraph<T> myGraph) {
            
            DepthFirst(myGraph, (Node<T> n) => { 
                Debug.Write(n.ToString());
            });
        }

    }

}

