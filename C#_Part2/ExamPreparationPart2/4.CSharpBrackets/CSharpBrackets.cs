using System;
using System.Text;
using System.Text.RegularExpressions;

class CSharpBrackets
{
    static void Main()
    {
        // Input data
        StringBuilder input = new StringBuilder();
        StringBuilder expected = new StringBuilder();

        int linesNum = int.Parse(Console.ReadLine());
        string tab = Console.ReadLine();

        for (int i = 0; i < linesNum; i++)
        {
            input.AppendLine(Regex.Replace(Console.ReadLine(), @"\s{2,}", " ").Trim());
        }

        // Formating
        int opened = 0;

        StringBuilder formated = new StringBuilder();

        string[] lines = input.ToString().Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

        for (int i = 0; i < lines.Length; i++)
		{
            int opening = lines[i].IndexOf('{');
            int closing = lines[i].IndexOf('}');

            while (opening != -1 || closing != -1)
            {
                if ((opening < closing && opening != -1) ||
                    (opening > closing && closing == -1))
                {
                    if (opening != 0)
                    {
                        for (int j = 0; j < opened; j++)
                        {
                            formated.Append(tab);
                        }

                        formated.AppendLine(lines[i].Substring(0, opening).Trim());
                    }

                    for (int j = 0; j < opened; j++)
                    {
                        formated.Append(tab);
                    }

                    formated.AppendLine("{");
                    lines[i] = lines[i].Remove(0, opening + 1);
                    lines[i] = lines[i].Trim();
                    opened++;
                }
                else if ((closing < opening && closing != -1) ||
                         (closing > opening && opening == -1))
                {
                    if (closing != 0)
                    {
                        for (int j = 0; j < opened; j++)
                        {
                            formated.Append(tab);
                        }

                        formated.AppendLine(lines[i].Substring(0, closing));
                    }

                    opened--;
                    for (int j = 0; j < opened; j++)
                    {
                        formated.Append(tab);
                    }

                    formated.AppendLine("}");
                    lines[i] = lines[i].Remove(0, closing + 1);
                    lines[i] = lines[i].Trim();
                }
                opening = lines[i].IndexOf('{');
                closing = lines[i].IndexOf('}');
            }
            if (lines[i] != string.Empty)
            {
                for (int j = 0; j < opened; j++)
                {
                    formated.Append(tab);
                }

                formated.AppendLine(lines[i].Trim());
            }
		}

        Console.WriteLine(formated.ToString().Trim('\r', '\n'));
    }
}