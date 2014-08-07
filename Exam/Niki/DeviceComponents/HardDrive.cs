namespace ComputersBuildingSystem.DeviceComponents
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class HardDrive : IHardDrive
    {
        private readonly Dictionary<int, string> data;

        public HardDrive(int capacity)
        {
            this.Capacity = capacity;
            this.data = new Dictionary<int, string>(capacity); 
        }

        public int Capacity { get; private set; }

        public void SaveData(int address, string data)
        {
            this.data[address] = data;
        }

        public string LoadData(int address)
        {
            return this.data[address];
        }
    }
}