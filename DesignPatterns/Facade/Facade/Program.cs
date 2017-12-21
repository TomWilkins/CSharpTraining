using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade.RealWorld
{
    class Program
    {
        static void Main(string[] args)
        {

            Mortgage mortgage = new Mortgage();

            Customer customer = new Customer("Tom");
            bool eligible = mortgage.IsEligible(customer, 125000);

            Console.WriteLine(customer.Name + " has been " + (eligible ? "Approved" : "Rejected") );


            Console.ReadKey();
        }

        class Bank
        {
            public bool HasSufficientSaving(Customer c, int amount)
            {
                Console.WriteLine("Check bank for " + c.Name);
                return true;
            }
        }

        class Credit
        {
            public bool HasGoodCredit(Customer c)
            {
                Console.WriteLine("Check loans for " + c.Name);
                return true;
            }
        }

        class Loan
        {
            public bool HasNoBadLoans(Customer c)
            {
                Console.WriteLine("Check loans for " + c.Name);
                return true;
            }
        }

        class Mortgage
        {
            private Bank _bank = new Bank();
            private Loan _loan = new Loan();
            private Credit _credit = new Credit();

            public bool IsEligible(Customer cust, int amount)
            {
                Console.WriteLine("{0} applies for {1:C} loan",cust.Name, amount);

                bool eligible = true;

                if(!_bank.HasSufficientSaving(cust, amount))
                {
                    eligible = false;
                }else if (!_loan.HasNoBadLoans(cust))
                {
                    eligible = false;
                }else if (!_credit.HasGoodCredit(cust))
                {
                    eligible = false;
                }

                return eligible;
            }

        }


        class Customer
        {
            private string _name;

            public Customer(string name)
            {
                _name = name;
            }

            public string Name
            {
                get { return _name; }
            }
        }


    }
}

namespace Facade.Structural
{
    class Program
    {
        static void Main(string[] args)
        {
            Facade facade = new Facade();

            facade.MethodA();
            facade.MethodB();

            Console.ReadKey();
        }

        class SubSystemOne
        {
            public void MethodOne()
            {
                Console.WriteLine("SubSystemOne Method");
            }
        }

        class SubSystemTwo
        {
            public void MethodTwo()
            {
                Console.WriteLine("SubSystemTwo Method");
            }
        }

        class SubSystemThree
        {
            public void MethodThree()
            {
                Console.WriteLine("SubSystemThree Method");
            }
        }

        class SubSystemFour
        {
            public void MethodFour()
            {
                Console.WriteLine("SubSystemFour Method");
            }
        }

        class Facade
        {
            private SubSystemOne _one;
            private SubSystemTwo _two;
            private SubSystemThree _three;
            private SubSystemFour _four;

            public void MethodA()
            {
                Console.WriteLine("Method A");
                _one.MethodOne();
                _two.MethodTwo();
                _four.MethodFour();
            }

            public void MethodB()
            {
                Console.WriteLine("Method B");
                _two.MethodTwo();
                _three.MethodThree();
            }
        }
    }
}