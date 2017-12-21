using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.RealWorld
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        abstract class Command
        {
            public abstract void Execute();
            public abstract void UnExecute();
        }

        class CalculatorCommand : Command
        {
            private char _operator;
            private int _operand;
            private Calculator _calculator;

            public CalculatorCommand(Calculator calculator, char @operator, int operand)
            {
                _calculator = calculator;
                _operand = operand;
                _operator = @operator;
            }

            public char Operator
            {
                set { _operator = value; }
            }

            public int Operand
            {
                set { _operand = value; }
            }

            public override void Execute()
            {
                _calculator.Operation(_operator, _operand);
            }

            public override void UnExecute()
            {
                _calculator.Operation(Undo(_operator), _operand);
            }

            private char Undo(char @operator)
            {
                switch (@operator)
                {
                    case '+': return '-';
                    case '-': return '+';
                    case '*': return '/';
                    case '/': return '*';
                   default:
                        throw new  ArgumentException("@operator");                    
                }
            }

        }
        class Calculator
        {
            private int _curr = 0;
            public void Operation(char @operator, int operand)
            {
                switch (@operator)
                {
                    case '+': _curr += operand; break;
                    case '-': _curr -= operand; break;
                    case '*': _curr *= operand; break;
                    case '/': _curr /= operand; break;
                }
                Console.WriteLine(
                  "Current value = {0,3} (following {1} {2})",
                  _curr, @operator, operand);
           }
        }


    }
}

namespace Command.Structural
{
    class Program
    {
        static void Main(string[] args)
        {
            Receiver receiver = new Receiver();
            Command command = new ConcreteCommand(receiver);
            Invoker invoker = new Invoker();

            invoker.SetCommand(command);
            invoker.ExecuteCommand();

            Console.ReadKey();

        }

        abstract class Command
        {
            protected Receiver receiver;

            public Command(Receiver receiver)
            {
                this.receiver = receiver;
            }
            public abstract void Execute();
        }

        class ConcreteCommand : Command
        {
            public ConcreteCommand(Receiver receiver) : base(receiver) { }

            public override void Execute()
            {
                receiver.Action();
            }
        }

        class Receiver
        {
            public void Action()
            {
                Console.WriteLine("Called receiver action");
            }
        }

        class Invoker
        {
            private Command _command;

            public void SetCommand(Command command)
            {
                this._command = command;
            }

            public void ExecuteCommand()
            {
                _command.Execute();
            }
        }
    }
}
