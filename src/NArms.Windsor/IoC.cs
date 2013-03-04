namespace NArms.Windsor
{
    using System;
    using System.Reflection;
    using Castle.Windsor;
    using Castle.Windsor.Installer;

    /// <summary>
    ///   Static wrapper for WindsorContainer
    /// </summary>
    public static class IoC
    {
        private static IWindsorContainer _innerContainer;

        /// <summary>
        ///   Initializes IoC using <see cref="IWindsorContainer" /> implementation installed with installers from current assembly
        /// </summary>
        public static void Init()
        {
            var installerAssembly = FromAssembly.Instance(Assembly.GetCallingAssembly());
            Init(new WindsorContainer().Install(installerAssembly));
        }

        /// <summary>
        ///   Initializes IoC using container specified
        /// </summary>
        /// <param name="container"> <see cref="IWindsorContainer" /> implementation </param>
        public static void Init(IWindsorContainer container)
        {
            _innerContainer = container;
        }

        /// <summary>
        ///   Tries to resolve implemnetation of service type given
        /// </summary>
        /// <typeparam name="TService">Type of service </typeparam>
        /// <exception cref="InvalidOperationException">Thrown if IoC is not initialized yet</exception>
        /// <returns> Implementation of <typeparamref name="TService" /> </returns>
        public static TService Resolve<TService>()
            where TService : class
        {
            if (_innerContainer == null)
                throw new InvalidOperationException(
                    string.Format("Unable to resolve class implementing {0} since IoC container is not initialized yet",
                                  typeof (TService).Name),
                    new NullReferenceException("Private field _innerContainer is null"));

            return _innerContainer.Resolve<TService>();
        }
    }
}