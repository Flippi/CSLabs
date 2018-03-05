namespace Сalculator.Operations
{
    public class Mul : IOperation
    {
        public char OperatorChar => '*';
        public bool Run(params object[] args)
        {
            var mathBuffer = (Buff)args[0];

            double a = mathBuffer.RetTopValue();
            double b = mathBuffer.ReadValue();
            a = a * b;
            mathBuffer.SaveValue(a);

            return true;
        }
    }
}
