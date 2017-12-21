using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite.RralWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            CompositeElement root = new CompositeElement("Picture");
            root.Add(new PrimitiveElement("Red Line"));
            root.Add(new PrimitiveElement("Blue Circle"));
            root.Add(new PrimitiveElement("Green Box"));

            CompositeElement comp = new CompositeElement("Two Circles");
            comp.Add(new PrimitiveElement("Black Circle"));
            comp.Add(new PrimitiveElement("White Circle"));
            root.Add(comp);

            PrimitiveElement pe = new PrimitiveElement("Yellow Line");
            root.Add(pe);
            root.Remove(pe);

            root.Display(1);

            Console.ReadKey();

        }

        // component class
        abstract class DrawingElement
        {
            protected string _name;

            public DrawingElement(string name)
            {
                this._name = name;
            }

            public abstract void Add(DrawingElement d);
            public abstract void Remove(DrawingElement d);
            public abstract void Display(int indent);
        }

        // Leaf
        class PrimitiveElement : DrawingElement
        {
            public PrimitiveElement(string name):base(name)
            {

            }

            public override void Add(DrawingElement d)
            {
                Console.WriteLine("Cannot add to PrimitiveElement");
            }

            public override void Display(int indent)
            {
                Console.WriteLine(new String('-', indent)+" "+ _name);
            }

            public override void Remove(DrawingElement d)
            {
                Console.WriteLine("Cannot remove from a PrimitiveElement");
            }
        }

        // Composite
        class CompositeElement: DrawingElement
        {
            private List<DrawingElement> elements = new List<DrawingElement>();

            public CompositeElement(string name) : base(name)
            {
            }

            public override void Add(DrawingElement d)
            {
                elements.Add(d);
            }

            public override void Display(int indent)
            {
                Console.WriteLine(new string('-', indent) + "+ " + _name);
                foreach (DrawingElement d in elements)
                {
                    d.Display(indent + 2);
                }
            }

            public override void Remove(DrawingElement d)
            {
                elements.Remove(d);
            }
        }

    }
}

namespace Composite.Structural
{
    class Program
    {
        static void Main(string[] args)
        {

            // Create a tree structure
            Composite root = new Composite("root");
            root.Add(new Leaf("Leaf A"));
            root.Add(new Leaf("Leaf B"));

            Composite comp = new Composite("Composite X");
            comp.Add(new Leaf("Leaf XA"));
            comp.Add(new Leaf("Leaf XB"));

            root.Add(comp);
            root.Add(new Leaf("Leaf C"));

            // Add and remove a leaf
            Leaf leaf = new Leaf("Leaf D");
            root.Add(leaf);
            root.Remove(leaf);

            // Recursively display tree
            root.Display(1);

            // Wait for user
            Console.ReadKey();

        }

        abstract class Component
        {
            protected string name;

            public Component(string name)
            {
                this.name = name;
            }

            public abstract void Add(Component C);
            public abstract void Remove(Component C);
            public abstract void Display(int depth);
        }

        class Composite : Component
        {
            private List<Component> _children = new List<Component>();

            public Composite(string name) :base(name){ }

            public override void Add(Component C)
            {
                _children.Add(C);
            }

            public override void Display(int depth)
            {
                Console.WriteLine(new string('-', depth) + name);

                // recursively display
                foreach (Component c in _children)
                {
                    c.Display(depth + 2);
                }
            }

            public override void Remove(Component C)
            {
                _children.Remove(C);
            }
        }

        class Leaf: Component
        {
            public Leaf(string name) : base(name) { }

            public override void Add(Component C)
            {
                Console.WriteLine("Cannot add to a leaf");
            }

            public override void Remove(Component C)
            {
                Console.WriteLine("Cannot remove from a leaf");
            }

            public override void Display(int depth)
            {
                Console.WriteLine(new String('-', depth) + name);
            }

        }



    }
}
