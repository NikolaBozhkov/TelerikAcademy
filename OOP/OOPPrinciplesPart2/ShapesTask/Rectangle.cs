namespace ShapesTask
{
    using System;

    public class Rectangle : Shape
    {
        // Constructors
        public Rectangle(double width, double height)
            : base(width, height)
        {
        }

        // Methods
        public override double CalculateSurface()
        {
            return this.Height * this.Width;
        }
    }
}