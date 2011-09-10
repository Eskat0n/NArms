using System.Net.Sockets;

namespace NArms.Shrapnel
{
    public interface IRequestDispatcher
    {
        IRequestProcessor Dispatch(Socket socket);
    }
}