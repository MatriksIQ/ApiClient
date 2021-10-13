using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matriks.ApiClient.TcpConnection
{
    public class OnDataInEventArgs
    {
        public byte[] Bytes { get; set; }

        public string Text { get; set; }

        public OnDataInEventArgs(byte[] bytes,string text)
        {
            Bytes = bytes;
            Text = text;
        }
    }
}
