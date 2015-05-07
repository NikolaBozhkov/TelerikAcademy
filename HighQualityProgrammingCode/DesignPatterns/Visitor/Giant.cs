namespace Visitor
{
    public class Giant : Monster
    {
        private const double GiantHealth = 500;
        private const double GiantDamage = 15;

        public Giant()
            : base(Giant.GiantHealth, Giant.GiantDamage)
        {
        }

        public void LifeSteal()
        {
            this.Health += this.Damage * 0.75;
        }
    }
}
