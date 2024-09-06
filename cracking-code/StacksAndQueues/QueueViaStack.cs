

using System.Diagnostics;
using System.Numerics;

namespace StacksAndQueues
{
    /*
      Cracking the coding interview)
    */

    public class MyQueue<T>() {


        MyStack<T>? enqueueStack;
        MyStack<T>? dequeueStack;

        public T Remove() {
            
            dequeueStack ??= new MyStack<T>();

            if (!dequeueStack.IsEmpty())
            {
                return dequeueStack.Pop();
            }
            else { // maybe expand 
                
                if (enqueueStack!.IsEmpty()) { 
                  throw new InvalidOperationException("Empty Stack should not be pop");
                }
                
                while (!enqueueStack.IsEmpty())
                {
                    dequeueStack.Push(enqueueStack.Pop());

                }
                return dequeueStack.Pop();
            } 
        }

        public bool IsEmpty() {
            return (enqueueStack?.IsEmpty()??true)  && (dequeueStack?.IsEmpty()??true);
        }
        
        public T Add (T elem) {
            enqueueStack ??= new MyStack<T>();
            return enqueueStack.Push(elem); 
        }
    }

    public partial class StacksAndQueues
    {

        public static MyQueue<T> QueueOf<T>(params T[] ints)
        {
            var stack = new MyQueue< T>();
            for (int i = 0; i < ints.Length; i++)
            {
                stack.Add(ints[i]);
            }
            return stack;
        }
    }

}

