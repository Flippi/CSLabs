using System;
namespace Сalculator.Operations
{
    public class Jmp : IOperation
    {
        public char OperatorChar => '#';
        public bool Run(params object[] args)
        {

            var mathBuffer = (Buff)args[0];
            var inStream = (ReadInst)args[1];
            
            Console.CursorTop -= 1;
            int number = inStream.ReadInt( mathBuffer.variables.Count );

            double a = mathBuffer.variables[number - 1];

            mathBuffer.SaveValue(a);

            return true;
        }
    }
}
