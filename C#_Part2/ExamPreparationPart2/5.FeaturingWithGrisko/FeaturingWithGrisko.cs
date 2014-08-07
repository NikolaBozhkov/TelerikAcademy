using System;
using System.Text;
using System.Collections.Generic;

class FeaturingWithGrisko
{
    static int count = 0;

    static void Main()
    {
        char[] charArray = Console.ReadLine().ToCharArray();
        Array.Sort(charArray);
        do
        {
            if (IsValid(charArray))
            {
                count++;
            }
        } 
        while (NextPermutation(charArray));

        Console.WriteLine(count);       
    }

    private static bool NextPermutation(char[] charArray)
    {
        /*
         Knuths
         1. Find the largest index j such that a[j] < a[j + 1]. If no such index exists, the permutation is the last permutation.
         2. Find the largest index l such that a[j] < a[l]. Since j + 1 is such an index, l is well defined and satisfies j < l.
         3. Swap a[j] with a[l].
         4. Reverse the sequence from a[j + 1] up to and including the final element a[n].

         */
        var largestIndex = -1;
        for (var i = charArray.Length - 2; i >= 0; i--)
        {
            if (charArray[i] < charArray[i + 1])
            {
                largestIndex = i;
                break;
            }
        }

        if (largestIndex < 0) return false;

        var largestIndex2 = -1;
        for (var i = charArray.Length - 1; i >= 0; i--)
        {
            if (charArray[largestIndex] < charArray[i])
            {
                largestIndex2 = i;
                break;
            }
        }

        var tmp = charArray[largestIndex];
        charArray[largestIndex] = charArray[largestIndex2];
        charArray[largestIndex2] = tmp;

        for (int i = largestIndex + 1, j = charArray.Length - 1; i < j; i++, j--)
        {
            tmp = charArray[i];
            charArray[i] = charArray[j];
            charArray[j] = tmp;
        }

        return true;
    }

    private static bool IsValid(char[] word)
    {
        for (int i = 0; i < word.Length - 1; i++)
        {
            if (word[i] == word[i + 1])
            {
                return false;
            }
        }

        return true;
    }
}