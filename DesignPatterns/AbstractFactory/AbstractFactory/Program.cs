using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Abstract Factory = Provide an interface for creating families of related or dependent objects without specifying their concrete classes.
// http://www.dofactory.com/net/abstract-factory-design-pattern
namespace AbstractFactory.RealWorld
{

    // Demonstrates the creation of different animal worlds for a computer game using different factories
    // although the animals created by the Continent factories are different, the interactions among the animals remain the same...
    class Program
    {
        static void Main(string[] args)
        {

            ContinentFactory africa = new AfricaFactory();
            AnimalWorld world = new AnimalWorld(africa);
            world.RunFoodChain();

            ContinentFactory america = new AfricaFactory();
            world = new AnimalWorld(america);
            world.RunFoodChain();

            Console.ReadKey();

        }

        // Client
        class AnimalWorld{
            private Herbivore _herbivore;
            private Carnivore _carnivore;

            public AnimalWorld(ContinentFactory factory)
            {
                _carnivore = factory.CreateCarnivore();
                _herbivore = factory.CreateHerbivore();
            }

            public void RunFoodChain()
            {
                _carnivore.Eat(_herbivore);
            }
        }

        // Abstract classes
        // The AbstractProductA abstract class
        abstract class Herbivore { }

        // The AbstractProductB abstract class
        abstract class Carnivore
        {
            public abstract void Eat(Herbivore h);
        }

        // The Abstract Factory
        abstract class ContinentFactory
        {
            public abstract Herbivore CreateHerbivore();
            public abstract Carnivore CreateCarnivore();
        }

        // implementation
        // ProductA1 class
        class Wildebeest : Herbivore { }

        // ProductB1 class
        class Lion : Carnivore
        {
            public override void Eat(Herbivore h)
            {
                Console.WriteLine(this.GetType().Name + " eats " + h.GetType().Name);
            }
        }

        // ProductA2
        class Bison : Herbivore
        {

        }

        // ProductB2
        class Wolf : Carnivore
        {
            public override void Eat(Herbivore h)
            {
                Console.WriteLine(this.GetType().Name + " eats " + h.GetType().Name);
            }
        }

        // ConcreteFactory 1
        class AfricaFactory : ContinentFactory
        {
            public override Herbivore CreateHerbivore()
            {
                return new Wildebeest();
            }
            public override Carnivore CreateCarnivore()
            {
                return new Lion();
            }
        }

        // ConcreteFactory2
        class AmericaFactory : ContinentFactory
        {
            public override Carnivore CreateCarnivore()
            {
                return new Wolf();
            }

            public override Herbivore CreateHerbivore()
            {
                return new Bison();
            }
        }



    }
}

namespace AbstractFactory.Structural
{
    class Program
    {
        static void Main(string[] args)
        {
            // Abstract Factory 1
            AbstractFactory factory1 = new ConcreteFactory1();
            Client client1 = new Client(factory1);
            client1.run();

            // Abstract Factory 2
            AbstractFactory factory2 = new ConcreteFactory2();
            Client client2 = new Client(factory2);
            client1.run();

            Console.ReadLine();
        }
    }

    // == Abstract classes
    abstract class AbstractProductA
    {}

    abstract class AbstractProductB
    {
        public abstract void Interact(AbstractProductA a);
    }

    abstract class AbstractFactory
    {
        public abstract AbstractProductA CreateProductA();
        public abstract AbstractProductB CreateProductB();

    }

    // == Implementation classes

    class ProductA1: AbstractProductA
    {

    }

    class ProductB1 : AbstractProductB
    {
        public override void Interact(AbstractProductA a)
        {
            Console.WriteLine(this.GetType().Name + " interacts with " + a.GetType().Name);
        }
    }

    class ProductA2 : AbstractProductA
    {

    }

    class ProductB2 : AbstractProductB
    {
        public override void Interact(AbstractProductA a)
        {
            Console.WriteLine(this.GetType().Name + " interacts with " + a.GetType().Name);
        }
    }

    // == Factory Classes

    class ConcreteFactory1 : AbstractFactory
    {
        public override AbstractProductA CreateProductA()
        {
            return new ProductA1();
        }

        public override AbstractProductB CreateProductB()
        {
            return new ProductB1();
        }
    }

    class ConcreteFactory2 : AbstractFactory
    {
        public override AbstractProductA CreateProductA()
        {
            return new ProductA2();
        }

        public override AbstractProductB CreateProductB()
        {
            return new ProductB2();
        }
    }


    // Class for interaction : object creation has been abstracted and there is no need for hard-coded class names
    class Client
    {
        private AbstractProductA _abstractProductA;
        private AbstractProductB _abstractProductB;

        public Client(AbstractFactory factory)
        {
            _abstractProductA = factory.CreateProductA();
            _abstractProductB = factory.CreateProductB();
        }

        public void run()
        {
            _abstractProductB.Interact(_abstractProductA);
        }

    }

}
