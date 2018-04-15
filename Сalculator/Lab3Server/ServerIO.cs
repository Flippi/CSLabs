using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Сalculator.Lab3Server
{
    public class ServerIO
    {
        public Socket Handler { get; private set; }

        public ServerIO(Socket handler)
        {
            Handler = handler;
        }

        public string ReadString()
        {
            var data = new byte[64];
            var builder = new StringBuilder();
            var bytes = 0;

            do
            {
                bytes = Handler.Receive(data);
                builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
            }
            while (Handler.Available > 0);

            return builder.ToString();
        }

        public void Write(string msg)
        {
            byte[] data = Encoding.Unicode.GetBytes(msg);
            Handler.Send(data);
        }

        public void WriteLine(string msg) => Write(msg + "\n");

        public void Disconnect()
        {
            Handler.Shutdown(SocketShutdown.Both);
            Handler.Close();
        }
    }
}
