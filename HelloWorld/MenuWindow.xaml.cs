using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HelloWorld
{
    /// <summary>
    /// Interaction logic for MenuWindow.xaml
    /// </summary>
    public partial class MenuWindow : Window
    {
        public MenuWindow()
        {
            InitializeComponent();
            uxContainer.DataContext = this;
        }

        // Exercise 3 under Menu
        // Note: if this returns false the MenuItem is disabled
        public bool IsFileNewActive //Note: we bind to this function in xaml
        {
            get
            {
                return false; // false sets it to disabled
            }
        }


        private void OnNew_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("New command");
        }
        private void OnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        
        // Exercise 1: For Toolbar - add a button to close
        private void uxClose_Click(object sender, RoutedEventArgs e)
        {
            Close(); // belongs to toolbar button
        }

        // Click Ctrl-N to execute the shortcut.
        private void OnNew_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            // Set this to false if the New command is not available
            e.CanExecute = false;
        }
    }
}
