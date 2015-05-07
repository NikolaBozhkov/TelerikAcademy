namespace Methods
{
    using System;

    public class Triangle
    {
        private int sideA;
        private int sideB;
        private int sideC;

        public Triangle(int sideA, int sideB, int sideC)
        {
            if (!CanFormTriangle(sideA, sideB, sideC))
            {
                throw new ArgumentException("Sides should form a valid triangle.");
            }

            this.SideA = sideA;
            this.SideB = sideB;
            this.SideC = sideC;
        }

        public int SideA
        {
            get
            {
                return this.sideA;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Side must be a number greater than 0.");
                }

                this.sideA = value;
            }
        }
        public int SideB
        {
            get
            {
                return this.sideB;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Side must be a number greater than 0.");
                }

                this.sideB = value;
            }
        }

        public int SideC
        {
            get
            {
                return this.sideC;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Side must be a number greater than 0.");
                }

                this.sideC = value;
            }
        }


        private static bool CanFormTriangle(int sideA, int sideB, int sideC)
        {
            if (sideA + sideB <= sideC
                || sideA + sideC <= sideB
                || sideB + sideC <= sideA)
            {
                return false;
            }

            return true;
        }

        public double CalculateArea()
        {
            double halfPerimeter = (this.SideA + this.SideB + this.SideC) / 2;

            double area = Math.Sqrt(halfPerimeter * (halfPerimeter - this.SideA) 
                * (halfPerimeter - this.SideB) * (halfPerimeter - this.SideC));

            return area;
        }
    }
}
