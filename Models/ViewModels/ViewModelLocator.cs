
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace ITC.SeedBank.Tool.ViewModels
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// The key used by the NavigationService to go to the second page.
        /// </summary>
        public const string SecondPageKey = "SecondPage";

        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            //pp SimpleIoc registers class with ServiceLocator
            SimpleIoc.Default.Register<DashboardViewModel>();
        }

        public DashboardViewModel DashboardVM
        {
            get
            {
                //pp ServiceLocator.Current return the registered class instance
                return ServiceLocator.Current.GetInstance<DashboardViewModel>();
            }
        }

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}