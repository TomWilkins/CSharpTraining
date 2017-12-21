using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype.RealWorld
{
    class Program
    {
        static void Main(string[] args)
        {

            ColorManager colorManager = new ColorManager();

            // standard colors
            colorManager["red"] = new Color(255, 0, 0);
            colorManager["green"] = new Color(0, 255, 0);
            colorManager["blue"] = new Color(0, 0, 255);

            // personalised colors 
            colorManager["angry"] = new Color(255, 54, 0);
            colorManager["peace"] = new Color(128, 211, 128);
            colorManager["flame"] = new Color(211, 34, 20);

            Color color1 = colorManager["red"].Clone() as Color;
            Color color2 = colorManager["peace"].Clone() as Color;
            Color color3 = colorManager["flame"].Clone() as Color;
        }

        abstract class ColorPrototype
        {
            public abstract ColorPrototype Clone();
        }

        class Color : ColorPrototype
        {
            private int _red;
            private int _green;
            private int _blue;

            public Color(int red, int green, int blue)
            {
                _red = red;
                _green = green;
                _blue = blue;
            }

            // creates a shallow copy
            public override ColorPrototype Clone()
            {
                Console.WriteLine("Cloning color RBG: {0,3},{1,3},{2,3}",_red,_green,_blue);
                return this.MemberwiseClone() as ColorPrototype;
            }
        }

        class ColorManager
        {
            private Dictionary<string, ColorPrototype> _colors = new Dictionary<string, ColorPrototype>();

            // indexer
            public ColorPrototype this[string key]
            {
                get { return _colors[key]; }
                set { _colors.Add(key, value); }
            }
        }



    }
}

namespace Prototype.Structural
{
    class Program
    {
        static void Main(string[] args)
        {

            ConcretePrototype1 p1 = new ConcretePrototype1("I");
            ConcretePrototype1 c1 = (ConcretePrototype1)p1.Clone();
            Console.WriteLine("Cloned: {0}",c1.id);

            ConcretePrototype2 p2 = new ConcretePrototype2("II");
            ConcretePrototype2 c2 = (ConcretePrototype2)p2.Clone();
            Console.WriteLine("Cloned: {0}", c2.id);

            Console.ReadKey();

        }

        abstract class Prototype
        {
            private string _id;

            public Prototype(string id)
            {
                this._id = id;
            }

            public string id
            {
                get { return _id; }
            }

            public abstract Prototype Clone();
        }

        class ConcretePrototype1 : Prototype
        {
            public ConcretePrototype1(string id) : base(id) { }

            public override Prototype Clone()
            {
                return (Prototype)this.MemberwiseClone();
            }
        }

        class ConcretePrototype2 : Prototype
        {
            public ConcretePrototype2(string id) : base(id) { }

            public override Prototype Clone()
            {
                return (Prototype)this.MemberwiseClone();
            }
        }
    }
}
