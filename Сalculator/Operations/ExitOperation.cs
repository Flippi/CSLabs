namespace Сalculator.Operations
{
    class ExitOperation : IOperation
    {
        public char OperatorChar => 'q';
        public bool Run(params object[] args)
        {
            
            return false;
        }
    }
}
