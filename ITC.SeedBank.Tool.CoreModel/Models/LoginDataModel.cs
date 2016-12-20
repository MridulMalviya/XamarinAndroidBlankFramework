using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITC.SeedBank.Tool.CoreModel.Models
{

    /// <summary>
    /// The model in the MVVM pattern encapsulates business logic and data
    /// </summary>
    public class LoginDataModel: ObservableObject /*INotifyPropertyChanged*/
    {
        private string _userId;
        private string _customerName;
        private string _userName;

        //1. Getter and Setter -------------------------------------------------------------------------
        public string UserID
        {
            get
            {
                return _userId;
            }
            set
            {
                _userId = value;
                RaisePropertyChanged("UserID");
            }
        }

        public string CustomerName
        {
            get
            {
                return _customerName;
            }
            set
            {
                _customerName = value;
                RaisePropertyChanged("CustomerName");
            }
        }

        public string UserName
        {
            get
            {
                return _userName;
            }
            set
            {
                _userName = value;
                RaisePropertyChanged("UserName");
            }
        }


        //2. Bussiness Logic -------------------------------------------------------------------------
        public bool ValidateLogin()
        {

            //do validate credential by server
            //perform WS communication and bind data with model
            UserID = "23508";
            CustomerName = "ITC Limited";
            UserName = "Prafulla Malviya";
            return true;
        }
               
        //-----------------------------------------------------------------------------------
    }    
}
