// Write a program that downloads a file from Internet (e.g. http://www.devbg.org/img/Logo-BASD.jpg) and stores it the current directory. 
// Find in Google how to download files in C#. Be sure to catch all exceptions and to free any used resources in the finally block.

using System;
using System.Net;

public class DownloadFile
{
    public static void Main()
    {
        // Tring and catching all exceptions
        // "Using" frees up the resources
        using (WebClient webClient = new WebClient())
        {
            try
            {
                webClient.DownloadFile("http://www.devbg.org/img/Logo-BASD.jpg", @"d:\Logo-BASD.jpg");
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Address and directory cannot be null.");
            }
            catch (WebException wE)
            {
                Console.WriteLine(wE.Message);
            }
            catch (NotSupportedException nSE)
            {
                Console.WriteLine(nSE.Message);
            }
        }
    }
}