namespace AbstractFactory
{
    using System.Collections.Generic;
    
    public class RAM : ComputerComponent
    {
        public RAM(int memory, IList<string> compositeMaterials, string manufacturer)
            : base(compositeMaterials, manufacturer)
        {
            this.Memory = memory;
        }

        public int Memory { get; private set; }
    }
}
