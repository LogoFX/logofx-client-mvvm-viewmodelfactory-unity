using LogoFX.Client.Bootstrapping;
using LogoFX.Client.Bootstrapping.Adapters.Unity;
using LogoFX.Client.Mvvm.ViewModel.Contracts;
using Solid.Practices.Middleware;

namespace LogoFX.Client.Mvvm.ViewModelFactory.Unity
{
    /// <summary>
    /// Middleware that registers view model factory implemented using LogoFX Simple Container.
    /// </summary>
    /// <typeparam name="TRootViewModel">The type of the root view model.</typeparam>    
    public class RegisterViewModelFactoryMiddleware<TRootViewModel> : 
        IMiddleware<IBootstrapperWithContainerAdapter<TRootViewModel, UnityContainerAdapter>>        
    {
        /// <summary>
        /// Applies the middleware on the specified object.
        /// </summary>
        /// <param name="object">The object.</param>
        /// <returns></returns>
        public IBootstrapperWithContainerAdapter<TRootViewModel, UnityContainerAdapter> 
            Apply(IBootstrapperWithContainerAdapter<TRootViewModel, UnityContainerAdapter> @object)
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
        /// <typeparam name="TRootViewModel">The type of the root view model.</typeparam>
        /// <param name="bootstrapper">The bootstrapper.</param>
        public static IBootstrapperWithContainerAdapter<TRootViewModel, UnityContainerAdapter> UseViewModelFactory<TRootViewModel>(
            this IBootstrapperWithContainerAdapter<TRootViewModel, UnityContainerAdapter> bootstrapper)
        {
            return bootstrapper.Use(new RegisterViewModelFactoryMiddleware<TRootViewModel>());            
        }
    }
}
