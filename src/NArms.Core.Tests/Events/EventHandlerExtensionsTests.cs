namespace NArms.Core.Events
{
    using System;
    using System.Threading;
    using NArms.Events;
    using NUnit.Framework;

    [TestFixture]
    public class EventHandlerExtensionsTests
    {
        [TestFixtureSetUp]
        public void FixtureSetpUp()
        {
            _customEventHandler += (sender, args) => _customEventHandlerData = new EventData(sender, args);
            _genericEventHandler += (sender, args) => _genericEventHandlerData = new EventData(sender, args);
            _basicEventHandler += (sender, args) => _basicEventHandlerData = new EventData(sender, args);
        }

        [SetUp]
        public void SetUp()
        {
            _customEventHandlerData = null;
            _genericEventHandlerData = null;
            _basicEventHandlerData = null;
        }

        private EventHandler<CustomEventArgs> _customEventHandler;
        private EventHandler<EventArgs> _genericEventHandler;
        private EventHandler _basicEventHandler;
        private EventData _customEventHandlerData;
        private EventData _genericEventHandlerData;
        private EventData _basicEventHandlerData;

        private class CustomEventArgs : EventArgs
        {
        }

        private class EventData
        {
            public readonly EventArgs EventArgs;
            public readonly object Sender;

            public EventData(object sender, EventArgs eventArgs)
            {
                Sender = sender;
                EventArgs = eventArgs;
            }
        }

        [Test]
        public void ShouldDoNotFireEventHandlerForNullEvent()
        {
            _customEventHandler = null;
            _genericEventHandler = null;
            _basicEventHandler = null;

            _customEventHandler.Fire();
            _genericEventHandler.Fire();
            _basicEventHandler.Fire();

            Assert.Null(_customEventHandlerData);
            Assert.Null(_genericEventHandlerData);
            Assert.Null(_basicEventHandlerData);
        }

        [Test]
        public void ShouldFireEventHandlerViaFireWithOneArgument()
        {
            _customEventHandler.Fire(new CustomEventArgs());
            _genericEventHandler.Fire(new CustomEventArgs());
            _basicEventHandler.Fire(new CustomEventArgs());

            Thread.Sleep(50);

            Assert.NotNull(_customEventHandlerData);
            Assert.NotNull(_genericEventHandlerData);
            Assert.NotNull(_basicEventHandlerData);
        }

        [Test]
        public void ShouldFireEventHandlerViaFireWithOneArgumentWithCorrentData()
        {
            var eventArgs = new CustomEventArgs();
            _customEventHandler.Fire(eventArgs);

            Thread.Sleep(50);

            Assert.NotNull(_customEventHandlerData);
            Assert.Null(_customEventHandlerData.Sender);
            Assert.AreEqual(eventArgs, _customEventHandlerData.EventArgs);
        }

        [Test]
        public void ShouldFireEventHandlerViaFireWithTwoArguments()
        {
            _customEventHandler.Fire(new object(), new CustomEventArgs());
            _genericEventHandler.Fire(new object(), new CustomEventArgs());
            _basicEventHandler.Fire(new object(), new CustomEventArgs());

            Thread.Sleep(50);

            Assert.NotNull(_customEventHandlerData);
            Assert.NotNull(_genericEventHandlerData);
            Assert.NotNull(_basicEventHandlerData);
        }

        [Test]
        public void ShouldFireEventHandlerViaFireWithTwoArgumentsWithCorrentData()
        {
            var sender = new object();
            var eventArgs = new CustomEventArgs();
            _customEventHandler.Fire(sender, eventArgs);

            Thread.Sleep(50);

            Assert.NotNull(_customEventHandlerData);
            Assert.AreEqual(sender, _customEventHandlerData.Sender);
            Assert.AreEqual(eventArgs, _customEventHandlerData.EventArgs);
        }

        [Test]
        public void ShouldFireEventHandlerViaFireWithoutArguments()
        {
            _customEventHandler.Fire();
            _genericEventHandler.Fire();
            _basicEventHandler.Fire();

            Thread.Sleep(50);

            Assert.NotNull(_customEventHandlerData);
            Assert.NotNull(_genericEventHandlerData);
            Assert.NotNull(_basicEventHandlerData);
        }

        [Test]
        public void ShouldFireEventHandlerViaFireWithoutArgumentsWithCorrentData()
        {
            _customEventHandler.Fire();

            Thread.Sleep(50);

            Assert.NotNull(_customEventHandlerData);
            Assert.Null(_customEventHandlerData.Sender);
            Assert.Null(_customEventHandlerData.EventArgs);
        }
    }
}