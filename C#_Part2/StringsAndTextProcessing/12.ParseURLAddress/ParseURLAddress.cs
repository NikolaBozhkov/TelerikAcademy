﻿// Write a program that parses an URL address given in the format:
// [protocol]://[server]/[resource]
// and extracts from it the [protocol], [server] and [resource] elements. 
// For example from the URL http://www.devbg.org/forum/index.php the following information should be extracted:
// [protocol] = "http"
// [server] = "www.devbg.org"
// [resource] = "/forum/index.php"

using System;
using System.Text.RegularExpressions;

public class ParseURLAddress
{
    public static void Main()
    {
        string url = "http://www.devbg.org/forum/index.php";
        var elements = Regex.Match(url, "(.*)://(.*?)(/.*)").Groups;
        foreach (var elem in elements)
        {
            Console.WriteLine(elem);
        }
    }
}