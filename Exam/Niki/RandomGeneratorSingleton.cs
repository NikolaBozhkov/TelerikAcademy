namespace ComputersBuildingSystem
{
    using System;

    public sealed class RandomGeneratorSingleton
    {
        private static Random randomInstance;

        private RandomGeneratorSingleton() 
        {
            randomInstance = new Random();
        }

        public static Random Instance
        {
            get
            {
                if (randomInstance == null)
                {
                    new RandomGeneratorSingleton();
                }

                return randomInstance;
            }
        }
    }
}
