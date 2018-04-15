using System;
using Сalculator.Lab2;
namespace Сalculator.Operations
{
    public class JumpOperation : IOperation
    {
        public char OperatorChar => '#';
        public bool Run(params object[] args)
        {

            var mathBuffer = (ValuesBuffer)args[0];
            var historyBuffer = (HistoryOperations)args[2];
            var inStream = (InOutStream)args[1];

            
            int number = inStream.ReadInt(mathBuffer.variables.Count);

            double a = mathBuffer.variables[number - 1];

            mathBuffer.SaveValue(a);
            historyBuffer.AddNewOperation(OperatorChar, a, number);

            return true;
        }
    }
}
