using TreesAndGraphs;

namespace cracking_code_tests
{
    [TestClass]
    public class TreesAndGraphsTests
    {
        [TestMethod]
        public void TestGraphBasics()
        {

            //this graph would be:
            // 1->2->4->3

            //build some nodes
            var n1 = new Node<int>(1);
            var n2 = new Node<int>(2);
            var n3 = new Node<int>(3);
            var n4 = new Node<int>(4);

            n1.Children =  new Node<int>[] { n2 };
            n2.Children =  new Node<int>[] { n4 };
            n4.Children = new Node<int>[]  { n3 };

            var graph = new MyGraph<int>(new Node<int>[] { n1, n2, n3, n4 });

            TreesAndGraphs.TreesAndGraphs.PrintGraphDepthFirst(graph);
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

            n1.Children = new Node<int>[] { n2 };
            n2.Children = new Node<int>[] { n4 };
            n4.Children = new Node<int>[] { n3 };

            var graph = new MyGraph<int>(new Node<int>[] { n1, n2, n3, n4 });

            var result = TreesAndGraphs.TreesAndGraphs.RouteBetween(graph, nodes[sn], nodes[tn]);

            Assert.AreEqual(expected, result);
        }


        
    }

}


