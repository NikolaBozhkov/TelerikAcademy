using System;
using System.Collections.Generic;

public class Path
{
    // Fields
    private List<Point3D> path = new List<Point3D>();

    // Constructors
    public Path()
    {
    }

    public Path(List<Point3D> path)
    {
        this.path = path;
    }

    // Methods
    public void AddPoint(Point3D point)
    {
        this.path.Add(point);
    }

    public void RemovePoint(int index)
    {
        this.path.RemoveAt(index);
    }

    public void RemovePoint(Point3D point)
    {
        this.path.Remove(point);
    }

    public List<Point3D> ToList()
    {
        return this.path;
    }
}