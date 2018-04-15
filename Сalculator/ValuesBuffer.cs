using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using Сalculator.Lab3Server;

namespace Сalculator
{
    public class ValuesBuffer
    {
        public int TopValue = 0;

        public Socket _socket;
        InOutStream _InOutStream;

        public ValuesBuffer(Socket socket)
        {
            _socket = socket;
            _InOutStream =  new InOutStream(_socket);
        }

       

        public List<double> variables = new List<double> { };

        public double ReturnTopValue()
        {
            double value = variables[TopValue - 1];
            return value;
        }

        public double ReadValue()
        {
            double value = _InOutStream.ReadOperand();
            return value;
        }

        public void SaveValue(double value)
        {
            variables.Add(value);

            _InOutStream._ServerIO.WriteLine(" [#" + variables.Count + "] = " + variables[TopValue]);
            TopValue++;

        }
        public void HideSaveValue(double value)
        {
            variables.Add(value);
            TopValue++;

        }

        public void СheckingValueForInfinity(double value)
        {
            if (value != double.PositiveInfinity && value != double.NegativeInfinity)
            {
                SaveValue(value);
            }
            else
            {
                Console.WriteLine("Going beyond double. Choose another operation or enter a different number");
            }
        }



    }
}
