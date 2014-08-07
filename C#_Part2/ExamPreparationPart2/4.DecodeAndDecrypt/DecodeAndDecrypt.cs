using System;
using System.Text;
using System.Collections.Generic;

class DecodeAndDecrypt
{
    static void Main()
    {
        // input
        string input = Console.ReadLine();
        var digits = new List<int>();
        for (int i = input.Length - 1; i >= 0; i--)
        {
            if (char.IsDigit(input[i]))
            {
                digits.Add(input[i] - '0');
            }
            else
            {
                break;
            }
        }

        // Length of the cypher
        digits.Reverse();
        int lengthOfCypher = 0;
        for (int i = 0; i < digits.Count; i++)
        {
            lengthOfCypher *= 10;
            lengthOfCypher += digits[i];
        }

        // Encoded message
        string encodedMessage = input.Substring(0, input.Length - digits.Count);
        string decodedMessage = Decode(encodedMessage);

        // Encrypted message and cypher
        string encryptedMessage = decodedMessage.Substring(0, decodedMessage.Length - lengthOfCypher);
        string cypher = decodedMessage.Substring(decodedMessage.Length - lengthOfCypher, lengthOfCypher);

        // Result
        Console.WriteLine(Decrypt(encryptedMessage, cypher));

    }

    public static string Decrypt(string message, string cypher)
    {
        StringBuilder result = new StringBuilder(message);
        var steps = Math.Max(message.Length, cypher.Length);
        for (int i = 0; i < steps; i++)
        {
            int messageIndex = i % message.Length;
            int cypherIndex = i % cypher.Length;
            result[messageIndex] = (char)(((result[messageIndex] - 'A') ^ (cypher[cypherIndex] - 'A')) + 'A');
        }

        return result.ToString();
    }

    public static string Decode(string message)
    {
        StringBuilder result = new StringBuilder();
        int count = 0;
        foreach (char ch in message)
        {
            if (char.IsDigit(ch))
            {
                count *= 10;
                count += int.Parse(ch.ToString());
            }
            else
            {
                if (count == 0)
                {
                    result.Append(ch);
                }
                else
                {
                    result.Append(ch, count);
                    count = 0;
                }
            }
        }

        return result.ToString();
    }
}