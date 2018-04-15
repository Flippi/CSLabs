using System;
using System.Collections.Generic;
using Сalculator.Operations;
using Сalculator.Lab3Server;
using System.Globalization;
using System.Net;
using System.Net.Sockets;
using System.Text;


namespace Сalculator
{
    public class InOutStream
    {
        public Socket _socket;
        public ServerIO _ServerIO;

        public InOutStream(Socket socket) {
            _socket = socket;
            _ServerIO = new ServerIO(_socket);
        } 


        public virtual IOperation ReadOperation(List<IOperation> list)
        {
            IOperation result = null;
            char key='w';

            do
            {
                _ServerIO.Write("@: ");
              
                try
                {
                    key = Convert.ToChar(_ServerIO.ReadString());
                }
                catch(Exception ex)
                {
                    _ServerIO.WriteLine("Некорректный ввод.");
                }
            }
            while ((result = list.Find(x => x.OperatorChar == key)) == null);

            return result;
        }

        public double ReadOperand()
        {
            while (true)

            {
                _ServerIO.Write(" > ");
                try
                {
                    double Operand;
                    Operand = double.Parse(_ServerIO.ReadString(), NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign);
                    return Operand;
                }
                catch (Exception ex)
                {
                    _ServerIO.WriteLine(ex.Message);
                }
            }
        }

        public int ReadInt(int a)
        {


            int operand = 0;
            while (operand < 1 || operand >= a)
            {
                try
                {
                    _ServerIO.Write("Input number:");
                    operand = int.Parse(_ServerIO.ReadString(), NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign);
                    if (operand < 1 || operand >= a) { _ServerIO.WriteLine("Некорректный ввод.");  }
                }
                catch
                {
                    _ServerIO.WriteLine("Некорректный ввод.");
                }
            }

            return operand;
        }

        public void HelpMessage()
        {
            _ServerIO.WriteLine("Usage: \n    " +
               "when first symbol on line is ‘>’ –enter operand (number) \n    " +
               "when first symbol on line is ‘@’ –enter operation \n    " +
               "operation is one of ‘+’, ‘-‘, ‘/’, ‘*’or \n    " +
               "‘#’ followed with number of evaluation step \n    " +
               "‘q’ to exit");
        }

        public void OutElement(int ElementNumber, double Element)
        {
            _ServerIO.WriteLine(" [" + ElementNumber + "] = " + Element);
        }

        public virtual void SendException() => _ServerIO.WriteLine(new DivideByZeroException().Message);
    }
}
