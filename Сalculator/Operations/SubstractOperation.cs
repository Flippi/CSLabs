using Сalculator.Lab2;
namespace Сalculator.Operations
{
    public class SubstractOperation : IOperation
    {
        public char OperatorChar => '-';
        public bool Run(params object[] args)
        {
            var mathBuffer = (ValuesBuffer)args[0];
            var historyBuffer = (HistoryOperations)args[2];

            double a = mathBuffer.ReturnTopValue();
            double b = mathBuffer.ReadValue();
            a = a - b;
            mathBuffer.СheckingValueForInfinity(a);
            historyBuffer.AddNewOperation(OperatorChar, a, 0);
            return true;
        }
    }
}