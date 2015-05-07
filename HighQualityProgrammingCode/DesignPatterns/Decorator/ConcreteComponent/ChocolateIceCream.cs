using Decorator.Component;

namespace Decorator.ConcreteComponent
{
    public class ChocolateIceCream : IceCream
    {
        private const double Price = 1.25;

        public override double Cost()
        {
            return ChocolateIceCream.Price;
        }
    }
}
