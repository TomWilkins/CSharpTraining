using System;
using System.Collections;
using System.Collections.Generic;

namespace csharp_intermediate_exercises
{
    partial class Program
    {
        public class Stack
        {

            private List<object> _stack = new List<object>();


            public void Push(object obj)
            {
                if (obj == null)
                    throw new InvalidOperationException("obj cannot be null.");

                _stack.Add(obj);
                Console.WriteLine("Item was added to the stack.");
            }

            public object Pop()
            {
                if (_stack.Count == 0)
                    throw new InvalidOperationException("Stack is empty.");
                
                object obj = _stack[_stack.Count - 1];

                // We don't need to check and see if the item was found in the list
                // given we just got it from the list.
                _stack.Remove(obj);

                Console.WriteLine("Item was removed from the stack.");

                return obj;
            }

            public void clear()
            {
                _stack.Clear();
            }


        }
    }
}
