using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YieldExplained
{
    class Program
    {

        static List<int> MyList = new List<int>();

        static void FillList()
        {
            MyList.Add(1);
            MyList.Add(2);
            MyList.Add(3);
            MyList.Add(4);
            MyList.Add(5);
        }

        static void Main(string[] args)
        {
            FillList();
            // 1-5
            foreach (int i in MyList)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine();
            // 4-5
            foreach (int i in Filter())
            {
                Console.WriteLine(i);
            }

            Console.WriteLine();
            // 4-5 using yield
            foreach (int i in Filter2())
            {
                Console.WriteLine(i);
            }

            Console.ReadLine();

        }

        // Filter used to remove unwanted data
        static IEnumerable<int> Filter()
        {
            List<int> temp = new List<int>();
            foreach (int i in MyList)
            {
                if(i > 3)
                {
                    temp.Add(i);
                }
            }
            return temp;
        }

        // yield enables us to get rid of the temp list...
        // when this happens, it will skip the 1,2,3 and then yield 4, the control moves back to the caller (main), displays 4 and then goes back to the function for 5
        // whereas in a list, it will perform the filtering and then return the values together at the end
        // yield allows data to be returned to the caller for processing, before returning control back to the function for the next item.
        static IEnumerable<int> Filter2()
        {
            foreach (int i in MyList)
            {
                if (i > 3)
                {
                    yield return i;
                }
            }
        }

        // when using yield, it is stateful meaning that when values exit the method with a return and re-enters, it will remember the state of previous values
        // in this case, it will accumulate runningtotal
        static IEnumerable<int> RunningTotal()
        {
            int runningtotal = 0;
            foreach (int i in MyList)
            {
                runningtotal += i;
                yield return (runningtotal);
            }
        }
    }
}
