using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator.RealWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create book
            Book book = new Book("Worley", "Inside ASP.NET", 10);
            book.Display();

            // Create video
            Video video = new Video("Spielberg", "Jaws", 23, 92);
            video.Display();

            // Make video borrowable, then borrow and display     
            Console.WriteLine("\nMaking video borrowable:");
            Borrowable borrowvideo = new Borrowable(video);
            borrowvideo.BorrowItem("Customer #1");
            borrowvideo.BorrowItem("Customer #2");
            borrowvideo.Display();



            // Wait for user

            Console.ReadKey();
        }

        abstract class LibraryItem
        {
            private int _numCopies;

            public int NumCopies
            {
                get { return _numCopies; }
                set { _numCopies = value; }
            }

            public abstract void Display();
        }

        class Book : LibraryItem
        {
            private string _author;
            private string _title;

            public Book(string author, string title, int numCopies)
            {
                _author = author;
                _title = title;
                NumCopies = numCopies;
            }

            public override void Display()
            {
                Console.WriteLine("\nBook ----");
                Console.WriteLine(" author {0}", _author);
                Console.WriteLine(" title {0}", _title);
                Console.WriteLine(" # copies {0}", NumCopies);
            }
        }

        class Video : LibraryItem
        {
            private string _director;
            private string _title;
            private int _playTime;

            public Video(string director, string title, int numCopies, int playTime)
            {
                _director = director;
                _title = title;
                NumCopies = numCopies;
                _playTime = playTime;
            }


            public override void Display()
            {
                Console.WriteLine("\nVideo ----");
                Console.WriteLine(" director {0}", _director);
                Console.WriteLine(" title {0}", _title);
                Console.WriteLine(" play time {0}", _playTime);
                Console.WriteLine(" # copies {0}", NumCopies);
            }
        }

        abstract class Decorator : LibraryItem
        {
            protected LibraryItem libraryItem;

            public Decorator(LibraryItem item)
            {
                libraryItem = item;
            }

            public override void Display()
            {
                libraryItem.Display();
            }
        }

        class Borrowable : Decorator
        {
            protected List<String> borrowers = new List<string>();

            public Borrowable(LibraryItem item) : base(item)
            {
            }

            public void BorrowItem(string name)
            {
                borrowers.Add(name);
                libraryItem.NumCopies--;
            }

            public void ReturnItem(string name)
            {
                borrowers.Remove(name);
                libraryItem.NumCopies++;
            }

            public override void Display()
            {
                base.Display();
                foreach(string borrower in borrowers)
                {
                    Console.WriteLine(" borrower: " + borrower);
                }
            }
        }
    }
}

namespace Decorator.Structural
{
    class Program
    {
        static void Main(string[] args)
        {

            ConcreteComponent c = new ConcreteComponent();
            ConcreteDectoratorA d1 = new ConcreteDectoratorA();
            ConcreteDectoratorB d2 = new ConcreteDectoratorB();

            d1.SetComponent(c);
            d2.SetComponent(d1);

            d2.Operation();

            Console.ReadKey();

        }

        abstract class Component
        {
            public abstract void Operation();
        }

        class ConcreteComponent : Component
        {
            public override void Operation()
            {
                Console.WriteLine("ConcreteComponent.Operation()");
            }
        }

        abstract class Decorator : Component
        {
            protected Component component;

            public void SetComponent(Component component)
            {
                this.component = component;
            }

            public override void Operation()
            {
                if(component != null)
                {
                    component.Operation();
                }
            }
        }

        class ConcreteDectoratorA : Decorator
        {
            public override void Operation()
            {
                base.Operation();
                Console.WriteLine("ConcreteDectoratorA.Operation()");
            }
        }

        class ConcreteDectoratorB : Decorator
        {
            public override void Operation()
            {
                base.Operation();
                AddedBehavior();
                Console.WriteLine("ConcreteDectoratorB.Operation()");
            }

            void AddedBehavior()
            {

            }

        }

    }
}