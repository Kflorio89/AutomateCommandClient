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
    public class SocketClient
    {
        IPAddress mServerIPAddress;
        int mServerPort;
        TcpClient mClient;

        public EventHandler<TextReceivedEventArgs> RaiseTextReceivedEvent;
        public EventHandler<MessageReceivedEventArgs> RaiseMessageReceivedEvent;

        public SocketClient()
        {
            mClient = null;
            mServerPort = -1;
            mServerIPAddress = null;
        }

        public IPAddress ServerIPAddress
        {
            get
            {
                return mServerIPAddress;
            }
        }

        public int ServerPort
        {
            get
            {
                return mServerPort;
            }
        }

        public bool SetServerIPAddress(string _IPAddressServer)
        {
            IPAddress ipaddr = null;
            /* Check to see if the IP address is valid or not */
            if (!IPAddress.TryParse(_IPAddressServer, out ipaddr))
            {
                OnRaiseMessageReceivedEvent(new MessageReceivedEventArgs("Invalid server IP supplied."));
                return false;
            }
            mServerIPAddress = ipaddr;

            return true;
        }

        /* Send info to server with checks */
        public async Task SendToServer(string strInputUser)
        {
            if (string.IsNullOrEmpty(strInputUser))
            {
                OnRaiseMessageReceivedEvent(new MessageReceivedEventArgs("Empty string supplied to send."));
                return;
            }

            if (mClient != null)
            {
                if (mClient.Connected)
                {
                    StreamWriter clientStreamWriter = new StreamWriter(mClient.GetStream());
                    clientStreamWriter.AutoFlush = true;

                    await clientStreamWriter.WriteAsync(strInputUser);
                    OnRaiseMessageReceivedEvent(new MessageReceivedEventArgs("Data sent..."));
                }
            }
        }

        public void CloseAndDisconnect()
        {
            if (mClient != null)
            {
                if (mClient.Connected)
                {
                    mClient.Close();
                }
            }
        }

        protected void OnRaiseTextReceivedEvent(TextReceivedEventArgs trea)
        {
            EventHandler<TextReceivedEventArgs> handler = RaiseTextReceivedEvent;
            if (handler != null)
            {
                handler(this, trea);
            }
        }

        protected void OnRaiseMessageReceivedEvent(MessageReceivedEventArgs mrea)
        {
            EventHandler<MessageReceivedEventArgs> handler = RaiseMessageReceivedEvent;
            if (handler != null)
            {
                handler(this, mrea);
            }
        }

        /* 
        *  Trying to convert port into an integer, if invalid int is provided in the
        *  string then it will fail, also if invalid range of port numbers is provided it 
        *  will fail too.
        */
        public bool SetPortNumber(string _ServerPort)
        {
            if (!int.TryParse(_ServerPort.Trim(), out int portNumber))
            {
                OnRaiseMessageReceivedEvent(new MessageReceivedEventArgs("Invalid port number supplied, return."));
                return false;
            }
            if (portNumber <= 0 || portNumber > 65535)
            {
                OnRaiseMessageReceivedEvent(new MessageReceivedEventArgs("Port number must be between 0 and 65535."));
                return false;
            }
            mServerPort = portNumber;

            return true;
        }

        public async Task ConnectToServer()
        {
            if (mClient == null)
            {
                mClient = new TcpClient();
            }

            try
            {
                await mClient.ConnectAsync(mServerIPAddress, mServerPort);
                OnRaiseMessageReceivedEvent(new MessageReceivedEventArgs(string.Format("Connected to server IP/Port: {0} / {1}", mServerIPAddress, mServerPort)));
                await ReadDataAsync(mClient);
            }
            catch (Exception ex)
            {
                OnRaiseMessageReceivedEvent(new MessageReceivedEventArgs(ex.Message));
                CloseAndDisconnect();
            }
        }

        /* To read data sent down by the server */
        private async Task ReadDataAsync(TcpClient mClient)
        {
            try
            {
                StreamReader clientStreamReader = new StreamReader(mClient.GetStream());
                char[] buff = new char[512];
                int readByteCount = 0;

                while (true)
                {
                    readByteCount = await clientStreamReader.ReadAsync(buff, 0, buff.Length);

                    if (readByteCount <= 0)
                    {
                        OnRaiseMessageReceivedEvent(new MessageReceivedEventArgs("Disconnected from server."));
                        mClient.Close();
                        break;
                    }
                    OnRaiseMessageReceivedEvent(new MessageReceivedEventArgs(string.Format("Received bytes: {0} - Message: {1}", readByteCount, new string(buff))));
                    //OnRaiseTextReceivedEvent(new TextReceivedEventArgs(mClient.Client.RemoteEndPoint.ToString(), new string(buff)));
                    Array.Clear(buff, 0, buff.Length);
                }
            }
            catch (Exception ex)
            {
                OnRaiseMessageReceivedEvent(new MessageReceivedEventArgs(ex.ToString()));
            }
        }
    }
}
