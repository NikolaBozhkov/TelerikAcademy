namespace CohesionAndCoupling
{
    using System;

    public class Cuboid
    {
        private double width;
        private double height;
        private double depth;

        public Cuboid(double width, double height, double depth)
        {
            this.Width = width;
            this.Height = height;
            this.Depth = depth;
        }

        public double Width
        {
            get
            {
                return this.width;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Width cannot be negative or 0.");
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
                if (value <= 0)
                {
                    throw new ArgumentException("Height cannot be negative or 0.");
                }

                this.height = value;
            }
        }

        public double Depth
        {
            get
            {
                return this.depth;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Depth cannot be negative or 0.");
                }

                this.depth = value;
            }
        }

        public double CalcVolume()
        {
            double volume = this.Width * this.Height * this.Depth;
            return volume;
        }

        public double WidthHeightDiagonal()
        {
            double length = CalculateDiagonal(this.Width, this.Height);

            return length;
        }

        public double WidthDepthDiagonal()
        {
            double length = CalculateDiagonal(this.Width, this.Depth);

            return length;
        }

        public double HeightDepthDiagonal()
        {
            double length = CalculateDiagonal(this.Height, this.Depth);

            return length;
        }

        public double WidthHeightDepthDiagonal()
        {
            double length = Math.Sqrt(
                CalculateDiagonal(this.Width, this.Depth) +
                (this.Height * this.Height));

            return length;
        }

        private static double CalculateDiagonal(double sideA, double sideB)
        {
            double length = Math.Sqrt(
                (sideA * sideA) 
                + (sideB * sideB));

            return length;
        }
    }
}
