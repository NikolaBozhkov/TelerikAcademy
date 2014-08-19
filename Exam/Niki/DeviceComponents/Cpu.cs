namespace ComputersBuildingSystem.DeviceComponents
{
    using System;

    public abstract class Cpu : MotherboardComponent, ICpu
    {
        private const string NumberTooLowMessage = "Number too low.";
        private const string NumberTooHighMessage = "Number too high.";
        private const string SquareOfNumberMessage = "Square of {0} is {1}.";

        internal Cpu(byte numberOfCores)
        {
            this.NumberOfCores = numberOfCores;
        }

        public byte NumberOfCores { get; set; }

        protected abstract int MaxValueForCalculation { get; }

        public void SquareOfNumber()
        {
            var value = this.Motherboard.LoadRamValue();

            if (value < 0)
            {
                this.Motherboard.DrawOnVideoCard(Cpu.NumberTooLowMessage);
            }
            else if (value > this.MaxValueForCalculation)
            {
                this.Motherboard.DrawOnVideoCard(Cpu.NumberTooHighMessage);
            }
            else
            {
                // Here was the useless for cycle(bottleneck)
                var square = value * value;
                this.Motherboard.DrawOnVideoCard(string.Format(Cpu.SquareOfNumberMessage, value, square));
            }
        }

        public void SaveRandomValueToRam(int minValue, int maxValue, Random randomGenerator)
        {
            // Here was used a useless while cycle(bottleneck)
            int randomNumber = randomGenerator.Next(minValue, maxValue + 1);

            this.Motherboard.SaveRamValue(randomNumber);
        }
    }
}