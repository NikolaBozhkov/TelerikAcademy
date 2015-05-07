namespace AbstractFactory
{
    using System.Collections.Generic;

    public class PowerSupply : ComputerComponent
    {
        public PowerSupply(int voltage, IList<string> compositeMaterials, string manufacturer)
            : base(compositeMaterials, manufacturer)
        {
            this.Voltage = voltage;
        }

        public int Voltage { get; private set; }
    }
}
