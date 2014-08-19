namespace ComputersBuildingSystem
{
    using System;
    using DeviceManufacturers;

    public static class ManufacturerSelector
    {
        private const string Hp = "HP";
        private const string Dell = "Dell";
        private const string Lenovo = "Lenovo";
        private const string InvalidManufacturerMessage = "Invalid manufacturer!";

        public static DeviceManufacturer GetManufacturer(string manufacturer)
        {
            switch (manufacturer)
            {
                case Hp:
                    return new HewlettPackard();
                case Dell:
                    return new Dell();
                case Lenovo:
                    return new Lenovo();
                default:
                    throw new ArgumentException(InvalidManufacturerMessage);
            }
        }
    }
}
