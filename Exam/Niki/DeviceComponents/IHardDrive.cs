namespace ComputersBuildingSystem.DeviceComponents
{
    public interface IHardDrive
    {
        int Capacity { get; }

        void SaveData(int address, string data);

        string LoadData(int address);
    }
}