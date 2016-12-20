
using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using GalaSoft.MvvmLight.Views;
using ITC.SeedBank.Tool.ViewModels;
using System.Collections.Generic;
using XamarinAndroidBlankFramework.Common;
using GalaSoft.MvvmLight.Helpers;
using System;

//http://tutorialsface.blogspot.in/2014/07/music-player-with-notification-and-lock.html

namespace XamarinAndroidBlankFramework.View.Activities
{
    [Activity(Label = "Dashboard", MainLauncher = false, Icon = "@drawable/icon")]
    public class Dashboard : ActivityBase
    {
        // Keep track of bindings to avoid premature garbage collection
        private readonly List<Binding> bindings = new List<Binding>();
        private EditText className1;
        private Button button;
        private EditText name;

        /// <summary>
        ///  Gets a reference to the DashboardViewModel from the ViewModelLocator.
        /// </summary>
        private DashboardViewModel ViewModel
        {
            get
            {
                return App.Locator.DashboardVM;
            }
        }






        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            //_viewModel = new DashboardViewModel();
            Init();
        }

       

        private void Init()
        {
            TextView classLabel = FindViewById<TextView>(Resource.Id.textview_class_label);
            name = FindViewById<EditText>(Resource.Id.editview_name);
            className1 = FindViewById<EditText>(Resource.Id.editview_class);
            //className1.Visibility = ViewStates.Gone;
            //classLabel.Visibility = ViewStates.Gone;
            button = FindViewById<Button>(Resource.Id.btn_find);

            BindDataWithViewModel();
            navigatePage();


            //button.Click += delegate
            //{
            //    if (button.Text.Equals("Try Again"))
            //    {
            //        // button.Text = string.Format("{0} clicks!", count++);
            //        name.Text = "";
            //        className.Text = "";
            //        className.Visibility = ViewStates.Gone;
            //        classLabel.Visibility = ViewStates.Gone;
            //        button.Text = "Find";
            //        name.Enabled = true;
            //    }
            //    else
            //    {
            //        // button.Text = string.Format("{0} clicks!", count++);
            //        className.Text = "" + .findClassName(name.Text);
            //        className.Visibility = ViewStates.Visible;
            //        classLabel.Visibility = ViewStates.Visible;
            //        name.Enabled = false;
            //        button.Text = "Try Again";
            //    }

            //};
        }

     

        
        

        private void BindDataWithViewModel()
        {
            // Binding between the TextView and the ViewModel property.
            // Keep track of the binding to avoid premature garbage collection
             var bind = this.SetBinding(() => ViewModel.StudentName, () => name.Text, BindingMode.TwoWay);
             bindings.Add(bind);
             bind = this.SetBinding(() => ViewModel.ClassName, () => className1.Text, BindingMode.TwoWay);
             bindings.Add(bind);
        }



        private void navigatePage()
        {
            // Actuate the NavigateCommand on the VM.
            button.SetCommand("Click", ViewModel.NavigateCommand);
            // button.SetCommand("Click", ViewModel.CheckClassNameCommand);
            
           // button.SetCommand("Click", ViewModel.ParaClassNameCommand);
        }
    }
}