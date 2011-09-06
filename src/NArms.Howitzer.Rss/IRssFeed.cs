namespace NArms.Howitzer.Rss
{
    public interface IRssFeed
    {
        IRssChannel Channel { get; }

        string Content { get; }
    }
}