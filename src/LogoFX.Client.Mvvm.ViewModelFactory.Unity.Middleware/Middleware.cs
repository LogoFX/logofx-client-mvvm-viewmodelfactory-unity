using LogoFX.Bootstrapping;
using LogoFX.Client.Bootstrapping.Adapters.Unity;
using LogoFX.Client.Mvvm.ViewModel.Contracts;
using Solid.Practices.Middleware;

namespace LogoFX.Client.Mvvm.ViewModelFactory.Unity
{
    /// <summary>
    /// Middleware that registers view model factory implemented using LogoFX Simple Container.
    /// </summary>
    /// <typeparam name="TRootObject">The type of the root object.</typeparam>    
    public class RegisterViewModelFactoryMiddleware<TRootObject> : 
        IMiddleware<IBootstrapperWithContainerAdapter<TRootObject, UnityContainerAdapter>>        
    {
        /// <summary>
        /// Applies the middleware on the specified object.
        /// </summary>
        /// <param name="object">The object.</param>
        /// <returns></returns>
        public IBootstrapperWithContainerAdapter<TRootObject, UnityContainerAdapter> 
            Apply(IBootstrapperWithContainerAdapter<TRootObject, UnityContainerAdapter> @object)
        {
            @object.ContainerAdapter.RegisterSingleton<IViewModelFactory, ViewModelFactory>();
            return @object;
        }
    }

    /// <summary>
    /// Bootstrapper extensions.
    /// </summary>
    public static class BootstrapperExtensions
    {
        /// <summary>
        /// Uses the view model factory which is based on LogoFX Simple Container.
        /// </summary>
        /// <typeparam name="TRootObject">The type of the root object.</typeparam>
        /// <param name="bootstrapper">The bootstrapper.</param>
        public static IBootstrapperWithContainerAdapter<TRootObject, UnityContainerAdapter> UseViewModelFactory<TRootObject>(
            this IBootstrapperWithContainerAdapter<TRootObject, UnityContainerAdapter> bootstrapper)
        {
            return bootstrapper.Use(new RegisterViewModelFactoryMiddleware<TRootObject>());            
        }
    }
}
