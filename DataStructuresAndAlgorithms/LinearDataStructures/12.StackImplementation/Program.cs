namespace StackImplementation
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            var stack = new Stack<int>();

            for (int i = 0; i < 150; i++)
            {
                stack.Push(i);
            }

            while (stack.Count > 0)
            {
                Console.WriteLine(stack.Pop());
            }
        }
    }
}
