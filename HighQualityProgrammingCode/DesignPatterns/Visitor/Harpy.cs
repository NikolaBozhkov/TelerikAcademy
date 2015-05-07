namespace Visitor
{
    public class Harpy : Monster
    {
        private const double HarpyHealth = 150;
        private const double HarpyDamage = 50;

        public Harpy()
            : base(Harpy.HarpyHealth, Harpy.HarpyDamage)
        {
        }
    }
}