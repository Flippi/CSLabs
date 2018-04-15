using Сalculator.Lab2;
namespace Сalculator.Operations
{
    public class SaveNumberOperation : IOperation
    {
        public char OperatorChar => '\0';
        public bool Run(params object[] args)
        {
            var mathBuffer = (ValuesBuffer)args[0];
            var historyBuffer = (HistoryOperations)args[2];

            double value = mathBuffer.ReadValue();
            mathBuffer.SaveValue(value);
            historyBuffer.AddNewOperation(OperatorChar, value, 0);
            return true;
        }
    }
}

