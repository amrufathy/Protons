using System;

namespace StackSession
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            MyStack stack = new MyStack();

            // Add 10 numbers to the stack
            int numCount = 10;
            for (int i = 0; i < numCount; i++)
            {
                stack.Push(i);
                Console.WriteLine("Pushed:" + i);
            }

            Console.WriteLine(".....................");

            // Retrieve the 10 numbers ( will be in reversed order )
            int bound = stack.Count();

            for (int i = 0; i < bound; i++)
            {
                Console.WriteLine("Popped:" + stack.Pop());
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}