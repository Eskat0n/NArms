using System;

namespace NArms.Howitzer.Rss
{
    public interface IRssChannel
    {
        string Title { get; set; }

        Uri Link { get; set; }

        string Description { get; set; }

        string Language { get; set; }

        string ManagingEditor { get; set; }

        string Generator { get; set; }

        DateTime PubDate { get; set; }

        DateTime? LastBuildDate { get; set; }

        IRssItem Item { get; }

        string Content { get; }
    }
}