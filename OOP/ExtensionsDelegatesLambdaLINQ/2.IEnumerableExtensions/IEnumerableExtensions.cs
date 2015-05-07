using System;
using System.Collections.Generic;

public static class IEnumerableExtensions
{
    private static T Reduce<T>(this IEnumerable<T> items, Func<dynamic, T, T> func, dynamic first = null)
    {
        IEnumerator<T> collection = items.GetEnumerator();

        collection.MoveNext();
        T previous = first ?? collection.Current;

        while (collection.MoveNext())
        {
            previous = func(previous, collection.Current);
        }

        return previous;
    }

    public static T Max<T>(this IEnumerable<T> items)
    {
        return items.Reduce((a, b) => a > b ? a : b);
    }

    public static T Min<T>(this IEnumerable<T> items)
    {
        return items.Reduce((a, b) => a < b ? a : b);
    }

    public static T Sum<T>(this IEnumerable<T> items)
    {
        return items.Reduce((a, b) => a + b);
    }

    public static T Product<T>(this IEnumerable<T> items)
    {
        return items.Reduce((a, b) => a * b);
    }

    public static int Count<T>(this IEnumerable<T> items)
    {
        // Here we don't need "a" or "b", but the function requires it
        // So we take the first item that we give as 1 and increase it
        return Convert.ToInt32(items.Reduce((a, _) => a + 1, 1));
    }

    public static double Average<T>(this IEnumerable<T> items)
    {
        return Convert.ToDouble(items.Sum()) / items.Count();
    }
}