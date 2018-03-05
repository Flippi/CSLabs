namespace Сalculator.Operations
{
    public class Div : IOperation
    {
        public char OperatorChar => '/';
        public bool Run(params object[] args)
        {
            var mathBuffer = (Buff)args[0];
            var outStream = (StreamOut)args[1];

            double b = mathBuffer.ReadValue();

            while (b == 0)
            {
                outStream.SendException();
                b = mathBuffer.ReadValue();
            }

            double a = mathBuffer.RetTopValue();
            a = a / b;
            mathBuffer.SaveValue(a);


            return true;
        }
    }
}
