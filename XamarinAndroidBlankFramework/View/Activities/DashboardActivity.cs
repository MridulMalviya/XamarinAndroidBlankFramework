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
using GalaSoft.MvvmLight.Helpers;
using ITC.SeedBank.Tool.ViewModels;
using ITC.SeedBank.Tool.CoreModel.Models;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;

namespace XamarinAndroidBlankFramework.View.Activities
{
    [Activity(Label = "DashboardActivity")]
    public class DashboardActivity : Activity
    {
        private TextView mTextViewUserId;
        private TextView mTextViewCustName;
        private TextView mTextViewUserName;
        private ViewModelLocator _viewModelLocator;
        private LoginDataModel _model;
        private LoginDataModel param;

        public NavigationService Nav
        {
            get
            {
                return (NavigationService)ServiceLocator.Current.GetInstance<INavigationService>();
            }
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.activity_dashboard);           
            Init();
            InitView();
            BindingData();
        }

        public LoginDataModel Model
        {
            get
            {
                return _model;
            }
            set
            {
                _model = value;               
            }
        }

        private void Init()
        {
            _viewModelLocator = new ViewModelLocator();
             param = Nav.GetAndRemoveParameter<LoginDataModel>(Intent);
        }

        private void BindingData()
        {
            //var bind = this.SetBinding(() => _viewModelLocator.LoginVM.UserName, () => mEditTextUserName.Text, BindingMode.OneWay);
            //bindings.Add(bind);
            //bind = this.SetBinding(() => _viewModelLocator.LoginVM.Password, () => mEditTextPassword.Text, BindingMode.OneWay);
            //bindings.Add(bind);
        }

        private void InitView()
        {
            mTextViewUserId = (TextView)FindViewById(Resource.Id.textvuew_dashboard_userid);
            mTextViewCustName = (TextView)FindViewById(Resource.Id.textview_dashboard_customername);
            mTextViewUserName = (TextView)FindViewById(Resource.Id.textview_dashboard_username);
            mTextViewUserId.Text = param.UserID;
            mTextViewCustName.Text = param.CustomerName;
            mTextViewUserName.Text = param.UserName;
        }


        private void OnBack()
        {
            if (Nav!=null)
            {
                Nav.GoBack();
            }
        }
    }
}