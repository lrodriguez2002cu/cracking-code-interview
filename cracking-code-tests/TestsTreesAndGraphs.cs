using TreesAndGraphs;

namespace cracking_code_tests
{
    [TestClass]
    public class TreesAndGraphsTests
    {
        [TestMethod]
        public void TestGraphDepthFirstVisit()
        {
            //this graph would be:
            // 1->2->4->3

            //build some nodes
            var n1 = new Node<int>(1);
            var n2 = new Node<int>(2);
            var n3 = new Node<int>(3);
            var n4 = new Node<int>(4);

            var graph = new MyGraph<int>(new Node<int>[] { n1, n2, n3, n4 });

            graph.AddEdge(n1, n2);
            graph.AddEdge(n2, n4);
            graph.AddEdge(n4, n3);

            TreesAndGraphs.TreesAndGraphs.PrintGraphDepthFirst(graph);
        }

        [TestMethod]
        public void TestGraphBasicsBreadthFirstVisiting()
        {

            //this graph would be:
            // 1->2->4->5
            // 1->3 
            // 1->6

            //build some nodes
            var n1 = new Node<int>(1);
            var n2 = new Node<int>(2);
            var n3 = new Node<int>(3);
            var n4 = new Node<int>(4);
            var n5 = new Node<int>(5);
            var n6 = new Node<int>(6);

            var graph = new MyGraph<int>(new Node<int>[] { n1, n2, n3, n4, n5, n6 });

            graph.AddEdge(n1, n2);
            graph.AddEdge(n2, n4);
            graph.AddEdge(n4, n5);
            graph.AddEdge(n1, n3);
            graph.AddEdge(n1, n6);

            TreesAndGraphs.TreesAndGraphs.PrintGraphBreadthFirst(graph);
        }



        [TestMethod]
        [DataRow(1, 3, true)]
        [DataRow(3, 1, false)]

        public void TestRouteBetween(int sn, int tn, bool expected)
        {
            //this graph would be:
            // 1->2->4->3

            //build some nodes
            var n1 = new Node<int>(1);
            var n2 = new Node<int>(2);
            var n3 = new Node<int>(3);
            var n4 = new Node<int>(4);

            var nodes = new Node<int>[] { n1, n2, n3, n4 };

            var graph = new MyGraph<int>(new Node<int>[] { n1, n2, n3, n4 });
            graph.AddEdge(n1, n2);
            graph.AddEdge(n2, n4);
            graph.AddEdge(n4, n3);

            var result = TreesAndGraphs.TreesAndGraphs.RouteBetweenDephFirst(graph, nodes[sn - 1], nodes[tn - 1]);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataRow(1, 2, true)]
        [DataRow(3, 1, false)]

        public void TestRouteBetween1(int sn, int tn, bool expected)
        {
            //this graph would be:
            // 1->2->4->3

            //build some nodes
            var n1 = new Node<int>(1);
            var n2 = new Node<int>(2);
            var n3 = new Node<int>(3);
            var n4 = new Node<int>(4);

            var nodes = new Node<int>[] { n1, n2, n3, n4 };

            var graph = new MyGraph<int>(new Node<int>[] { n1, n2, n3, n4 });
            graph.AddEdge(n1, n2);
            graph.AddEdge(n4, n3);

            var result = TreesAndGraphs.TreesAndGraphs.RouteBetweenDephFirst(graph, nodes[sn - 1], nodes[tn - 1]);

            Assert.AreEqual(expected, result);
        }


        [TestMethod]

        public void TestBreadthFirstSearch()
        {
            //this graph would be:
            // s1->s2
            // s1->s3
            // s2->c4


            //this graph would be:
            // t1->t2
            // t1->t3
            // t3->c4

            //build some nodes
            var s1 = new Node<int>(1);
            var s2 = new Node<int>(2);
            var s3 = new Node<int>(3);
            var c4 = new Node<int>(4);

            var t1 = new Node<int>(11);
            var t2 = new Node<int>(12);
            var t3 = new Node<int>(13);


            var graph = new MyGraph<int>([s1, s2, s3, c4, t1, t2, t3], true);

            graph.AddEdge(s1, s2);
            graph.AddEdge(s1, s3);
            graph.AddEdge(s2, c4);

            graph.AddEdge(t1, t2);
            graph.AddEdge(t1, t3);
            graph.AddEdge(t3, c4);


            var result = TreesAndGraphs.TreesAndGraphs.BreadthFirstSearch(s1, t1, graph, (n, r) => { });

            //expected result would be s1-s2-c4-t3-t1
            Node<int>[] expected = [s1, s2, c4, t3, t1];

            Assert.AreEqual(expected.Length, result.Length);

            CollectionAssert.AreEqual(expected.Select(n => n.Value).ToArray(), result.Select(n => n.Value).ToArray());
        }


        [TestMethod]

        public void TestBreadthFirstSearchNotFound()
        {
            //this graph would be:
            // s1->s2
            // s1->s3
            // s2->c4


            //this graph would be:
            // t1->t2
            // t1->t3
            // t3->c4

            //build some nodes
            var s1 = new Node<int>(1);
            var s2 = new Node<int>(2);
            var s3 = new Node<int>(3);
            var c4 = new Node<int>(4);

            var t1 = new Node<int>(11);
            var t2 = new Node<int>(12);
            var t3 = new Node<int>(13);


            var graph = new MyGraph<int>([s1, s2, s3, c4, t1, t2, t3], true);

            graph.AddEdge(s1, s2);
            graph.AddEdge(s1, s3);
            graph.AddEdge(s2, c4);

            graph.AddEdge(t1, t2);
            graph.AddEdge(t1, t3);

            // remove next statement, so no connection
            //graph.AddEdge(t3, c4);

            var result = TreesAndGraphs.TreesAndGraphs.BreadthFirstSearch(s1, t1, graph, (n, r) => { });

            //expected result would be s1-s2-c4-t3-t1
            Node<int>[] expected = [];

            Assert.AreEqual(expected.Length, result.Length);

            CollectionAssert.AreEqual(expected.Select(n => n.Value).ToArray(), result.Select(n => n.Value).ToArray());
        }



        [TestMethod]
        public void TestMinimalTree()
        {

            int [] originalNodes = [1, 2, 3, 4, 5, 6];

            var result = TreesAndGraphs.TreesAndGraphs.GetMinimalTree(originalNodes);

            var resultNodes =  new List<Node<int>>();
            var fn =TreesAndGraphs.TreesAndGraphs.CollectInOrder(resultNodes);
            
            //if the algorithm worked then an in order traversal would give an ordered array. 
            TreesAndGraphs.TreesAndGraphs.InOrderTraversal(result, fn);

            CollectionAssert.AreEqual(resultNodes.Select(n => n.Value).ToArray(), originalNodes);
            

        }

    }
}


