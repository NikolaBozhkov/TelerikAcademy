namespace ComputersBuildingSystem.Devices
{
    using System;
    using System.Collections.Generic;
    using DeviceComponents;

    public class PersonalComputer : Device
    {
        private const string YouWinMessage = "You win!";
        private const string FailedToGuessTheNumberMessage = "You didn't guess the number {0}.";

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
                this.Motherboard.DrawOnVideoCard(string.Format(PersonalComputer.FailedToGuessTheNumberMessage, number));
            }
            else
            {
                this.Motherboard.DrawOnVideoCard(PersonalComputer.YouWinMessage);
            }
        }
    }
}