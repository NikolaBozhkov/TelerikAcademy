namespace ComputersBuildingSystem.DeviceManufacturers
{
    using Devices;
    using DeviceComponents;

    public abstract class DeviceManufacturer
    {
        public abstract PersonalComputer ManufacturePersonalComputer();
        public abstract Laptop ManufactureLaptop();
        public abstract Server ManufactureServer();
    }
}
