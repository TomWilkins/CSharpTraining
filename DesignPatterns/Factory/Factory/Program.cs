using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//http://www.dofactory.com/net/factory-method-design-pattern

// Defines an interface for creating an object, but lets subclasses decide which class to instantiate.
// Lets a class defer instantiateion to subclasses

namespace Factory.RealWorld
{

    class Program
    {
        static void Main(string[] args)
        {
        }

        abstract class Page { }

        class SkillsPage : Page { }

        class EducationPage : Page { }

        class ExperiencePage : Page { }

        class IntroductionPage : Page { }

        class ResultsPage : Page { }

        class ConclusionPage : Page { }

        class SummaryPage : Page { }

        class BibliographyPage : Page { }


        abstract class Document
        {
            private List<Page> _pages = new List<Page>();

            // Factory Method
            public abstract void CreatePages();

            // Constructor calls abstract factory method
            public Document()
            {
                this.CreatePages();
            }

            public List<Page> Pages
            {
                get { return _pages;  }
            }
        }

        class Report : Document
        {
            public override void CreatePages()
            {
                Pages.Add(new IntroductionPage());
                Pages.Add(new ResultsPage());
                Pages.Add(new ConclusionPage());
                Pages.Add(new SummaryPage());
                Pages.Add(new BibliographyPage());
            }
        }

        class Resume : Document
        {
            public override void CreatePages()
            {
                Pages.Add(new SkillsPage());
                Pages.Add(new EducationPage());
                Pages.Add(new ExperiencePage());
            }
        }


    }


}


namespace Factory.Structural
{

    class Program
    {
        static void Main(string[] args)
        {

            Creator[] creators = new Creator[2];

            creators[0] = new ConcreteCreatorA();
            creators[1] = new ConcreteCreatorB();

            foreach (Creator creator in creators)
            {
                Product product = creator.FactoryMethod();
                Console.WriteLine("Created {0}", product.GetType().Name);
            }

            Console.ReadKey();

        }

        abstract class Product { }

        class ConcreteProductA : Product { }

        class ConcreteProductB : Product { }

        abstract class Creator
        {
            public abstract Product FactoryMethod();
        }

        class ConcreteCreatorA : Creator
        {
            public override Product FactoryMethod()
            {
                return new ConcreteProductA();
            }
        }

        class ConcreteCreatorB : Creator
        {
            public override Product FactoryMethod()
            {
                return new ConcreteProductB();
            }
        }


    }


}
