using System.Text;
using NArms.Howitzer.Rss.Declarations;

namespace NArms.Howitzer.Rss
{
    public sealed class RssFeed : IRssFeed
    {
        private readonly RssFeedVersion _version;
        private readonly StringBuilder _target;
        private readonly RssChannel _rssChannel;

        public RssFeed(RssFeedVersion version = RssFeedVersion.Two)
        {            
            _target = new StringBuilder();
            _rssChannel = new RssChannel();
            _version = version;

            Initialize();
        }
        
        private void Initialize()
        {
            _target.AppendLine("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");

            var version = string.Empty;
            switch (_version)
            {
                case RssFeedVersion.One:
                    version = "1.0";
                    break;
                case RssFeedVersion.Two:
                    version = "2.0";
                    break;
            }

            _target.AppendFormat("<rss version=\"{0}\" xmlns:dc=\"http://purl.org/dc/elements/1.1/\">", version);
        }

        public IRssChannel Channel
        {
            get { return _rssChannel; }
        }

        public string Content
        {
            get
            {
                var content = new StringBuilder();

                content.AppendLine(_target.ToString());
                content.Append("</rss>");

                return content.ToString();
            }
        }
    }
}