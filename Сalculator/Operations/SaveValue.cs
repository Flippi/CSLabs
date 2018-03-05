namespace Сalculator.Operations
{
    public class SaveNumber : IOperation
    {
        public char OperatorChar => '\0';
        public bool Run(params object[] args)
        {
            var mathBuffer = (Buff)args[0];

            double value = mathBuffer.ReadValue();
            mathBuffer.SaveValue( value );

            return true;
        }
    }
}
