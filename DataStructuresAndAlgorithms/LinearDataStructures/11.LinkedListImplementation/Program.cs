namespace LinkedListImplementation
{
    public class Program
    {
        public static void Main()
        {
            var list = new LinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);
            list.Add(6);

            var nextItem = list.FirstItem;
            while (nextItem != null)
            {
                System.Console.WriteLine(nextItem.Value);
                nextItem = nextItem.NextItem;
            }
        }
    }
}
