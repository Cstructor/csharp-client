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
    /// Interaction logic for StatusWindow.xaml
    /// </summary>
    public partial class StatusWindow : Window
    {
        public StatusWindow()
        {
            InitializeComponent();
            uxProgressBar.Maximum = 100; // Set the maximum
            
            // Exercise 1 - We need to set the Progress bar to allowed Max Length
            uxProgressBar.Maximum = uxTextEditor.MaxLength;
        }

        private void uxTextEditor_SelectionChanged(object sender, RoutedEventArgs e)
        {
            int row = uxTextEditor.GetLineIndexFromCharacterIndex(uxTextEditor.CaretIndex);
            int col = uxTextEditor.CaretIndex - uxTextEditor.GetCharacterIndexFromLineIndex(row);
            uxStatus.Text = "Line " + (row + 1) + ", Char " + (col + 1);

            // Exercise 1 - Set the Progress Bar
            uxProgressBar.Value = uxTextEditor.Text.Length;

            // Exercise 1 (cont.) - calculate the percentage
            int percentage = (100 * uxTextEditor.Text.Length) / uxTextEditor.MaxLength;

            // Exercise 1 (cont.) - show the percentage string on the bar
            uxPercentComplete.Text = string.Format("{0}%", percentage);


        }
    }
}
