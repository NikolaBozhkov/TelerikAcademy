// Write a program that encodes and decodes a string using given encryption key (cipher). 
// The key consists of a sequence of characters. The encoding/decoding is done by performing XOR 
// (exclusive or) operation over the first letter of the string with the first of the key, the second
// – with the second, etc. When the last key character is reached, the next is the first.

using System;
using System.Text;

public class EncodeDecodeString
{
    public static string EncryptDecrypt(string message, string key)
    {
        var result = new StringBuilder(message.Length);
        for (int i = 0; i < message.Length; i++)
        {
            result.Append((char)(message[i] ^ key[i % key.Length]));
        }

        return result.ToString();
    }

    public static void Main()
    {
        string message = "This is a message, those who can decrypt it will posses the power!";
        string key = "power";
        string encrypted = EncryptDecrypt(message, key);
        Console.WriteLine("Encrypted: ");
        Console.WriteLine(encrypted);
        Console.WriteLine("Decrypted: ");
        Console.WriteLine(EncryptDecrypt(encrypted, key));
    }    
}