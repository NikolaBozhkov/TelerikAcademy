namespace AbstractFactory
{
    public abstract class ComputerComponentsFactory
    {
        public abstract CPU CreateCPU(int cores, decimal speed);
        public abstract GPU CreateGPU(int memory, string memoryType);
        public abstract RAM CreateRAM(int memory);
        public abstract PowerSupply CreatePowerSupply(int voltage);
        public abstract MotherBoard CreateMotherBoard(int ramSlots);
    }
}
