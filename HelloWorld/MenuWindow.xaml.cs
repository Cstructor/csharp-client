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
        }


        private void OnNew_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("New command");
        }
        private void OnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        // ADD CAN EXECUTE
        // Click Ctrl-N to execute the shortcut.
        private void OnNew_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            // Set this to false if the New command is not available
            //e.CanExecute = true;
            // NOTE: if set to false instead of true, it will disable the "New"
            e.CanExecute = false;
        }
    }
}
