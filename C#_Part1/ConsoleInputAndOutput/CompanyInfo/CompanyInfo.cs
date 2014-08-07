// A company has name, address, phone number, fax number, web site and manager. The manager has first name, last name, age and a phone number. 
// Write a program that reads the information about a company and its manager and prints them on the console.

using System;
using System.Collections.Generic;

public class CompanyInfo
{
    public static void Main()
    {
        while (true)
        {   
            Console.Write("Please enter the name of the company(only letters and spaces): ");
            string name = Console.ReadLine();
            Console.Write("Please enter the address of the company: ");
            string address = Console.ReadLine();
            Console.Write("Please enter the phone number of the company: ");
            string linephone = Console.ReadLine();
            Console.Write("Please enter the fax number of the company: ");
            string linefax = Console.ReadLine();
            Console.Write("Please enter the web site of the company: ");
            string web = Console.ReadLine();
            Console.Write("Please enter the first name of the manager of the company(only letters and spaces): ");
            string manfn = Console.ReadLine();
            Console.Write("Please enter the last name of the manager of the company(only letters and spaces): ");
            string manln = Console.ReadLine();
            Console.Write("Please enter the age of the manager of the company: ");
            string linemanage = Console.ReadLine();
            Console.Write("Please enter the phone number of the manager of the company: ");
            string linemanphone = Console.ReadLine();

            long phone;
            long fax;
            int manage;
            long manphone;
            string manfullname = manfn + " " + manln;
            string space = new string('-', 51);

            List<string> strings = new List<string>();
            strings.Add(name);
            strings.Add(manfn);
            strings.Add(manln);
            bool check = false;
            for (int i = 0; i < strings.Count; i++)
            {
                foreach (char c in strings[i])
                {
                    if (!char.IsLetter(c))
                    {
                        if (c == ' ')
                        {
                            check = true;
                        }
                        else
                        {
                            check = false;
                            break;
                        }
                    }
                    else
                    {
                        check = true;
                    }                  
                }

                if (check == false)
                {
                    break;
                }
            }

            if (check && long.TryParse(linephone, out phone) && long.TryParse(linefax, out fax) && int.TryParse(linemanage, out manage) && long.TryParse(linemanphone, out manphone))
            {
                Console.WriteLine("\n\nInformation about the company \"{0}\": ", name);
                Console.WriteLine(space);
                Console.WriteLine("Name        :{0, 37}|", name);
                Console.WriteLine("Address     :{0, 37}|", address);
                Console.WriteLine("Phone number:{0, 37}|", phone);
                Console.WriteLine("Fax number  :{0, 37}|", fax);
                Console.WriteLine("Web site    :{0, 37}|", web);
                Console.WriteLine("Manager     :{0, 37}|", manfullname);
                Console.WriteLine(space);
                Console.WriteLine("\n\nInformation about the manager: ");
                Console.WriteLine(space);
                Console.WriteLine("First name  :{0, 37}|", manfn);
                Console.WriteLine("Last name   :{0, 37}|", manln);
                Console.WriteLine("Age         :{0, 37}|", manage);
                Console.WriteLine("Phone number:{0, 37}|", manphone);
                Console.WriteLine(space);
                break;
            }
            else
            {
                Console.WriteLine("Invalid input, please enter the information again.");
            }
        }
    }
}