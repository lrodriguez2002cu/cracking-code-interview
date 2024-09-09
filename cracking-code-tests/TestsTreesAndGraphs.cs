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
            var n5= new Node<int>(5);
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

            var result = TreesAndGraphs.TreesAndGraphs.RouteBetweenDephFirst(graph, nodes[sn-1], nodes[tn-1]);

            Assert.AreEqual(expected, result);
        }



    }

}


