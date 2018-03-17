namespace Сalculator.Operations
{
    public class SaveNumberOperation : IOperation
    {
        public char OperatorChar => '\0';
        public bool Run(params object[] args)
        {
            var mathBuffer = (ValuesBuffer)args[0];

            double value = mathBuffer.ReadValue();
            mathBuffer.SaveValue(value);

            return true;
        }
    }
}

