namespace AbstractFactory
{
    using System.Collections.Generic;

    public class CPU : ComputerComponent
    {
        public CPU(int cores, decimal speed, IList<string> compositeMaterials, string manufacturer)
            : base(compositeMaterials, manufacturer)
        {
            this.Cores = cores;
            this.Speed = speed;
        }

        public int Cores { get; private set; }
        public decimal Speed { get; private set; }
    }
}
