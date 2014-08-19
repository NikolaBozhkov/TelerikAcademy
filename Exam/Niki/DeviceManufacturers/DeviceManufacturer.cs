namespace ComputersBuildingSystem.DeviceManufacturers
{
    using DeviceComponents;
    using Devices;

    public abstract class DeviceManufacturer
    {
        public abstract PersonalComputer ManufacturePersonalComputer();

        public abstract Laptop ManufactureLaptop();

        public abstract Server ManufactureServer();
    }
}
