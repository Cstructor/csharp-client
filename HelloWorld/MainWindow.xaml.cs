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
using Microsoft.EntityFrameworkCore;

namespace HelloWorld
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Models.User user = new Models.User();
        public MainWindow()
        {
            InitializeComponent();
            //uxName.DataContext = user;
            //uxNameError.wDataContext = user;

            uxContainer.DataContext = user;

            var sample = new SampleContext();
            sample.User.Load();
            var users = sample.User.Local.ToObservableCollection();
            uxList.ItemsSource = users;
        }

        private void uxSubmit_Click(object sender, RoutedEventArgs e)
        {
            int x = 1;
            x = x / (x - 1); // Induce a DivideByZeroException

            MessageBox.Show("Submitting password:" + uxPassword.Text);

            var window = new SecondWindow();
            Application.Current.MainWindow = window;
            Close();
            window.Show();
        }

        
    }
}
