namespace ComputersBuildingSystem.Devices
{
    using System.Collections.Generic;
    using ComputersBuildingSystem.DeviceComponents;

    public class Laptop : Device
    {
        private const string BatteryStatusMessage = "Battery status: {0}%";

        public Laptop(Motherboard motherboard, IEnumerable<IHardDrive> hardDrives, LaptopBattery battery)
            : base(motherboard, hardDrives)
        {
            this.Battery = battery;
        }

        public LaptopBattery Battery { get; set; }

        internal void ChargeBattery(int percentage)
        {
            this.Battery.Charge(percentage);

            var text = string.Format(Laptop.BatteryStatusMessage, this.Battery.Percentage);
            VideoCard.Draw(text);
        }
    }
}
