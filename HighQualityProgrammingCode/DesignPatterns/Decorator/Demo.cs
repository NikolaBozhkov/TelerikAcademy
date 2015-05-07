using Decorator.Component;
using Decorator.ConcreteComponent;
using Decorator.ConcreteDecorator;
using System;

namespace Decorator
{
    public class Demo
    {
        public static void Main()
        {
            // Decorator pattern allows us to put different toppings on different ice creams
            // We sum the cost by calling Cost of the inner instance till we get to the base
            // We now have 6 classes instead of 8, if we have 3 toppings then we jump to 7 - 16
            // Here is an example of this awesome pattern

            IceCream chocIceCream = new ChocolateIceCream();
            IceCream chocIceCreamWithStrberry = new StrawberryTopping(chocIceCream);
            Console.WriteLine("Price of chocolate ice cream with strawberry topping: {0}", chocIceCreamWithStrberry.Cost());

            // The names become too large so I am just gonna use ice cream
            IceCream iceCream = new VanillaIceCream();
            iceCream = new StrawberryTopping(iceCream);
            iceCream = new ChocolateTopping(iceCream);

            Console.WriteLine("Price of vanilla ice cream with strawberry and chocolate topping: {0}", iceCream.Cost());
        }
    }
}
