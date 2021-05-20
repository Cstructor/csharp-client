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
using Microsoft.EntityFrameworkCore;

namespace HelloWorld
{
    /// <summary>
    /// Interaction logic for ComboWindow.xaml
    /// </summary>
    public partial class ComboWindow : Window
    {
        public ComboWindow()
        {
            InitializeComponent();

            var sample = new SampleContext();
            sample.User.Load();
            uxListBox.ItemsSource = sample.User.Local.ToObservableCollection();
        }

        private void uxComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            uxGrid.DataContext = e.AddedItems[0];
        }
    }
}
