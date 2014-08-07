namespace ComputersBuildingSystem.DeviceComponents
{
    public class Cpu32Bit : Cpu
    {
        internal Cpu32Bit(byte numberOfCores)
            : base(numberOfCores)
        {
        }

        protected override int MaxValueForCalculation
        {
            get
            {
                return 500;
            }
        }
    }
}
