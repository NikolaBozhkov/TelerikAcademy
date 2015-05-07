using Decorator.Component;
using Decorator.Decorator;

namespace Decorator.ConcreteDecorator
{
    public class ChocolateTopping : Topping
    {
        private const double Price = 0.50;

        public ChocolateTopping(IceCream iceCream)
            : base(iceCream)
        {
        }

        public override double Cost()
        {
            return ChocolateTopping.Price + IceCream.Cost();
        }
    }
}
