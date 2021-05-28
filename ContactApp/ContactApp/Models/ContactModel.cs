using System;
using AutoMapper; // Exercise 2 NuGet Package Installed and called here
using System.ComponentModel; // add this for validation

namespace ContactApp.Models
{
    public class ContactModel : IDataErrorInfo, INotifyPropertyChanged
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneType { get; set; }
        public string PhoneNumber { get; set; }
        public int Age { get; set; }
        public string Notes { get; set; }
        public DateTime CreatedDate { get; set; }

        // add the validation code here
        private string nameError { get; set; }
       
        // Exercise 1 - validation for email
        private string emailError { get; set; }

        // INotifyPropertyChanged interface
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // IDataErrorInfo interface
        public string Error => "Never Used";

        public string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case "Name":
                        {
                            NameError = "";

                            if (Name == null || string.IsNullOrEmpty(Name))
                            {
                                NameError = "Name cannot be empty.";
                            }
                            else if (Name.Length > 12)
                            {
                                NameError = "Name cannot be longer than 12 characters.";
                            }

                            return NameError;
                        }
                    // add other cases as needed

                    case "Email":
                        {
                            EmailError = "";

                            if (Email == null || string.IsNullOrEmpty(Email))
                            {
                                EmailError = "Email cannot be empty.";
                            }
                            else if (Email.Length > 12)
                            {
                                EmailError = "Email cannot be longer than 12 characters.";
                            }

                            return EmailError;
                        }
                }

                return null;
            }
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

        // Exercise 1 - Validation for Email Error
        public string EmailError
        {
            get
            {
                return emailError;
            }
            set
            {
                if (emailError != value)
                {
                    emailError = value;
                    OnPropertyChanged("EmailError");
                }
            }
        } // this is the end of code for email validation error message

        //====================

        // Exercise 2 - Fix update so background behaves correctly
        // adding Clone() method
        // so both objects do not point to the same data
        internal ContactModel Clone()
        {
            return (ContactModel)this.MemberwiseClone();
        }

        // Exercise 2 - Automapper Configuration
        private static readonly MapperConfiguration
          config = new MapperConfiguration(cfg => cfg.
          CreateMap<ContactRepository.ContactModel, ContactModel>()
          .ReverseMap());

        private static IMapper mapper = config.CreateMapper();

        // Exercise 2 - Cont. use the mapper 
        // Returning the Repository version of the UI Model
        // Going from Model to Repository
        public ContactRepository.ContactModel ToRepositoryModel()
        {
            // Exercise 2 under Delete - do not call field by field
            //  use Automapper to call on the data

            //var repositoryModel = new ContactRepository.ContactModel
            //{
            //    Age = Age,
            //    CreatedDate = CreatedDate,
            //    Email = Email,
            //    Id = Id,
            //    Name = Name,
            //    Notes = Notes,
            //    PhoneNumber = PhoneNumber,
            //    PhoneType = PhoneType
            //};

            var repositoryModel = mapper.Map<ContactRepository.ContactModel>(this);

            return repositoryModel;
            
        }

        // Exercise 2 - Cont. use the mapper 
        // Returning the UI version of the Repository Model
        // Going from Respository to UI Model
        public static ContactModel ToModel(ContactRepository.ContactModel repositoryModel)
        {
            //var contactModel = new ContactModel
            //{
            //    Age = respositoryModel.Age,
            //    CreatedDate = respositoryModel.CreatedDate,
            //    Email = respositoryModel.Email,
            //    Id = respositoryModel.Id,
            //    Name = respositoryModel.Name,
            //    Notes = respositoryModel.Notes,
            //    PhoneNumber = respositoryModel.PhoneNumber,
            //    PhoneType = respositoryModel.PhoneType
            //};

            var contactModel = mapper.Map<ContactModel>(repositoryModel);

            return contactModel;


        }
    }
}