using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// http://www.dofactory.com/net/bridge-design-pattern
// Decouple an abstraction from its implementation so that the two can vary independently. 

namespace Bridge.RealWorld
{

    //This real-world code demonstrates the Bridge pattern in which a BusinessObject abstraction is decoupled from the implementation in DataObject. The DataObject implementations can evolve dynamically without changing any clients. 

    class Program
    {
        static void Main(string[] args)
        {

            // create refined abstraction
            Customers customers = new Customers("Chicago");

            // Set the implementation of data
            customers.Data = new CustomersData();

            customers.Show();
            customers.Next();
            customers.Show();
            customers.Next();
            customers.Show();
            customers.Next();
            customers.Show();
            customers.Next();
            customers.Add("Shaun Archer");

            customers.ShowAll();

            Console.ReadKey();

        }

        // implementor
        abstract class DataObject
        {
            public abstract void NextRecord();
            public abstract void PriorRecord();
            public abstract void AddRecord(string name);
            public abstract void DeletRecord(string name);
            public abstract void ShowRecord();
            public abstract void ShowAllRecords();
        }

        // abstraction
        class CustomerBase
        {
            private DataObject _dataObject;
            protected string group;

            public CustomerBase(string group)
            {
                this.group = group;
            }

            public DataObject Data
            {
                set { _dataObject = value; }
                get { return _dataObject; }
            }

            public virtual void Next()
            {
                _dataObject.NextRecord();
            }

            public virtual void Prior()
            {
                _dataObject.PriorRecord();
            }

            public virtual void Add(string customer)
            {
                _dataObject.AddRecord(customer);
            }

            public virtual void Delete(string customer)
            {
                _dataObject.DeletRecord(customer);
            }

            public virtual void Show()
            {
                _dataObject.ShowRecord();
            }

            public virtual void ShowAll()
            {
                Console.WriteLine("Customer group: " + group);
                _dataObject.ShowAllRecords();
            }

        }

        // refined abstraction
        class Customers : CustomerBase
        {
            public Customers(string group) : base(group)
            { }

            public override void ShowAll()
            {
                base.ShowAll();
            }
        }

        // ConcreteImplementor
        class CustomersData : DataObject
        {
            private List<String> _customers = new List<String>();
            private int _current = 0;

            public CustomersData()
            {
                _customers.Add("James Weldrake");
                _customers.Add("Martin Simon");
                _customers.Add("Jack Daniels");
            }

            public override void NextRecord()
            {
                if(_current <= _customers.Count -1)
                {
                    _current++;
                }
            }

            public override void PriorRecord()
            {
                if (_current > 0)
                {
                    _current--;
                }
            }

            public override void AddRecord(string customer)
            {
                _customers.Add(customer);
            }

            public override void DeletRecord(string customer)
            {
                _customers.Remove(customer);
            }

            public override void ShowRecord()
            {
                Console.WriteLine(_customers[_current]);
            }

            public override void ShowAllRecords()
            {
                foreach(string c in _customers)
                {
                    Console.WriteLine(" " + c);
                }
            }
        }

    }
}

namespace Bridge.Structural
{
    class Program
    {
        static void Main(string[] args)
        {
            Abstraction ab = new RefinedAbstraction();

            ab.Implementor = new ConcreteImplementorA();
            ab.Operation();

            ab.Implementor = new ConcreteImplementorB();
            ab.Operation();

            Console.ReadKey();


        }

        abstract class Implementor
        {
            public abstract void Operation();
        }

        class Abstraction
        {
            protected Implementor implementor;

            public Implementor Implementor
            {
                set { implementor = value; }
            }

            public virtual void Operation()
            {
                implementor.Operation();
            }
        }

        class RefinedAbstraction : Abstraction
        {
            public override void Operation()
            {
                implementor.Operation();
            }
        }

        class ConcreteImplementorA : Implementor
        {
            public override void Operation()
            {
                Console.WriteLine("ConcreteImplementorA Operation");
            }
        }

        class ConcreteImplementorB : Implementor
        {
            public override void Operation()
            {
                Console.WriteLine("ConcreteImplementorB Operation");
            }
        }
    }
}
