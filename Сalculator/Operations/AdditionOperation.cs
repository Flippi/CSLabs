
namespace Сalculator.Operations
{
    public class AdditionOperation : IOperation
    {
        public char OperatorChar => '+';
        public bool Run(params object[] args)
        {
            var mathBuffer = (ValuesBuffer)args[0];

            double a = mathBuffer.ReturnTopValue();
            double b = mathBuffer.ReadValue();
            a = a + b;
            mathBuffer.СheckingValueForInfinity(a);

            return true;
        }
    }
}
