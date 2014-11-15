using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace SliderFontSizeTask
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            this.SetToSmallButton.Click += SetToSmallButton_Click;
            this.SetToMediumButton.Click += SetToMediumButton_Click;
            this.SetToLargeButton.Click += SetToLargeButton_Click;
        }

        void SetToLargeButton_Click(object sender, RoutedEventArgs e)
        {
            this.FontSizeSlider.Value = 50;
        }

        void SetToMediumButton_Click(object sender, RoutedEventArgs e)
        {
            this.FontSizeSlider.Value = 30;
        }

        void SetToSmallButton_Click(object sender, RoutedEventArgs e)
        {
            this.FontSizeSlider.Value = 11;
        }
    }
}
