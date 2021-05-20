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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HelloWorld
{
    /// <summary>
    /// Interaction logic for RGBControl.xaml
    /// </summary>
    public partial class RGBControl : UserControl
    {
        public RGBControl()
        {
            InitializeComponent();
        }
        private void uxColor_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                byte red = 0;

                if (uxRed != null) // defensive coding
                {
                    red = byte.Parse(uxRed.Text);
                }

                byte green = 0;
                if (uxGreen != null)
                {
                    green = byte.Parse(uxGreen.Text);
                }

                byte blue = 0;

                if (uxBlue != null)
                {
                    blue = byte.Parse(uxBlue.Text);
                }

                if (uxColor != null)
                {
                    uxColor.Background = new SolidColorBrush(Color.FromRgb(red, green, blue));
                }
            }
            catch (Exception ex)
            {
                // just ignore the exception
            }
        }
    }

}
