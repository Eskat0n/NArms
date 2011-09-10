using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Threading;

namespace NArms.Shrapnel.Processing
{
    internal class DefaultRequestDispatcher : IRequestDispatcher
    {
        private readonly ICollection<Tuple<IRequestProcessor, Thread>> _requestProcessors = new List<Tuple<IRequestProcessor, Thread>>();

        public IRequestProcessor Dispatch(Socket socket)
        {
            var requestProcessor = new CustomRequestProcessor(socket);
            var thread = new Thread(requestProcessor.Start);

            _requestProcessors.Add(new Tuple<IRequestProcessor, Thread>(requestProcessor, thread));

            thread.Start();

            return requestProcessor;
        }
    }
}