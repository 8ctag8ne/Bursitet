using System;
namespace Decorator.Examples
{
    class MainApp
    {
        static void Main()
        {
            // Create ConcreteComponent and two Decorators
            ConcreteComponent c = new ConcreteComponent();
            BallDecorator d1 = new BallDecorator();
            LightsDecorator d2 = new LightsDecorator();

            // Link decorators
            d1.SetComponent(c);
            d2.SetComponent(d1);

            d2.Operation();

            // Wait for user
            Console.Read();
        }
    }
    // "Component"
    abstract class Component
    {
        public abstract void Operation();
    }

    // "ConcreteComponent"
    class ConcreteComponent : Component
    {
        public override void Operation()
        {
            Console.Write("Tree");
        }
    }
    // "Decorator"
    abstract class Decorator : Component
    {
        protected Component component;

        public void SetComponent(Component component)
        {
            this.component = component;
        }
        public override void Operation()
        {
            if (component != null)
            {
                component.Operation();
            }
        }
    }

    // "ConcreteDecoratorA"
    class BallDecorator : Decorator
    {
        private string ball;
        public override void Operation()
        {
            ball = "Ball's hanging";
            Console.Write(ball+"[ ");
            base.Operation();
            Console.Write(" ]");
        }
    }

    // "ConcreteDecoratorB" 
    class LightsDecorator : Decorator
    {
        public override void Operation()
        {
            LightsOn();
            Console.Write("( ");
            base.Operation();
            Console.Write(" )");
        }
        void LightsOn()
        { 
            Console.Write("Lights On");

        }
    }
}
