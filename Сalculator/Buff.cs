using System;
using System.Collections.Generic;

namespace Сalculator
{
    public class Buff
    {
        public int TopValue = 0;

        ReadInst inStream = new ReadInst();

        public List<double> variables = new List<double> { };

        public double RetTopValue()
        {
            double value = variables[TopValue -1 ];
            return value;
        }

        public double ReadValue()
        {
            double Value = inStream.ReadOperand();
            return Value;
        }

        public void SaveValue(double value)
        {
            variables.Add(value);
            
            Console.WriteLine(" [ " + variables.Count + " ] = " + variables[TopValue]);
            TopValue++;

        }



    }
}
