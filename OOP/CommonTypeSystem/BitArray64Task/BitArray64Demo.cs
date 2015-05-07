namespace BitArray64Task
{
    using System;

    public class BitArray64Demo
    {
        public static void Main()
        {
            BitArray64 arr1 = new BitArray64(5);
            foreach (var bit in arr1)
            {
                Console.Write(bit + " ");
            }

            Console.WriteLine();

            BitArray64 arr2 = new BitArray64(5);
            Console.WriteLine("arr1 hash code: {0}\narr2 hash code: {1}",
                arr1.GetHashCode(), arr2.GetHashCode());

            Console.WriteLine("arr1 == arr2: {0}\narr1 != arr2: {1}\narr1.Equals(arr2): {2}",
                arr1 == arr2, arr1 != arr2, arr1.Equals(arr2));

            arr2[50] = 1;
            Console.WriteLine("After change, arr1 = 5, arr2 = {0}\narr1 == arr2: {1}\narr1 != arr2: {2}\narr1.Equals(arr2): {3}",
                arr2.Value, arr1 == arr2, arr1 != arr2, arr1.Equals(arr2));

            Console.WriteLine("arr1 hash code: {0}\narr2 hash code: {1}",
                arr1.GetHashCode(), arr2.GetHashCode());
        }
    }
}