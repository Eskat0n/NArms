using System;

namespace NArms.Howitzer.Rss.Tests
{
    using NUnit.Framework;

    public class RssFeedTests
    {
        [Test]
        public void CanCreateFeedWithInternalContentStringBuilder()
        {
            var feed = new RssFeed();

            Assert.NotNull(feed.Content);
        }

        [Test]
        public void GettingChannelAlwaysReturnsOneChannel()
        {
            var feed = new RssFeed();

            var channelOne = feed.Channel;
            var channelTwo = feed.Channel;

            Assert.AreEqual(channelOne, channelTwo);
        }

        [Test]
        public void CreatingFeedAppendsToContentCorrectVersion()
        {
            var feed = new RssFeed();
            var content = feed.Content;
            var lines = content.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            Assert.AreEqual("<?xml version=\"1.0\" encoding=\"UTF-8\"?>", lines[0]);
            Assert.AreEqual("<rss version=\"2.0\" xmlns:dc=\"http://purl.org/dc/elements/1.1/\">", lines[1]);
        }
    }
}