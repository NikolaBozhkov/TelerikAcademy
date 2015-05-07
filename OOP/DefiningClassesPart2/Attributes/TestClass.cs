using System;
using System.Linq;

[Version("1.0")]
public class TestClass
{
    public static void Main()
    {
        // Check AttributeExtensions class to see what I did
        string version = typeof(TestClass).GetAttributeValue((VersionAttribute verAtt) => verAtt.Version);
        Console.WriteLine("The version of this class is {0}", version);
    }
}