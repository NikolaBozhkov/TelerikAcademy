namespace Visitor
{
    public class TimeLimitVisitor : IVisitor
    {
        public void Visit(IVisitable element)
        {
            var monster = element as Monster;

            if (monster != null)
            {
                // Kill the monster due to time limit
                monster.Health = 0;
            }
        }
    }
}
