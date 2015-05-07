namespace Visitor
{
    public class Zombie : Monster
    {
        private const double ZombieHealth = 200;
        private const double ZombieDamage = 30;

        public Zombie()
            : base(Zombie.ZombieHealth, Zombie.ZombieDamage)
        {
        }

        public void Frenzy()
        {
            this.Damage *= 2;
            this.Health *= 1.5;
        }
    }
}