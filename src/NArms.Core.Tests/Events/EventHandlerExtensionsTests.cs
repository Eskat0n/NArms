namespace NArms.Core.Events
{
    using System;
    using NArms.Events;
    using Xunit;

    public class EventHandlerExtensionsTests
    {
        private EventHandler<CustomEventArgs> _customEventHandler;

        private EventHandler<EventArgs> _genericEventHandler;

        private EventHandler _basicEventHandler;

        private EventData _customEventHandlerData;

        private EventData _genericEventHandlerData;

        private EventData _basicEventHandlerData;

        public EventHandlerExtensionsTests()
        {
            _customEventHandler += (sender, args) => _customEventHandlerData = new EventData(sender, args);
            _genericEventHandler += (sender, args) => _genericEventHandlerData = new EventData(sender, args);
            _basicEventHandler += (sender, args) => _basicEventHandlerData = new EventData(sender, args);
        }

        [Fact]
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

        [Fact]
        public void ShouldFireEventHandlerViaFireWithoutArguments()
        {
            _customEventHandler.Fire();
            _genericEventHandler.Fire();
            _basicEventHandler.Fire();

            Assert.NotNull(_customEventHandlerData);
            Assert.NotNull(_genericEventHandlerData);
            Assert.NotNull(_basicEventHandlerData);
        }

        [Fact]
        public void ShouldFireEventHandlerViaFireWithoutArgumentsWithCorrentData()
        {
            _customEventHandler.Fire();

            Assert.NotNull(_customEventHandlerData);
            Assert.Null(_customEventHandlerData.Sender);
            Assert.Null(_customEventHandlerData.EventArgs);
        }

        [Fact]
        public void ShouldFireEventHandlerViaFireWithOneArgument()
        {
            _customEventHandler.Fire(new CustomEventArgs());
            _genericEventHandler.Fire(new CustomEventArgs());
            _basicEventHandler.Fire(new CustomEventArgs());

            Assert.NotNull(_customEventHandlerData);
            Assert.NotNull(_genericEventHandlerData);
            Assert.NotNull(_basicEventHandlerData);
        }

        [Fact]
        public void ShouldFireEventHandlerViaFireWithOneArgumentWithCorrentData()
        {
            var eventArgs = new CustomEventArgs();
            _customEventHandler.Fire(eventArgs);

            Assert.NotNull(_customEventHandlerData);
            Assert.Null(_customEventHandlerData.Sender);
            Assert.Equal(eventArgs,_customEventHandlerData.EventArgs);
        }

        [Fact]
        public void ShouldFireEventHandlerViaFireWithTwoArguments()
        {
            _customEventHandler.Fire(new object(), new CustomEventArgs());
            _genericEventHandler.Fire(new object(), new CustomEventArgs());
            _basicEventHandler.Fire(new object(), new CustomEventArgs());

            Assert.NotNull(_customEventHandlerData);
            Assert.NotNull(_genericEventHandlerData);
            Assert.NotNull(_basicEventHandlerData);
        }

        [Fact]
        public void ShouldFireEventHandlerViaFireWithTwoArgumentsWithCorrentData()
        {
            var sender = new object();
            var eventArgs = new CustomEventArgs();
            _customEventHandler.Fire(sender, eventArgs);

            Assert.NotNull(_customEventHandlerData);
            Assert.Equal(sender, _customEventHandlerData.Sender);
            Assert.Equal(eventArgs,_customEventHandlerData.EventArgs);
        }

        private class CustomEventArgs : EventArgs
        {            
        }

        private class EventData
        {
            public EventData(object sender, EventArgs eventArgs)
            {
                Sender = sender;
                EventArgs = eventArgs;
            }

            public object Sender;
            public EventArgs EventArgs;
        }
    }
}