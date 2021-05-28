using ContactApp.Models;
using System.Linq;
using System.Windows;
using System.ComponentModel; // added
using System.Windows.Controls; // added
using System.Windows.Documents; //added

namespace ContactApp

{
    public partial class MainWindow : Window
    {

        private GridViewColumnHeader listViewSortCol = null; // added for exercise
        private SortAdorner listViewSortAdorner = null;      // added for exercise

        private ContactModel selectedContact;


        public MainWindow()
        {
            InitializeComponent();

            LoadContacts();
        }

        private void LoadContacts()
        {
            var contacts = App.ContactRepository.GetAll();

            uxContactList.ItemsSource = contacts
                .Select(t => ContactModel.ToModel(t))
                .ToList();

            // OR
            //var uiContactModelList = new List<ContactModel>();
            //foreach (var repositoryContactModel in contacts)
            //{
            //    This is the .Select(t => ... )
            //    var uiContactModel = ContactModel.ToModel(repositoryContactModel);
            //
            //    uiContactModelList.Add(uiContactModel);
            //}

            //uxContactList.ItemsSource = uiContactModelList;
        }

        // add this method for doing updates
        private void uxFileChange_Click(object sender, RoutedEventArgs e)
        {
            var window = new ContactWindow();
            
            // Exercise 2 for update - fix this to call on Clone()
            window.Contact = selectedContact.Clone();

            if (window.ShowDialog() == true)
            {
                App.ContactRepository.Update(window.Contact.ToRepositoryModel());
                LoadContacts();
            }
        }

        private void uxFileChange_Loaded(object sender, RoutedEventArgs e)
        {
            uxFileChange.IsEnabled = (selectedContact != null);
            uxContextFileChange.IsEnabled = uxFileChange.IsEnabled;
        }

        private void uxFileNew_Click(object sender, RoutedEventArgs e)
        {
            var window = new ContactWindow();

            if (window.ShowDialog() == true)
            {
                var uiContactModel = window.Contact;

                var repositoryContactModel = uiContactModel.ToRepositoryModel();

                App.ContactRepository.Add(repositoryContactModel);

                // OR
                //App.ContactRepository.Add(window.Contact.ToRepositoryModel());

                LoadContacts();
            }
        }        


        private void GridViewColumnHeader_Click(object sender, RoutedEventArgs e)
        {
            GridViewColumnHeader column = (sender as GridViewColumnHeader);
            string sortBy = column.Tag.ToString();
            if (listViewSortCol != null)
            {
                AdornerLayer.GetAdornerLayer(listViewSortCol).Remove(listViewSortAdorner);
                uxContactList.Items.SortDescriptions.Clear();
            }

            ListSortDirection newDir = ListSortDirection.Ascending;
            if (listViewSortCol == column && listViewSortAdorner.Direction == newDir)
                newDir = ListSortDirection.Descending;

            listViewSortCol = column;
            listViewSortAdorner = new SortAdorner(listViewSortCol, newDir);
            AdornerLayer.GetAdornerLayer(listViewSortCol).Add(listViewSortAdorner);
            uxContactList.Items.SortDescriptions.Add(new SortDescription(sortBy, newDir));
        }

        // Important Method: detect if selection has been made
        private void uxContactList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedContact = (ContactModel)uxContactList.SelectedValue;

            // Exercise 1 under Delete - fix the context menu
            uxContextFileDelete.IsEnabled = (selectedContact != null);

        }

        private void uxFileDelete_Click(object sender, RoutedEventArgs e)
        {
            App.ContactRepository.Remove(selectedContact.Id);
            selectedContact = null;
            LoadContacts();
        }

        private void uxFileDelete_Loaded(object sender, RoutedEventArgs e)
        {
            uxFileDelete.IsEnabled = (selectedContact != null);
        }

        // Exercise 1 - Update double-clicking on a contact will bring up the update Contact window
        private void uxContactList_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            // call on this FileChange Click function with two null parameters
            uxFileChange_Click(sender, null);

        }
    }
}
