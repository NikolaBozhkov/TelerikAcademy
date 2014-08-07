namespace ComputersBuildingSystem.DeviceComponents
{
    public class Cpu128Bit : Cpu
    {
        internal Cpu128Bit(byte numberOfCores)
            : base(numberOfCores)
        {
        }

        protected override int MaxValueForCalculation
        {
            get
            {
                return 2000;
            }
        }
    }
}