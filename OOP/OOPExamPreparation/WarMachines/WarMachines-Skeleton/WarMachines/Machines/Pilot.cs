namespace WarMachines.Machines
{
    using System;
    using System.Text;
    using System.Linq;
    using System.Collections.Generic;
    using WarMachines.Interfaces;

    public class Pilot : IPilot
    {
        #region Fields
        private string name;
        private readonly IList<IMachine> machines = new List<IMachine>();

        #endregion

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

        public void AddMachine(IMachine machine)
        {
            this.machines.Add(machine);
        }

        public string Report()
        {
            var report = new StringBuilder();

            var pilotInfo = string.Format(
                "{0} - {1} {2}",
                this.Name,
                this.machines.Count != 0 ? this.machines.Count.ToString() : "no",
                this.machines.Count != 1 ? "machines" : "machine");

            report.Append(pilotInfo);

            var sortedMachines = this.machines.OrderBy(m => m.HealthPoints).ThenBy(m => m.Name);

            foreach (var machine in sortedMachines)
            {
                report.AppendFormat("\n{0}", machine.ToString());
            }

            return report.ToString();
        }
    }
}
