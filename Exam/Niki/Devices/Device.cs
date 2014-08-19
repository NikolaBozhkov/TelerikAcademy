namespace ComputersBuildingSystem.Devices
{
    using System;
    using System.Collections.Generic;
    using ComputersBuildingSystem.DeviceComponents;

    public abstract class Device
    {
        public Device(Motherboard motherboard, IEnumerable<IHardDrive> hardDrives)
        {
            this.Motherboard = motherboard;
            this.HardDrives = hardDrives;
        }

        public IEnumerable<IHardDrive> HardDrives { get; set; }

        public VideoCard VideoCard 
        {
            get
            {
                return this.Motherboard.VideoCard;
            }
        }

        public Cpu Cpu 
        { 
            get
            {
                return this.Motherboard.Cpu;
            }
        }

        public RamMemory RamMemory 
        {
            get
            {
                return this.Motherboard.RamMemory;
            }
        }

        public Motherboard Motherboard { get; private set; }
    }
}
