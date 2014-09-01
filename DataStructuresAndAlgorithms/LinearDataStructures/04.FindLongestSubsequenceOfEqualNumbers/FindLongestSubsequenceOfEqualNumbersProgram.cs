namespace FindLongestSubsequenceOfEqualNumbers
{
    using System;
    using System.Collections.Generic;

    public class FindLongestSubsequenceOfEqualNumbersProgram
    {
        public static void Main()
        {
            var sequence = new List<int>()
            {
                1, 1, 3, 3, 2, 2, 2, 2
            };

            var subsequence = FindLongestSubsequenceOfEqualNumbers(sequence);

            Console.WriteLine("Longest subsequence -> [{0}]", string.Join(", ", subsequence));
        }

        public static List<int> FindLongestSubsequenceOfEqualNumbers(List<int> sequence)
        {
            var currentSubsequence = new List<int>();
            var bestSubsequence = new List<int>();

            for (int i = 1; i < sequence.Count; i++)
            {
                if (i == 1)
                {
                    currentSubsequence.Add(sequence[0]);
                }

                if (sequence[i] == sequence[i - 1])
                {
                    currentSubsequence.Add(sequence[i]);
                }
                
                if (sequence[i] != sequence[i - 1] || i == sequence.Count - 1)
                {
                    if (currentSubsequence.Count >= bestSubsequence.Count)
                    {
                        bestSubsequence = new List<int>(currentSubsequence);
                    }

                    currentSubsequence.Clear();
                    currentSubsequence.Add(sequence[i]);
                }
            }

            return bestSubsequence;
        }
    }
}
