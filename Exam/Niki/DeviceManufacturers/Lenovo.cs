namespace ComputersBuildingSystem.DeviceManufacturers
{
    using ComputersBuildingSystem.DeviceComponents;
    using ComputersBuildingSystem.Devices;
    using System;
    using System.Collections.Generic;

    public class Lenovo : DeviceManufacturer
    {
        private const byte PersonalComputerNumberOfCores = 2;
        private const int PersonalComputerRamCapacity = 4;
        private const int PersonalComputerHardDriveCapacity = 2000;
        private const bool PersonalComputerVideoCardColorful = false;

        private const byte LaptopNumberOfCores = 2;
        private const int LaptopRamCapacity = 16;
        private const int LaptopHardDriveCapacity = 1000;
        private const bool LaptopVideoCardColorful = true;

        private const byte ServerNumberOfCores = 2;
        private const int ServerRamCapacity = 8;
        private const int ServerHardDriveCapacity = 500;

        public override PersonalComputer ManufacturePersonalComputer()
        {
            var cpu = new Cpu64Bit(Lenovo.PersonalComputerNumberOfCores);

            var ram = new RamMemory(Lenovo.PersonalComputerRamCapacity);

            var hardDrives = new List<HardDrive>();
            hardDrives.Add(new HardDrive(Lenovo.PersonalComputerHardDriveCapacity));

            var videoCard = new VideoCard(PersonalComputerVideoCardColorful);

            var motherboard = new Motherboard(cpu, ram, videoCard);

            var personalComputer = new PersonalComputer(motherboard, hardDrives);
            return personalComputer;
        }

        public override Laptop ManufactureLaptop()
        {
            var cpu = new Cpu32Bit(Lenovo.LaptopNumberOfCores);

            var ram = new RamMemory(Lenovo.LaptopRamCapacity);

            var hardDrives = new List<HardDrive>();
            hardDrives.Add(new HardDrive(Lenovo.LaptopHardDriveCapacity));

            var videoCard = new VideoCard(Lenovo.LaptopVideoCardColorful);
            var battery = new DeviceComponents.LaptopBattery();

            var motherboard = new Motherboard(cpu, ram, videoCard);
            var laptop = new Laptop(motherboard, hardDrives, battery);
            return laptop;
        }

        public override Server ManufactureServer()
        {
            var cpu = new Cpu64Bit(Lenovo.ServerNumberOfCores);

            var ram = new RamMemory(Lenovo.ServerRamCapacity);

            var hardDrives = new List<IHardDrive>();
            hardDrives.Add(new RaidHardDrive(Lenovo.ServerHardDriveCapacity, 2));

            var videoCard = new VideoCard(false);

            var motherboard = new Motherboard(cpu, ram, videoCard);
            var server = new Server(motherboard, hardDrives);
            return server;
        }
    }
}
