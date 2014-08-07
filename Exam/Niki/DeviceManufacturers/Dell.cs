namespace ComputersBuildingSystem.DeviceManufacturers
{
    using ComputersBuildingSystem.DeviceComponents;
    using ComputersBuildingSystem.Devices;
    using System;
    using System.Collections.Generic;

    public class Dell : DeviceManufacturer
    {
        private const byte PersonalComputerNumberOfCores = 4;
        private const int PersonalComputerRamCapacity = 8;
        private const int PersonalComputerHardDriveCapacity = 1000;
        private const bool PersonalComputerVideoCardColorful = true;

        private const byte LaptopNumberOfCores = 4;
        private const int LaptopRamCapacity = 8;
        private const int LaptopHardDriveCapacity = 1000;
        private const bool LaptopVideoCardColorful = true;

        private const byte ServerNumberOfCores = 8;
        private const int ServerRamCapacity = 64;
        private const int ServerHardDriveCapacity = 2000;

        public override PersonalComputer ManufacturePersonalComputer()
        {
            var cpu = new Cpu64Bit(Dell.PersonalComputerNumberOfCores);

            var ram = new RamMemory(Dell.PersonalComputerRamCapacity);
   
            var hardDrives = new List<HardDrive>();
            hardDrives.Add(new HardDrive(Dell.PersonalComputerHardDriveCapacity));

            var videoCard = new VideoCard(PersonalComputerVideoCardColorful);

            var motherboard = new Motherboard(cpu, ram, videoCard);

            var personalComputer = new PersonalComputer(motherboard, hardDrives);
            return personalComputer;
        }

        public override Laptop ManufactureLaptop()
        {
            var cpu = new Cpu32Bit(Dell.LaptopNumberOfCores);

            var ram = new RamMemory(Dell.LaptopRamCapacity);

            var hardDrives = new List<HardDrive>();
            hardDrives.Add(new HardDrive(Dell.LaptopHardDriveCapacity));

            var videoCard = new VideoCard(Dell.LaptopVideoCardColorful);
            var battery = new DeviceComponents.LaptopBattery();

            var motherboard = new Motherboard(cpu, ram, videoCard);
            var laptop = new Laptop(motherboard, hardDrives, battery);
            return laptop;
        }

        public override Server ManufactureServer()
        {
            var cpu = new Cpu64Bit(Dell.ServerNumberOfCores);

            var ram = new RamMemory(Dell.ServerRamCapacity);

            var hardDrives = new List<IHardDrive>();
            hardDrives.Add(new RaidHardDrive(Dell.ServerHardDriveCapacity, 2));

            var videoCard = new VideoCard(false);

            var motherboard = new Motherboard(cpu, ram, videoCard);
            var server = new Server(motherboard, hardDrives);
            return server;
        }
    }
}
