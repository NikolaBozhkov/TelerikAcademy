namespace ComputersBuildingSystem.Devices
{
    using ComputersBuildingSystem.DeviceComponents;
    using System.Collections.Generic;

    public class Laptop : Device
    {
        public Laptop(Motherboard motherboard, IEnumerable<IHardDrive> hardDrives, LaptopBattery battery)
            : base(motherboard, hardDrives)
        {
            this.Battery = battery;
        }

        public LaptopBattery Battery { get; set; }

        internal void ChargeBattery(int percentage)
        {
            this.Battery.Charge(percentage);

            var text = string.Format("Battery status: {0}%", this.Battery.Percentage);
            VideoCard.Draw(text);
        }
    }
}
