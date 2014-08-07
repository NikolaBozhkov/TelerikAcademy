namespace ComputersBuildingSystem.DeviceComponents
{
    public class Motherboard : IMotherboard
    {
        public Motherboard(Cpu cpu, RamMemory ramMemory, VideoCard videoCard)
        {
            this.Cpu = cpu;
            this.Cpu.Motherboard = this;

            this.RamMemory = ramMemory;
            this.RamMemory.Motherboard = this;

            this.VideoCard = videoCard;
            this.VideoCard.Motherboard = this;
        }

        public Cpu Cpu { get; set; }

        public RamMemory RamMemory { get; set; }

        public VideoCard VideoCard { get; set; }

        public int LoadRamValue()
        {
            return this.RamMemory.LoadValue();
        }

        public void SaveRamValue(int value)
        {
            this.RamMemory.SaveValue(value);
        }

        public void DrawOnVideoCard(string data)
        {
            this.VideoCard.Draw(data);
        }
    }
}
