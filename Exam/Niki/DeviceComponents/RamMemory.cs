namespace ComputersBuildingSystem.DeviceComponents
{ 
    public class RamMemory : MotherboardComponent
    { 
        public RamMemory(int capacity) 
        {
            this.Capacity = capacity;
        } 

        public int Capacity { get; set; }
        public int Value { get; set; }

        public void SaveValue(int newValue) 
        {
            this.Value = newValue;
        }
        public int LoadValue()
        {
            return this.Value; 
        }
    } 
}