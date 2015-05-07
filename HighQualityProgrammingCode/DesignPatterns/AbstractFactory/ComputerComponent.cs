namespace AbstractFactory
{
    using System.Collections.Generic;
    using System.Text;

    public abstract class ComputerComponent
    {
        private readonly IList<string> compositeMaterials;
        public ComputerComponent(IList<string> compositeMaterials, string manufacturer)
        {
            this.compositeMaterials = new List<string>(compositeMaterials);
            this.Manufacturer = manufacturer;
        }

        public string Manufacturer { get; private set; }

        public IList<string> CompositeMaterials
        {
            get
            {
                return new List<string>(this.compositeMaterials);
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(new string('-', 50));
            sb.AppendFormat("Manufacturer: {0}\n", this.Manufacturer);
            sb.AppendLine("Materials: ");
            for (int i = 0; i < this.compositeMaterials.Count; i++)
            {
                sb.AppendFormat("--- {0}\n", this.compositeMaterials[i]);
            }

            sb.AppendLine(new string('-', 50));

            return sb.ToString();
        }
    }
}