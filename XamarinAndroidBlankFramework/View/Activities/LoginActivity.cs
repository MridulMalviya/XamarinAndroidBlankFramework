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
using GalaSoft.MvvmLight.Helpers;
using GalaSoft.MvvmLight.Threading;
using GalaSoft.MvvmLight.Views;
using GalaSoft.MvvmLight.Ioc;
using XamarinAndroidBlankFramework.Common;

/// <summary>
/// View connects with ViewModel
/// </summary>
namespace XamarinAndroidBlankFramework.View.Activities
{
    [Activity(Label = "Demo", MainLauncher = true, Icon = "@drawable/icon")]
    public class LoginActivity : ActivityBase
    {
        // Keep track of bindings to avoid premature garbage collection
        private readonly List<Binding> bindings = new List<Binding>();
        private EditText mEditTextUserName;
        private EditText mEditTextPassword;
        private Button mBtnSubmit;
        private ViewModelLocator _viewModelLocator;
        

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_login);
            Init();
            InitView();            
            BindingData();
        }

        

        private void Init()
        {

            // Initialize the MVVM Light DispatcherHelper.
            // This needs to be called on the UI thread.
            DispatcherHelper.Initialize();
            // Configure and register the MVVM Light NavigationService
            NavigationService nav = new NavigationService();

            //Passing data by NavigationService
            //Intent intent = new Intent();
            //Bundle bundle = new Bundle();
            //bundle.PutString("key","value");
            //intent.PutExtras(bundle);
            //_nav.NavigateTo(ViewModelLocator.SecondPageKey, intent);

            nav.Configure(ViewModelLocator.SecondPageKey, typeof(DashboardActivity));
            SimpleIoc.Default.Register<INavigationService>(() => nav);
            //define navigation 
            _viewModelLocator = new ViewModelLocator();



        }

        private void InitView()
        {
            mEditTextUserName = (EditText)FindViewById(Resource.Id.edittext_login_username);
            mEditTextPassword = (EditText)FindViewById(Resource.Id.edittext_login_password);
            mBtnSubmit = (Button)FindViewById(Resource.Id.btn_login_submit);
            DoLogin();
        }

       

        private void BindingData()
        {
            var bind = this.SetBinding(() => _viewModelLocator.LoginVM.UserName, () => mEditTextUserName.Text, BindingMode.TwoWay);
            bindings.Add(bind);
            bind = null;
            bind = this.SetBinding(() => _viewModelLocator.LoginVM.Password, () => mEditTextPassword.Text, BindingMode.TwoWay);
            bindings.Add(bind);
            //bind = this.SetBinding(() => _viewModelLocator.LoginVM.CanLogin(), () => mBtnSubmit.Enabled, BindingMode.TwoWay);
        }

        private void DoLogin()
        {
            mBtnSubmit.SetCommand("Click", _viewModelLocator.LoginVM.LoginCommand);
        }


        //-------------------------------------------------------------------
    }
}