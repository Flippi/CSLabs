using System.Net.Sockets;
using System.Net;
using System;
using Сalculator.Operations;
using System.Collections.Generic;
using Сalculator.Lab2;
using System.Threading;
using Сalculator.Lab3Server;

namespace Сalculator
{
    public class Program
    {
        public static List<Socket> listSocket = new List<Socket>();
        public static List<IOperation> operations = new List<IOperation>
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

        private static bool _programRun;
        static void Main(string[] args)
        {
            _programRun = true;
            if (args.Length == 0 ) {
                args = new string[] { "8888" };
            }

            var ipPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), int.Parse(args[0]));
            Socket listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            Console.WriteLine("Server started at port " + args[0]);

            listenSocket.Bind(ipPoint);
            listenSocket.Listen(10);

            while (_programRun)
            {
                var socket = listenSocket.Accept();
                if (socket != null)
                {
                    ParameterizedThreadStart _start = new ParameterizedThreadStart(Start);
                    var thread = new Thread(_start);
                    thread.Start(socket);
                }
            }
        }


        public static void Start(object clientSocket)
        {
            Socket socket = (Socket)clientSocket;
            var OperationsBuffer = new HistoryOperations();
            var _InOutStream = new InOutStream(socket);
            var Buffer = new ValuesBuffer(socket);
            IOperation currentOperation = new SaveNumberOperation();

            _InOutStream.HelpMessage();
            try
            {
                while (currentOperation.Run(Buffer, _InOutStream, OperationsBuffer, socket))
                {
                    currentOperation = _InOutStream.ReadOperation(operations);
                }
            }
            catch (Exception e){
                Console.WriteLine(e.Message);
            }

        }
    }

}
