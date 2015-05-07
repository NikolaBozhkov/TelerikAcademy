namespace AbstractFactory
{
    using System;
    using System.Collections.Generic;

    public class Demo
    {
        public static void Main()
        {
            // I know it can be more organized
            // I thought of combining this with Builder pattern for computers
            // But the code will be too much for a demo
            ComputerComponentsFactory intelFactory = new Intel();
            ComputerComponentsFactory amdFactory = new AMD();

            var intelParts = new List<ComputerComponent>();
            var amdParts = new List<ComputerComponent>();

            intelParts.Add(intelFactory.CreateCPU(4, 2.6M));
            intelParts.Add(intelFactory.CreateGPU(3, "DDR5"));
            intelParts.Add(intelFactory.CreatePowerSupply(500));
            intelParts.Add(intelFactory.CreateRAM(8));
            intelParts.Add(intelFactory.CreateMotherBoard(4));

            amdParts.Add(amdFactory.CreateCPU(4, 2.6M));
            amdParts.Add(amdFactory.CreateGPU(3, "DDR5"));
            amdParts.Add(amdFactory.CreatePowerSupply(500));
            amdParts.Add(amdFactory.CreateRAM(8));
            amdParts.Add(amdFactory.CreateMotherBoard(4));

            Console.WriteLine("Intel parts: ");
            for (int i = 0; i < intelParts.Count; i++)
            {
                Console.WriteLine(intelParts[i].ToString());
            }

            Console.WriteLine();
            Console.WriteLine("AMD parts: ");
            for (int i = 0; i < amdParts.Count; i++)
            {
                Console.WriteLine(amdParts[i].ToString());
            }
        }
    }
}