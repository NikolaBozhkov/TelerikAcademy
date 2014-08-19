namespace ComputersBuildingSystem.DeviceComponents
{
    public class LaptopBattery
    {
        private const int InitialCharge = 50;
        private const int MinCharge = 0;
        private const int MaxCharge = 100;

        public LaptopBattery()
        {
            this.Percentage = LaptopBattery.InitialCharge;
        }

        public int Percentage { get; set; }

        public void Charge(int percents)
        {
            this.Percentage += percents;
            if (this.Percentage > LaptopBattery.MaxCharge)
            {
                this.Percentage = LaptopBattery.MaxCharge;
            }

            if (this.Percentage < LaptopBattery.MinCharge)
            {
                this.Percentage = LaptopBattery.MinCharge;
            }
        }
    }
}
