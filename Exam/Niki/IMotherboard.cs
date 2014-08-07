namespace ComputersBuildingSystem
{
    public interface IMotherboard 
    { 
        /// <summary>
        /// Loads the value that is currently saved in the ram of the motherboard
        /// </summary>
        /// <returns>ram value</returns>
        int LoadRamValue(); 

        /// <summary>
        /// Saves the given value as current to the ram, it can be later accessed
        /// </summary>
        /// <param name="value">value to save</param>
        void SaveRamValue(int value);
 
        /// <summary>
        /// Uses the videocard in the motherboard to draw data
        /// </summary>
        /// <param name="data">data to draw</param>
        void DrawOnVideoCard(string data);
    }
}
