

using System.Diagnostics;
using System.Numerics;

namespace StacksAndQueues
{
    /*
      Cracking the coding interview)
    */

    public class MyStack<T>(int capacity = 100) {

        private int topIndex = -1;

        T[]? elems;

        public T Peek() {
            if (topIndex >= 0 &&  elems is not null)
            {
                var e = elems[topIndex];
                return e;
            }
            else
            { // maybe expand 
                throw new InvalidOperationException("Empty Stack should not be peeked");
            }
        }

        public bool IsEmpty() { 
           return topIndex < 0;
        }

        public T Pop() {

            if (topIndex >= 0 && elems is not null)
            {
                var e= elems[topIndex];
                topIndex--;
                return e;
            }
            else { // maybe expand 
               throw new InvalidOperationException("Empty Stack should not be pop");
            } 
        }
        
        public T Push (T elem) {

            elems ??= new T[capacity];

            if (topIndex < capacity - 1) { 
               elems [++topIndex] = elem;
            }
            else throw new IndexOutOfRangeException ("Exceeded the capacity of the stack.");

            return elems [topIndex];
        }
    } 

    public partial class StacksAndQueues
    {

        public static MyStack<T> StackOf<T>(params T[] ints){
            var stack = new MyStack<T>();
            for (int i = 0; i < ints.Length; i++) { 
               stack.Push (ints [i]);
            }
            return stack;
        }

        public static bool AreEqualStacks<T>(MyStack<T> stack1, MyStack<T> stack2) where T: IComparable{
            
            var equal = true;
            while (!stack1.IsEmpty() || !stack2.IsEmpty())
            { 
                equal= equal && (stack1.Pop().CompareTo(stack2.Pop()) == 0);
            } 

            return equal && stack1.IsEmpty() &&  stack2.IsEmpty();
        }

        public static void SortStack<T>(MyStack<T> stack) where T : IComparable{ 
            MyStack<T> tempStack =  new MyStack<T>(100);

            int pushedCounter = 0;
            //sort the stack

            while (!stack.IsEmpty()) {

                var currentValue = stack.Pop();

                if (tempStack.IsEmpty() || (tempStack.Peek().CompareTo(currentValue) <= 0))
                {
                    tempStack.Push(currentValue);
                }
                else {
                    //might need to pop temp stack while peek is > current value 
                    while (!tempStack.IsEmpty() && tempStack.Peek().CompareTo(currentValue) >0) {
                        stack.Push(tempStack.Pop());
                        pushedCounter++;
                    }

                    //push the current value in temp stack
                    tempStack.Push(currentValue);

                    while (pushedCounter > 0)
                    {
                        tempStack.Push(stack.Pop());
                        pushedCounter--;
                    }                    
                }
            }

            // fill back the stack and the elements should be in the appropriate order
            while (!tempStack.IsEmpty()) { 
              stack.Push (tempStack.Pop());
            }
        }

    }

}

