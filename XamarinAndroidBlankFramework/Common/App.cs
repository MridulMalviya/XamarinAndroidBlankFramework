using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ITC.SeedBank.Tool.ViewModels;
using GalaSoft.MvvmLight.Views;
using GalaSoft.MvvmLight.Threading;
using GalaSoft.MvvmLight.Ioc;
using XamarinAndroidBlankFramework.View.Activities;

namespace XamarinAndroidBlankFramework.Common
{
    public static class App
    {

        /// <summary>
        /// refering ViewModelLocator, defined inside the portable lib
        /// </summary>
        private static ViewModelLocator locator;

        public static ViewModelLocator Locator
        {
            get
            {
                if (locator==null)
                {
                    // Initialize the MVVM Light DispatcherHelper.
                    // This needs to be called on the UI thread.
                    DispatcherHelper.Initialize();
                    // Configure and register the MVVM Light NavigationService
                    var nav = new NavigationService();
                    SimpleIoc.Default.Register<INavigationService>(() => nav);
                    nav.Configure(ViewModelLocator.SecondPageKey, typeof(SecondActivity));
                    locator = new ViewModelLocator();
                }
                return locator;
            }
        }

    }
}