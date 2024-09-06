using StacksAndQueues;

namespace cracking_code_tests
{
    [TestClass]
    public class StacksAndQueuesTests
    {
        [TestMethod]
        public void TestStackBasics()
        {
            var stack = new StacksAndQueues.MyStack<int>(100);

            Assert.IsTrue(stack.IsEmpty());

            Assert.ThrowsException<InvalidOperationException>(() => { stack.Pop(); });

            Assert.AreEqual(stack.Push(1), 1);

            Assert.AreEqual(stack.Peek(), 1);

            Assert.AreEqual(stack.Pop(), 1);

            Assert.AreEqual(stack.IsEmpty(), true);



            Assert.ThrowsException<InvalidOperationException>(() => { stack.Peek(); });

            // pushing and popping

            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            Assert.IsTrue(!stack.IsEmpty());

            Assert.IsTrue(stack.Pop() == 3);
            Assert.IsTrue(stack.Pop() == 2);
            Assert.IsTrue(stack.Pop() == 1);

            Assert.IsTrue(stack.IsEmpty());

        }


        [TestMethod]
        [DataRow(new int[] { 2, 9, 5 }, new int[] { 9, 5, 2 })]

        public void TestSortStack(int[] values1, int [] expectedStack)
        {
            var stack = StacksAndQueues.StacksAndQueues.StackOf(values1);
            
            StacksAndQueues.StacksAndQueues.StackOf(values1);
            
            StacksAndQueues.StacksAndQueues.SortStack(stack);

            var expected = StacksAndQueues.StacksAndQueues.StackOf(expectedStack);

            Assert.IsTrue(StacksAndQueues.StacksAndQueues.AreEqualStacks(expected, stack));

        }


        [TestMethod]
        [DataRow(new int[] { 2, 9, 5 }, new int[] { 2, 9, 5})]

        public void TestQueueViaStack(int[] values1, int[] expectedValues)
        {
            var queue = StacksAndQueues.StacksAndQueues.QueueOf(values1);

            Assert.IsTrue(!queue.IsEmpty());

            var i = 0;
            
            while (!queue.IsEmpty()) { 
              Assert.AreEqual(queue.Remove(), expectedValues[i]);
              i++;
            }

            Assert.IsTrue(i==3);
        }

    }

}


