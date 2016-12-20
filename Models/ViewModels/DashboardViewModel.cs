using Android.Util;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using ITC.SeedBank.Tool.CoreModel.Models;
using System;

namespace ITC.SeedBank.Tool.ViewModels
{
    public class DashboardViewModel : ViewModelBase
    {
        private string className;
        private string studentName;

        private ClassNameModel _classNameModel;

        
        private readonly INavigationService navigationService;
        public DashboardViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
            _classNameModel = new ClassNameModel();
            
        }


       



        /// <summary>
        /// getter and setter for className
        /// </summary>
            public string ClassName
            {
                get
                {
                    return className;
                }
                set
                {
                    Set(ref className, value);
                    RaisePropertyChanged("ClassName");
                }
            }


        public string StudentName
        {
            get
            {
                return studentName;
            }
            set
            {
                Set(ref studentName, value);
            }
        }


        /// <summary>
        /// Gets the NavigateCommand.
        /// Goes to the second page, using the navigation service.
        /// Use the "mvvmr*" snippet group to create more such commands.
        /// </summary>
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


        private RelayCommand navigateCommand1;
        public RelayCommand CheckClassNameCommand
        {
            //set
            //{
            //    RelayCommand<string> checkClassNameCommand = new RelayCommand<string>(e => FindClassName(e));
            //}
            get
            {
                return navigateCommand1 ?? (navigateCommand1 = new RelayCommand(() => FindClassName()));
            }
        }


        private RelayCommand<string> paraCommand;
        public RelayCommand<string> ParaClassNameCommand
        {
            //set
            //{
            //    RelayCommand<string> checkClassNameCommand = new RelayCommand<string>(e => FindClassName(e));
            //}
            get
            {
                return paraCommand ?? (paraCommand = new RelayCommand<String>((s) => FindClassName(s)));
            }
        }

        private void FindClassName(string name)
        {
            Log.Debug("ITC","name "+name);
            ClassName = "" + _classNameModel.findClassName(StudentName);
        }



        /// <summary>
        /// call to corresponding model class to find the class name WRT given name
        /// </summary>
        /// <param name="name">student name </param>
        /// <returns>class name</returns>
        public void FindClassName()
        {
            //Log.Debug("ITC","name "+name);
            ClassName = "" + _classNameModel.findClassName(className);
        }
    }
}
