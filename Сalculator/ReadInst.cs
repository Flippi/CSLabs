using System;
using System.Collections.Generic;
using Сalculator.Operations;
using System.Globalization;

namespace Сalculator
{
    public class ReadInst
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

        public int ReadInt(int  a)
        {
            Console.WriteLine("@: #");

            int operand = 0;
            while ( operand < 1 || operand >= a)
            {
                try
                {
                    ConsoleDeleteLine.CleanPreviousLine(4);
                    operand = int.Parse(Console.ReadLine(), NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign);
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return operand;
        }
    }
}
