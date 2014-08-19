namespace ComputersBuildingSystem.Devices
{
    using System.Collections.Generic;
    using ComputersBuildingSystem.DeviceComponents;

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