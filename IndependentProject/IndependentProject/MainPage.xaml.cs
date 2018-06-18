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
        public static string username;
        public static string password;

        public MainPage()
        {
            this.InitializeComponent();
        }
        // checks if files exist or should I just save everything to one file
        public async void LoginButton_ItemClickAsync(object sender, RoutedEventArgs e)
        {
            string userpass = UsernameTextbox.Text + PasswordTextbox.Text;

            Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            try
            {
                Windows.Storage.StorageFile storage = await storageFolder.GetFileAsync(userpass + ".txt");
                username = UsernameTextbox.Text;
                password = PasswordTextbox.Text;
                string text = await Windows.Storage.FileIO.ReadTextAsync(storage);
                Frame.Navigate(typeof(HomePage));
            }
            catch
            {
                // Clear the textboxes if the password is incorrect.
                ErrorBox.Text = "Login failed. Username or password is incorrect.";
            }

            UsernameTextbox.Text = String.Empty;
            PasswordTextbox.Text = String.Empty;

        }

        public async void MakeNewAccount_ItemClickAsync(object sender, RoutedEventArgs e)
        {
            // For the people that like looking for bugs
            if (UsernameTextbox.Text == "" || PasswordTextbox.Text == "")
            {
                ErrorBox.Text = "Please try another username/password";
                return;
            }

            string userpass = UsernameTextbox.Text + PasswordTextbox.Text;

            try
            {
                Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
                Windows.Storage.StorageFile sampleFile = await storageFolder.CreateFileAsync(userpass + ".txt", Windows.Storage.CreationCollisionOption.FailIfExists);
                ErrorBox.Text = "Account successfully made. Try logging in.";
            }
            catch
            {
                ErrorBox.Text = "Account username already exists.";
            }

            UsernameTextbox.Text = String.Empty;
            PasswordTextbox.Text = String.Empty;
        }
    }
}
