namespace ComputersBuildingSystem.Devices
{
    using DeviceComponents;
    using System;
    using System.Collections.Generic;

    public class PersonalComputer : Device
    {
        public PersonalComputer(Motherboard motherboard, IEnumerable<IHardDrive> hardDrives)
            : base(motherboard, hardDrives)
        {
        }

        public void Play(int guessNumber)
        {
            this.Cpu.SaveRandomValueToRam(1, 10, RandomGeneratorSingleton.Instance);
            var number = this.Motherboard.LoadRamValue();

            if (number != guessNumber)
            {
                this.Motherboard.DrawOnVideoCard(string.Format("You didn't guess the number {0}.", number));
            }
            else
            {
                this.Motherboard.DrawOnVideoCard("You win!");
            }
        }
    }
}