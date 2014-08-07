using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class BBCode
{
    public static void Main()
    {
        string input = Console.ReadLine();
        Dictionary<int, string> code = new Dictionary<int, string>();
        Dictionary<string, int> variables = new Dictionary<string, int>(5);
        variables.Add("X", 0);
        variables.Add("Y", 0);
        variables.Add("Z", 0);
        variables.Add("W", 0);
        variables.Add("V", 0);
        while (input != "RUN" || input != "STOP")
        {
            input = string.Join(string.Empty, input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
            int lineNum = int.Parse(Regex.Match(input, "[0-9]*").Value);
            input = input.Remove(0, lineNum.ToString().Length);
            code.Add(lineNum, input);
        }
    }
}