using System;
using System.Text;

public static class StringBuilderExtensions
{
    public static StringBuilder Substring(
        this StringBuilder sb,
        int startIndex,
        int length)
    {
        // The easy way
        return new StringBuilder(sb.ToString().Substring(startIndex, length));

        // The hard way
        //StringBuilder result = new StringBuilder(length);
        //for (int i = index; i < length + index; i++)
        //{
        //    result.Append(sb[i]);
        //}

        //return result;
    }
}