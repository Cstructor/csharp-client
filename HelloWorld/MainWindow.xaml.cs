using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HelloWorld
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // add a call to User class
        private Models.User user = new Models.User();
        public MainWindow()
        {
            InitializeComponent();
            //uxName.DataContext = user; 
            //uxNameError.DataContext = user;

            uxContainer.DataContext = user;

        }

        private void uxSubmit_Click(object sender, RoutedEventArgs e)
        {
            // for Exercise 2
            MessageBox.Show("Submitting password: " + uxPasswordBox.Password);
            var window = new SecondWindow();
            Application.Current.MainWindow = window;
            Close();
            window.Show();
        }
    }
}
