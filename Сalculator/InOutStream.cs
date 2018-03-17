using System;
using System.Collections.Generic;
using Сalculator.Operations;
using System.Globalization;

namespace Сalculator
{
    public class InOutStream
    {
        public virtual IOperation ReadOperation(List<IOperation> list)
        {
            IOperation result = null;
            char key;

            Console.Write("@: ");

            do
            {
                key = Console.ReadKey(true).KeyChar;
            }
            while ((result = list.Find(x => x.OperatorChar == key)) == null);

            Console.WriteLine(result.OperatorChar);
            return result;
        }

        public double ReadOperand()
        {
            while (true)

            {
                Console.Write(" > ");
                try
                {
                    double Operand;
                    Operand = double.Parse(Console.ReadLine(), NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign);
                    return Operand;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public int ReadInt(int a)
        {
            

            int operand = 0;
            while (operand < 1 || operand >= a)
            {
                try
                {
                    Console.WriteLine("@: #");
                    ConsoleDeleteLine.CleanPreviousLine(4);
                    operand = int.Parse(Console.ReadLine(), NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign);

                }
                catch
                {
                    ConsoleDeleteLine.CleanPreviousLine(4);
                }
            }

            return operand;
        }

        public void HelpMessage()
        {
            Console.WriteLine("Usage: \n    " +
               "when first symbol on line is ‘>’ –enter operand (number) \n    " +
               "when first symbol on line is ‘@’ –enter operation \n    " +
               "operation is one of ‘+’, ‘-‘, ‘/’, ‘*’or \n    " +
               "‘#’ followed with number of evaluation step \n    " +
               "‘q’ to exit");
        }

        public void OutElement(int ElementNumber, double Element)
        {
            Console.WriteLine(" [" + ElementNumber + "] = " + Element);
        }

        public virtual void SendException() => Console.WriteLine(new DivideByZeroException().Message);
    }
}
