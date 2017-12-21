using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy.RealWorld
{
    class Program
    {
        static void Main(string[] args)
        {

            MathProxy proxy = new MathProxy();

            Console.WriteLine("4+2=" + proxy.Add(4,2));
            Console.WriteLine("4-2=" + proxy.Sub(4, 2));
            Console.WriteLine("4/2=" + proxy.Div(4, 2));
            Console.WriteLine("4*2=" + proxy.Mul(4, 2));

            Console.ReadKey();

        }

        public interface IMath
        {
            double Add(double x, double y);
            double Sub(double x, double y);
            double Mul(double x, double y);
            double Div(double x, double y);
        }

        class Math : IMath
        {
            public double Add(double x, double y)
            {
                return x + y;
            }

            public double Div(double x, double y)
            {
                return x / y;
            }

            public double Mul(double x, double y)
            {
                return x * y;
            }

            public double Sub(double x, double y)
            {
                return x - y;
            }
        }

        class MathProxy : IMath
        {
            private Math _math = new Math();

            public double Add(double x, double y)
            {
                return _math.Add(x, y);
            }

            public double Div(double x, double y)
            {
                return _math.Div(x, y);
            }

            public double Mul(double x, double y)
            {
                return _math.Mul(x, y);
            }

            public double Sub(double x, double y)
            {
                return _math.Sub(x, y);
            }
        }

    }
}

namespace Proxy.Structural
{
    class Program
    {
        static void Main(string[] args)
        {

            // proxy class for realsubject
            Proxy proxy = new Proxy();
            proxy.Request();

            Console.ReadKey();

        }

        abstract class Subject
        {
            public abstract void Request();
        }

        class RealSubject : Subject
        {
            public override void Request()
            {
                Console.WriteLine("Real subject request");
            }
        }

        class Proxy : Subject
        {
            private RealSubject _realSubject;

            public override void Request()
            {
                if(_realSubject == null)
                {
                    _realSubject = new RealSubject();
                }

                _realSubject.Request();
            }

        }

    }
}
