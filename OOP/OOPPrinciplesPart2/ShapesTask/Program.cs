namespace ShapesTask
{
    public class Program
    {
        public static void Main()
        {
            Shape[] shapes =
            {
                new Triangle(10, 2.5),
                new Triangle(11.5, 5),
                new Rectangle(12, 6),
                new Rectangle(13, 5.5),
                new Circle(4),
                new Circle(5.5)
            };

            foreach (var shape in shapes)
            {
                System.Console.WriteLine("{0}({1}, {2}) has area: {3}",
                    shape.GetType().Name, shape.Width, shape.Height, shape.CalculateSurface());
            }
        }
    }
}