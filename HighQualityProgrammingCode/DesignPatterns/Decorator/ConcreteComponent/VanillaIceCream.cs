using Decorator.Component;

namespace Decorator.ConcreteComponent
{
    public class VanillaIceCream : IceCream
    {
        private const double Price = 1;

        public override double Cost()
        {
            return VanillaIceCream.Price;
        }
    }
}
