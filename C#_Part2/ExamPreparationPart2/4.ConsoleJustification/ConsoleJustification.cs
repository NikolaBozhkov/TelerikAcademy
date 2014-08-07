using System;
using System.Text;
using System.Text.RegularExpressions;
 
class ConsoleJustification
{
    static void Main()
    {
        // Input data
        int lines = int.Parse(Console.ReadLine());
        int width = int.Parse(Console.ReadLine());
 
        StringBuilder initText = new StringBuilder();
 
        for (int i = 0; i < lines; i++)
        {
            initText.Append(Console.ReadLine() + " ");          
        }
 
        // Justification
        string[] words = initText.ToString().Split(new char[] { ' ' },
            StringSplitOptions.RemoveEmptyEntries);
        StringBuilder justText = new StringBuilder();
        int index = 0;
        bool stop = false;
 
        while (!stop)
        {
            StringBuilder temp = new StringBuilder();
            bool fill = false;
            bool cut = true;
 
            while (true)
            {
                if (index >= words.Length)
                {
                    stop = true;
                    fill = true;                   
                }
                if (!stop)
                {
                    temp.Append(words[index]);
                }             
 
                if (temp.Length > width)
                {
                    temp.Remove(temp.Length - words[index].Length - 1,
                        words[index].Length + 1);
                    fill = true;
                    cut = false;
                    if (temp.ToString() == words[index])
                    {
                        temp.Append(" ");
                        break;
                    }                   
                }
                if (fill)
                {
                    string tempBackUp = temp.ToString();
                    int count = 1;
                    if (cut)
                    {
                        tempBackUp = tempBackUp.Remove(tempBackUp.Length - 1);
                        if (tempBackUp.ToString() == words[index - 1])
                        {
                            temp.Append(" ");
                            break;
                        }
                    }
                    while (tempBackUp.Length != width)
                    {
                        int gap = width - tempBackUp.Length;
                        Regex rgx = new Regex(@"(\s{" + string.Format("{0}", count) + "})");
                        tempBackUp = rgx.Replace(tempBackUp, "$1 ", gap);
                        count++;
                    }
                    temp.Clear();
                    temp.Append(tempBackUp);
                    temp.Append(" ");
                    break;
                }
                index++;               
                temp.Append(" ");
                if (temp.Length == width)
                {
                    int i = temp.ToString().IndexOf(' ');
                    temp = temp.Insert(i, " ");
                    break;
                }
            }
 
            temp.Remove(temp.Length - 1, 1);
            justText.Append(temp.ToString() + "\n");
        }
 
        //Output
        justText.Remove(justText.Length - 1, 1);
        string result = justText.ToString();
        Console.WriteLine(result);
    }
}
