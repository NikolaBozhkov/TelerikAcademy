namespace Methods
{
    using System;

    public class Line
    {
        public Point PointA { get; set; }
        public Point PointB { get; set; }

        public Line(Point pointA, Point pointB)
        {
            this.PointA = pointA;
            this.PointB = pointB;
        }

        public double Length
        {
            get
            {
                double distance = Math.Sqrt(
                    (this.PointA.X - this.PointB.X) * (this.PointA.X - this.PointB.X)
                    + (this.PointA.Y - this.PointB.Y) * (this.PointA.Y - this.PointB.Y));

                return distance;
            }
        }

        public bool IsHorizontal()
        {
            return this.PointA.Y == this.PointB.Y;
        }

        public bool IsVertical()
        {
            return this.PointA.X == this.PointB.X;
        }
    }
}
