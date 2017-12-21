using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        class Context
        {
            private string _input;
            private int _output;

            public Context(string input)
            {
                _input = input;
            }

            public string Input
            {
                get { return _input; }
                set { _input = value;  }
            }

            public int Output
            {
                get { return _output; }
                set { _output = value; }
            }

        }

        abstract class Expression
        {
            public void Interpret(Context context)
            {
                if (context.Input.Length == 0)
                    return;

                if (context.Input.StartsWith(Nine()))
                {
                    context.Output += (9 * Multiplier());
                    context.Input = context.Input.Substring(2);
                }
                else if (context.Input.StartsWith(Four()))
                {
                    context.Output += (4 * Multiplier());
                    context.Input = context.Input.Substring(2);
                }
                else if (context.Input.StartsWith(Five()))
                {
                    context.Output += (5 * Multiplier());
                    context.Input = context.Input.Substring(1);
                }
                while (context.Input.StartsWith(One()))
                {
                    context.Output += (1 * Multiplier());
                    context.Input = context.Input.Substring(1);
                }
            }

            public abstract string One();
            public abstract string Four();
            public abstract string Five();
            public abstract string Nine();
            public abstract int Multiplier();
        }

        class ThousandExpression : Expression
        {
            public override string One() { return "M"; }
            public override string Four() { return " "; }
            public override string Five() { return " "; }
            public override string Nine() { return " "; }
            public override int Multiplier() { return 1000; }
        }
    }
}


namespace Interpreter.Structural
{
    class Program
    {
        static void Main(string[] args)
        {

            Context context = new Structural.Program.Context();

            ArrayList list = new ArrayList();

            list.Add(new TerminalExpression());
            list.Add(new NonterminalExpression());
            list.Add(new TerminalExpression());
            list.Add(new TerminalExpression());

            foreach (AbstractExpression exp in list)
            {
                exp.Interpret(context);
            }

        }

        class Context
        {
        }

        abstract class AbstractExpression
        {
            public abstract void Interpret(Context context);
        }

        class TerminalExpression : AbstractExpression
        {
            public override void Interpret(Context context)
            {
                Console.WriteLine("called terminal.interpret");
            }
        }

        class NonterminalExpression : AbstractExpression
        {
            public override void Interpret(Context context)
            {
                Console.WriteLine("called nonterminal.interpret");
            }
        }
    }
}
