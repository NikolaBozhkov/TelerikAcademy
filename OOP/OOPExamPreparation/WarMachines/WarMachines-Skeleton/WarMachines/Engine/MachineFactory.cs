namespace WarMachines.Engine
{
    using WarMachines.Interfaces;
    using WarMachines.Machines;

    public class MachineFactory : IMachineFactory
    {
        public IPilot HirePilot(string name)
        {
            var pilot = new Pilot();

            pilot.Name = name;

            return pilot;
        }

        public ITank ManufactureTank(string name, double attackPoints, double defensePoints)
        {
            var tank = new Tank();

            tank.Name = name;
            tank.AttackPoints = attackPoints;
            tank.DefensePoints = defensePoints;
            tank.HealthPoints = 100;
            tank.ToggleDefenseMode();

            return tank;
        }

        public IFighter ManufactureFighter(string name, double attackPoints, double defensePoints, bool stealthMode)
        {
            var fighter = new Fighter();

            fighter.Name = name;
            fighter.AttackPoints = attackPoints;
            fighter.DefensePoints = defensePoints;
            fighter.HealthPoints = 200;

            if (stealthMode)
            {
                fighter.ToggleStealthMode();
            }

            return fighter;
        }
    }
}
