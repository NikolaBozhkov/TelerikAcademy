namespace ComputersBuildingSystem
{
    using System;
    using DeviceManufacturers;

    public static class ManufacturerSelector
    {
        public static DeviceManufacturer GetManufacturer(string manufacturer)
        {
            switch (manufacturer)
            {
                case "HP":
                    return new HewlettPackard();
                case "Dell":
                    return new Dell();
                case "Lenovo":
                    return new Lenovo();
                default:
                    throw new ArgumentException("Invalid manufacturer!");
            }
        }
    }
}
