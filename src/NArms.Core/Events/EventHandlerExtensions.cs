namespace NArms.Events
{
    using System;

    public static class EventHandlerExtensions
    {
        public static void Fire(this EventHandler eventHandler) 
        {
            if (eventHandler == null)
                return;

            eventHandler(null, null);
        }
        
        public static void Fire(this EventHandler eventHandler, EventArgs eventArgs) 
        {
            if (eventHandler == null)
                return;

            eventHandler(null, eventArgs);
        }
        
        public static void Fire(this EventHandler eventHandler, object sender, EventArgs eventArgs) 
        {
            if (eventHandler == null)
                return;

            eventHandler(sender, eventArgs);
        }
        
        public static void Fire<TEventArgs>(this EventHandler<TEventArgs> eventHandler) 
            where TEventArgs : EventArgs
        {
            if (eventHandler == null)
                return;

            eventHandler(null, null);
        }
        
        public static void Fire<TEventArgs>(this EventHandler<TEventArgs> eventHandler, TEventArgs eventArgs) 
            where TEventArgs : EventArgs
        {
            if (eventHandler == null)
                return;

            eventHandler(null, eventArgs);
        }
        
        public static void Fire<TEventArgs>(this EventHandler<TEventArgs> eventHandler, object sender, TEventArgs eventArgs) 
            where TEventArgs : EventArgs
        {
            if (eventHandler == null)
                return;

            eventHandler(sender, eventArgs);
        }
    }
}