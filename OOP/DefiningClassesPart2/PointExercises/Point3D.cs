using System;

public struct Point3D
{
    // Fields
    public int X { get; set; }
    public int Y { get; set; }
    public int Z { get; set; }
    private static readonly Point3D point0 = new Point3D(0, 0, 0);

    // Constructors
    public Point3D(int x, int y, int z)
        : this()
    {
        this.X = x;
        this.Y = y;
        this.Z = z;
    }

    // Properties
    public static Point3D Point0
    {
        get { return point0; }
    }

    // Methods
    public override string ToString()
    {
        return string.Format("X-{0} Y-{1} Z-{2}", this.X, this.Y, this.Z);
    }
}