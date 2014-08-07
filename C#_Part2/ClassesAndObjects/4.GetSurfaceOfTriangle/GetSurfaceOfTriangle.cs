// Write methods that calculate the surface of a triangle by given:
// Side and an altitude to it; Three sides; Two sides and an angle between them. Use System.Math.

using System;

public class GetSurfaceOfTriangle
{
    public static double BySideAndAltitude(double side, double altitude)
    {
        // I didn't know where to use Math here...
        double surface;
        surface = (side * altitude) / 2;
        return surface;
    }

    public static double ByThreeSides(double sideA, double sideB, double sideC)
    {
        double surface = 0;
        double halfSum = (sideA + sideB + sideC) / 2;
        double preResult = halfSum * (halfSum - sideA) * (halfSum - sideB) * (halfSum - sideC);
        surface = Math.Sqrt(preResult);
        return surface;
    }

    public static double ByTwoSidesAndAngle(double sideA, double sideB, double angle)
    {
        double surface;
        double sinA = Math.Sin(angle);
        surface = (sideA * sideB * sinA) / 2;
        return surface;
    }

    public static void Main()
    {
        double sideA = 4;
        double sideB = 5;
        double sideC = 6;
        double alt = 7;
        double angle = 90;
        Console.WriteLine("The surface of a triangle with side {0} and altitude {1} is: {2}", sideA, alt, BySideAndAltitude(sideA, alt));
        Console.WriteLine("The surface of a triangle with side {0}, side {1} and side {2} is: {3}", sideA, sideB, sideC, ByThreeSides(sideA, sideB, sideC));
        Console.WriteLine("The surface of a triangle with side {0}, side {1}, and an angle inbetween {2} is:\n{3}", sideB, sideC, angle, ByTwoSidesAndAngle(sideB, sideC, angle));
    }
}