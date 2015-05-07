using System;

// Using extension methods, because idk what else works and they are elegant : )
public static class GenericListExtensions
{
    public static T Min<T>(this GenericList<T> list)
        where T : IComparable, IComparable<T>
    {
        if (list == null || list.Count == 0)
        {
            throw new InvalidOperationException("Cannot call Min<T>() on empty or null list.");
        }

        T min = list[0];
        for (int index = 1; index < list.Count; index++)
        {
            if (list[index].CompareTo(min) < 0)
            {
                min = list[index];
            }
        }

        return min;
    }

    public static T Max<T>(this GenericList<T> list)
        where T : IComparable, IComparable<T>
    {
        if (list == null || list.Count == 0)
        {
            throw new InvalidOperationException("Cannot call Max<T>() on empty or null list.");
        }

        T max = list[0];
        for (int index = 1; index < list.Count; index++)
        {
            if (list[index].CompareTo(max) > 0)
            {
                max = list[index];
            }
        }

        return max;
    }
}