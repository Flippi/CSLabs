using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Сalculator.Lab2
{
    public class HistoryOperations
    {
        public List<string> OperationData = new List<string> { };

        public void AddNewOperation(char OperatorType, double value, int number)
        {
            switch (OperatorType)
            {
                case '\0':
                    OperationData.Add(Convert.ToString(value));
                    break;
                case '#':
                    OperationData.Add("Out[" + Convert.ToString(number) + "]");
                    break;
                default:
                    OperationData.Add("Out[-1] " + OperatorType + " " + Convert.ToString(value));
                    break;
            }
        }
    }
}
