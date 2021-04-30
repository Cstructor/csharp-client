using System.ComponentModel;

namespace HelloWorld.Models
{
    class User : IDataErrorInfo, INotifyPropertyChanged
    {
        private string name = string.Empty;
        private string nameError;

        // Exercise 1 - add a passwordErro for password validation
        private string password = string.Empty;
        private string passwordError;

        // Add ToString method
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
        // Exercise 1 - Need a PasswordError Property
        public string PasswordError
        {
            get
            {
                return passwordError;
            }

            set
            {
                if (passwordError != value)
                {
                    passwordError = value;
                    OnPropertyChanged("PasswordError");
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
                NameError = "";
                switch (columnName)
                {
                    case "Name":
                        {
                            NameError = "";
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
                    case "Password": // Exercise 1 - password validation message lable
                        {
                            PasswordError = "";
                            if (string.IsNullOrEmpty(Password))
                            {
                                PasswordError = "Password cannot be empty.";
                            }
                            if (Password.Length > 12)
                            {
                                PasswordError = "Password cannot be longer than 12 characters.";
                            }

                            return PasswordError;

                        }
                        
                } // end of switch statement

                return null;

            } // end of get
        }

        // INotifyPropertyChanged interface
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null) // when a trigger happens
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}