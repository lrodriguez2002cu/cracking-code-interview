

using LinkedLists;
using System.Collections;
using System.Diagnostics;
using System.Numerics;
using System.Threading.Tasks.Sources;
using System.Xml.Linq;

namespace TreesAndGraphs
{
    /*
      Cracking the coding interview)
    */

    public class Node<T> { 
       public T Value { get; set; }
       //public Node<T>[]? Children { get; set; }
    
       public Node(T value) { 
         Value = value; 
       }

        public override string ToString() {
            return "[" + Value.ToString() + "]";
        }
    }

    public interface IMyGraph<T> {

        Node<T>[] Nodes { get; set; }
        Node<T>[] Adjacent(Node<T> n);

        void AddEdge(Node<T> s, Node<T> t);
    }

    //public class MyGraph<T>(Node<T>[] nodes) : IMyGraph<T>
    //{
    //    public Node<T>[] Nodes { get; set; } = nodes;

    //    public Node<T>[] Adjacent(Node<T> n)
    //    {
    //        return n.Children
    //    }
    //}

    public class MyGraph<T> : IMyGraph<T>{

        readonly bool[,] AdjacencyMatrix;
        
        public Node<T>[] Nodes { get ; set ; }

        public MyGraph(Node<T>[] nodes) {

            Nodes = nodes;
            AdjacencyMatrix = new bool[Nodes.Length, Nodes.Length];

            //for (var i = 0; i< Nodes.Length; i++) {                
            //    var node = Nodes[i];
            //    var adjacent = Adjacent(node);

            //    foreach (var chNode in adjacent ?? []) {
            //        var j = getIndex(chNode);
            //        AdjacencyMatrix[i, j] = true;
            //    }
            //}
        }

        private int getIndex(Node<T> n){
            for (var i = 0; i< Nodes.Length; i++) {
                if (Nodes[i] == n) {
                    return i;
                }
            }

            return -1;
        }

        public Node<T>[] Adjacent(Node<T> n)
        {
            var index = getIndex(n);
            var result = new List<Node<T>>();


            for (var j = 0; j < Nodes.Length; j++) {
                if (AdjacencyMatrix[index, j]) { 
                   result.Add(Nodes[j]);
                }
            }

            return [.. result];
        }

        public void AddEdge(Node<T> s, Node<T> t)
        {
            var i = getIndex(s);
            var j = getIndex(t);
            AdjacencyMatrix[i, j] = true;
        }
    }

    public class Result { 
       public bool Value { get; set; }
    }

    public partial class TreesAndGraphs
    {
        public static bool RouteBetweenDephFirst<T>(IMyGraph<T> graph, Node<T> n1, Node<T> n2) { 
           
           //Depth first seems to be appropriate
           List<Node<T>> currentRoute = new List<Node<T>>();
           
           Result r =  new Result();
           HashSet<Node<T>> visiting = new HashSet<Node<T>>();
           
           DepthFirst(n1, graph, VisitHasRoute(n2, r), visiting);
           
           return r.Value;
        }

        public static Action<Node<T>> VisitHasRoute<T>(Node<T> targetNode, Result result) { 
           return (Node<T>  visitedNode) => {
               result.Value = result.Value || visitedNode == targetNode; 
            };
        }

        public static void DepthFirst<T>(IMyGraph<T> graph, Action<Node<T>> visitFn)
        {
            HashSet<Node<T>> visiting =  new ();
            for (int i = 0; i < graph.Nodes.Length; i++)
            {
                visiting.Clear();
                var n = graph.Nodes[i];
                Debug.WriteLine("");
                Debug.WriteLine("<<<Node: " + n);
                DepthFirst(n, graph, visitFn, visiting);
            }

        }


        public static void DepthFirst<T>(Node<T> n1, IMyGraph<T> graph, Action <Node<T>> visitFn, HashSet<Node<T>> visiting) { 
            
            if (n1 == null) return;

            visiting.Add(n1);
            var adjacent = graph.Adjacent(n1);

            if (adjacent != null) {
                for (var i = 0; i < adjacent.Length; i++)
                {
                    var ch = adjacent[i];
                    if (!visiting.Contains(ch)) { 
                       DepthFirst(ch, graph, visitFn, visiting);
                    }
                }
            }
            visitFn(n1);
        }


        public static void PrintGraphDepthFirst<T>(IMyGraph<T> myGraph) {
            
            DepthFirst(myGraph, (Node<T> n) => { 
                Debug.Write(n.ToString());
            });
        }

        public static void PrintGraphBreadthFirst<T>(IMyGraph<T> myGraph)
        {

            BreadthFirst(myGraph, (Node<T> n) => {
                Debug.Write(n.ToString());
            });
        }


        public static bool RouteBetweenBreadthFirst<T>(IMyGraph<T> graph, Node<T> n1, Node<T> n2)
        {
            return false;
        }

        public static void BreadthFirst<T>(IMyGraph<T> graph, Action<Node<T>> visitFn) {
            HashSet<Node<T>> visiting = new();
            BreadthFirst<T>(graph.Nodes[0], graph, visitFn, visiting);       
        }

        public static void BreadthFirst<T>(Node<T> n1, IMyGraph<T> graph, Action<Node<T>> visitFn, HashSet<Node<T>> visiting) 
        {

            Queue<Node<T>> queue = new ();
            queue.Enqueue(n1);
            if (n1 == null) return;

            while (queue.Count > 0) {

                var current = queue.Dequeue();
                var adjacent = graph.Adjacent(current);

                visitFn(current);
                visiting.Add(current);

                for (var i = 0; i < adjacent.Length; i++)
                {
                    var ch = adjacent[i];
                    if (!visiting.Contains(ch))
                    {
                        queue.Enqueue(ch);
                    }
                    
                }
            }
            
        }

    }

}

