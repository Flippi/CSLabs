using System;
namespace Сalculator.Operations
{
    public class JumpOperation : IOperation
    {
        public char OperatorChar => '#';
        public bool Run(params object[] args)
        {

            var mathBuffer = (ValuesBuffer)args[0];
            var inStream = (InOutStream)args[1];
            
            Console.CursorTop -= 1;
            int number = inStream.ReadInt( mathBuffer.variables.Count );

            double a = mathBuffer.variables[number - 1];

            mathBuffer.SaveValue(a);

            return true;
        }
    }
}
