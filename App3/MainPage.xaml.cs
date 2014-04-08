using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using Color2Name;
using Windows.UI.Input;
// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace App3
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        C2n temp;
        HelperColor hc;
        WriteableBitmap slika;

        public MainPage()
        {
            temp = new C2n();
            temp.initRGB_HSL();
            
            hc=temp.clr_name("#FBF84B");

            
            this.InitializeComponent();
            textblock1.Text = hc.name_closest;
        }

        private async Task readimageAsync()
        {
            var rass1 = RandomAccessStreamReference.CreateFromUri(new System.Uri("Assert/cvet.jpg"));
            IRandomAccessStream stream1 = await rass1.OpenReadAsync();
            WriteableBitmap slika = new WriteableBitmap(150, 150);
            slika = await slika.FromStream(stream1);

        }

        private void image1_Tapped(object sender, TappedRoutedEventArgs e)
        {
            
             /* var rass1 = RandomAccessStreamReference.CreateFromUri(new System.Uri("Assert/cvet.jpg")); */
            /* IRandomAccessStream stream1 = await rass1.OpenReadAsync(); */

            /* http://msdn.microsoft.com/en-us/library/hh763341.aspx */
           
            
            
            
            /*im.GetPixel POSTOJI =D dakle ucitam sliku uzmem pixel , sledece je da se prevede u zvuk */
            /* IRandomAccessStream strSrc; */
            /* im.SetSource(strSrc); */ 
            /*Za najbolje performanse (real time scenario) implementirati njegov kod direktno u petlji*/
            Point p=e.GetPosition(image1);
            Color clr=slika.GetPixel(Convert.ToInt32(p.X), Convert.ToInt32(p.Y));
            String temp2 = Color2Hex(clr);
            hc = temp.clr_name(temp2);
            textblock1.Text = hc.name_shade;
            
            
        }
        private String Color2Hex(Color c)
        {
            return "#" + c.R.ToString("X2") + c.G.ToString("X2") + c.B.ToString("X2");
        }

        

        private async void image1_Loaded(object sender, RoutedEventArgs e)
        {
            RandomAccessStreamReference temp_ = RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Assets/cvet.jpg", UriKind.Absolute));

            IRandomAccessStream stream = await temp_.OpenReadAsync();

            Stream stream1 = stream.AsStream();
            slika = new WriteableBitmap((int)image1.Width, (int)image1.Height);
            Task<WriteableBitmap> tempor = slika.FromStream(stream1);
            slika = tempor.Result;

            
        }


    }
}
