using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SocketAsync
{
    /* 
     * This event will tell the subscriber application what client has connected
     * and what the IPAddress : Port number connected
     */
    public class ClientConnectedEventArgs : EventArgs
    {
        /* Property */
        public string NewClient { get; set; }

        public ClientConnectedEventArgs(string _newClient)
        {
            NewClient = _newClient;
        }
    }

    /* Custom class derived from EventArgs */
    public class TextReceivedEventArgs : EventArgs
    {
        /* Properties */
        public string ClientWhoSentText { get; set; }
        public string TextReceived { get; set; }

        public TextReceivedEventArgs(string _clientWhoSentText, string _textReceived)
        {
            ClientWhoSentText = _clientWhoSentText;
            TextReceived = _textReceived;
        }
    }

    /* Custom class derived from EventArgs */
    public class MessageReceivedEventArgs : EventArgs
    {
        /* Properties */
        public string Message { get; set; }

        public MessageReceivedEventArgs(string _message)
        {
            Message = _message;
        }
    }

}