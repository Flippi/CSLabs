using Сalculator.Operations;
using System.Collections.Generic;

namespace Сalculator
{
    public class Generic
    {
        protected ValuesBuffer Buffer;

        protected IOperation currentOperation = new SaveNumberOperation();

        protected List<IOperation> operations = new List<IOperation>
        {
            new AdditionOperation(),
            new SubstractOperation(),
            new MultiplicationOperation(),
            new DivisionOperation(),
            new JumpOperation(),
            new ExitOperation()
        };

        InOutStream _InOutStream = new InOutStream();

        public void Start()
        {
            Buffer = new ValuesBuffer();
            _InOutStream.HelpMessage();

            while (currentOperation.Run(Buffer, _InOutStream))
            {
                currentOperation = _InOutStream.ReadOperation(operations);
            }
        }
    }
}
