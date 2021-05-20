using System.ComponentModel;

namespace HelloWorld.Models
{
    class User : IDataErrorInfo, INotifyPropertyChanged
    {
        private string name = string.Empty;
        private string password = string.Empty;
        private string nameError;
        private string passError;

        // Add ToString method - For Listview
        public override string ToString()
        {
            return name;
        }

        public string NameError
        {
            get
            {
                return nameError;
            }
            set
            {
                if (nameError != value)
                {
                    nameError = value;
                    OnPropertyChanged("NameError");
                }
            }
        }

        public string PassError
        {
            get
            {
                return passError;
            }
            set
            {
                if (passError != value)
                {
                    passError = value;
                    OnPropertyChanged("PassError");
                }
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (name != value)
                {
                   name = value;
                    OnPropertyChanged("Name");
                }
            }
        }

        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                if (password != value)
                {
                    password = value;
                    OnPropertyChanged("Password");
                }
            }
        }

        // IDataErrorInfo interface
        public string Error
        {
            get
            {
                return NameError;
            }
        }

        // IDataErrorInfo interface
        // Called when ValidatesOnDataErrors=True
        public string this[string columnName]
        {
            get
            {               
               
                switch (columnName)
                {
                    case "Name":
                        {
                            NameError = ""; // reset where it needs to be
                            if (string.IsNullOrEmpty(Name))
                            {
                                NameError = "Name cannot be empty.";
                            }
                            if (Name.Length > 12)
                            {
                                NameError = "Name cannot be longer than 12 characters.";
                            }
                            return NameError;

                        }

                    case "Password":
                        {
                            PassError = ""; // reset where it needs to be
                            if (string.IsNullOrEmpty(Password))
                            {
                                PassError = "Password cannot be empty.";
                            }
                            if (Password.Length > 12)
                            {
                                PassError = "Password cannot be longer than 12 characters.";
                            }
                            
                            return PassError;
                        }
                }
                return null; 
            }
        }

        // INotifyPropertyChanged interface
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}