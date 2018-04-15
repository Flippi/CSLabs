using Сalculator.Lab2;
using System.IO;
using System.Net.Sockets;
using System;
using Сalculator.Lab3Server;
using Сalculator.Operations;


namespace Сalculator.Lab2
{
    public class LoadHistory : IOperation
    {
        public char OperatorChar => 'l';
        public bool Run(params object[] args)
        {

            string NextLine;
            double result = 0;
            double lastValue = 0;
            int numberLine = 0;
            string outInfo;
            char operationType;
            var mathBuffer = (ValuesBuffer)args[0];
            var historyBuffer = (HistoryOperations)args[2];
            Socket socket = (Socket)args[3];

            ServerIO _ServerIO = new ServerIO(socket);

            mathBuffer.variables.Clear();
            mathBuffer.TopValue = 0;

            _ServerIO.WriteLine("Enter file name without extension:");
            string pathFile = Directory.GetCurrentDirectory() + "\\" + _ServerIO.ReadString() + ".txt";
            if (!File.Exists(pathFile))
            {

                _ServerIO.WriteLine("Such file does not exist");
                return true;
            }


            using (var file = new StreamReader(pathFile))
            {
                while ((NextLine = file.ReadLine()) != null)
                {
                    numberLine++;
                    string[] ParseLine = NextLine.Split(' ');

                    switch (ParseLine.Length)
                    {
                        case 1:
                            outInfo = ParseLine[0];
                            if (Double.TryParse(outInfo, out result))
                            {
                                _ServerIO.WriteLine($"[#{numberLine}] - {result}");
                                mathBuffer.HideSaveValue(result);
                            }
                            else
                            {
                                result = ConvertToInteger(outInfo);
                                _ServerIO.WriteLine($"[#{numberLine}] - {outInfo} = {result}");
                                mathBuffer.HideSaveValue(result);
                            }
                            break;
                        case 3:
                            outInfo = ParseLine[0];
                            operationType = Convert.ToChar(ParseLine[1]);
                            result = Convert.ToDouble(ParseLine[2]);
                            lastValue = SearchLastValue(operationType, mathBuffer.ReturnTopValue(), result);
                            _ServerIO.WriteLine($"[#{numberLine}] - {outInfo} {operationType} {lastValue} = " +
                                $"{mathBuffer.ReturnTopValue()} {operationType} {lastValue} = {result}");
                            mathBuffer.HideSaveValue(result);
                            break;
                        default:
                            _ServerIO.Write("Parse error!\n");
                            break;

                    }

                }

            }


            return true;
        }

        public int ConvertToInteger(string line)
        {
            string str = "";
            char[] mas = line.ToCharArray();
            foreach (char h in mas)
            {
                if (char.IsDigit(h) == true)
                {
                    str += h;
                }
            }

            int number = Convert.ToInt32(str);
            return number;
        }

        public double SearchLastValue(char operatorType, double previous, double result)
        {
            double lastValue = 0;
            switch (operatorType)
            {
                case '+':
                    lastValue = result - previous;
                    break;

                case '-':
                    lastValue = previous - result;
                    break;
                case '*':
                    lastValue = result / previous;
                    break;
                case '/':
                    lastValue = previous / result;
                    break;
                default:
                   break;
            }
            return lastValue;
        }
    }

}
