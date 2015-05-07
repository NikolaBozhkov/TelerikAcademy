using System;

public static class CalculateDistance
{
    // Methods
    public static double Between3DPoints(Point3D pointA, Point3D pointB)
    {
        double xDist = pointA.X - pointB.X;
        double yDist = pointA.Y - pointB.Y;
        double zDist = pointA.Z - pointB.Z;

        return Math.Sqrt(xDist * xDist + yDist * yDist + zDist * zDist);
    }
}