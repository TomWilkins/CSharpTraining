﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chain.RealWorld
{
    class Program
    {
        static void Main(string[] args)
        {

            Approver larry = new Director();
            Approver sam = new VicePresident();
            Approver tom = new President();

            larry.SetSuccessor(sam);
            sam.SetSuccessor(tom);

            Purchase p = new Purchase(2034, 350.00, "Assets");
            larry.ProcessRequest(p);

            p = new Purchase(2035, 32590.0, "Project X");
            larry.ProcessRequest(p);

            p = new Purchase(2036, 212122.00, "Project Y");
            larry.ProcessRequest(p);

            Console.ReadKey();
        }

        abstract class Approver
        {
            protected Approver successor;

            public void SetSuccessor(Approver successor)
            {
                this.successor = successor;
            }

            public abstract void ProcessRequest(Purchase purchase);
        }

        class Director : Approver
        {
            public override void ProcessRequest(Purchase purchase)
            {
                if(purchase.Amount < 10000.0)
                {
                    Console.WriteLine("{0} approved request# {1}", this.GetType().Name, purchase.Number);
                }else if(successor != null)
                {
                    successor.ProcessRequest(purchase);
                }
            }
        }

        class VicePresident : Approver
        {
            public override void ProcessRequest(Purchase purchase)
            {
                if (purchase.Amount < 25000.0)
                {
                    Console.WriteLine("{0} approved request# {1}", this.GetType().Name, purchase.Number);
                }
                else if (successor != null)
                {
                    successor.ProcessRequest(purchase);
                }
            }
        }

        class President : Approver
        {
            public override void ProcessRequest(Purchase purchase)
            {
                if (purchase.Amount < 100000.0)
                {
                    Console.WriteLine("{0} approved request# {1}", this.GetType().Name, purchase.Number);
                }
                else if (successor != null)
                {
                    successor.ProcessRequest(purchase);
                }
            }
        }

        class Purchase
        {
            private int _number;
            private double _amount;
            private string _purpose;

            // Constructor
            public Purchase(int number, double amount, string purpose)
            {
                this._number = number;
                this._amount = amount;
                this._purpose = purpose;
            }

            // Gets or sets purchase number
            public int Number
            {
                get { return _number; }
                set { _number = value; }
            }

            // Gets or sets purchase amount

            public double Amount
            {
                get { return _amount; }
                set { _amount = value; }
            }

            // Gets or sets purchase purpose
            public string Purpose
            {
                get { return _purpose; }
                set { _purpose = value; }
            }
        }
    }
}

namespace Chain.Structural
{
    class Program
    {
        static void Main(string[] args)
        {

            Handler h1 = new ConcreteHandler1();
            Handler h2 = new ConcreteHandler2();
            Handler h3 = new ConcreteHandler3();
            h1.SetSuccessor(h2);
            h2.SetSuccessor(h3);

            int[] requests = { 2, 5, 14, 22, 18, 3, 27, 20};

            foreach (int req in requests)
            {
                h1.HandleRequest(req);
            }

            Console.ReadKey();


        }

        abstract class Handler
        {
            protected Handler successor;

            public void SetSuccessor(Handler successor)
            {
                this.successor = successor;
            }

            public abstract void HandleRequest(int request);

        }

        class ConcreteHandler1 : Handler
        {
            public override void HandleRequest(int request)
            {
                if(request >= 0 && request < 10)
                {
                    Console.WriteLine("{0} handled request {1}", this.GetType().Name, request);
                }else if(successor != null)
                {
                    successor.HandleRequest(request);
                }
            }
        }

        class ConcreteHandler2 : Handler
        {
            public override void HandleRequest(int request)
            {
                if (request >= 10 && request < 20)
                {
                    Console.WriteLine("{0} handled request {1}", this.GetType().Name, request);
                }
                else if (successor != null)
                {
                    successor.HandleRequest(request);
                }
            }
        }

        class ConcreteHandler3 : Handler
        {
            public override void HandleRequest(int request)
            {
                if (request >= 20 && request < 30)
                {
                    Console.WriteLine("{0} handled request {1}", this.GetType().Name, request);
                }
                else if (successor != null)
                {
                    successor.HandleRequest(request);
                }
            }
        }

    }
}