using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using NArms.Shrapnel.DataObjects;

namespace NArms.Shrapnel.Processing
{
    public abstract class RequestProcessorBase : IRequestProcessor
    {
        private readonly Socket _socket;

        protected RequestProcessorBase(Socket socket)
        {
            _socket = socket;
        }

        public void Start()
        {
            var receiveBuffer = new byte[_socket.Available];
            _socket.Receive(receiveBuffer);

            var request = Encoding.UTF8.GetString(receiveBuffer);
            var requestLines = request.Split(new[] {"\r\n"}, StringSplitOptions.None);

            var firstLineLexems = requestLines[0].Split(' ');
            var method = firstLineLexems[0];
            var url = firstLineLexems[1];
            var protocol = firstLineLexems[2];

            var requestHeadersRaw = requestLines.Skip(1).TakeWhile(x => string.IsNullOrEmpty(x) == false);
            var requestHeaders = new WebHeaderCollection();

            foreach (var requestHeader in requestHeadersRaw.Select(x => x.Split(':')))
                requestHeaders.Add(requestHeader[0], requestHeader[1]);

            var requestDataLines = requestLines.SkipWhile(x => string.IsNullOrEmpty(x) == false);
            var requestDataTemp = new StringBuilder();
            foreach (var requestDataLine in requestDataLines)
                requestDataTemp.Append(requestDataLine);

            var requestData = requestDataTemp.ToString();

//            var responce = Process(method, url, requestHeaders, requestData);
//
//            _socket.Send(responce.Data);
            _socket.Close();
        }

        protected abstract HttpResponse Process(HttpRequest request);
    }
}