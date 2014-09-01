namespace FindAllExeFiles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.IO;

    public class FindAllExeFiles
    {
        public static void Main()
        {
            Console.Write("Enter a root(test with: D:\\Projects): ");
            var startPoint = Console.ReadLine();

            var directories = new Stack<string>();
            directories.Push(startPoint);

            while (directories.Count > 0)
            {
                var current = directories.Pop();

                var currentFiles = Directory.EnumerateFiles(current, "*.exe");
                foreach (var file in currentFiles)
                {
                    Console.WriteLine(file);
                }

                var children = Directory.EnumerateDirectories(current);

                foreach (var child in children)
                {
                    directories.Push(child);
                }
            }
        }
    }
}
