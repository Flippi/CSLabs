using Сalculator.Operations;
using Сalculator.Lab2;
using Сalculator.Lab3Server;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System;

/*namespace Сalculator
{
    public class Generic
    {
        protected IOperation currentOperation = new SaveNumberOperation();

        protected List<IOperation> operations = new List<IOperation>
        {
            new AdditionOperation(),
            new SubstractOperation(),
            new MultiplicationOperation(),
            new DivisionOperation(),
            new JumpOperation(),
            new ExitOperation(),
            new SaveHistory(),
            new LoadHistory()
        };

       
        public void Start()
        {
            
                       
            var OperationsBuffer = new HistoryOperations();
            var _InOutStream = new InOutStream(socket);
            var Buffer = new ValuesBuffer(socket);

            _InOutStream.HelpMessage();

            while (currentOperation.Run(Buffer, _InOutStream, OperationsBuffer, socket))
            {
                currentOperation = _InOutStream.ReadOperation(operations);
            }
            
        }
    }
}
*/