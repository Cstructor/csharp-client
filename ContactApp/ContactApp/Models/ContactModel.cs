using System;

namespace ContactApp.Models
{
    public class ContactModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneType { get; set; }
        public string PhoneNumber { get; set; }
        public int Age { get; set; }
        public string Notes { get; set; }
        public DateTime CreatedDate { get; set; }

        public ContactRepository.ContactModel ToRepositoryModel()
        {
            var repositoryModel = new ContactRepository.ContactModel
            {
                Age = Age,
                CreatedDate = CreatedDate,
                Email = Email,
                Id = Id,
                Name = Name,
                Notes = Notes,
                PhoneNumber = PhoneNumber,
                PhoneType = PhoneType
            };

            return repositoryModel;
        }

        public static ContactModel ToModel(ContactRepository.ContactModel respositoryModel)
        {
            var contactModel = new ContactModel
            {
                Age = respositoryModel.Age,
                CreatedDate = respositoryModel.CreatedDate,
                Email = respositoryModel.Email,
                Id = respositoryModel.Id,
                Name = respositoryModel.Name,
                Notes = respositoryModel.Notes,
                PhoneNumber = respositoryModel.PhoneNumber,
                PhoneType = respositoryModel.PhoneType
            };

            return contactModel;
        }
    }
}