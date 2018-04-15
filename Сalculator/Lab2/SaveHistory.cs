using Сalculator.Lab2;
using System.IO;
using System;
using System.Net.Sockets;
using Сalculator.Lab3Server;
using System.Text.RegularExpressions;
namespace Сalculator.Operations
{
    public class SaveHistory : IOperation
    {
        public char OperatorChar => 's';
        public bool Run(params object[] args)
        {

            var historyBuffer = (HistoryOperations)args[2];

            Socket socket = (Socket)args[3];

            ServerIO _ServerIO = new ServerIO(socket);

            _ServerIO.WriteLine("Input file name:");
            string fileName = _ServerIO.ReadString();

            string sPattern = @"^(([a-zA-Z]:|\\)\\)?(((\.)|(\.\.)|([^\\/:\*\?""\|<>\. ](([^\\/:\*\?""\|<>\. ])|([^\\/:\*\?""\|<>]*[^\\/:\*\?""\|<>\. ]))?))\\)*[^\\/:\*\?""\|<>\. ](([^\\/:\*\?""\|<>\. ])|([^\\/:\*\?""\|<>]*[^\\/:\*\?""\|<>\. ]))?$";
            if (Regex.IsMatch(fileName, sPattern) && fileName.Length < 255)
            {
                using (StreamWriter sw = new StreamWriter(fileName + ".txt"))
                {
                    for (int i = 0; i < historyBuffer.OperationData.Count; i++)
                    {
                        sw.WriteLine(historyBuffer.OperationData[i]);
                    }
                }
                _ServerIO.WriteLine("Ready!");
            }
            else
            {
                _ServerIO.WriteLine("Uncorrect filename");
            }

            return true;
        }
    }

}
