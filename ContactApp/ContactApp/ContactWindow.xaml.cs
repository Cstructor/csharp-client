using ContactApp.Models;
using System;
using System.Windows;

namespace ContactApp
{
    /// <summary>
    /// Interaction logic for ContactWindow.xaml
    /// </summary>
    public partial class ContactWindow : Window
    {
        public ContactWindow()
        {
            InitializeComponent();

            // Don't show this window in the task bar
            ShowInTaskbar = false;
        }

        public ContactModel Contact { get; set; }

        private void uxSubmit_Click(object sender, RoutedEventArgs e)
        {
            Contact = new ContactModel();

            Contact.Name = uxName.Text;
            Contact.Email = uxEmail.Text;

            if (uxHome.IsChecked.Value)
            {
                Contact.PhoneType = "Home";
            }
            else
            {
                Contact.PhoneType = "Mobile";
            }

            Contact.PhoneNumber = uxPhoneNumber.Text;
            
            //Contact.Age = 0;
            //Exercise 1 - connect age to slider (name is uxAgeSlider from Xaml)
            Contact.Age = (int)uxAgeSlider.Value;
            
            Contact.Notes = uxNotes.Text;
            Contact.CreatedDate = DateTime.Now;

            // This is the return value of ShowDialog( ) below
            DialogResult = true;
            Close();
        }

        private void uxCancel_Click(object sender, RoutedEventArgs e)
        {
            // This is the return value of ShowDialog( ) below
            DialogResult = false;
            Close();
        }
    }
}