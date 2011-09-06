using System;

namespace NArms.Howitzer
{
    public class XmlMarkupNode : IDisposable
    {
        private readonly Action _onDispose;

        internal XmlMarkupNode(Action onDispose)
        {
            _onDispose = onDispose;
        }

        public void Dispose()
        {
            _onDispose();
        }
    }
}