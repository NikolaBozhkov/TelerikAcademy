namespace ComputersBuildingSystem.DeviceComponents
{
    public class Cpu64Bit : Cpu
    {
        internal Cpu64Bit(byte numberOfCores)
            : base(numberOfCores)
        {
        }

        protected override int MaxValueForCalculation
        {
            get
            {
                return 1000;
            }
        }
    }
}