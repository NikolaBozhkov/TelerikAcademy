namespace Visitor
{
    public class Monster : IVisitable
    {
        public Monster(double health, double damage)
        {
            this.Health = health;
            this.Damage = damage;
        }

        public double Health { get; set; }

        public double Damage { get; set; }

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }

        public override string ToString()
        {
            return "Health: " + this.Health + " Damage: " + this.Damage;
        }
    }
}