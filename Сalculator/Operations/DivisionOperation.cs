using Сalculator.Lab2;
namespace Сalculator.Operations
{
    public class DivisionOperation : IOperation
    {
        public char OperatorChar => '/';
        public bool Run(params object[] args)
        {
            var mathBuffer = (ValuesBuffer)args[0];
            var outStream = (InOutStream)args[1];
            var historyBuffer = (HistoryOperations)args[2];

            double b = mathBuffer.ReadValue();

            while (b == 0)
            {
                outStream.SendException();
                b = mathBuffer.ReadValue();
            }

            double a = mathBuffer.ReturnTopValue();
            a = a / b;
            mathBuffer.СheckingValueForInfinity(a);
            historyBuffer.AddNewOperation(OperatorChar, a, 0);

            return true;
        }
    }
}
