using Сalculator.Operations;
using System.Collections.Generic;



namespace Сalculator
{
    public class Generic
    {

        Buff Buff;

        protected IOperation currentOperation = new SaveNumber();

        protected List<IOperation> operations = new List<IOperation>
        {
            new Add(),
            new Sub(),
            new Mul(),
            new Div(),
            new Jmp(),
            new Exit()
        };

        StreamOut outStream = new StreamOut();
        ReadInst inStream = new ReadInst();

        public void Start()
        {
            Buff = new Buff();

            outStream.HelpMassage();


            while (RunOperation())
            {
                ReadOperation();
            }   
        }

        
        protected virtual bool RunOperation() => currentOperation.Run(Buff, inStream, outStream);

        protected virtual void ReadOperation() => currentOperation = inStream.ReadOperation(operations);

        

       
    }
}
