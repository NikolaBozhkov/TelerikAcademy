namespace TradeAndTravel
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Wood : Item
    {
        private const int GeneralWoodValue = 2;
        private int currentWoodValue = Wood.GeneralWoodValue;

        public int CurrentWoodValue 
        {
            get
            {
                return this.currentWoodValue;
            }
            private set
            {
                if (this.currentWoodValue > 0)
                {
                    currentWoodValue = value;
                }
            }
        }

        public Wood(string name, Location location = null)
            : base(name, Wood.GeneralWoodValue, ItemType.Wood, location)
        {
        }

        public static List<ItemType> GetComposingItems()
        {
            return new List<ItemType>() { ItemType.Wood };
        }

        public override void UpdateWithInteraction(string interaction)
        {
            switch (interaction)
            {
                case "drop":
                    DecreaseWoodValue();
                    break;
                default:
                    break;
            }
        }

        private void DecreaseWoodValue()
        {
            this.CurrentWoodValue--;
        }
    }
}