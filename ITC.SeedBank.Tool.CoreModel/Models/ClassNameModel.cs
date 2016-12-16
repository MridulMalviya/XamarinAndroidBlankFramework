using System.ComponentModel;

namespace ITC.SeedBank.Tool.CoreModel.Models
{
    public class ClassNameModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        private string className;


        public string ClassName
        {
            get
            {
                return className;
            }
            set
            {
                className = value;
                RaisePropertyChanged("ClassName");
            }
        }



        /// <summary>
        /// define bussiness logic for finding class by given name
        /// </summary>
        /// <param name="name">student name </param>
        /// <returns>class</returns>
        public int findClassName(string name)
        {
            switch (name)
            {
                case "Prafulla":
                    //ClassName += 12;
                    return 12;
                case "test":
                    return 10;

            }
            return 0;
        }
    }



}
