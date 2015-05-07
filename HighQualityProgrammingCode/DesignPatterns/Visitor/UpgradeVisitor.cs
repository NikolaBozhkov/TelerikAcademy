namespace Visitor
{
    public class UpgradeVisitor : IVisitor
    {
        public void Visit(IVisitable element)
        {
            var monster = element as Monster;

            if (monster != null)
            {
                // Upgrade monster by increasing health by 10% and damage by 15%
                // for example due to survived time longer than expected
                monster.Health *= 1.10;
                monster.Damage *= 1.15;
            }
        }
    }
}
