using LogoFX.Client.Mvvm.ViewModel.Contracts;
using Solid.Bootstrapping;
using Solid.Extensibility;
using Solid.Practices.Middleware;

namespace LogoFX.Client.Mvvm.ViewModelFactory.Unity
{
    /// <summary>
    /// Middleware that registers view model factory.
    /// </summary>    
    public class RegisterViewModelFactoryMiddleware<TBootstrapper, TViewModelFactory> : 
        IMiddleware<TBootstrapper> 
        where TBootstrapper : class, IHaveContainerRegistrator
        where TViewModelFactory : class, IViewModelFactory  
    {
        /// <summary>
        /// Applies the middleware on the specified object.
        /// </summary>
        /// <param name="object">The object.</param>
        /// <returns></returns>
        public TBootstrapper 
            Apply(TBootstrapper @object)
        {
            @object.Registrator.RegisterSingleton<IViewModelFactory, TViewModelFactory>();
            return @object;
        }
    }

    /// <summary>
    /// The bootstrapper extension methods.
    /// </summary>
    public static class BootstrapperExtensions
    {
        /// <summary>
        /// Uses the view model factory which is based on Unity Container.
        /// </summary>        
        /// <param name="bootstrapper">The bootstrapper.</param>
        public static TBootstrapper UseViewModelFactory<TBootstrapper>(
            this TBootstrapper bootstrapper) 
            where TBootstrapper : class, IExtensible<TBootstrapper>, IHaveContainerRegistrator
        {
            return bootstrapper.Use(new RegisterViewModelFactoryMiddleware<TBootstrapper, ViewModelFactory>());            
        }
    }
}
