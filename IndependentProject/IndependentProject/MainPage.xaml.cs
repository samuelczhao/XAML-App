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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace IndependentProject
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }
        // checks if files exist or should I just save everything to one file
        private async void LoginButton_ItemClickAsync(object sender, RoutedEventArgs e)
        {
            string userpass = UsernameTextbox.Text + PasswordTextbox.Text;

            Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            Windows.Storage.StorageFile storage = await storageFolder.GetFileAsync(userpass + ".txt");
            string text = await Windows.Storage.FileIO.ReadTextAsync(storage);

            if (text.Contains(userpass))
            {

            }
        }

        private void MakeNewAccount_ItemClick(object sender, RoutedEventArgs e)
        {
            string userpass = UsernameTextbox.Text + PasswordTextbox.Text;

            if (true)
            {

            }


        }
    }
}
