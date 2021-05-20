using System.Windows;

namespace ContactApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static ContactRepository.ContactRepository contactRepository;

        static App()
        {
            contactRepository = new ContactRepository.ContactRepository();
        }

        public static ContactRepository.ContactRepository ContactRepository
        {
            get
            {
                return contactRepository;
            }
        }

    }
}