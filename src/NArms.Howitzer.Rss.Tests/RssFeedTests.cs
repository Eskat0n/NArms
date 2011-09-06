using System;
using Xunit;

namespace NArms.Howitzer.Rss.Tests
{
    public class RssFeedTests
    {
        [Fact]
        public void CanCreateFeedWithInternalContentStringBuilder()
        {
            var feed = new RssFeed();

            Assert.NotNull(feed.Content);
        }

        [Fact]
        public void GettingChannelAlwaysReturnsOneChannel()
        {
            var feed = new RssFeed();

            var channelOne = feed.Channel;
            var channelTwo = feed.Channel;

            Assert.Equal(channelOne, channelTwo);
        }

        [Fact]
        public void CreatingFeedAppendsToContentCorrectVersion()
        {
            var feed = new RssFeed();
            var content = feed.Content;
            var lines = content.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            Assert.Equal("<?xml version=\"1.0\" encoding=\"UTF-8\"?>", lines[0]);
            Assert.Equal("<rss version=\"2.0\" xmlns:dc=\"http://purl.org/dc/elements/1.1/\">", lines[1]);
        }
    }
}