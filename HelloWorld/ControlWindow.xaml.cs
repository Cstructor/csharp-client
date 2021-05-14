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
using System.Diagnostics;

namespace HelloWorld
{
    /// <summary>
    /// Interaction logic for ControlWindow.xaml
    /// </summary>
    public partial class ControlWindow : Window
    {
        public ControlWindow()
        {
            InitializeComponent();
        }

        private void uxLocal_Checked(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Local Checked");
        }
        private void uxLocal_Unchecked(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Local Unchecked");
        }

        private void uxNavigator_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            // Convert the Uri into a string
            var fileName = e.Uri.AbsoluteUri;

            // Pass the fileName to the helper class
            var processStartInfo = new ProcessStartInfo(fileName)
            {
                UseShellExecute = true,
                Verb = "open",
            };

            // Start a new process
            Process.Start(processStartInfo);
        }

        private void uxSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // Update the progress from the slider
            uxProgressBar.Value = e.NewValue;

            // Send the output to the Debug window
            Debug.WriteLine("Slider: OldValue={0} NewValue={1}", e.OldValue, e.NewValue);
        }
    }
}
