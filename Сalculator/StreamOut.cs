using System;

namespace Сalculator
{
    public class StreamOut 
    {
        public void HelpMessage()
        {
            Console.WriteLine("Usage: \n    " +
               "when first symbol on line is ‘>’ –enter operand (number) \n    " +
               "when first symbol on line is ‘@’ –enter operation \n    " +
               "operation is one of ‘+’, ‘-‘, ‘/’, ‘*’or \n    " +
               "‘#’ followed with number of evaluation step \n    " +
               "‘q’ to exit");
        }

        public void OutElement(int ElementNumber, double Element)
        {
            Console.WriteLine(" [" + ElementNumber + "] = " + Element);
        }

        public virtual void SendException() => Console.WriteLine(new DivideByZeroException().Message);

    }
}
