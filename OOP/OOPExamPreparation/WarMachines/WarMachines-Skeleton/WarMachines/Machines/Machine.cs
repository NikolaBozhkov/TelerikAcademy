namespace WarMachines.Machines
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using WarMachines.Interfaces;

    public abstract class Machine : IMachine
    {
        #region Fields
        private string name;
        private IPilot pilot;
        private IList<string> targets = new List<string>();

        #endregion

        #region Properties
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Name cannot be null.");
                }

                if (value.Length < 3)
                {
                    throw new ArgumentException("Name cannot contain less than 3 characters.");
                }

                this.name = value;
            }
        }

        public IPilot Pilot
        {
            get
            {
                return this.pilot;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Pilot cannot be null.");
                }

                this.pilot = value;
            }
        }

        public double HealthPoints { get; set; }

        public double AttackPoints { get; set; }

        public double DefensePoints { get; set; }

        public abstract string Type { get; }

        public IList<string> Targets
        {
            get { return this.targets; }
        }

        #endregion

        #region Methods
        public virtual void Attack(string target)
        {
        }

        public override string ToString()
        {
            return string.Format(
                "- {0}\n *Type: {1}\n *Health: {2}\n *Attack: {3}\n *Defense: {4}\n *Targets: {5}",
                this.Name,
                this.Type,
                this.HealthPoints,
                this.AttackPoints,
                this.DefensePoints,
                this.targets.Count != 0 ? string.Join(", ", this.targets) : "None");
        }

        #endregion
    }
}
