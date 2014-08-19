namespace ComputersBuildingSystem.DeviceComponents
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class RaidHardDrive : IHardDrive
    {
        private const string NoHardDrivesInRaidMessage = "No hard drive in the RAID array!";

        private readonly IList<IHardDrive> hardDrives = new List<IHardDrive>();

        public RaidHardDrive(int capacity, int count)
        {
            for (int i = 0; i < count; i++)
            {
                this.hardDrives.Add(new HardDrive(capacity));
            }
        }

        public int Capacity
        {
            get
            {
                if (!this.hardDrives.Any())
                {
                    return 0;
                }

                return this.hardDrives.First().Capacity;
            }
        }

        public void SaveData(int address, string data)
        {
            foreach (var hardDrive in this.hardDrives)
            {
                hardDrive.SaveData(address, data);
            }
        }

        public string LoadData(int address)
        {
            if (!this.hardDrives.Any())
            {
                throw new InvalidOperationException(NoHardDrivesInRaidMessage);
            }

            return this.hardDrives.First().LoadData(address);
        }
    }
}
