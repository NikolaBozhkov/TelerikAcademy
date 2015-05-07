namespace WarMachines.Machines
{
    using System;
    using System.Linq;
    using WarMachines.Interfaces;

    public class Fighter : Machine, IMachine, IFighter
    {
        #region Properties
        public bool StealthMode { get; private set; }

        public override string Type
        {
            get { return "Fighter"; }
        }

        #endregion

        #region Methods
        public void ToggleStealthMode()
        {
            this.StealthMode = !this.StealthMode;
        }

        public override string ToString()
        {
            var infoTillNow = base.ToString();

            return string.Format(
                "{0}\n *Stealth: {1}",
                infoTillNow,
                this.StealthMode ? "ON" : "OFF");
        }

        #endregion
    }
}