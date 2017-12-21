using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//http://www.dofactory.com/net/builder-design-pattern

namespace Builder.RealWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            VehicleBuilder builder;

            Shop shop = new Shop();

            builder = new ScooterBuilder();
            shop.Construct(builder);
            builder.Vehicle.Show();

            builder = new CarBuilder();
            shop.Construct(builder);
            builder.Vehicle.Show();

            builder = new MotorCycleBuilder();
            shop.Construct(builder);
            builder.Vehicle.Show();


            Console.ReadKey();
        }

        class Shop
        {
            public void Construct(VehicleBuilder builder)
            {
                builder.BuildFrame();
                builder.BuildEngine();
                builder.BuildDoors();
                builder.BuildWheels();
            }
        }

        class Vehicle
        {
            private string _vehicleType;
            private Dictionary<string, string> _parts = new Dictionary<string, string>();

            public Vehicle(string vehicleType)
            {
                this._vehicleType = vehicleType;
            }

            // Custom indexer
            public string this[string key]
            {
                get { return _parts[key]; }
                set { _parts[key] = value; }
            }

            public void Show()
            {
                Console.WriteLine("Vehicle Type: {0}", _vehicleType);
                Console.WriteLine("Frame: {0}", _parts["frame"]);
                Console.WriteLine("Engine: {0}", _parts["engine"]);
                Console.WriteLine("Wheels: {0}", _parts["wheels"]);
                Console.WriteLine("Doors: {0}", _parts["doors"]);
            }

        }

        abstract class VehicleBuilder
        {
            protected Vehicle vehicle;

            public Vehicle Vehicle
            {
                get { return vehicle; }
            }

            public abstract void BuildFrame();
            public abstract void BuildEngine();
            public abstract void BuildWheels();
            public abstract void BuildDoors();

        }

        class MotorCycleBuilder : VehicleBuilder
        {
            public MotorCycleBuilder()
            {
                vehicle = new Vehicle("MotorCycle");
            }

            public override void BuildDoors()
            {
                vehicle["doors"] = "0"; // can be accessed because we override Vehicle class index
            }

            public override void BuildEngine()
            {
                vehicle["engine"] = "500 cc";
            }

            public override void BuildFrame()
            {
                vehicle["frame"] = "Motorcycle Frame";
            }

            public override void BuildWheels()
            {
                vehicle["wheels"] = "2";
            }
        }

        class CarBuilder : VehicleBuilder
        {
            public CarBuilder()
            {
                vehicle = new Vehicle("Car");
            }

            public override void BuildDoors()
            {
                vehicle["doors"] = "4"; // can be accessed because we override Vehicle class index
            }

            public override void BuildEngine()
            {
                vehicle["engine"] = "2500 cc";
            }

            public override void BuildFrame()
            {
                vehicle["frame"] = "Car Frame";
            }

            public override void BuildWheels()
            {
                vehicle["wheels"] = "4";
            }
        }

        class ScooterBuilder : VehicleBuilder
        {
            public ScooterBuilder()
            {
                vehicle = new Vehicle("Scooter");
            }

            public override void BuildDoors()
            {
                vehicle["doors"] = "0"; // can be accessed because we override Vehicle class index
            }

            public override void BuildEngine()
            {
                vehicle["engine"] = "50 cc";
            }

            public override void BuildFrame()
            {
                vehicle["frame"] = "Scooter Frame";
            }

            public override void BuildWheels()
            {
                vehicle["wheels"] = "2";
            }
        }

    }
}


namespace Builder.Structural
{
    class Program
    {
        static void Main(string[] args)
        {

            Director director = new Director();
            Builder b1 = new ConcreteBuilder1();
            Builder b2 = new ConcreteBuilder2();

            director.Construct(b1);
            Product p1 = b1.GetResult();
            p1.Show();

            director.Construct(b2);
            Product p2 = b2.GetResult();
            p2.Show();

            Console.ReadKey();
        }


        class Product
        {
            private List<string> _parts = new List<string>();
            public void Add(string part)
            {
                _parts.Add(part);
            }
            public void Show()
            {
                Console.WriteLine("Product Parts:");
                foreach (string part in _parts)
                {
                    Console.WriteLine(part);
                }
            }
        }

        abstract class Builder
        {
            public abstract void BuildPartA();
            public abstract void BuildPartB();
            public abstract Product GetResult();
        }

        class Director
        {
            public void Construct(Builder builder)
            {
                builder.BuildPartA();
                builder.BuildPartB();
            }
        }

        class ConcreteBuilder1 : Builder
        {

            private Product _product = new Product();

            public override void BuildPartA()
            {
                _product.Add("PartA");
            }

            public override void BuildPartB()
            {
                _product.Add("PartB");
            }

            public override Product GetResult()
            {
                return _product;
            }
        }

        class ConcreteBuilder2 : Builder
        {

            private Product _product = new Product();

            public override void BuildPartA()
            {
                _product.Add("PartX");
            }

            public override void BuildPartB()
            {
                _product.Add("PartY");
            }

            public override Product GetResult()
            {
                return _product;
            }
        }

    }
}
