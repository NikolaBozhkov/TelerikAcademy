namespace AbstractFactory
{
    using System.Collections.Generic;

    public class Intel : ComputerComponentsFactory
    {
        private const string Name = "Intel Corp.";

        public string CompanyName
        {
            get
            {
                return Name;
            }
        }
        public override CPU CreateCPU(int cores, decimal speed)
        {
            var compositeMaterials = new List<string> 
            { 
                "super cool intel material", 
                "interesting metal", 
                "incredible aluminium" 
            };

            var cpu = new CPU(cores, speed, compositeMaterials, this.CompanyName);
            return cpu;
        }

        public override GPU CreateGPU(int memory, string memoryType)
        {
            var compositeMaterials = new List<string> 
            { 
                "super cool intel material", 
                "interesting metal", 
                "incredible polyfiber",
                "intel gpu super material"
            };

            var gpu = new GPU(memory, memoryType, compositeMaterials, this.CompanyName);
            return gpu;
        }

        public override RAM CreateRAM(int memory)
        {
            var compositeMaterials = new List<string> 
            { 
                "super cool intel material"
            };

            var ram = new RAM(memory, compositeMaterials, this.CompanyName);
            return ram;
        }

        public override PowerSupply CreatePowerSupply(int voltage)
        {
            var compositeMaterials = new List<string> 
            { 
                "super cool intel material", 
                "interesting metal", 
                "incredible aluminium",
                "intel power supply element"
            };

            var powerSupply = new PowerSupply(voltage, compositeMaterials, this.CompanyName);
            return powerSupply;
        }

        public override MotherBoard CreateMotherBoard(int ramSlots)
        {
            var compositeMaterials = new List<string> 
            { 
                "super cool intel material",  
                "incredible aluminium",
                "intel motherboard element"
            };

            var motherBoard = new MotherBoard(ramSlots, compositeMaterials, this.CompanyName);
            return motherBoard;
        }
    }
}
