using Microsoft.Toolkit.Uwp.UI.Lottie;
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
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Samples.ManagedUWP
{

    public sealed partial class LottieAnimationPage : Page
    {
        public LottieAnimationPage()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //var assembly = this.GetType().Assembly;

            //foreach (string name in assembly.GetManifestResourceNames())
            //{
            //    System.Diagnostics.Debug.WriteLine(name);
            //}

            var jsonString = string.Empty;

            using (var stream = File.OpenRead(@"Assets\LottieLogo1.json"))
            {
                using (var reader = new StreamReader(stream))
                {
                    jsonString = reader.ReadToEnd();
                }
            }

            var source = LottieVisualSource.CreateFromString(jsonString);

            LottiePlayer.Source = source;
            _ = LottiePlayer.PlayAsync(0, 1, true);
        }
    }
}
