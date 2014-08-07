// Declare five variables choosing for each of them the most appropriate of the types
// byte, sbyte, short, ushort, int, uint, long, ulong to represent the following values: 52130, -115, 4825932, 97, -10000.

using System;

public class DeclareFiveVariables
{
    public static void Main()
    {
        ushort ushortValue = 52130;
        sbyte sbyteValue = -115;
        int intValue = 4825932;
        byte byteValue = 97;
        short shortValue = -10000;

        Console.WriteLine("ushort = {0}\nsbyte = {1}\nint = {2}\nbyte = {3}\nshort = {4}", 
            ushortValue, sbyteValue, intValue, byteValue, shortValue);
    }
}
