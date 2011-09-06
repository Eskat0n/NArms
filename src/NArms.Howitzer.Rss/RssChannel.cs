using System;
using System.Collections.Generic;

namespace NArms.Howitzer.Rss
{
    public class RssChannel : IRssChannel
    {
        private readonly ICollection<IRssItem> _items = new List<IRssItem>();

        internal RssChannel()
        {
        }

        public string Title { get; set; }

        public Uri Link { get; set; }

        public string Description { get; set; }

        public string Language { get; set; }

        public string ManagingEditor { get; set; }

        public string Generator { get; set; }

        public DateTime PubDate { get; set; }

        public DateTime? LastBuildDate { get; set; }

        public IRssItem Item
        {
            get 
            {
                var item = new RssItem();
                _items.Add(item);
                return item;
            }
        }

        public string Content
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}