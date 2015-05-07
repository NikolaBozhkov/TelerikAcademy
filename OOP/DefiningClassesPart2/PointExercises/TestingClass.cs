using System;

class TestingClass
{
    static void Main()
    {
        // Some testing of save and load
        Point3D point = new Point3D(1, 2, 3);
        Path path = new Path();
        for (int i = 0; i < 50000; i++)
        {
            path.AddPoint(point);
        }

        PathStorage.Save(path, "path.txt");
        Path loadedPath = PathStorage.Load("path.txt");
    }
}