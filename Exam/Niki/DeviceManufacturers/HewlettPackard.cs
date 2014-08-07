namespace ComputersBuildingSystem.DeviceManufacturers
{
    using ComputersBuildingSystem.DeviceComponents;
    using ComputersBuildingSystem.Devices;
    using System;
    using System.Collections.Generic;

    public class HewlettPackard : DeviceManufacturer
    {
        private const byte PersonalComputerNumberOfCores = 2;
        private const int PersonalComputerRamCapacity = 2;
        private const int PersonalComputerHardDriveCapacity = 500;
        private const bool PersonalComputerVideoCardColorful = true;

        private const byte LaptopNumberOfCores = 2;
        private const int LaptopRamCapacity = 4;
        private const int LaptopHardDriveCapacity = 500;
        private const bool LaptopVideoCardColorful = true;

        private const byte ServerNumberOfCores = 4;
        private const int ServerRamCapacity = 32;
        private const int ServerHardDriveCapacity = 1000;

        public override PersonalComputer ManufacturePersonalComputer()
        {
            var cpu = new Cpu64Bit(HewlettPackard.PersonalComputerNumberOfCores);

            var ram = new RamMemory(HewlettPackard.PersonalComputerRamCapacity);

            var hardDrives = new List<HardDrive>();
            hardDrives.Add(new HardDrive(HewlettPackard.PersonalComputerHardDriveCapacity));

            var videoCard = new VideoCard(PersonalComputerVideoCardColorful);

            var motherboard = new Motherboard(cpu, ram, videoCard);

            var personalComputer = new PersonalComputer(motherboard, hardDrives);
            return personalComputer;
        }

        public override Laptop ManufactureLaptop()
        {
            var cpu = new Cpu32Bit(HewlettPackard.LaptopNumberOfCores);

            var ram = new RamMemory(HewlettPackard.LaptopRamCapacity);

            var hardDrives = new List<HardDrive>();
            hardDrives.Add(new HardDrive(HewlettPackard.LaptopHardDriveCapacity));

            var videoCard = new VideoCard(HewlettPackard.LaptopVideoCardColorful);
            var battery = new DeviceComponents.LaptopBattery();

            var motherboard = new Motherboard(cpu, ram, videoCard);
            var laptop = new Laptop(motherboard, hardDrives, battery);
            return laptop;
        }

        public override Server ManufactureServer()
        {
            var cpu = new Cpu64Bit(HewlettPackard.ServerNumberOfCores);

            var ram = new RamMemory(HewlettPackard.ServerRamCapacity);

            var hardDrives = new List<IHardDrive>();
            hardDrives.Add(new RaidHardDrive(HewlettPackard.ServerHardDriveCapacity, 2));

            var videoCard = new VideoCard(false);

            var motherboard = new Motherboard(cpu, ram, videoCard);
            var server = new Server(motherboard, hardDrives);
            return server;
        }
    }
}
