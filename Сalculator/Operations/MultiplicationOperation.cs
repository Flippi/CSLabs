using Сalculator.Lab2;
using System;
namespace Сalculator.Operations
{
    public class MultiplicationOperation : IOperation
    {
        public char OperatorChar => '*';
        public bool Run(params object[] args)
        {
            var mathBuffer = (ValuesBuffer)args[0];
            var historyBuffer = (HistoryOperations)args[2];

            double a = mathBuffer.ReturnTopValue();
            double b = mathBuffer.ReadValue();
            a = a * b;

            mathBuffer.СheckingValueForInfinity(a);
            historyBuffer.AddNewOperation(OperatorChar, a, 0);
            return true;
        }
    }
}
