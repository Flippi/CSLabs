using System;
using System.Collections.Generic;

namespace Сalculator
{
    public class ValuesBuffer
    {
        public int TopValue = 0;

        InOutStream _InOutStream = new InOutStream();

        public List<double> variables = new List<double> { };

        public double ReturnTopValue()
        {
            double value = variables[TopValue -1 ];
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
            
            Console.WriteLine(" [ " + variables.Count + " ] = " + variables[TopValue]);
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
