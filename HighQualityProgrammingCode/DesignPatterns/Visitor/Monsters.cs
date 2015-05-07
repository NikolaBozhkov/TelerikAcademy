namespace Visitor
{
    using System.Collections.Generic;

    public class Monsters
    {
        private readonly IList<Monster> monsters = new List<Monster>();

        public IList<Monster> List
        {
            get
            {
                return new List<Monster>(this.monsters);
            }
        }

        public void Attach(Monster monster)
        {
            this.monsters.Add(monster);
        }

        public void Detach(Monster monster)
        {
            this.monsters.Remove(monster);
        }

        public void Accept(IVisitor visitor)
        {
            foreach (var monster in this.monsters)
            {
                monster.Accept(visitor);
            }
        }
    }
}