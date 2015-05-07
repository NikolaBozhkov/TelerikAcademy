namespace ShapesTask
{
    using System;

    public abstract class Shape
    {
        // Fields
        private double width;
        private double height;

        // Constructors
        public Shape(double width, double height)
        {
            this.width = width;
            this.height = height;
        }

        // Properties
        public double Width
        {
            get
            {
                return this.width;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("width cannot be less than 0.");
                }

                this.width = value;
            }
        }

        public double Height
        {
            get
            {
                return this.height;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("width cannot be less than 0.");
                }

                this.height = value;
            }
        }

        // Methods
        public abstract double CalculateSurface();
    }
}