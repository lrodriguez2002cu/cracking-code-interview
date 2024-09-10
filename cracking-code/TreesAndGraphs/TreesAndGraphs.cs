

using System.Diagnostics;
using System.Dynamic;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using static LinkedLists.LinkedLists;
namespace TreesAndGraphs
{
    /*
      Cracking the coding interview)
    */

    public class TreeNode<T> : Node<T>
    {
        public TreeNode(T Value) : base(Value)
        {
            this.Value = Value;
        }

        //public T Value { get; set; }
        public TreeNode<T>[]? Children { get; set; }

        public override string ToString()
        {
            return "[" + Value!.ToString() + "]";
        }
    }

    public class BinaryTree<T> : IMyGraph<T>
    {

        public Node<T>[] Nodes { get => getNodes(); set => throw new InvalidOperationException("Nodes can not be set on trees."); } // todo
        public BinaryTreeNode<T> Root { get; set; }

        Node<T>[] getNodes()
        {
            //todo implement this
            return [];
        }

        public BinaryTree(BinaryTreeNode<T> root)
        {
            this.Root = root;
        }

        public void AddEdge(Node<T> s, Node<T> t)
        {
            throw new InvalidOperationException("Not supported on trees.");
        }

        public Node<T>[] Adjacent(Node<T> n)
        {
            if (n is BinaryTreeNode<T> node)
            {
                if (node.Left != null && node.Right != null)
                {
                    return [node.Left, node.Right];
                }
                else
                {
                    var e = node.Left ?? node.Right;
                    return e != null ? [e] : [];
                }
            }
            else { throw new InvalidOperationException("Adjacent can only be requested on nodes of this tree"); }
        }
    }

    public class BinaryTreeNode<T> : TreeNode<T>
    {

        public BinaryTreeNode<T>? Right { get { return getRight(); } set { setRight(value); } }
        public BinaryTreeNode<T>? Left { get { return getLeft(); } set { setLeft(value); } }

        public BinaryTreeNode(T Value, BinaryTreeNode<T>? right, BinaryTreeNode<T>? left) : base(Value)
        {
            this.Value = Value;
            Children = new TreeNode<T>[2];
            Right = right;
            Left = left;
        }

        public BinaryTreeNode(T Value) : base(Value)
        {
            this.Value = Value;
            Children = new TreeNode<T>[2];
        }

        private void setRight(BinaryTreeNode<T> Value)
        {

            if (Children == null)
            {
                Children = new TreeNode<T>[2];
            }
            Children[1] = Value;
        }

        private void setLeft(BinaryTreeNode<T> Value)
        {

            Children ??= new TreeNode<T>[2];
            Children[0] = Value;
        }

        private BinaryTreeNode<T> getRight()
        {
            return (BinaryTreeNode<T>)Children[1];
        }

        private BinaryTreeNode<T> getLeft()
        {
            return (BinaryTreeNode<T>)Children[0];
        }


    }

    public class Node<T>(T value)
    {
        public T Value { get; set; } = value;

        public override string ToString()
        {
            return "[" + Value.ToString() + "]";
        }
    }

    public interface IMyGraph<T>
    {

        Node<T>[] Nodes { get; set; }
        Node<T>[] Adjacent(Node<T> n);

        void AddEdge(Node<T> s, Node<T> t);
    }

    public class MyGraph<T> : IMyGraph<T>
    {

        readonly bool[,] AdjacencyMatrix;

        public Node<T>[] Nodes { get; set; }

        bool Directed { get; set; }

        public MyGraph(Node<T>[] nodes, bool bidirectional = false)
        {
            Nodes = nodes;
            AdjacencyMatrix = new bool[Nodes.Length, Nodes.Length];
            Directed = !bidirectional;
        }

        private int getIndex(Node<T> n)
        {
            for (var i = 0; i < Nodes.Length; i++)
            {
                if (Nodes[i] == n)
                {
                    return i;
                }
            }
            return -1;
        }

