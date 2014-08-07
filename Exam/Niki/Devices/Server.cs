namespace ComputersBuildingSystem.Devices
{
    using ComputersBuildingSystem.DeviceComponents;
    using System.Collections.Generic;

    public class Server : Device
    {
        public Server(Motherboard motherboard, IEnumerable<IHardDrive> hardDrives)
            : base(motherboard, hardDrives)
        {
        }

        internal void Process(int data)
        {
            this.Motherboard.SaveRamValue(data);

            Cpu.SquareOfNumber();
        }
    }
}