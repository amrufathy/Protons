using System;
using System.Collections.Generic;

namespace StackSession
{
    public class MyStack
    {
        private List<int> data = new List<int>();

        public void Push(int item)
        {
            data.Add(item);
        }

        public int Pop()
        {
            // If the stack is empty, throw an exception ( error )
            if (data.Count == 0) throw new InvalidOperationException("Stack is empty");

            // Get the last element in the list
            int lastElementIndex = data.Count - 1;
            int retVal = data[lastElementIndex];

            // Remove the item from the stack
            data.RemoveAt(lastElementIndex);

            return retVal;
        }

        public int Count()
        {
            return data.Count;
        }
    }
}