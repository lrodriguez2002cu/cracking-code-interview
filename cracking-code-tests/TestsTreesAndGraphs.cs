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


        [TestMethod]
        public void TestListOfDepths()
        {

            int[] originalNodes = [1, 2, 3, 4, 5, 6];

            var result = TreesAndGraphs.TreesAndGraphs.GetMinimalTree(originalNodes);

            var listOfDepths = TreesAndGraphs.TreesAndGraphs.ListOfDepths(result);

            Assert.AreEqual(listOfDepths[0].Count, 1);
            Assert.AreEqual(listOfDepths[1].Count, 2);
            Assert.AreEqual(listOfDepths[2].Count, 3);

        }


        [TestMethod]
        public void TestCheckBalanced()
        {

            int[] originalNodes = [1, 2, 3, 4, 5, 6];

            var result = TreesAndGraphs.TreesAndGraphs.GetMinimalTree(originalNodes);

            var balanced = TreesAndGraphs.TreesAndGraphs.CheckBalanced(result);

            Assert.IsTrue(balanced);

        }


        [TestMethod]
        public void TestCheckBalancedOnAnUnbalancedTree()
        {

            //build a linear tree, just a root with a child and a child of this 1->2->3
            BinaryTreeNode<int> childOfChildOfRoot = new BinaryTreeNode<int>(3);
            BinaryTreeNode<int> childOfroot = new BinaryTreeNode<int>(2, null, childOfChildOfRoot);
            BinaryTreeNode<int> root = new BinaryTreeNode<int>(1, null, childOfroot);

            var balanced = TreesAndGraphs.TreesAndGraphs.CheckBalanced(new BinaryTree<int>(root));

            Assert.IsFalse(balanced);

        }



        [TestMethod]
        public void TestValidateBST()
        {

            int[] originalNodes = [1, 2, 3, 4, 5, 6];

            var result = TreesAndGraphs.TreesAndGraphs.GetMinimalTree(originalNodes);

            var isBST = TreesAndGraphs.TreesAndGraphs.ValidateBST(result);

            Assert.IsTrue(isBST);

        }


        [TestMethod]
        public void TestIsNotABST()
        {

            //build a linear tree, just a root with a child and a child of this 1->2->3 (all of them the left child)
            BinaryTreeNode<int> childOfChildOfRoot = new BinaryTreeNode<int>(3);
            BinaryTreeNode<int> childOfRoot = new BinaryTreeNode<int>(2, null, childOfChildOfRoot);
            BinaryTreeNode<int> root = new BinaryTreeNode<int>(1, null, childOfRoot);

            var isBST = TreesAndGraphs.TreesAndGraphs.ValidateBST(new BinaryTree<int>(root));

            Assert.IsFalse(isBST);

        }

        [TestMethod]
        public void TestIsABSTNonBalanced()
        {

            //build a linear tree, just a root with a child and a child of this 1->2->3 (all of them the right child)
            BinaryTreeNode<int> childOfChildOfRoot = new BinaryTreeNode<int>(3);
            BinaryTreeNode<int> childOfRoot = new BinaryTreeNode<int>(2, childOfChildOfRoot, null);
            BinaryTreeNode<int> root = new BinaryTreeNode<int>(1, childOfRoot, null);

            var isBST = TreesAndGraphs.TreesAndGraphs.ValidateBST(new BinaryTree<int>(root));

            Assert.IsTrue(isBST);

        }

        [TestMethod]
        public void TestBuildOrderSimple()
        {
            
            var prjsInOrder = TreesAndGraphs.TreesAndGraphs.BuildOrder([1, 2, 3, 4, 5], [(1, 2), (2, 3), (3, 4), (4, 5)]);

            CollectionAssert.AreEqual(new int[] { 5, 4, 3, 2, 1 }, prjsInOrder);

        }



        [TestMethod]
        public void TestBuildOrderComplex()
        {
            //1->2
            //1->3
            //3->4
            //2->4
            //3->5
            //5->4
            var prjsInOrder = TreesAndGraphs.TreesAndGraphs.BuildOrder([1, 2, 3, 4, 5], [(1, 2), (1, 3), (3, 4), (2, 4), (3, 5), (5, 4) ]);

            //CollectionAssert.AreEqual(new int[] { 4, 5, 2, 3, 1 }, prjsInOrder);
            CollectionAssert.AreEqual(new int[] { 4, 2, 5, 3, 1 }, prjsInOrder);

        }
        
        [TestMethod]
        public void TestBuildOrderFailsDueToCycle()
        {
            //1->2
            //1->3
            //3->4
            //4->1

            var ex= Assert.ThrowsException<Exception>(() => { TreesAndGraphs.TreesAndGraphs.BuildOrder([1, 2, 3, 4], [(1, 2), (1, 3), (3, 4), (4, 1)]); });

            Assert.IsTrue(ex.Message.Contains("A cycle in the build order was found"));
            

        }

    }
}


