using System.Net;
using System.Net.Sockets;
using System.Threading;
using NArms.Shrapnel.Processing;

namespace NArms.Shrapnel
{
    public class HttpServer
    {
        private readonly TcpListener _tcpListener;
        private readonly Thread _listeningThread;
        private readonly DefaultRequestDispatcher _requestDispatcher;

        public HttpServer(IPAddress address, int port = 80)
        {
            _tcpListener = new TcpListener(address, port);
            _listeningThread = new Thread(DispatchConnection);

            _requestDispatcher = new DefaultRequestDispatcher();
        }
        
        public HttpServer(string address, int port = 80)
            : this(IPAddress.Parse(address), port)
        {
        }

        public void Listen()
        {
            _tcpListener.Start();
            _listeningThread.Start();            
        }

        private void DispatchConnection()
        {
            while (true)
            {
                var socket = _tcpListener.AcceptSocket();
                _requestDispatcher.Dispatch(socket);
            }
        }
    }
}
