// Write a program that enters file name along with its full file path (e.g. C:\WINDOWS\win.ini), reads its contents and prints it on the console. 
// Find in MSDN how to use System.IO.File.ReadAllText(…). Be sure to catch all possible exceptions and print user-friendly error messages.

using System;
using System.IO;
using System.Text;
using System.Security;

public class ReadFileAndPrintCont
{
    public static void Main()
    {
        // Just a big list of all possible exceptions
        // I think the built-in messages are explaining the problem good,
        // so I put them, only changed NullException
        // The names are kinda funky I don't know how to name the exceptions in a short readable way
        try
        {
            string path = Console.ReadLine();
            string text = File.ReadAllText(path);
            Console.WriteLine(text);
        }
        catch (ArgumentNullException)
        {
            Console.WriteLine("The path cannot be null.");
        }
        catch (ArgumentException aE)
        {
            Console.WriteLine(aE.Message);
        }
        catch (UnauthorizedAccessException uAE)
        {
            Console.WriteLine(uAE.Message);
        }
        catch (SecurityException sE)
        {
            Console.WriteLine(sE.Message);
        }
        catch (NotSupportedException nSE)
        {
            Console.WriteLine(nSE.Message);
        }
        catch (PathTooLongException pTLE)
        {
            Console.WriteLine(pTLE.Message);
        }
        catch (DirectoryNotFoundException dNFE)
        {
            Console.WriteLine(dNFE.Message);
        }
        catch (FileNotFoundException fNFE)
        {
            Console.WriteLine(fNFE.Message);
        }
        catch (IOException ioE)
        {
            Console.WriteLine(ioE.Message);
        }
    }
}