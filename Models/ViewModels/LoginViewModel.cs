using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using ITC.SeedBank.Tool.CoreModel.Models;
using ITC.SeedBank.Tool.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ITC.SeedBank.Tool.ViewModels
{


    public class LoginViewModel: ViewModelBase
    {
        private readonly INavigationService navigationService;

        

        public LoginViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
            Model = new LoginDataModel();

        }

        //a. ViewModel knows its Models
        private LoginDataModel _model;
        public LoginDataModel Model
        {
            get
            {
                return _model;
            }
            set
            {               
                Set((() => Model), ref _model, value);
            }
        }

       

        //1. Getter and Setter for communicating with View----------------------------------------------------------
        private String _userName = "";
        public string UserName
        {
            get
            {
                return _userName;
            }
            set
            {
                Set(ref _userName, value);
                //Set( ( ) => UserName, ref _userName, value );
                RaisePropertyChanged("UserName");
            }
        }


        private String _password= "";      
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                Set(ref _password, value);
                RaisePropertyChanged("Password");
            }
        }





        //2. Command ----------------------------------------------------------------------------------
        private RelayCommand _loginCommand;
        public RelayCommand LoginCommand
        {
            get
            {
                return _loginCommand ?? (_loginCommand = new RelayCommand(() =>
                {
                   //call to model to validate login credential and on response need to navigate to Dashboard     
                   var result = Model.ValidateLogin();
                    if (result)
                    {
                        //navigate to Dashboard
                        navigationService.NavigateTo(ViewModelLocator.SecondPageKey,Model);
                    }
                }));
            }
        }

        public bool CanLogin()
        {
            //valide fileds 
            return ClassUtils.ValidateLoginFields(UserName, Password);
        }

      

        private RelayCommand navigateCommand;
        public RelayCommand NavigateCommand
        {
            get
            {
                return navigateCommand
                    ?? (navigateCommand = new RelayCommand(() => navigationService.NavigateTo(
                            ViewModelLocator.SecondPageKey)));
            }
        }

        /// <summary>
        /// Define commands for Login
        /// </summary>
        private RelayCommand _cancelCommand;       
    
        public RelayCommand CancelCommand
        {
            get
            {
                return _cancelCommand ?? (_cancelCommand = new RelayCommand(() =>
                {
                    UserName = "";
                    Password = "";
                }));
            }

        }

        

        //---------------------------------------------------------------------------
    }
}
