namespace Сalculator.Operations
{
    class Exit : IOperation
    {
        public char OperatorChar => 'q';
        public bool Run(params object[] args)
        {
            
            return false;
        }
    }
}
