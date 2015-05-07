using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor
{
    public class Demo
    {
        public static void Main(string[] args)
        {
            // Not the greatest visitors, but I think it works for the demo
            // I chose this pattern, because I couldn't understand the difference
            // Between this and Decorator, but now I got it
            // Decorator works on a particular object by wrapping it and adding functunality or state
            // Visitor is used on a tree of objects, where u don't want to add a particular operation to every class
            // Instead you send a visitor to the structure of classes and collect or alter data.

            var monsters = new Monsters();

            monsters.Attach(new Harpy());
            monsters.Attach(new Giant());
            monsters.Attach(new Zombie());

            // yea, there are copy-pastes here, for the foreach : )
            Console.WriteLine("Before upgrade: ");
            foreach (var monster in monsters.List)
            {
                Console.WriteLine("{0} with health: {1} and damage: {2}",
                    monster.GetType().Name, monster.Health, monster.Damage);
            }

            monsters.Accept(new UpgradeVisitor());
            
            Console.WriteLine("\nAfter upgrade: ");
            foreach (var monster in monsters.List)
            {
                Console.WriteLine("{0} with health: {1} and damage: {2}",
                    monster.GetType().Name, monster.Health, monster.Damage);
            }

            monsters.Accept(new TimeLimitVisitor());

            Console.WriteLine("\nAfter time limit: ");
            foreach (var monster in monsters.List)
            {
                Console.WriteLine("{0} with health: {1} and damage: {2}",
                    monster.GetType().Name, monster.Health, monster.Damage);
            }
        }
    }
}