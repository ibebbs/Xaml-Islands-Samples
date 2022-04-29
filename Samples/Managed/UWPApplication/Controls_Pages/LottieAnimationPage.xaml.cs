using Microsoft.Toolkit.Uwp.UI.Lottie;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
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

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var resourceContext = new Windows.ApplicationModel.Resources.Core.ResourceContext(); // not using ResourceContext.GetForCurrentView 
            var namedResource = Windows.ApplicationModel.Resources.Core.ResourceManager.Current.MainResourceMap[@"Files/Assets/LottieLogo1.json"];
            var resourceCandidate = namedResource.Resolve(resourceContext);
            var lottieFileStream = await resourceCandidate.GetValueAsStreamAsync();

            // Debug code just to confirm resource is being loaded correctly
            //var inputStream = lottieFileStream.GetInputStreamAt(0);
            //var stream = inputStream.AsStreamForRead();
            //var reader = new StreamReader(stream);
            //string text = reader.ReadToEnd();

            var source = new LottieVisualSource();

            await source.SetSourceAsync(lottieFileStream);

            LottiePlayer.Source = source;
            await LottiePlayer.PlayAsync(0, 1, true);
        }
    }
}
