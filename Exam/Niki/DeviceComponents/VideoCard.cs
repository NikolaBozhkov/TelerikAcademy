namespace ComputersBuildingSystem.DeviceComponents
{
    using System;

    public class VideoCard : MotherboardComponent
    {
        public VideoCard(bool colorful)
        {
            if (colorful)
            {
                this.Color = ConsoleColor.Green;
            }
            else
            {
                this.Color = ConsoleColor.Gray;
            }
        }

        public VideoCard(ConsoleColor color)
        {
            this.Color = color;
        }

        public ConsoleColor Color { get; private set; }

        public void Draw(string data)
        {
            Console.ForegroundColor = this.Color;
            Console.WriteLine(data);
            Console.ResetColor();
        }
    }
}