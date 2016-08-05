using Solid.Bootstrapping;
using Solid.Extensibility;

namespace LogoFX.Client.Mvvm.ViewModelFactory.Unity
{
    /// <summary>
    /// The bootstrapper extension methods.
    /// </summary>
    public static class BootstrapperExtensions
    {
        /// <summary>
        /// Uses the view model factory which is based on LogoFX Simple Container.
        /// </summary>        
        /// <param name="bootstrapper">The bootstrapper.</param>
        public static TBootstrapper UseViewModelFactory<TBootstrapper>(
            this TBootstrapper bootstrapper)
            where TBootstrapper : class, IExtensible<TBootstrapper>, IHaveContainerRegistrator
        {
            return bootstrapper.UseViewModelFactory<TBootstrapper, ViewModelFactory>();
        }
    }
}
