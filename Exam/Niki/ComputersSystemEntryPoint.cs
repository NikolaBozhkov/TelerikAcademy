namespace ComputersBuildingSystem
{
    using System;

    public class ComputersSystemEntryPoint
    {
        private static void Main()
        {
            const string ExitCommand = "Exit";
            const string InvalidCommandMessage = "Invalid command!";
            const string ChargeCommand = "Charge";
            const string ProcessCommand = "Process";
            const string PlayCommand = "Play";

            var manufacturerCommand = Console.ReadLine();
            var manufacturer = ManufacturerSelector.GetManufacturer(manufacturerCommand);

            var personalComputer = manufacturer.ManufacturePersonalComputer();
            var laptop = manufacturer.ManufactureLaptop();
            var server = manufacturer.ManufactureServer();

            while (true)
            {
                var command = Console.ReadLine();

                if (command.Trim() == ExitCommand)
                {
                    break;
                }

                var commandParameters = command.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (commandParameters.Length != 2)
                {
                    {
                        throw new ArgumentException(InvalidCommandMessage);
                    }
                }

                var commandName = commandParameters[0];
                var commandArgument = int.Parse(commandParameters[1]);

                if (commandName == ChargeCommand)
                {
                    laptop.ChargeBattery(commandArgument);
                }
                else if (commandName == ProcessCommand)
                {
                    server.Process(commandArgument);
                }
                else if (commandName == PlayCommand)
                {
                    personalComputer.Play(commandArgument);
                }
            }
        }
    }
}