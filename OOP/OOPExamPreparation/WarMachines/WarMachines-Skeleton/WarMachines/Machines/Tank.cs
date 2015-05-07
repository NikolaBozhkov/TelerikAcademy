namespace WarMachines.Machines
{
    using System;
    using System.Linq;
    using WarMachines.Interfaces;

    public class Tank : Machine, IMachine, ITank
    {
        #region Properties
        public bool DefenseMode { get; private set; }

        public override string Type
        {
            get { return "Tank"; }
        }

        #endregion

        #region Methods
        public void ToggleDefenseMode()
        {
            this.DefenseMode = !this.DefenseMode;
            this.ToggleDefenseModePoints();
        }

        protected virtual void ToggleDefenseModePoints()
        {
            if (this.DefenseMode)
            {
                this.AttackPoints -= 40;
                this.DefensePoints += 30;
            }
            else
            {
                this.AttackPoints += 40;
                this.DefensePoints -= 30;
            }
        }

        public override string ToString()
        {
            var infoTillNow = base.ToString();

            return string.Format(
                "{0}\n *Defense: {1}",
                infoTillNow,
                this.DefenseMode ? "ON" : "OFF");
        }

        #endregion
    }
}