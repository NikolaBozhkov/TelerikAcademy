using Decorator.Component;

namespace Decorator.Decorator
{
    public abstract class Topping : IceCream
    {
        protected Topping(IceCream iceCream)
        {
            this.IceCream = iceCream;
        }

        protected IceCream IceCream { get; set; }

        public override double Cost()
        {
            return this.IceCream.Cost();
        }
    }
}
