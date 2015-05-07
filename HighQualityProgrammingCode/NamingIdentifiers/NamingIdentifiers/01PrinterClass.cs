using System;

namespace NamingIdentifiers
{
    class PrinterClass
    {
        const int MAX_COUNT = 6;

        class PrintingClass
        {
            public void PrintBoolAsString(bool variable)
            {
                string variableAsString = variable.ToString();
                Console.WriteLine(variableAsString);
            }
        }

        public static void Entry()
        {
            PrinterClass.PrintingClass instance = new PrinterClass.PrintingClass();
            instance.PrintBoolAsString(true);
        }
    }

}
