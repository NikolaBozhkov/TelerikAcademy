namespace ShapesTask
{
    using System;

    public class Circle : Shape
    {
        // Fields
        private double radius;

        // Constructors
        public Circle(double radius)
            : base(radius * 2, radius * 2)
        {
            this.radius = radius;
        }

        // Methods
        public override double CalculateSurface()
        {
            return Math.PI * this.radius * this.radius;
        }
    }
}
