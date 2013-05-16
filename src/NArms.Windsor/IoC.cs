namespace NArms.Windsor
{
    using System;
    using System.Reflection;
    using Castle.MicroKernel.Registration;
    using Castle.Windsor;
    using Castle.Windsor.Installer;

    /// <summary>
    ///   Static wrapper for WindsorContainer
    /// </summary>
    public static class IoC
    {
        private static IWindsorContainer _innerContainer;

        /// <summary>
        ///   Initializes IoC using <see cref="IWindsorContainer" /> implementation created with installers from current assembly
        /// </summary>
        public static void Init()
        {
            var installerAssembly = FromAssembly.Instance(Assembly.GetCallingAssembly(),
                                                          new OrderedInstallerFactory());
            Init(new WindsorContainer().Install(installerAssembly));
        }

        /// <summary>
        ///   Initializes IoC using <see cref="IWindsorContainer" /> implementation created with installers from assembly containing <typeparamref name="TInstaller"/>
        /// </summary>
        public static void Init<TInstaller>()
            where TInstaller : class, IWindsorInstaller
        {
            var installerAssembly = FromAssembly.Containing<TInstaller>(new OrderedInstallerFactory());
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
        ///     Tries to resolve implemnetation of service type given
        /// </summary>
        /// <typeparam name="TService">Type of service</typeparam>
        /// <exception cref="InvalidOperationException">Thrown if IoC is not initialized yet</exception>
        /// <returns>
        ///     Implementation of <typeparamref name="TService" />
        /// </returns>
        /// <exception cref="InvalidOperationException">Thrown if container is not initialized yet</exception>
        public static TService Resolve<TService>()
            where TService : class
        {
            return (TService) Resolve(typeof (TService));
        }

        /// <summary>
        ///     Tries to resolve implemnetation of service type given
        /// </summary>
        /// <param name="serviceType">Type of service</param>
        /// <returns>
        ///     Implementation of <paramref name="serviceType" />
        /// </returns>
        /// <exception cref="InvalidOperationException">Thrown if container is not initialized yet</exception>
        public static object Resolve(Type serviceType)
        {
            if (_innerContainer == null)
                throw new InvalidOperationException(
                    string.Format("Unable to resolve class implementing {0} since IoC container is not initialized yet",
                                  serviceType.Name),
                    new NullReferenceException("Private field _innerContainer is null"));

            return _innerContainer.Resolve(serviceType);
        }
    }
}