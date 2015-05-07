namespace AbstractFactory
{
    using System.Collections.Generic;

    public class MotherBoard : ComputerComponent
    {
        public MotherBoard(int ramSlots, IList<string> compositeMaterials, string manufacturer)
            : base(compositeMaterials, manufacturer)
        {
            this.RamSlots = ramSlots;
        }

        public int RamSlots { get; private set; }
    }
}
