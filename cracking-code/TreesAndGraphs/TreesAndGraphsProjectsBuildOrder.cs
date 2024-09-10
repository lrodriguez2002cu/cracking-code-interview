

using LinkedLists;
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

    public partial class TreesAndGraphs
    {

        public static T[] BuildOrder <T>(T[] projects, List<(T, T)> dependencies) where T: IComparable{

            var prjNodes = projects.Select(n => new Node<T>(n)).ToArray();

            var graph = new MyGraph<T>(prjNodes);

            foreach (var dep in dependencies)            
            {
                var node1 = findNode(dep.Item1, prjNodes);
                var node2 = findNode(dep.Item2, prjNodes);

                //check the nodes of the dep exist in the actual list of nodes
                if (node1 is null || node2 is null) throw new InvalidOperationException("Projects must exist to be able to process the dependency.");
                
                // there is an edge if item1 depends on item2
                graph.AddEdge(node1, node2);

            }

            
            Dictionary<Node<T>, int> values = new ();

            DepthFirstBuildOrder<T>(graph, visitFn<T>(values));

            //values contains the number of dependencies of each node..
            var sorted = values.OrderBy(e => e.Value);

            return sorted.Select(s=>s.Key.Value).ToArray();

            //position contains an ordered list of projects from less dependent to most dependent on others
            // the less dependent are a good starting point to start with..


            Node<T>? findNode(T val, Node<T>[] prjNodes) {
                foreach (var node in prjNodes)
                {
                    if (node.Value.CompareTo(val) == 0) {
                        return node;
                    }
                }
                return null;
            }

            return [];

        }
        



        public static void DepthFirstBuildOrder<T>(IMyGraph<T> graph, Action<Node<T>, Node<T>[]> visitFn)
        {
            HashSet<Node<T>> visiting = new();
            for (int i = 0; i < graph.Nodes.Length; i++)
            {
                visiting.Clear();
                var n = graph.Nodes[i];
                Debug.WriteLine("");
                Debug.WriteLine("<<<Node: " + n);
                DepthFirstBuildOrder(n, graph, visitFn, visiting);
            }
        }

        public static Action<Node<T> , Node<T>[] > visitFn<T>(/*Node<int> node, Node<int>[] adjacent, */Dictionary<Node<T>, int> values)
        {
            return (Node<T> node, Node<T>[] adjacent) =>
            {
                values[node] = 1;
                for (int i = 0; i < adjacent.Length; i++)
                {
                    values[node] += values[adjacent[i]];
                }
            };            
        }

        public static void DepthFirstBuildOrder<T>(Node<T> n1, IMyGraph<T> graph, Action<Node<T>, Node<T>[]> visitFn, HashSet<Node<T>> visiting)
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
                        DepthFirstBuildOrder(ch, graph, visitFn, visiting);
                    }
                    else {
                        throw new Exception("A cycle in the build order was found.");
                    }
                }
            }
            visitFn(n1, adjacent);

            //remove from visiting as already explored the children
            visiting.Remove(n1);
        }


        
        public static BinaryTreeNode<T>? FirstCommonAncestor<T>(BinaryTree<T> tree, BinaryTreeNode<T> n1, BinaryTreeNode<T> n2) {

            var n1Found = false;
            var n2Found = false;

            return InOrderTraversalCommonAncestor(tree.Root, tree.Root, n1, n2, ref n1Found, ref n2Found);

        }

        private static BinaryTreeNode<T>? InOrderTraversalCommonAncestor<T>(BinaryTreeNode<T> current, 
            BinaryTreeNode<T> commonAncestor,            
            BinaryTreeNode<T> n1, BinaryTreeNode<T> n2, ref bool n1Found, ref bool n2Found)
        {
            //reference equality??
            n1Found = n1Found || n1 == current;
            n2Found = n2Found || n2 == current;

            if (n1Found && n2Found) {
                return commonAncestor;
            }

            
            var commonAncestorDown = /*n1 == current || n2 == current*/n1Found || n2Found? commonAncestor: current;

            if (current.Left != null)
            {

             var result1 =   InOrderTraversalCommonAncestor(current.Left, commonAncestorDown, n1, n2, ref n1Found, ref n2Found);
                if ( result1!= null)
                {
                    return result1;
                }
            }

            //visitFn(root);

            if (current.Right != null)
            {
                var result2= InOrderTraversalCommonAncestor(current.Right, commonAncestorDown, n1, n2, ref n1Found, ref n2Found);
                if (result2 != null)
                {
                    return result2;
                }
            }

            return null;
        }


    }

}

