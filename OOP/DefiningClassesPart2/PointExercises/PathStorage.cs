using System;
using System.IO;
using System.Linq;

public static class PathStorage
{
    // Methods
    public static void Save(Path path, string location)
    {
        using (StreamWriter writer = new StreamWriter(location))
        {
            int length = path.ToList().Count;
            decimal increase = 100m / length;
            decimal percent = 0;
            int cursorTop = Console.CursorTop;
            int cursorLeft = Console.CursorLeft;
            Console.Write("{0:f2} %", percent);

            foreach (Point3D point in path.ToList())
            {
                // I added percentage, because longer paths take a while : )
                writer.WriteLine("({0}, {1}, {2})(X, Y, Z)", point.X, point.Y, point.Z);
                percent += increase;
                Console.SetCursorPosition(cursorLeft, cursorTop);
                Console.Write("{0:f2} %", percent);
            }

            Console.WriteLine();
        }
    }

    public static Path Load(string location)
    {
        Path path = new Path();
        using (StreamReader reader = new StreamReader(location))
        {
            string line = reader.ReadLine();
            decimal lineNumber = 0;
            int cursorTop = Console.CursorTop;
            int cursorLeft = Console.CursorLeft;
            Console.Write("Current line: {0}", lineNumber);

            while (line != null)
            {
                // The precentage is harder here as I don't know how many lines the file has
                // Get the values from the line, format: "({0}, {1}, {2})(X, Y, Z)"
                string[] points = line.Substring(1, line.Length - 11).Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                path.AddPoint(new Point3D(int.Parse(points[0]), int.Parse(points[1]), int.Parse(points[2])));
                lineNumber++;
                Console.SetCursorPosition(cursorLeft, cursorTop);
                Console.Write("Current line: {0}", lineNumber);
                line = reader.ReadLine();
            }

            Console.Write(" Finished\n");
        }

        return path;
    }
}