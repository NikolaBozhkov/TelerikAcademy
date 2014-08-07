namespace ComputersBuildingSystem
{
    using System;
    public class ComputersSystemEntryPoint
    {
        private static void Main()
        {
            var manufacturerCommand = Console.ReadLine();
            var manufacturer = ManufacturerSelector.GetManufacturer(manufacturerCommand);

            var personalComputer = manufacturer.ManufacturePersonalComputer();
            var laptop = manufacturer.ManufactureLaptop();
            var server = manufacturer.ManufactureServer();

            while (true)
            {
                var command = Console.ReadLine();

                if (command.Trim() == "Exit")
                {
                    break;
                }

                var commandParameters = command.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (commandParameters.Length != 2)
                {
                    {
                        throw new ArgumentException("Invalid command!");
                    }
                }

                var commandName = commandParameters[0];
                var commandArgument = int.Parse(commandParameters[1]);

                if (commandName == "Charge")
                {
                    laptop.ChargeBattery(commandArgument);
                }
                else if (commandName == "Process")
                {
                    server.Process(commandArgument);
                }
                else if (commandName == "Play")
                {
                    personalComputer.Play(commandArgument);
                }
            }
        }
    }
}