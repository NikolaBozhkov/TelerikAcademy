namespace AbstractFactory
{
    using System.Collections.Generic;

    public class GPU : ComputerComponent
    {
        public GPU(int memory, string memoryType, IList<string> compositeMaterials, string manufacturer)
            : base(compositeMaterials, manufacturer)
        {
            this.Memory = memory;
            this.MemoryType = memoryType;
        }

        public int Memory { get; private set; }
        public string MemoryType { get; private set; }
    }
}
