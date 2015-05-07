using Decorator.Component;
using Decorator.Decorator;

namespace Decorator.ConcreteDecorator
{
    public class StrawberryTopping : Topping
    {
        private const double Price = 0.25;

        public StrawberryTopping(IceCream iceCream)
            : base(iceCream)
        {
        }

        public override double Cost()
        {
            return StrawberryTopping.Price + IceCream.Cost();
        }
    }
}
