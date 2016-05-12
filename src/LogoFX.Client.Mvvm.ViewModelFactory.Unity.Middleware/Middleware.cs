using LogoFX.Bootstrapping;
using LogoFX.Client.Bootstrapping.Adapters.Unity;
using LogoFX.Client.Mvvm.ViewModel.Contracts;
using Solid.Practices.Middleware;

namespace LogoFX.Client.Mvvm.ViewModelFactory.Unity
{
    /// <summary>
    /// Middleware that registers view model factory implemented using Unity Container.
    /// </summary>    
    public class RegisterViewModelFactoryMiddleware : 
        IMiddleware<IBootstrapperWithContainerAdapter<UnityContainerAdapter>>        
    {
        /// <summary>
        /// Applies the middleware on the specified object.
        /// </summary>
        /// <param name="object">The object.</param>
        /// <returns></returns>
        public IBootstrapperWithContainerAdapter<UnityContainerAdapter> 
            Apply(IBootstrapperWithContainerAdapter<UnityContainerAdapter> @object)
        {
            @object.Registrator.RegisterSingleton<IViewModelFactory, ViewModelFactory>();
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
        public static IBootstrapperWithContainerAdapter<UnityContainerAdapter> UseViewModelFactory(
            this IBootstrapperWithContainerAdapter<UnityContainerAdapter> bootstrapper)
        {
            return bootstrapper.Use(new RegisterViewModelFactoryMiddleware());            
        }
    }
}
