using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using XamarinAndroidBlankFramework.Models;
using System.Diagnostics;

namespace XamarinAndroidBlankFramework.VeiwModels
{

    internal class CustomerViewModel
    {

        /// <summary>
        /// initialize a new instance of this class
        /// </summary>
        public CustomerViewModel()
        {
            _Customer = new CustomerModel("Prafulla Malviya");
        }
        private CustomerModel _Customer;

        /// <summary>
        /// Get the customer instance
        /// </summary>
        public CustomerModel Customer
        {
            get
            {
                return _Customer;
            }   
        }

        /// <summary>
        /// save changes made to the customer instance.
        /// </summary>
        public void SaveChanges()
        {
          Debug.Assert(false, String.Format("{0} was updated", Customer.Name));
        }
    }
} 
