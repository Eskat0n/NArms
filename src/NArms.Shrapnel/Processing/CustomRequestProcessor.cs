using System;
using System.Net.Sockets;
using NArms.Shrapnel.DataObjects;

namespace NArms.Shrapnel.Processing
{
    internal class CustomRequestProcessor : RequestProcessorBase
    {
        public CustomRequestProcessor(Socket socket)
            : base(socket)
        {
        }

        protected override HttpResponse Process(HttpRequest request)
        {
            throw new NotImplementedException();
        }
    }
}