        public Node<T>[] Adjacent(Node<T> n)
        {
            var index = getIndex(n);
            var result = new List<Node<T>>();


            for (var j = 0; j < Nodes.Length; j++)
            {
                if (AdjacencyMatrix[index, j])
                {
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
            if (!Directed)
            {
                AdjacencyMatrix[j, i] = true;
            }

        }
    }

    public class Result
    {
        public bool Value { get; set; }
    }

    public partial class TreesAndGraphs
    {
        public static bool RouteBetweenDephFirst<T>(IMyGraph<T> graph, Node<T> n1, Node<T> n2)
        {

            //Depth first seems to be appropriate
            List<Node<T>> currentRoute = new List<Node<T>>();

            Result r = new Result();
            HashSet<Node<T>> visiting = new HashSet<Node<T>>();

            DepthFirst(n1, graph, VisitHasRoute(n2, r), visiting);

            return r.Value;
        }

        public static Action<Node<T>> VisitHasRoute<T>(Node<T> targetNode, Result result)
        {
            return (Node<T> visitedNode) =>
            {
                result.Value = result.Value || visitedNode == targetNode;
            };
        }

        public static void DepthFirst<T>(IMyGraph<T> graph, Action<Node<T>> visitFn)
        {
            HashSet<Node<T>> visiting = new();
            for (int i = 0; i < graph.Nodes.Length; i++)
            {
                visiting.Clear();
                var n = graph.Nodes[i];
                Debug.WriteLine("");
                Debug.WriteLine("<<<Node: " + n);
                DepthFirst(n, graph, visitFn, visiting);
            }

        }


        public static void DepthFirst<T>(Node<T> n1, IMyGraph<T> graph, Action<Node<T>> visitFn, HashSet<Node<T>> visiting)
        {

            if (n1 == null) return;

            visiting.Add(n1);
            var adjacent = graph.Adjacent(n1);

            if (adjacent != null)
            {
                for (var i = 0; i < adjacent.Length; i++)
                {
                    var ch = adjacent[i];
                    if (!visiting.Contains(ch))
                    {
                        DepthFirst(ch, graph, visitFn, visiting);
                    }
                }
            }
            visitFn(n1);
        }


        public static void PrintGraphDepthFirst<T>(IMyGraph<T> myGraph)
        {

            DepthFirst(myGraph, (Node<T> n) =>
            {
                Debug.Write(n.ToString());
            });
        }

        public static void PrintGraphBreadthFirst<T>(IMyGraph<T> myGraph)
        {

            BreadthFirst(myGraph, (Node<T> n, List<Node<T>> route) =>
            {
                string routeStr = "";
                string sep = "";
                foreach (var node in route)
                {
                    routeStr += sep + node.ToString();
                    sep = "->";
                }

                Debug.Write(n.ToString() + $" route: {{ {routeStr} }} ");
            });
        }



        public static void BreadthFirst<T>(IMyGraph<T> graph, Action<Node<T>, List<Node<T>>> visitFn)
        {
            HashSet<Node<T>> visiting = new();
            BreadthFirst<T>(graph.Nodes[0], graph, visitFn, visiting);
        }

        private record NR<T>(Node<T> Node, List<Node<T>> Route);

        public static void BreadthFirst<T>(Node<T> n1, IMyGraph<T> graph, Action<Node<T>, List<Node<T>>> visitFn, HashSet<Node<T>> visiting)
        {

            Queue<NR<T>> queue = new();

            queue.Enqueue(new NR<T>(n1, new List<Node<T>>() { n1 }));
            if (n1 == null) return;

            while (queue.Count > 0)
            {

                var t = queue.Dequeue();
                var current = t.Node;
                var route = t.Route;

                var adjacent = graph.Adjacent(current);

                visitFn(current, route);
                visiting.Add(current);

                for (var i = 0; i < adjacent.Length; i++)
                {
                    var ch = adjacent[i];
                    if (!visiting.Contains(ch))
                    {
                        var newRoute = new List<Node<T>>();
                        newRoute.AddRange(route);
                        newRoute.Add(ch);
                        queue.Enqueue(new NR<T>(ch, newRoute));
                    }

                }
            }

        }

        //The algorithm consists in start searching from both ends
        public static Node<T>[] BreadthFirstSearch<T>(Node<T> n1, Node<T> n2, IMyGraph<T> graph, Action<Node<T>, List<Node<T>>> visitFn)
        {

            if (n1 == null || n2 == null) return [];

            //cycle control..
            var visiting1 = new Dictionary<Node<T>, List<Node<T>>>();
            var visiting2 = new Dictionary<Node<T>, List<Node<T>>>();

            Queue<NR<T>> queue1 = new();
            queue1.Enqueue(new NR<T>(n1, new List<Node<T>>() { n1 }));


            Queue<NR<T>> queue2 = new();
            queue2.Enqueue(new NR<T>(n2, new List<Node<T>>() { n2 }));

            while (queue1.Count > 0 && queue2.Count > 0)
            {
                queue1.TryDequeue(out var t1);
                var current1 = t1?.Node;
                var route1 = t1?.Route;
                var adjacent1 = current1 != null ? graph.Adjacent(current1) : Array.Empty<Node<T>>();

                if (current1 != null)
                {
                    visiting1.Add(current1, t1!.Route);
                }

                queue2.TryDequeue(out var t2);
                var current2 = t2?.Node;
                var route2 = t2?.Route;
                var adjacent2 = current2 != null ? graph.Adjacent(current2) : Array.Empty<Node<T>>();

                if (current2 != null)
                {
                    visiting2.Add(current2, t2!.Route);
                }

                if (current2 != null && visiting1.TryGetValue(current2, out var routeVisited1))
                {
                    //route from both ends concatenated
                    var res = new List<Node<T>>();
                    res.AddRange(routeVisited1);

                    var r = t2!.Route;
                    r.Reverse();
                    res.AddRange(r[1..]);
                    return res.ToArray();
                }

                if (current1 != null && visiting2.TryGetValue(current1, out var routeVisited2))
                {
                    //route from both ends concatenated
                    var res = new List<Node<T>>();
                    res.AddRange(routeVisited2);
                    var r = t1!.Route;
                    r.Reverse();
                    res.AddRange(r[1..]);
                    return res.ToArray();
                }

                for (var i = 0; adjacent1 != null && i < adjacent1.Length; i++)
                {
                    var ch = adjacent1[i];
                    if (!visiting1.ContainsKey(ch))
                    {
                        var newRoute = new List<Node<T>>();
                        newRoute.AddRange(route1!);
                        newRoute.Add(ch);
                        queue1.Enqueue(new NR<T>(ch, newRoute));
                    }

                }

                for (var i = 0; i < adjacent2.Length; i++)
                {
                    var ch = adjacent2[i];
                    if (!visiting2.ContainsKey(ch))
                    {
                        var newRoute = new List<Node<T>>();
                        newRoute.AddRange(route2!);
                        newRoute.Add(ch);
                        queue2.Enqueue(new NR<T>(ch, newRoute));
                    }

                }
            }
            return [];
        }



        public static BinaryTree<T> GetMinimalTree<T>(T[] orderedNodes) {
            return new BinaryTree<T>(MinimalTree(orderedNodes));
        }

        private static BinaryTreeNode<T> MinimalTree<T>(T[] orderedNodes)
        {

            if (orderedNodes.Length == 0) return null;

            var mid = orderedNodes.Length / 2;
            var root = new BinaryTreeNode<T>(orderedNodes[mid]);

            if (mid > 0)
            {
                root.Left = MinimalTree(orderedNodes[0..(mid)]);

                if ((mid + 1) <= (orderedNodes.Length - 1))
                {
                    root.Right = MinimalTree(orderedNodes[(mid + 1)..(orderedNodes.Length)]);
                }

            }
            return root;
        }



        public static void InOrderTraversal<T>(BinaryTree<T> binaryTree, Action<Node<T>> visitFn)
        {

            if (binaryTree == null) return;

            InOrderTraversal(binaryTree.Root, visitFn);

        }

        private static void InOrderTraversal<T>(BinaryTreeNode<T> root, Action<Node<T>> visitFn)
        {
            if (root == null) return;

            if (root.Left != null)
            {

                InOrderTraversal(root.Left, visitFn);
            }

            visitFn(root);

            if (root.Right != null)
            {
                InOrderTraversal(root.Right, visitFn);
            }
        }

        public static Action<Node<T>> CollectInOrder<T>(List<Node<T>> nodesVisited) {

            return nodesVisited.Add;
        }


        public static Dictionary<int, List<BinaryTreeNode<T>>> ListOfDepths<T>(BinaryTree<T> tree) {

            var result = new Dictionary<int, List<BinaryTreeNode<T>>>();
            ListOfDepths<T>(tree.Root, result, 0);

            return result;
        }

        private static void ListOfDepths<T>(BinaryTreeNode<T> treeNode, Dictionary<int, List<BinaryTreeNode<T>>> result, int depth)
        {
            if (result.ContainsKey(depth))
            {

                result[depth].Add(treeNode);
            }
            else
            {
                result[depth] = [treeNode];
            }

            if (treeNode.Left != null) {
                ListOfDepths<T>(treeNode.Left, result, depth+1);
            }

            if (treeNode.Right != null)
            {
                ListOfDepths<T>(treeNode.Right, result, depth + 1);
            }

        }


        // Check balanced
        public static bool CheckBalanced<T>(BinaryTree<T> tree)
        {
            CheckBalanced<T>(tree.Root, 0, out var result);
            return result;
        }

        private static int CheckBalanced<T>(BinaryTreeNode<T> treeNode, int depth, out bool balanced)
        {
            if (treeNode == null) {
               balanced = true;
               return depth;
            }

            var depthRight = depth;
            var depthLeft = depth;

            bool leftBalanced =  true;
            bool rightBalanced = true;

            if (treeNode.Left != null)
            {
                depthLeft= CheckBalanced<T>(treeNode.Left, depth + 1, out leftBalanced);
            }

            if (treeNode.Right != null)
            {
                depthRight = CheckBalanced<T>(treeNode.Right, depth + 1, out rightBalanced);
            }

            balanced = leftBalanced && rightBalanced && Math.Abs(depthRight - depthLeft) <= 1;

            return int.Max(depthLeft, depthRight);
        }

        // Check balanced
        public static bool ValidateBST<T>(BinaryTree<T> tree) where T: IComparable<T>
        {
            return ValidateBST<T>(tree.Root);
            
        }

        private static bool ValidateBST<T>(BinaryTreeNode<T> treeNode) where T: IComparable<T>
        {
            if (treeNode == null)
            {
                return true;
            }

            bool result = true;

            if (treeNode.Right != null) {
                result = result && (treeNode.Right.Value.CompareTo(treeNode.Value) > 0) && ValidateBST<T>(treeNode.Right);
            }

            if (treeNode.Left != null)
            {
                result = result && (treeNode.Left.Value.CompareTo(treeNode.Value) <= 0) && ValidateBST<T>(treeNode.Left);
            }

            return  result;

        }
        
    }

}

